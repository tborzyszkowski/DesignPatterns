# 06. Asynchroniczni workerzy i pomiar wydajności

## Cel rozdziału

Pokazać scenariusz, w którym Object Pool daje realną przewagę: kosztowne, niezależne workery I/O oraz limit zasobów zewnętrznych.

---

## Założenia przykładu

- mamy tylko `W` drogich workerów (limit licencji/API),
- napływa dużo żądań równolegle,
- żądania czekają asynchronicznie na wolnego workera,
- po użyciu worker wraca do puli.

---

## Diagram sekwencji

![Asynchroniczna pula](diagrams/01-async-pool-sequence.png)

Źródło: [diagrams/01-async-pool-sequence.puml](diagrams/01-async-pool-sequence.puml)

## Model przepustowości

![Model przepustowości](diagrams/02-throughput-model.png)

Źródło: [diagrams/02-throughput-model.puml](diagrams/02-throughput-model.puml)

Przybliżenie:

$$QPS \approx \frac{W}{T}$$

gdzie:

- $W$ - liczba workerów,
- $T$ - średni czas obsługi pojedynczego zadania (sekundy).

---

## Przykład C Sharp

Kod: [AsyncWorkersSample/Program.cs](AsyncWorkersSample/Program.cs)

Implementacja używa:

- `ConcurrentQueue<HeavyWorker>` - kolejka wolnych workerów,
- `SemaphoreSlim` - kontrola równoległości i czekanie asynchroniczne,
- `Stopwatch` - pomiar całkowitego czasu obsługi.

Uruchom:

```bash
cd src/05-object-pool/06-asynchroniczne-workery/AsyncWorkersSample
dotnet run
```

---

## Jak dobrać liczbę workerów

1. Zmierz średni czas zadania (`T`) i wymagany QPS.
2. Policz wstępnie `W = QPS * T`.
3. Przetestuj `W-1`, `W`, `W+1` pod obciążeniem i porównaj P95/P99.
4. Dodaj limit timeoutu oczekiwania na worker.
