# Zadania — Singleton

## Zadanie 1 — Nowa wariant Singletona

**Katalog:** `01-definicja`

1. Zaimplementuj `EnumSingleton` — singleton oparty na statycznym polu `readonly` z jawnym konstruktorem statycznym (wzorzec „static holder" bez klasy zagnieżdżonej).
2. Dodaj metodę `Greet()` zwracającą opis wariantu.
3. Napisz testy sprawdzające identyczność instancji i działanie metody.
4. **Refleksja:** Czym ten wariant różni się od `EagerSingleton`?

## Zadanie 2 — Multiton z konfigurowalnym limitem

**Katalog:** `02-konsekwencje`

1. Rozbuduj `LimitedInstancesSingleton` tak, aby `MaxInstances` można było ustawiać przed pierwszym wywołaniem `GetInstance()` (np. metoda `Configure(int max)`).
2. Dodaj możliwość resetu puli — metoda `ResetPool()` (przydatna w testach).
3. Napisz testy weryfikujące: konfigurację limitu, reset, round-robin dla różnych rozmiarów puli.
4. **Uwaga:** Zadbaj o thread-safety przy konfiguracji i resecie.

## Zadanie 3 — Testowalne logowanie

**Katalog:** `03-przyklady`

1. Wyodrębnij interfejs `IAppLogger` z metod `Log`, `LogDebug`, `LogInfo` itp.
2. Stwórz implementację `InMemoryLogger : IAppLogger`, która zapisuje logi do `List<string>` zamiast do pliku.
3. Napisz testy jednostkowe, które weryfikują treść logów bez dostępu do pliku.
4. **Cel:** Pokaż, dlaczego wstrzykiwanie interfejsu jest łatwiejsze do przetestowania niż Singleton.

## Zadanie 4 — Ochrona przed klonowaniem

**Katalog:** `04-problemy`

1. Dodaj do `HardenedSingleton` implementację `ICloneable`, której metoda `Clone()` rzuca `InvalidOperationException`.
2. Stwórz drugą klasę `UnprotectedCloneable` — singleton implementujący `ICloneable` bez ochrony, demonstrujący problem.
3. Napisz testy pokazujące, że `MemberwiseClone()` przez refleksję tworzy nowy obiekt dla niezabezpieczonego singletona.
4. Napisz testy potwierdzające, że `HardenedSingleton.Clone()` rzuca wyjątek.

## Zadanie 5 — Benchmark rozszerzony

**Katalog:** `05-wspolbieznosc`

1. Dodaj do benchmarku pomiar `NonThreadSafeSingleton` (z ostrzeżeniem o potencjalnych duplikatach).
2. Dodaj nową implementację: `InterlockedSingleton` — singleton korzystający z `Interlocked.CompareExchange` zamiast `lock`.
3. Porównaj wyniki z pozostałymi wariantami (LockSingleton, DCLSingleton, LazyTSingleton, StaticInitSingleton).
4. Napisz testy thread-safety dla nowej implementacji.

---

## Pytania kontrolne

1. Wymień co najmniej **trzy problemy**, które Singleton wprowadza w kontekście testowalności kodu.
2. Czym różni się `Lazy<T>` z domyślnym trybem od `Lazy<T>` z `LazyThreadSafetyMode.None`?
3. Dlaczego wzorzec Monostate jest łatwiejszy do rozszerzenia przez dziedziczenie niż klasyczny Singleton?
4. W jaki sposób `Ambient Context` (np. `AppTimeProvider`) rozwiązuje problem globalnego stanu w testach?
5. Kiedy użycie Singletona jest uzasadnione, a kiedy lepiej zastosować Dependency Injection z `AddSingleton<T>()`?
