# Wykorzystanie puli do niezależnych asynchronicznych workerów (Async Workers)

Najlepszym zastosowaniem wzorca Object Pool lub Thread Pool w środowiskach wielowątkowych typu .NET jest zarządzanie tzw. "Ciężkimi aktorami" lub "Workami", które są silnie związane np. z systemami wejścia/wyjścia (I/O). Przykłady obejmują dedykowane procesy analizy grafiki, dedykowane gniazda Socket/TcpClient do protokołów niskopoziomowych, połączenia z limitowanym restrykcjami API zewnętrznym, czy np. Headless Browsers (np. Selenium / Puppeteer).

## Założenia przykładu:
- Mamy zewnętrzne limitowane serwisy biznesowe (np. możemy obsłużyć maksymalnie 3 workery naraz w zadanym czasie, z racji limitów licencyjnych w API).
- Chcemy obsłużyć w asynchronicznym środowisku HTTP (np. zadania w C# z użyciem `Task` i blokad wbudowanych jak `SemaphoreSlim`) ok. 20 dużych żądań od użytkowników.
- Zamiast odrzucać żądania lub nieskończenie skalować system obijając się o limit API, wykorzystamy pulę! Żądania poczekają cierpliwie w kolejce (`await pool.AcquireAsync()`), zostaną obsłużone przez te same 3 obiekty Workera iteracyjnie, nie przeciążając sprzętu.

## Zysk
Pokazana w `AsyncWorkersSample` wersja używa SemaphoreSlim, która wymusza asynchroniczne zawieszenie metod pobierających, kiedy liczba maksymalna obiektów została wyczerpana. System zyskuje duży komfort - liczba użytych zasobów jest ścisła, nigdzie nie "ciekną" połączenia, powołujemy do życia obiekty jeden raz.

Kroki w prezentacji w aplikacji:
1. Określamy pulę na 3 workery, symulujące obróbkę ciężkiego żądania (100-300ms).
2. Startujemy 20 żądań klienta zrównoleglonych na wątkach bez opóźnień.
3. Obserwujemy na logach konsoli i po czasie wykonania, jak obiekty pracują naprzemiennie wymieniając stan.

Uruchom, wchodząc do głównego katalogu tego rozdziału za pomocą:
```bash
cd AsyncWorkersSample
dotnet run
```
