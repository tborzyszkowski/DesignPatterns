# Materiały wykładowe — Adapter

## Plan wykładu (90 min)

| Czas | Temat | Forma |
| --- | --- | --- |
| 0-10 | Problem niezgodnych interfejsów — motywacja i historia | slajd + dyskusja |
| 10-25 | Kiedy stosować Adapter — drzewo decyzji i metryki | slajd + ćwiczenie |
| 25-40 | Struktura GoF — role, diagram klas i sekwencji | slajd + live coding |
| 40-55 | Object Adapter vs Class Adapter — porównanie wariantów | slajd + live coding |
| 55-65 | Two Way Adapter — adaptacja dwukierunkowa | slajd + demo |
| 65-80 | Pluggable Adapter — rejestr, Open/Closed, architektura pluginowa | slajd + demo |
| 80-90 | Kiedy NIE stosować Adaptera, alternatywy, podsumowanie | slajd + Q&A |

## Slajdy

### Slajd 1 — Problem niezgodnych interfejsów (01-idea-i-kontekst)

1. W systemach integrujących legacy, zewnętrzne SDK i mikroserwisy interfejsy rzadko są zgodne.
1. Adapter dodaje warstwę tłumaczącą — klient nie musi znać API dostawcy.
1. Przykład: `IPaymentGateway.Charge(decimal, string)` deleguje do `LegacyPaymentSystem.MakePayment(double, string)`.
1. Izolacja zależności: klient nie importuje klasy legacy.
1. Diagramy: `01-context.puml`, `02-problem-solution.puml`.

### Slajd 2 — Kiedy stosować Adapter (02-kiedy-stosowac)

1. Stosuj, gdy: klient wymaga stabilnego interfejsu, dostawca jest poza kontrolą, migracja ma być etapowa.
1. Nie stosuj, gdy: oba końce kontraktu możesz zmienić lub rośnie łańcuch adapterów.
1. Mierz narzut: $overhead = \frac{AdapterMs - NoAdapterMs}{NoAdapterMs} \cdot 100\%$.
1. Benchmark w programie: `Benchmark.Run(operations, mapCostMs)` → porównaj `NoAdapterMs` vs `AdapterMs`.
1. Diagramy: `01-decision-tree.puml`, `02-signals.puml`.

### Slajd 3 — Struktura GoF (03-struktura-gof)

1. Cztery role: Target (interfejs klienta), Adaptee (legacy API), Adapter (tłumacz), Client (używa Target).
1. Adapter implementuje Target i deleguje do Adaptee z mapowaniem danych.
1. Przykład: `LegacyAdapter.Request(payload)` → `Adaptee.SpecificRequest(payload)` → zamiana `legacy::` na `mapped::`.
1. Client zależy tylko od ITarget — łatwa podmiana implementacji.
1. Diagramy: `01-class-diagram.puml`, `02-sequence.puml`.

### Slajd 4 — Object Adapter vs Class Adapter (04-implementacje-i-warianty)

1. Object Adapter (kompozycja): adapter posiada referencję do adaptee, deleguje wywołania.
1. Class Adapter (dziedziczenie): adapter dziedziczy po adaptee i implementuje interfejs klienta.
1. Object Adapter: niższe sprzężenie, lepsza testowalność, preferowany w C#.
1. Class Adapter: mniej kodu, ale silniejsze sprzężenie i ograniczenia single-inheritance.
1. Diagramy: `01-object-vs-class.puml`, `02-history.puml`.

### Slajd 5 — Two Way Adapter (06-two-way-adapter)

1. Implementuje dwa interfejsy jednocześnie — obiekt działa w obu kierunkach integracji.
1. Przykład: `Seabird` implementuje `IAircraft` i `ISeacraft` ze wspólnym stanem (tryb, wysokość, głębokość).
1. Walidacja domenowa: nie można startować pod wodą ani nurkować w locie.
1. Ryzyko: niespójny stan, dwuznaczna semantyka, tendencja do god object.
1. Diagramy: `01-two-way-class.puml`, `02-two-way-sequence.puml`.

### Slajd 6 — Pluggable Adapter (07-pluggable-adapter)

1. Dynamiczny dobór adaptera z rejestru na podstawie `SourceType`.
1. `AdapterRegistry` przechowuje mapę `string → IMessageAdapter`; nowe adaptery dodajesz przez `Register()`.
1. Zasada Open/Closed: klient nie zmienia się przy dodaniu nowego formatu (JSON, XML, CSV).
1. Dobre praktyki: loguj decyzję, waliduj rejestr przy starcie, dodaj strategię fallback.
1. Diagramy: `01-pluggable-class.puml`, `02-pluggable-sequence.puml`.

### Slajd 7 — Kiedy NIE stosować i alternatywy (05-kiedy-nie-i-alternatywy)

1. Czerwone flagi: adapter większy niż klient + adaptee, mapowanie warunkowe, kruche testy.
1. Alternatywy: Fasada (uproszczenie bez translacji), Anti-Corruption Layer (izolacja bounded contexts), refaktoryzacja kontraktu.
1. Heurystyka: adapter = tymczasowa migracja z cudzym API; ACL = trwała granica domen; refaktor = kontrolujesz oba końce.
1. Program: porównanie kosztów trzech opcji na horyzoncie 12 miesięcy z ryzykiem semantycznym.

## FAQ

### 1. Czym Adapter różni się od Fasady?

Adapter tłumaczy interfejs jednego komponentu na inny oczekiwany przez klienta. Fasada upraszcza dostęp do podsystemu wielu klas bez zmiany semantyki wywołań.

### 2. Czy Adapter łamie zasadę Single Responsibility?

Nie, jeśli odpowiada wyłącznie za translację kontraktu. Gdy zaczyna zawierać logikę biznesową lub walidację domenową, staje się antywzorcem.

### 3. Kiedy Class Adapter jest lepszy od Object Adapter?

Gdy potrzebujesz nadpisać zachowanie adaptee (override) i dziedziczenie nie ogranicza architektury. W C# zazwyczaj preferujemy Object Adapter ze względu na single-inheritance.

### 4. Jak testować Adapter?

Testuj kontrakt: wejście adaptera → wyjście adaptera. Mockuj adaptee w Object Adapter. Dla Two Way Adapter testuj oba kierunki i przejścia stanów.

### 5. Czym Pluggable Adapter różni się od wzorca Strategia?

Strategia wymienia algorytm wewnątrz jednego kontraktu. Pluggable Adapter wymienia translację między różnymi kontraktami źródeł danych, często z rejestrem i dynamicznym rozwiązywaniem.

## Literatura

| Źródło | Zakres |
| --- | --- |
| GoF, Design Patterns (1994) | formalny opis wzorca |
| [Refactoring Guru - Adapter](https://refactoring.guru/design-patterns/adapter) | definicja i podstawowy model |
| [SourceMaking - Adapter](https://sourcemaking.com/design_patterns/adapter) | warianty i relacje ze wzorcami |
| [Martin Fowler - Gateway](https://martinfowler.com/articles/refactoring-external-service.html) | granice adaptera w integracjach |
