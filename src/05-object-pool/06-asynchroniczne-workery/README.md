# 06. Asynchroniczni workerzy i pomiar wydajności

## Cel rozdziału

Pokazać scenariusz, w którym Object Pool daje realną przewagę: kosztowne, niezależne workery I/O oraz limit zasobów zewnętrznych.

---

## Szczegółowy opis

### Założenia przykładu

- mamy tylko `W` drogich workerów (limit licencji/API),
- napływa dużo żądań równolegle,
- żądania czekają asynchronicznie na wolnego workera,
- po użyciu worker wraca do puli.

Założenia operacyjne (co to znaczy w praktyce):

1. Worker jest zasobem ekskluzywnym: w danej chwili jeden worker obsługuje tylko jedno zadanie.
2. Czas obsługi pojedynczego zadania jest zmienny (I/O), więc modelujemy nie tylko średnią, ale też ogon opóźnień (P95/P99 wait-time).
3. Liczba workerów jest ograniczona zewnętrznie (koszt, limity API, limity połączeń), więc nie możemy "doskalować" bez końca.
4. Backpressure realizujemy przez timeout oczekiwania: zamiast nieskończonej kolejki wolimy kontrolowane odrzucenia.
5. Celem nie jest maksymalizacja samego throughput, ale kompromis: throughput + stabilny czas odpowiedzi + niski odsetek timeoutów.

Model obciążenia przyjęty w przykładzie:

- `jobs` określa łączną liczbę żądań testowych,
- `workers` określa pojemność puli (maksymalna równoległość),
- `timeoutMs` określa maksymalny czas oczekiwania na wolnego workera,
- wynik testu to: czas całkowity, średni wait-time, liczba timeoutów i throughput.

Wersja rozszerzona przykładu obejmuje dodatkowo:

1. timeout oczekiwania na workera,
2. pomiar średniego wait-time,
3. liczbę timeoutów,
4. szacowanie throughput (req/s).

---

## Diagram wyjaśniający

### Diagram sekwencji

![Asynchroniczna pula](diagrams/01-async-pool-sequence.png)

Źródło: [diagrams/01-async-pool-sequence.puml](diagrams/01-async-pool-sequence.puml)

### Model przepustowości

![Model przepustowości](diagrams/02-throughput-model.png)

Źródło: [diagrams/02-throughput-model.puml](diagrams/02-throughput-model.puml)

#### Intuicja — prawo Little'ego

Prawo Little'ego (Little's Law) opisuje każdy stabilny system kolejkowy:

$$N = \lambda \cdot L$$

gdzie:

- $N$ — liczba zadań jednocześnie przetwarzanych (= workerów zajętych w danej chwili),
- $\lambda$ — natężenie ruchu (żądań na sekundę, QPS),
- $L$ — średni czas spędzony przez zadanie w systemie.

Gdy wszyscy $W$ workerzy są zajęci ($N = W$) i każde zadanie przetwarzane jest przez czas $T$, prawo daje górne ograniczenie:

$$QPS_{max} = \frac{W}{T}$$

To jest **idealne maksimum** — osiągalne tylko gdy queue jest pusta i nie ma timeoutów.

#### Formuła rozszerzona (efektywny throughput)

W praktyce każde żądanie czeka najpierw $W_q$ w kolejce, zanim dostanie workera, a część żądań jest odrzucana timeout'em:

$$QPS_{eff} \approx \frac{W}{T + W_q} \cdot (1 - p_{timeout})$$

gdzie:

- $W$ — liczba workerów w puli,
- $T$ — średni czas obsługi przez workera (sekundy),
- $W_q$ — średni czas oczekiwania w kolejce na wolnego workera (sekundy),
- $p_{timeout}$ — odsetek żądań odrzuconych przez timeout (0–1).

Rozkład czasu odpowiedzi dla **jednego** żądania:

$$t_{response} = \underbrace{W_q}_{\text{kolejka}} + \underbrace{T}_{\text{obsługa}}$$

Żądanie jest odrzucane, gdy $W_q$ przekroczy ustawiony `timeoutMs` zanim zwolni się worker.

#### Przykład liczbowy

Przyjmij: $W = 4$, $T = 200\,\text{ms} = 0{,}2\,\text{s}$, $W_q = 50\,\text{ms} = 0{,}05\,\text{s}$, $p_{timeout} = 0{,}05$

Górna granica:

$$QPS_{max} = \frac{4}{0{,}2} = 20 \text{ req/s}$$

Efektywny throughput:

$$QPS_{eff} = \frac{4}{0{,}2 + 0{,}05} \cdot (1 - 0{,}05) = \frac{4}{0{,}25} \cdot 0{,}95 = 16 \cdot 0{,}95 \approx 15{,}2 \text{ req/s}$$

Efektywny throughput jest **~24% niższy** niż ideał — tylko przez kolejkowanie (+50 ms) i 5% odrzutów.

#### Jak parametry wpływają na siebie nawzajem

| Zmiana | Efekt na $W_q$ | Efekt na $p_{timeout}$ | Efekt na $QPS_{eff}$ |
|---|---|---|---|
| ↑ liczba workerów $W$ | ↓ (mniej czekania) | ↓ | ↑ |
| ↑ czas zadania $T$ | ↑ (kolejka rośnie) | ↑ | ↓ |
| ↑ natężenie ruchu | ↑ (kolejka rośnie) | ↑ | ↓ przy stałym $W$ |
| ↑ `timeoutMs` | — | ↓ (więcej czasu na slot) | ↑ (więcej ukończonych) |
| ↓ `timeoutMs` | — | ↑ (szybciej porzucamy) | ↓ (mniej ukończonych) |

Kluczowa obserwacja: zwiększenie $W$ pomaga tylko do momentu, gdy bottleneckiem staje się zasób zewnętrzny (API/DB/sieć) — wtedy $T$ samo w sobie rośnie i efekt jest zniwelowany.

#### Jak czytać model

1. Gdy `wait-time` rośnie, nawet stałe `W` i `T` dają niższy efektywny throughput.
2. Gdy timeout jest zbyt niski względem obciążenia, rośnie $p_{timeout}$ i spada liczba ukończonych żądań.
3. Zwiększenie `W` pomaga tylko do momentu, gdy bottleneckiem staje się system zewnętrzny (API/DB/sieć).
4. Dlatego w praktyce trzeba obserwować jednocześnie: `throughput`, `wait-time` i `timeouts`.

---

## Kod C#

### Przykład

Kod: [AsyncWorkersSample/Program.cs](AsyncWorkersSample/Program.cs)

Implementacja używa:

- `ConcurrentQueue<HeavyWorker>` - kolejka wolnych workerów,
- `SemaphoreSlim` - kontrola równoległości i czekanie asynchroniczne,
- `Stopwatch` - pomiar całkowitego czasu obsługi.

Architektura kodu (krok po kroku):

1. Inicjalizacja puli:
- tworzona jest pula z określoną liczbą workerów,
- każdy worker reprezentuje kosztowny zasób I/O.

2. Przyjęcie żądania:
- zadanie wywołuje `AcquireWorkerAsync(timeout)`,
- jeśli w limicie czasu nie ma slotu, żądanie jest oznaczane jako timeout.

3. Obsługa biznesowa:
- po pozyskaniu workera wykonywane jest `ProcessJobAsync(...)`,
- mierzony jest czas oczekiwania na pozyskanie workera.

4. Zwrot zasobu:
- worker wraca do puli w `finally`,
- gwarantuje to brak "zgubienia" workera nawet przy błędach.

5. Agregacja metryk:
- zliczane są sukcesy i timeouty,
- liczony jest średni wait-time,
- throughput liczony jest jako liczba zakończonych sukcesem żądań na sekundę.

Dodatkowo implementacja mierzy:

1. czas oczekiwania na slot (`WaitAsync`) dla każdego żądania,
2. liczbę zadań zakończonych timeoutem,
3. końcowy throughput na podstawie liczby ukończonych zadań i czasu testu.

Kluczowy fragment:

```csharp
var acquired = await pool.AcquireWorkerAsync(timeout);
if (acquired is null)
{
    onTimeout();
    return;
}

var result = acquired.Value;
await result.Worker.ProcessJobAsync(requestJobId);
onSuccess(result.WaitMs);
```

Co to pokazuje:

1. Pool może być nie tylko źródłem obiektów, ale też mechanizmem kontroli przeciążenia.
2. Timeout chroni system przed nieograniczonym kolejkowaniem.
3. Mierzenie wait-time pomaga dobrać liczbę workerów na podstawie danych.
4. Ten sam kod może mieć różne SLA przy innym `workers/jobs/timeoutMs`, więc strojenie musi być oparte o pomiar.

Uruchom:

```bash
cd src/05-object-pool/06-asynchroniczne-workery/AsyncWorkersSample
dotnet run
```

Warianty uruchomienia:

```bash
dotnet run -- --workers 3 --jobs 20 --timeoutMs 1000
dotnet run -- --workers 2 --jobs 100 --timeoutMs 300
dotnet run -- --workers 6 --jobs 200 --timeoutMs 1500
```

### Tabela scenariuszy testowych

| Scenariusz | Parametry | Co symuluje | Oczekiwany wynik | Jak interpretować |
| --- | --- | --- | --- | --- |
| Niski ruch, zapas zasobów | `--workers 6 --jobs 20 --timeoutMs 1500` | System daleko od limitu | Niski wait-time, 0 timeoutów, stabilny throughput | Jeśli już tu pojawiają się timeouty, problem leży raczej w implementacji niż w pojemności puli |
| Zbalansowane obciążenie | `--workers 4 --jobs 80 --timeoutMs 1000` | Typowy ruch produkcyjny | Umiarkowany wait-time, pojedyncze timeouty, dobry throughput | Dobry punkt referencyjny do porównań przy zmianie liczby workerów |
| Wysokie obciążenie, mała pula | `--workers 2 --jobs 100 --timeoutMs 300` | Przeciążenie i backpressure | Wysoki wait-time, dużo timeoutów, spadek throughput efektywnego | Pokazuje granicę wydolności puli i koszt zbyt małego `workers` |
| Wysokie obciążenie, większa pula | `--workers 6 --jobs 200 --timeoutMs 1500` | Skalowanie puli pod większy ruch | Mniej timeoutów niż przy małej puli, wyższy throughput | Jeśli poprawa jest mała, bottleneck jest poza pulą (API/DB/sieć) |
| Agresywny timeout | `--workers 4 --jobs 120 --timeoutMs 100` | Polityka niskiej latencji kosztem odrzuceń | Niski średni wait-time, ale wyższy odsetek timeoutów | Dobre dla systemów SLA-first, gdzie lepszy szybki fail niż długa kolejka |
| Łagodny timeout | `--workers 4 --jobs 120 --timeoutMs 2000` | Polityka maksymalizacji sukcesów | Mniej timeoutów, ale wyższy wait-time i większa zmienność | Dobre gdy ważniejszy jest completion rate niż twarde opóźnienie odpowiedzi |

Opis użycia tabeli:

1. Uruchom wszystkie scenariusze w tej samej konfiguracji maszyny i w trybie `Release`.
2. Dla każdego scenariusza wykonaj 3-5 powtórzeń i porównaj medianę metryk.
3. Zapisz osobno: `throughput`, średni wait-time, P95/P99 wait-time, liczbę timeoutów.
4. Nie oceniaj wyniku tylko po jednym wskaźniku - decyzja o rozmiarze puli zawsze jest kompromisem.

Interpretacja wyników:

1. rosnące timeouty oznaczają zbyt małą pulę lub zbyt długi czas pracy workera,
2. wysokie wait-time przy niskim timeoutie zwiastuje niestabilne SLA,
3. wzrost workerów poprawia throughput tylko do momentu, gdy ograniczeniem staje się zasób zewnętrzny.

---

## Jak dobrać liczbę workerów

1. Zmierz średni czas zadania (`T`) i wymagany QPS.
2. Policz wstępnie `W = QPS * T`.
3. Przetestuj `W-1`, `W`, `W+1` pod obciążeniem i porównaj P95/P99.
4. Dodaj limit timeoutu oczekiwania na worker.
5. Ustal próg akceptowalnego wait-time (np. średnio < 50 ms, P95 < 200 ms).
6. Dobierz minimalne `W`, które spełnia throughput i SLA jednocześnie.
