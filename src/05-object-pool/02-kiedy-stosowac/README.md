# 02. Kiedy stosować Object Pool

## Cel rozdziału

Po tym rozdziale student powinien:

- umieć podjąć decyzję, czy Object Pool ma sens,
- rozpoznać sygnały, że pula jest over-engineeringiem,
- znać metryki, które warto mierzyć przed wdrożeniem.

---

## Kryteria decyzyjne

Stosuj Object Pool, gdy spełnione są co najmniej 2-3 warunki:

- koszt stworzenia obiektu jest wysoki (np. > 1 ms lub koszt I/O),
- istnieje limit zasobów (licencje, API, liczba połączeń),
- obciążenie jest wysokie i współbieżne,
- obiekt da się bezpiecznie zresetować i ponownie użyć.

Nie stosuj, gdy:

- obiekt jest mały i tani,
- żyje bardzo krótko,
- koszt synchronizacji jest większy niż koszt `new`.

---

## Diagramy decyzyjne

### Drzewo decyzji

![Drzewo decyzji](diagrams/01-decision-tree.png)

Źródło: [diagrams/01-decision-tree.puml](diagrams/01-decision-tree.puml)

### Sygnały „pomaga" vs „szkodzi"

![Sygnały użycia](diagrams/02-signals.png)

Źródło: [diagrams/02-signals.puml](diagrams/02-signals.puml)

---

## Co mierzyć przed wdrożeniem

Przed podjęciem decyzji o wprowadzeniu puli trzeba zebrać twarde dane. Sama intuicja bardzo często prowadzi do over-engineeringu.

### Co oznacza P95/P99?

- P95 (95. percentyl) oznacza czas, poniżej którego kończy się 95% pomiarów, a 5% najwolniejszych trwa dłużej.
- P99 (99. percentyl) oznacza czas, poniżej którego kończy się 99% pomiarów, a 1% najwolniejszych trwa dłużej.
- To metryki ogona rozkładu (tail latency), więc pokazują opóźnienia, które najbardziej odczuwa użytkownik przy pikach obciążenia.

Przykład: jeśli P95 = 40 ms, a P99 = 120 ms, to większość żądań jest szybka, ale rzadkie przypadki są 3x wolniejsze i właśnie tam pooling może pomóc.

1. Średni i percentylowy czas utworzenia obiektu (P95/P99).
Co mówi ta metryka: czy tworzenie obiektu rzeczywiście boli wydajnościowo w ogonie rozkładu.
Jak interpretować: jeśli średnia jest niska, ale P95/P99 wysokie, to pool może stabilizować czasy odpowiedzi.

2. Liczba alokacji na pojedyncze żądanie.
Co mówi ta metryka: jak duża presja pamięci powstaje przy naturalnym użyciu komponentu.
Jak interpretować: dużo krótkotrwałych alokacji zwykle zwiększa częstotliwość GC, ale w .NET to nie zawsze oznacza, że pool będzie szybszy.

3. Narzut GC (Gen0, Gen1, Gen2) oraz czas pauz.
Co mówi ta metryka: czy garbage collector staje się wąskim gardłem.
Jak interpretować: wzrost Gen1/Gen2 i widoczne pauzy pod obciążeniem to sygnał, że warto rozważyć pooling lub inną strategię redukcji alokacji.

Rozszerzenie: jak czytać Gen0/Gen1/Gen2 w praktyce:

- **Gen0**: trafiają tu nowe, krótkotrwałe obiekty. Częste kolekcje Gen0 są normalne w aplikacjach serwerowych i same w sobie nie są problemem.
- **Gen1**: obiekty, które przeżyły Gen0. Wzrost częstotliwości Gen1 oznacza, że więcej obiektów żyje dłużej niż zakładano i zaczyna obciążać kolejne etapy GC.
- **Gen2**: obiekty długowieczne (oraz często większe struktury). Kolekcje Gen2 są najdroższe i zwykle najbardziej odczuwalne dla opóźnień.

Na co patrzeć przed wdrożeniem puli:

- czy przy tym samym ruchu liczba kolekcji Gen1/Gen2 rośnie szybciej niż throughput,
- czy piki P95/P99 zgrywają się czasowo z kolekcjami Gen2,
- czy całkowity czas spędzony w GC stanowi istotny procent czasu procesu,
- czy po wprowadzeniu puli spadają alokacje i Gen0, ale nie rośnie nadmiernie czas oczekiwania na obiekt z puli.

Praktyczna heurystyka:

- wysoki Gen0 i niski Gen1/Gen2: najpierw optymalizuj lokalne alokacje, pool nie zawsze potrzebny,
- rosnący Gen1/Gen2 + skoki P95/P99: pooling może pomóc, jeśli obiekt jest faktycznie drogi i bezpieczny do resetu,
- brak poprawy P95/P99 po włączeniu puli: koszt synchronizacji lub zbyt mały rozmiar puli niweluje zysk.

4. Przepustowość i opóźnienia pod obciążeniem.
Co mówi ta metryka: jak system zachowuje się przy rzeczywistym ruchu równoległym.
Jak interpretować: porównuj nie tylko średni czas, ale także P95/P99 oraz stabilność wyników przy tej samej liczbie równoległych operacji.

5. Czas oczekiwania na wolny obiekt w puli.
Co mówi ta metryka: czy pool nie staje się kolejką blokującą użytkowników.
Jak interpretować: jeśli wait-time rośnie, pula jest za mała albo obiekt jest przetrzymywany zbyt długo.

6. Bilans kosztów: synchronizacja kontra zysk z reuse.
W puli płacisz za koordynację (np. `SemaphoreSlim`, kolejki, reset stanu).
Jeżeli ten koszt jest większy niż koszt `new`, pool pogorszy wydajność.

Praktyczna procedura pomiarowa:

1. Zmierz wariant bez puli na danych zbliżonych do produkcyjnych.
2. Zmierz wariant z pulą przy kilku rozmiarach puli.
3. Porównaj średnią, P95/P99, GC i wait-time.
4. Wybierz rozwiązanie dopiero na podstawie wyników, nie na podstawie założeń.

---

## Przykład C Sharp

Kod demonstracyjny: [Examples/Program.cs](Examples/Program.cs)

Przykład uruchamia dwa warianty:

- bez puli (`new`),
- z pulą (`SemaphoreSlim` + kolejka).

Kluczowy fragment porównania:

```csharp
foreach (var simulatedInitMs in initCostsMs)
{
    var noPool = MeasureNoPool(operations, simulatedInitMs);
    var pooled = MeasureWithPool(operations, simulatedInitMs);

    Console.WriteLine(
        $"Init = {simulatedInitMs,2} ms | new = {noPool,5} ms | pool = {pooled,5} ms | delta = {noPool - pooled,5} ms");
}
```

Co robi ten kod:

1. Uruchamia test dla kilku kosztów inicjalizacji obiektu (`1, 3, 8, 20 ms`).
2. Dla każdego kosztu liczy czas wykonania wariantu bez puli i z pulą.
3. Wypisuje różnicę (`delta`), która pokazuje realny zysk albo stratę.

Dlaczego to ważne dydaktycznie:

1. Ten sam kod biznesowy może dawać odwrotne wyniki zależnie od kosztu tworzenia obiektu.
2. Przy taniej inicjalizacji koszt synchronizacji puli często zjada zysk.
3. Przy drogiej inicjalizacji pool zaczyna stabilnie wygrywać.

Na co zwrócić uwagę podczas uruchamiania:

1. Uruchamiaj w trybie Release.
2. Powtórz test kilka razy i policz medianę.
3. Zmieniaj liczbę operacji i współbieżność (np. `operations = 200, 1000, 5000`).
4. Sprawdzaj, czy wynik nie zmienia się po modyfikacji pojemności puli.

### `Stopwatch` vs profiler: co jest „najlepsze"?

Krótka odpowiedź: **`Stopwatch` jest dobry na szybkie porównanie wariantów**, ale **nie zastępuje profilera**. Najlepsza praktyka to użycie obu narzędzi.

`Stopwatch` w tym przykładzie mierzy czas ścienny (wall-clock) całej operacji i świetnie nadaje się do pytania:
"czy wariant z pool jest szybszy od wariantu bez pool przy tym samym obciążeniu?".

Plusy `Stopwatch`:

- bardzo prosty w użyciu i praktycznie bez konfiguracji,
- niski narzut pomiaru,
- łatwo automatyzować i porównywać wyniki między wariantami,
- dobry do testów regresji wydajności w CI.

Minusy `Stopwatch`:

- nie pokazuje, **dlaczego** coś jest wolniejsze (GC, locki, czekanie na pool, CPU, I/O),
- wynik bywa wrażliwy na „szum" środowiska (inne procesy, scheduler, thermal throttling),
- pojedyncza liczba czasu ukrywa rozkład opóźnień (średnia może wyglądać dobrze, gdy P99 jest słabe),
- nie rozdziela czasu pracy aplikacji od czasu pauz GC i synchronizacji.

Co daje profiler ponad `Stopwatch`:

- rozbicie czasu na metody (hot paths),
- statystyki GC (alokacje, kolekcje Gen0/Gen1/Gen2, pauzy),
- analiza blokad i oczekiwania (`SemaphoreSlim`, lock contention),
- timeline zdarzeń, dzięki któremu można skorelować piki P95/P99 z GC lub synchronizacją.

### Jak użyć profilera w praktyce (CLI)

Najprostszy scenariusz bez IDE:

1. Uruchom aplikację w trybie Release:

```bash
cd src/05-object-pool/02-kiedy-stosowac/Examples
dotnet run -c Release
```

2. W drugim terminalu znajdź PID procesu:

```bash
dotnet-counters ps
```

3. Podejrzyj liczniki runtime na żywo (GC, CPU, alokacje):

```bash
dotnet-counters monitor --process-id <PID> System.Runtime
```

4. Zbierz ślad do głębszej analizy:

```bash
dotnet-trace collect --process-id <PID>
```

5. Otwórz wynik `.nettrace` w narzędziu wizualnym (np. PerfView lub Visual Studio) i sprawdź:

- CPU stacks (gdzie idzie czas),
- GC stats (Gen0/Gen1/Gen2, pause time),
- contention/blocking (czy pool nie tworzy kolejki).

### Jak użyć profilera w Visual Studio

1. Otwórz projekt `Examples` i ustaw konfigurację `Release`.
2. Wejdź w **Debug > Performance Profiler**.
3. Zaznacz co najmniej: **CPU Usage** i **.NET Object Allocation** (opcjonalnie **Concurrency Visualizer**).
4. Uruchom profilowanie, wykonaj scenariusz testowy, zatrzymaj sesję.
5. Porównaj wariant bez puli i z pulą przy tym samym obciążeniu.

Wniosek dydaktyczny:

- `Stopwatch` odpowiada na pytanie **czy** jest szybciej,
- profiler odpowiada na pytanie **dlaczego** jest szybciej lub wolniej.

Do finalnych decyzji architektonicznych warto mieć oba typy danych.

Uruchom:

```bash
cd src/05-object-pool/02-kiedy-stosowac/Examples
dotnet run -c Release
```

---

## Zadanie dla studentów

Zadanie: Zwiększ liczbę operacji i porównaj, przy jakim czasie inicjalizacji obiektu pool zaczyna dawać zysk.

Wskazówka: zmieniaj parametr `simulatedInitMs` w kodzie i zapisuj wyniki w tabeli.
