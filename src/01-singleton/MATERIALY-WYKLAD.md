# Materiały wykładowe — Singleton

## Plan wykładu (90 min)

| Czas | Temat | Forma |
| --- | --- | --- |
| 0-15 | Definicja — Classic, Eager, Lazy\<T\>, Static Holder, ChocolateBoiler | slajd + live coding |
| 15-25 | Konsekwencje — globalny dostęp, kontrola liczby instancji, Multiton | slajd + live coding |
| 25-40 | Przykłady praktyczne — Configuration, ConnectionPool, Factory, Logger | slajd + demo |
| 40-55 | Problemy — dziedziczenie, serializacja, refleksja + rozwiązania | slajd + live coding |
| 55-70 | Współbieżność — NonThreadSafe, lock, DCL, Lazy\<T\>, StaticInit + benchmark | slajd + live coding |
| 70-85 | Alternatywy — DI (AddSingleton), Monostate, Ambient Context | slajd + live coding |
| 85-90 | Podsumowanie, pytania kontrolne | Q&A |

## Slajdy

### Slajd 1 — Definicja i warianty implementacji (01-definicja)

1. **ClassicSingleton**: `if (_instance is null)` — leniwy, ale NIE thread-safe. GoF oryginał.
1. **EagerSingleton**: `static readonly _instance = new()` — CLR inicjalizuje raz, thread-safe. Brak leniwości.
1. **LazySingleton**: `Lazy<T>` (ExecutionAndPublication) — leniwy + thread-safe. **Zalecany w C#.**
1. **StaticHolderSingleton**: zagnieżdżona klasa z jawnym `static` ctor — leniwy bez `Lazy<T>`.
1. **ChocolateBoiler**: praktyczny singleton — sterowanie stanem fizycznym urządzenia (Fill→Boil→Drain).

### Slajd 2 — Konsekwencje wzorca (02-konsekwencje)

1. **Kontrola dostępu**: prywatny konstruktor gwarantuje, że NIE powstanie druga instancja.
1. **Globalny punkt dostępu**: `Instance` / `GetInstance()` — wygoda, ale ukryta zależność.
1. **Rozszerzalność**: Multiton — `LimitedInstancesSingleton` z pulą N instancji i round-robin.
1. **Stan współdzielony**: zmiana przez jedną referencję widoczna wszędzie — zaleta i zagrożenie.
1. **Czas życia = czas aplikacji**: brak jawnego `Dispose` — trudne do zarządzania zasobami.

### Slajd 3 — Przykłady praktyczne (03-przyklady)

1. **AppConfiguration**: singleton wczytujący ustawienia raz — `Get<T>(key, default)`.
1. **DbConnectionPool**: pula połączeń (SemaphoreSlim + Queue) — `AcquireAsync` / `Release`.
1. **VehicleFactory**: singleton-registry — `Register("type", () => new T())` + `Create("type")`.
1. **AppLogger**: singleton z `StreamWriter` + `lock` — `Log(level, msg)`, `IDisposable`.
1. **Wspólna cecha**: kosztowna inicjalizacja + potrzeba jednej instancji = motywacja dla Singletona.

### Slajd 4 — Problemy (04-problemy)

1. **Dziedziczenie**: `ProblematicLogger.GetInstance()` zawsze zwraca bazowy typ — podklasa nie może mieć własnego singletona.
1. **Rozwiązanie 1**: Registry of Singletons — `BaseLogger.GetInstance("file")` / `GetInstance("console")`.
1. **Rozwiązanie 2**: Niezależne singletony — `IndependentFileLogger.Instance` / `IndependentDatabaseLogger.Instance`.
1. **Serializacja**: `JsonSerializer.Deserialize<T>()` tworzy **nowy obiekt** → naruszenie singletona. Rozwiązanie: `JsonConverter<T>`.
1. **Refleksja**: `ctor.Invoke(null)` omija prywatny konstruktor. Rozwiązanie: guard `Interlocked.Increment` + `throw`.

### Slajd 5 — Współbieżność (05-wspolbieznosc)

1. **NonThreadSafe**: `if (_instance is null)` → race condition, wiele instancji.
1. **LockSingleton**: `lock(_lock)` na każde wywołanie — bezpieczny, ale wolniejszy po inicjalizacji.
1. **DCLSingleton**: double-checked locking + `volatile` — szybki po inicjalizacji, złożony w implementacji.
1. **LazyTSingleton**: `Lazy<T>` — jedna linia, thread-safe, **zalecany**. Po init: bezblokadowy odczyt.
1. **StaticInitSingleton**: jawny `static` ctor — CLR gwarantuje jedną inicjalizację. Brak zależności od `Lazy<T>`.

### Slajd 6 — Alternatywy (06-alternatywy)

1. **Dependency Injection**: `services.AddSingleton<IEmailSender, SmtpEmailSender>()` — singleton zarządzany przez kontener, testowalny.
1. **Testowalność DI**: `OrderService(new MockEmailSender())` — łatwa podmiana w testach, brak globalnego stanu.
1. **Monostate**: wiele instancji, wspólny stan (pola `static`) — przezroczysty dla klienta, trudny do resetu w testach.
1. **Ambient Context**: `AppTimeProvider.Current` z `AsyncLocal<T>` — globalny, ale wymienialny per wątek/task.
1. **Reguła**: Singleton → mały lub legacy projekt. DI + `AddSingleton` → nowoczesne aplikacje z testami.

## FAQ

### 1. Kiedy Singleton jest lepszy od DI z AddSingleton?

Singleton jest prostszy w małych projektach bez kontenera DI. W aplikacjach z DI konteneren (ASP.NET, MAUI) zawsze preferuj `AddSingleton<T>()` — daje testowalność i zarządzanie cyklem życia.

### 2. Czy Lazy\<T\> jest zawsze bezpieczny wątkowo?

Domyślny tryb `ExecutionAndPublication` jest bezpieczny. `LazyThreadSafetyMode.None` nie blokuje — szybszy, ale niebezpieczny w środowisku wielowątkowym.

### 3. Jak przetestować kod zależny od Singletona?

Najlepiej: wyodrębnij interfejs i wstrzyknij zależność (DI). Alternatywa: Ambient Context z `AsyncLocal<T>` pozwala na podmianę per test.

### 4. Czym Monostate różni się od Singletona?

Singleton: jedna instancja, wiele referencji. Monostate: wiele instancji, wspólny stan (pola statyczne). Monostate jest bardziej przezroczysty, ale trudniejszy do resetu.

### 5. Czy enum singleton z Javy działa w C#?

C# enum nie może mieć pól instancyjnych jak Java. Odpowiednikiem jest `sealed class` z `static readonly` polem — np. `EagerSingleton`.

## Literatura

| Źródło | Zakres |
| --- | --- |
| GoF, Design Patterns (1994), s. 127–134 | oryginalna definicja Singletona |
| Joshua Bloch, Effective Java (2018), Item 3 | enum singleton, ochrona przed serializacją i refleksją |
| Mark Seemann, Dependency Injection in .NET (2019) | DI jako alternatywa, Ambient Context |
| [Refactoring.Guru: Singleton](https://refactoring.guru/design-patterns/singleton) | wizualizacja, problemy, porównanie |
| Microsoft Docs, Lazy\<T\> Class | thread-safety modes, best practices |
