# Materiały wykładowe — Budowniczy (Builder)

## Plan wykładu (90 min)

| Czas | Temat | Forma |
| --- | --- | --- |
| 0-15 | Problem z konstrukcją — teleskopowy konstruktor, mutowalność, motywacja | slajd + live coding |
| 15-30 | Struktura GoF — Director, Builder, ConcreteBuilder, Product | slajd + live coding |
| 30-50 | Fluent Builder — method chaining, implicit operator, walidacja w Build() | slajd + live coding |
| 50-70 | Typy implementacji — Step Builder, Immutable Builder (record), porównanie | slajd + live coding |
| 70-85 | Kiedy stosować, kiedy nie — drzewo decyzyjne, ReportBuilder, kontrprzykłady | slajd + demo |
| 85-90 | Podsumowanie, pytania kontrolne | Q&A |

## Slajdy

### Slajd 1 — Problem z konstrukcją obiektów (01-problem-konstrukcji)

1. Teleskopowy konstruktor: `new Pizza("large", true, false, true)` — co oznacza trzecie `true`? Nieczytelny, nieskalowalny.
1. Object Initializer: czytelny, ale obiekt mutowalny po stworzeniu — brak enkapsulacji.
1. Nested Builder: `new Pizza.Builder("large").WithCheese().WithBacon().Build()` — czytelny, niemutowalny, z walidacją.
1. Builder rozdziela JAK budować (krok po kroku) od CZYM jest obiekt docelowy.
1. Factory odpowiada "KTÓRY obiekt?", Builder odpowiada "JAK go złożyć?" — mogą współpracować.

### Slajd 2 — Struktura GoF (02-struktura-gof)

1. **Product** (`Vehicle`): budowany obiekt — przechowuje części, nie wie jak się buduje.
1. **Builder** (`VehicleBuilder`): abstrakcyjny interfejs kroków — `BuildFrame()`, `BuildEngine()`, `BuildWheels()`, `BuildDoors()`.
1. **ConcreteBuilder** (`CarBuilder`, `ScooterBuilder`, `MotorCycleBuilder`): konkretne implementacje — wiedzą JAK budować daną kategorię.
1. **Director** (`Shop`): wie w jakiej KOLEJNOŚCI budować — wywołuje kroki na dowolnym Builderze.
1. Director jest opcjonalny — klient może wywoływać kroki ręcznie, co daje niekompletny produkt.

### Slajd 3 — Fluent Builder (03-fluent-builder)

1. Method chaining: każda metoda zwraca `this` → `.WithFirstName("Anna").WithLastName("Kowalska").Build()`.
1. `Employee.Builder`: zagnieżdżony builder z domyślnymi wartościami i walidacją (data urodzenia, pensja).
1. `implicit operator Employee`: konwersja niejawna — pozwala pominąć `.Build()` przy przypisaniu.
1. `Email.Builder`: builder z listami (To, Cc, Attachments) — `.To()` dodaje element, nie nadpisuje.
1. Walidacja w `Build()`: centralne sprawdzenie spójności — From wymagany, min. 1 adresat, Subject wymagany.

### Slajd 4 — Typy implementacji (04-typy-implementacji)

1. **Step Builder** (`SqlQueryBuilder`): interfejsy kroków (`IFromStep → ISelectStep → IWhereStep → IBuildStep`) — kompilator wymusza kolejność.
1. Jeden builder implementuje wszystkie interfejsy — typ zwracany ogranicza dostępne metody.
1. **Immutable Builder** (`PersonBuilder`): Builder z prywatnymi polami → `Build()` tworzy record `Person` z walidacją.
1. **Record + with** (C# 9+): `original with { Age = 31 }` — lekka kopia z modyfikacją, value equality.
1. Porównanie: Step = bezpieczeństwo kompilacji, Fluent = elastyczność, record = prostota bez buildera.

### Slajd 5 — Kiedy stosować, kiedy nie (05-kiedy-stosowac)

1. **TAK**: Obiekt z wieloma opcjonalnymi parametrami, złożoną strukturą, potrzebą walidacji (ReportBuilder z sekcjami i wykresami).
1. **TAK**: Gdy ten sam proces budowania ma tworzyć różne reprezentacje (HTML vs Markdown vs PDF).
1. **NIE**: `Point2D(3.0, 4.5)` — konstruktor jest wystarczający dla 2 pól.
1. **NIE**: `Color(R: 255, G: 128, B: 0)` — named arguments rozwiązują problem czytelności.
1. **NIE**: `ApiOptions { BaseUrl = "..." }` — object initializer wystarcza gdy brak walidacji.

## FAQ

### 1. Czym Builder różni się od Abstract Factory?

Abstract Factory tworzy rodziny powiązanych obiektów jednym wywołaniem. Builder konstruuje jeden złożony obiekt krok po kroku z opcjonalnymi parametrami.

### 2. Czy Director jest obowiązkowy?

Nie. Director porządkuje algorytm budowania, ale klient może wywoływać kroki bezpośrednio. W Fluent Builderze rolę Directora pełni sam klient.

### 3. Kiedy wybrać Step Builder zamiast Fluent Buildera?

Gdy kolejność kroków jest krytyczna i chcesz ją wymusić na poziomie kompilacji. Step Builder jest trudniejszy w rozszerzaniu, ale bezpieczniejszy.

### 4. Czy record w C# zastępuje Builder?

Częściowo — `with`-expression wystarczy dla prostych niemutowalnych obiektów. Builder jest nadal potrzebny gdy wymagana jest walidacja, wiele opcjonalnych pól lub złożona struktura.

### 5. Jak przetestować Builder?

Testuj product (wynik Build()) — sprawdzaj wartości pól, walidację i niezależność instancji. Builder sam w sobie jest szczegółem implementacyjnym.

## Literatura

| Źródło | Zakres |
| --- | --- |
| GoF, Design Patterns (1994), s. 97–106 | oryginalna definicja — Director, Builder, Product |
| Joshua Bloch, Effective Java (2018), Item 2 | nested Builder jako zamiennik telescoping constructor |
| Martin Fowler, Domain-Specific Languages (2010) | Fluent Interface i wewnętrzne DSL |
| [Refactoring.Guru: Builder](https://refactoring.guru/design-patterns/builder) | wizualizacja, przykłady w wielu językach |
