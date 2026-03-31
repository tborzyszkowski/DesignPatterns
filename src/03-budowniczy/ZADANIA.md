# Zadania dla studentów — Budowniczy (Builder)

## Zadanie 1 (podstawowe)

Temat: Nested Builder z walidacją

Treść:
W projekcie [01-problem-konstrukcji/Examples](01-problem-konstrukcji/Examples) rozszerz `Pizza.Builder` o metodę `WithExtraCheese()` i walidację w `Build()`: jeśli `ExtraCheese == true` ale `Cheese == false`, rzuć wyjątek — nie można dodać extra sera bez sera bazowego.

Rozwiązanie (skrót):
1. Dodaj pole `bool ExtraCheese` do `Pizza` i `Builder`.
2. Dodaj `Builder WithExtraCheese()`.
3. W `Build()` sprawdź spójność i rzuć `InvalidOperationException`.

Omówienie:
`Build()` to naturalne miejsce na walidację reguł biznesowych dotyczących całego obiektu — nie da się tego wymusić w konstruktorze teleskopowym.

---

## Zadanie 2 (średnio zaawansowane)

Temat: Nowy ConcreteBuilder

Treść:
W projekcie [02-struktura-gof/Examples](02-struktura-gof/Examples) dodaj `TruckBuilder` implementujący `VehicleBuilder`. Ciężarówka ma ramę "Ladder Frame — Reinforced Steel", silnik "6.7L Diesel 400 KM", koła "6 × 315/80 R22.5" i drzwi "2". Zbuduj ją przez `Shop.Construct()` i sprawdź wynik.

Rozwiązanie (skrót):
1. Utwórz `TruckBuilder : VehicleBuilder` z odpowiednimi wartościami.
2. W `Program.cs` dodaj sekcję budowania ciężarówki.
3. Sprawdź, że `Shop` nie wymaga żadnych zmian — akceptuje każdy `VehicleBuilder`.

Omówienie:
Director (Shop) i abstrakcyjny Builder (VehicleBuilder) umożliwiają dodawanie nowych produktów bez modyfikacji istniejącego kodu (OCP).

---

## Zadanie 3 (średnio zaawansowane)

Temat: Fluent Builder z Reset

Treść:
W projekcie [03-fluent-builder/Examples](03-fluent-builder/Examples) dodaj do `Email.Builder` metodę `Reset()`, która zeruje wszystkie pola i pozwala zbudować kolejnego maila tym samym builderem. Zademonstruj budowanie 3 różnych maili jednym builderem.

Rozwiązanie (skrót):
1. Dodaj `Builder Reset()` czyszczący wszystkie listy i pola.
2. Zbuduj maila, wywołaj Reset(), zbuduj kolejnego.
3. Sprawdź, że poprzedni mail nie został zmodyfikowany (listy są kopiowane w `Build()`).

Omówienie:
Reset eliminuje potrzebę tworzenia nowej instancji buildera na każdy obiekt. Ważne: product musi kopiować dane, nie współdzielić referencji.

---

## Zadanie 4 (zaawansowane)

Temat: Step Builder — nowe kroki

Treść:
W projekcie [04-typy-implementacji/Examples](04-typy-implementacji/Examples) rozszerz `SqlQueryBuilder` o krok `JOIN`. Nowy interfejs `IJoinStep` powinien być dostępny po `From()` a przed `Select()`. Kompilator powinien wymusić, że `JOIN` jest opcjonalny, ale jeśli użyty — musi być przed SELECT.

Rozwiązanie (skrót):
1. Dodaj `IJoinStep` z `Join(string table, string on)` i `Select()`.
2. `IFromStep.From()` zwraca `IJoinStep` zamiast `ISelectStep`.
3. `IJoinStep` dziedziczy po `ISelectStep` lub udostępnia metody `Select()`.
4. W `SqlQuery` dodaj pole `Joins` i uwzględnij je w `ToSql()`.

Omówienie:
Step Builder wymaga przemyślenia grafu przejść. Dodanie nowego kroku jest trudniejsze niż w Fluent Builderze — to kompromis za bezpieczeństwo typów.

---

## Zadanie 5 (porównawcze)

Temat: Builder vs record with

Treść:
Porównaj trzy podejścia do tworzenia obiektu `ConnectionOptions`: (1) Fluent Builder, (2) record + with-expression, (3) konstruktor z named parameters. Dla każdego podejścia stwórz 3 warianty konfiguracji i oceń: czytelność, bezpieczeństwo typów, możliwość walidacji.

Rozwiązanie (skrót):
1. Stwórz `ConnectionOptions` jako record i jako klasę z Builderem.
2. Porównaj kod tworzenia: builder jest najbezpieczniejszy, record + with najkrótszy.
3. Opisz: Builder opłaca się, gdy potrzebna walidacja, wiele opcjonalnych pól lub obiekty złożone.

Omówienie:
Nie ma jednego najlepszego podejścia. Kluczowe jest zrozumienie kompromisów i dopasowanie do konkretnego scenariusza.

## Pytania kontrolne

1. Jaki problem rozwiązuje wzorzec Budowniczy w porównaniu z teleskopowym konstruktorem i object initializerem?

1. Jakie role pełnią Director, Builder, ConcreteBuilder i Product w klasycznej strukturze GoF i dlaczego Director jest opcjonalny?

1. Czym Fluent Builder różni się od klasycznego GoF Buildera i jaką rolę pełni method chaining oraz implicit operator?

1. Jak Step Builder wymusza kolejność kroków na poziomie kompilacji i kiedy warto go użyć zamiast zwykłego Fluent Buildera?

1. W jakich sytuacjach Builder jest przerostem formy i jakie alternatywy (konstruktor, named arguments, record with, object initializer) są lepszym wyborem?
