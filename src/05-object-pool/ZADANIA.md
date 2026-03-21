# Zadania dla studentów - Object Pool

## Zadanie 1 (podstawowe)

Temat: Reset stanu obiektu

Treść:
W projekcie [03-struktura-dzialanie/StructureSample](03-struktura-dzialanie/StructureSample) dodaj do `ExpensiveResource` pole `UserId` i pokaż, dlaczego brak resetu pola przy `Release()` może powodować wyciek danych między żądaniami.

Rozwiązanie (skrót):
1. Dodaj `public string UserId { get; set; } = string.Empty;`.
2. W metodzie `Reset()` ustaw `UserId = string.Empty;`.
3. W logach wypisz wartość `UserId` przed i po zwrocie do puli.

Omówienie:
To klasyczny błąd bezpieczeństwa i spójności danych. W systemach webowych może prowadzić do ujawnienia danych innego użytkownika.

---

## Zadanie 2 (decyzyjne)

Temat: Kiedy pool się opłaca

Treść:
W projekcie [02-kiedy-stosowac/Examples](02-kiedy-stosowac/Examples) zmieniaj koszt inicjalizacji (`initCostsMs`) i wyznacz próg, od którego użycie puli jest szybsze niż `new`.

Rozwiązanie (skrót):
1. Uruchom benchmark dla `initCostsMs = 1, 3, 8, 20`.
2. Dodaj własne punkty, np. `2, 5, 12`.
3. Wyznacz granicę opłacalności i opisz wnioski.

Omówienie:
Object Pool jest optymalizacją zależną od kontekstu. Bez pomiarów łatwo wprowadzić over-engineering.

---

## Zadanie 3 (średnio zaawansowane)

Temat: Timeout na `Acquire`

Treść:
W projekcie [06-asynchroniczne-workery/AsyncWorkersSample](06-asynchroniczne-workery/AsyncWorkersSample) dodaj timeout 500 ms na oczekiwanie workera. Jeśli timeout minie, zwróć błąd biznesowy `WorkerUnavailableException`.

Rozwiązanie (skrót):
1. Użyj `WaitAsync(TimeSpan)` dla `SemaphoreSlim`.
2. Przy `false` rzuć wyjątek domenowy.
3. Dodaj licznik timeoutów i wypisz statystykę po zakończeniu.

Omówienie:
W produkcji pool bez timeoutów może powodować długie kolejki i kaskadowe timeouty na wyższych warstwach.

---

## Zadanie 4 (zaawansowane)

Temat: Dobór liczby workerów

Treść:
W projekcie [06-asynchroniczne-workery/AsyncWorkersSample](06-asynchroniczne-workery/AsyncWorkersSample) uruchom testy dla `W = 2, 3, 4, 5` workerów i stałej liczby 100 zadań. Porównaj całkowity czas oraz oszacowany QPS.

Rozwiązanie (skrót):
1. Parametryzuj rozmiar puli przez argument CLI.
2. Zbieraj `ElapsedMilliseconds` i licz `QPS = tasks / seconds`.
3. Wybierz minimalne `W`, które spełnia wymaganie SLA.

Omówienie:
Większa pula nie zawsze znaczy lepsza. Może zwiększać koszt pamięci i presję na zasoby zewnętrzne.

---

## Zadanie 5 (porównawcze)

Temat: Alternatywy

Treść:
Dla scenariusza dużych buforów `byte[]` porównaj Object Pool i `ArrayPool<byte>`. Oceń wydajność i złożoność kodu.

Rozwiązanie (skrót):
1. Stwórz dwa warianty przetwarzania danych.
2. Zmierz czas i liczbę alokacji.
3. Opisz, kiedy standardowa biblioteka (`ArrayPool<T>`) jest lepsza od ręcznego poola.

Omówienie:
Celem zadania jest nauczenie podejścia: najpierw sprawdź gotowe narzędzie platformy, potem twórz własną infrastrukturę.