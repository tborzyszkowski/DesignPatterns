# Materiały wykładowe — Object Pool

## Plan wykładu (90 min)

| Czas | Temat | Forma |
| --- | --- | --- |
| 0-10 | Idea i kontekst — dlaczego pula obiektów? | slajd + dyskusja |
| 10-25 | Kiedy stosować Object Pool — benchmark i próg opłacalności | slajd + live demo |
| 25-40 | Struktura i działanie — role, diagram klas i sekwencji | slajd + live coding |
| 40-55 | Implementacje i warianty — ConcurrentBag, ObjectPool\<T\> | slajd + live coding |
| 55-70 | Over-engineering i alternatywy — ArrayPool, GC vs Pool | slajd + demo |
| 70-85 | Asynchroniczni workerzy — SemaphoreSlim, timeout, throughput | slajd + demo |
| 85-90 | Podsumowanie, pytania kontrolne | Q&A |

## Slajdy

### Slajd 1 — Idea i kontekst (01-idea-i-kontekst)

1. Object Pool zarządza pulą gotowych obiektów — wypożycza i przyjmuje zwroty zamiast tworzyć na nowo.
1. Motywacja: obiekty kosztowne w inicjalizacji (duże bufory, sockety, połączenia DB).
1. Przykład: 10 operacji z `Thread.Sleep(35)` jako symulacją kosztu → pula eliminuje powtórną inicjalizację.
1. Prosty pool: `ConcurrentBag<T>` + fabryka + reset + limit `maxRetained`.
1. Diagramy: `01-history-context.puml`, `02-problem-vs-solution.puml`.

### Slajd 2 — Kiedy stosować (02-kiedy-stosowac)

1. Stosuj, gdy: koszt tworzenia obiektu jest wysoki, obiekty są wielokrotnie używane, współbieżność jest duża.
1. Nie stosuj, gdy: obiekty są lekkie, GC sobie radzi, synchronizacja puli jest droższa niż `new`.
1. Benchmark: porównaj `NoPool` vs `Pool` dla różnych `initCostMs = {1, 3, 8, 20}`.
1. Im wyższy koszt inicjalizacji, tym większy zysk z puli.
1. Diagramy: `01-decision-tree.puml`, `02-signals.puml`.

### Slajd 3 — Struktura i działanie (03-struktura-dzialanie)

1. Trzy role: Pool (zarządza cyklem życia), Resource (drogi obiekt), Client (wypożycza i zwraca).
1. `Acquire()` → sprawdź pulę → jeśli pusta: utwórz nowy (do limitu) → zwróć obiekt.
1. `Release()` → reset stanu → oddaj do puli.
1. Krytyczne: `Reset()` czyści stan — bez tego wyciek danych między żądaniami.
1. Diagramy: `01-class-diagram.puml`, `02-sequence-lifecycle.puml`.

### Slajd 4 — Implementacje i warianty (04-implementacje-warianty)

1. Wariant 1: ręczny `ConcurrentBag<T>` — prosty, ale brak limitów i polityki zwrotu.
1. Wariant 2: `DefaultObjectPool<T>` z `Microsoft.Extensions.ObjectPool` — produkcyjny, z polityką `IPooledObjectPolicy<T>`.
1. Benchmark: `new StringBuilder` vs manual pool vs `ObjectPool<T>` na 60 000 operacji.
1. ObjectPool\<T\> upraszcza kod i zwykle lepiej skaluje się pod współbieżnością.
1. Diagramy: `01-eager-vs-lazy.puml`, `02-variants-map.puml`, `03-variant-manual-lock-queue.puml`, `04-variant-concurrentbag.puml`, `05-variant-dotnet-objectpool.puml`.

### Slajd 5 — Over-engineering i alternatywy (05-over-engineering-alternatywy)

1. Pool dla lekkich obiektów jest wolniejszy niż `new` — narzut synchronizacji > koszt alokacji.
1. Benchmark: 2 mln iteracji — `new` vs `ConcurrentBag` pool vs `ArrayPool<byte>`.
1. Alternatywa: `ArrayPool<T>.Shared` — zero ręcznego zarządzania, optymalna dla buforów.
1. Zasada: najpierw sprawdź gotowe narzędzie platformy, potem buduj własną pulę.
1. Diagramy: `01-when-not-to-use.puml`, `02-alternatives.puml`.

### Slajd 6 — Asynchroniczni workerzy (06-asynchroniczne-workery)

1. Realny scenariusz: `HeavyWorker` z kosztowną inicjalizacją (500 ms) przetwarza zadania I/O (200 ms).
1. `AsyncWorkerPool` z `SemaphoreSlim` — asynchroniczne oczekiwanie na wolny slot, eager pre-alokacja.
1. Timeout na `AcquireWorkerAsync` — zapobiega zatokom i kaskadowym timeoutom.
1. Metryki: throughput (QPS), średni wait-time, liczba timeoutów.
1. Diagramy: `01-async-pool-sequence.puml`, `02-throughput-model.puml`.

## FAQ

### 1. Czym Object Pool różni się od Flyweight?

Flyweight współdzieli niemodyfikowalny stan między wieloma klientami jednocześnie. Object Pool wypożycza obiekt jednemu klientowi na wyłączność i odzyskuje go po użyciu.

### 2. Czy Object Pool jest potrzebny w erze nowoczesnego GC?

Tylko dla obiektów naprawdę kosztownych w tworzeniu (połączenia sieciowe, duże bufory). Dla lekkich obiektów GC gen-0 jest szybszy niż synchronizacja puli.

### 3. Jak uniknąć wycieku danych między żądaniami?

Zawsze resetuj stan obiektu w `Release()` / `Return()`. Testuj reset jako osobny przypadek testowy.

### 4. Kiedy wybrać `ArrayPool<T>` zamiast własnego poola?

Gdy poolowane obiekty to tablice (`byte[]`, `char[]`). `ArrayPool<T>.Shared` jest wbudowany, bezpieczny wątkowo i nie wymaga konfiguracji.

### 5. Jaki rozmiar puli ustawić?

Zacznij od liczby rdzeni (`Environment.ProcessorCount`). Mierz throughput i wait-time, zwiększaj tylko gdy metryki to uzasadniają.

## Literatura

| Źródło | Zakres |
| --- | --- |
| GoF, Design Patterns (1994) | kontekst wzorców kreacyjnych |
| [Microsoft Docs: ObjectPool in ASP.NET Core](https://learn.microsoft.com/aspnet/core/performance/objectpool) | produkcyjne użycie |
| [SourceMaking: Object Pool](https://sourcemaking.com/design_patterns/object_pool) | intuicja wzorca |
| [System.Buffers ArrayPool](https://learn.microsoft.com/dotnet/api/system.buffers.arraypool-1) | alternatywa dla buforów |
