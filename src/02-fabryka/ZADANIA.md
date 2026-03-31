# Zadania — Fabryka (Factory)

## Zadanie 1 — Nowa strategia wysyłki (OCP)

**Katalog:** `01-open-close`

Dodaj nową strategię wysyłki `EcoShipping`, która implementuje `IShippingCalculator`:
- Koszt = 5.00 zł dla zamówień powyżej 100 zł, 15.00 zł poniżej.
- Zarejestruj ją w tablicy `calculators` w `Program.cs`.
- Napisz testy jednostkowe dla nowej klasy.
- **Cel:** Upewnij się, że `OrderProcessor` NIE wymaga żadnych zmian.

## Zadanie 2 — Rozbudowa Simple Factory

**Katalog:** `02-simple-factory`

1. Dodaj nowy typ pizzy `HawaiianPizza` (Name = "Hawajska", Dough = "cienkie ciasto", Sauce = "sos słodko-kwaśny", Toppings = ["szynka", "ananas"]).
2. Zarejestruj ją w `SimplePizzaFactory.CreatePizza()` pod kluczem `"hawaiian"`.
3. Dodaj nowy kanał powiadomień `TeamsNotification` w `NotificationFactory`.
4. Napisz testy dla nowych typów.
5. **Refleksja:** Ile istniejących klas musiałeś zmodyfikować? Dlaczego to narusza OCP?

## Zadanie 3 — Nowy ConcreteCreator (Factory Method)

**Katalog:** `03-factory-method`

1. Dodaj `TexasPizzaStore : PizzaStore` z metodą `CreatePizza()` obsługującą `"cheese"` i `"bbq"`.
2. Stwórz klasy `TexasStyleCheesePizza` i `TexasStyleBBQPizza` z odpowiednimi składnikami.
3. Dodaj `LenovoComputerFactory : ComputerFactory` z produktami `LenovoGamingPC` i `LenovoWorkStation`.
4. Napisz testy jednostkowe dla obu nowych fabryk.
5. **Cel:** Żadna istniejąca klasa nie powinna być modyfikowana.

## Zadanie 4 — Nowa rodzina produktów (Abstract Factory)

**Katalog:** `04-abstract-factory`

1. Dodaj nową rodzinę składników: `CaliforniaPizzaIngredientFactory` implementującą `IPizzaIngredientFactory`.
2. Stwórz składniki: `SourdoughDough`, `AvocadoSauce`, `PepperJackCheese`, `CaliforniaClams`.
3. Dodaj `CaliforniaPizzaStore : PizzaStore` korzystający z nowej fabryki.
4. Dodaj `LenovoComputerFactory : IComputerFactory` z trzema produktami (GamingPC, WorkStation, Laptop).
5. Napisz testy sprawdzające, że każda rodzina tworzy spójne produkty (ten sam Brand).

## Zadanie 5 — Porównanie wzorców

**Katalog:** dowolny

Napisz krótki dokument (plik Markdown) porównujący:
- Simple Factory vs Factory Method vs Abstract Factory
- Kiedy stosować każdy z nich
- Który z nich najlepiej spełnia OCP i dlaczego

Uwzględnij diagram UML (PlantUML) pokazujący różnice strukturalne.

---

## Pytania kontrolne

1. Dlaczego Simple Factory **nie jest** wzorcem projektowym GoF, a jedynie idiomem programistycznym?
2. W jaki sposób Factory Method wykorzystuje zasadę Hollywood ("Don't call us, we'll call you")?
3. Czym różni się Abstract Factory od Factory Method pod względem liczby tworzonych produktów?
4. Wyjaśnij, jak zasada OCP jest spełniona w `OrderProcessor` z katalogu `01-open-close/WithOcp`.
5. Kiedy warto użyć Simple Factory zamiast pełnego Factory Method?
