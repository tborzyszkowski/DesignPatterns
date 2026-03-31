# Materiały wykładowe — Fabryka (Factory)

## Plan wykładu (90 min)

| Czas | Temat | Forma |
| --- | --- | --- |
| 0-15 | Zasada Otwarte-Zamknięte (OCP) — motywacja dla wzorców wytwórczych | slajd + live coding |
| 15-30 | Simple Factory — idiom, ograniczenia, naruszenie OCP | slajd + live coding |
| 30-50 | Factory Method — metoda wytwórcza, Template Method, polimorfizm | slajd + live coding |
| 50-75 | Abstract Factory — rodziny produktów, spójność, porównanie z FM | slajd + live coding |
| 75-85 | Porównanie trzech podejść — kiedy które, drzewo decyzyjne | slajd + dyskusja |
| 85-90 | Podsumowanie, pytania kontrolne | Q&A |

## Slajdy

### Slajd 1 — Zasada Otwarte-Zamknięte (01-open-close)

1. **Naruszenie OCP**: `OrderProcessor` z `if/else` na `ShippingType` — każdy nowy typ wymaga modyfikacji metody.
1. **Rozwiązanie**: interfejs `IShippingCalculator` + rejestracja implementacji — `OrderProcessor` zamknięty na modyfikacje.
1. Nowa wysyłka = nowa klasa (`SameDayShipping`), zero zmian w istniejącym kodzie.
1. Analogia z kształtami: `ShapeRendererBad` (switch) vs `ShapeRendererGood` (polimorfizm przez `IShape`).
1. OCP to fundament wszystkich wzorców wytwórczych — fabryka przenosi `new` do wyizolowanego miejsca.

### Slajd 2 — Simple Factory (02-simple-factory)

1. Simple Factory to **idiom**, nie wzorzec GoF — jedna klasa z `switch/case` tworzącym obiekty.
1. `SimplePizzaFactory.CreatePizza("cheese")` → centralizacja `new`, klient (`PizzaStore`) zna tylko `Pizza`.
1. `NotificationFactory.Create("email")` → ten sam schemat dla powiadomień.
1. **Zaleta**: prostota, izolacja tworzenia w jednym miejscu.
1. **Wada**: narusza OCP — nowy typ produktu = modyfikacja fabryki. Akceptowalne gdy typy są stabilne.

### Slajd 3 — Factory Method (03-factory-method)

1. **Struktura GoF**: abstrakcyjny `Creator` z metodą wytwórczą `CreatePizza()` + podklasy (`NYPizzaStore`, `ChicagoPizzaStore`).
1. `OrderPizza()` to Template Method — zna algorytm (Prepare→Bake→Cut→Box), nie zna konkretnego produktu.
1. Nowy styl = nowa podklasa (`TexasPizzaStore`), zero modyfikacji istniejącego kodu → OCP ✓.
1. `ComputerFactory` z `CreateGamingPC()` + `CreateWorkStation()` — `ComputerStore` operuje na abstrakcji.
1. Zasada Hollywood: klasa bazowa wywołuje `CreatePizza()` (hook), podklasa decyduje CO stworzyć.

### Slajd 4 — Abstract Factory (04-abstract-factory)

1. **Interfejs fabryki**: `IPizzaIngredientFactory` z metodami `CreateDough()`, `CreateSauce()`, `CreateCheese()`, `CreateClams()`.
1. **Rodzina produktów**: NY = ThinCrust + Marinara + Reggiano + FreshClams; Chicago = ThickCrust + PlumTomato + Mozzarella + FrozenClams.
1. `CheesePizza` przyjmuje `IPizzaIngredientFactory` — nie wie SKĄD składniki, wie JAK je złożyć.
1. `IComputerFactory` z 3 metodami — zmiana dostawcy (Dell→HP) = podmiana jednej fabryki, cały sprzęt się zmienia.
1. **Spójność rodziny**: DellFactory nigdy nie stworzy HpLaptop — interfejs to gwarantuje.

### Slajd 5 — Porównanie wzorców

1. **Simple Factory**: 1 fabryka, 1 metoda, switch/case → narusza OCP, akceptowane dla stabilnych typów.
1. **Factory Method**: abstrakcyjna metoda w klasie bazowej → podklasa decyduje o JEDNYM produkcie, OCP ✓.
1. **Abstract Factory**: interfejs z wieloma metodami → jedna implementacja = CAŁA RODZINA, OCP ✓.
1. **Kiedy co**: Simple Factory → mało typów, rzadko się zmieniają; FM → jeden produkt, różne warianty; AF → wiele powiązanych produktów, spójność rodziny.
1. Factory Method i Abstract Factory mogą współpracować — AF używa FM wewnętrznie do tworzenia poszczególnych produktów.

## FAQ

### 1. Czym Simple Factory różni się od Factory Method?

Simple Factory to zwykła klasa z metodą tworzącą (switch/case). Factory Method to wzorzec oparty na dziedziczeniu — abstrakcyjna metoda w klasie bazowej, konkretny produkt definiuje podklasa.

### 2. Czy Abstract Factory zawsze musi tworzyć wiele produktów?

Tak, to jej istota — tworzy rodzinę powiązanych produktów. Jeśli potrzebujesz tylko jednego produktu, Factory Method jest prostszym rozwiązaniem.

### 3. Jak wybrać między Factory Method a Abstract Factory?

Factory Method: jeden typ produktu z wariantami (np. różne style pizzy). Abstract Factory: wiele typów produktów, które muszą być ze sobą spójne (np. składniki pizzy z jednego regionu).

### 4. Czy fabryki naruszają zasadę Single Responsibility?

Nie — fabryka ma jedną odpowiedzialność: tworzenie obiektów. Oddziela logikę tworzenia od logiki biznesowej klienta.

### 5. Jak testować kod korzystający z fabryk?

Wstrzyknij fabrykę przez konstruktor (DI). W testach podaj mock lub stub fabryki zwracający kontrolowane obiekty.

## Literatura

| Źródło | Zakres |
| --- | --- |
| GoF, Design Patterns (1994), s. 87–96 (AF), 107–116 (FM) | oryginalne definicje obu wzorców |
| Freeman & Robson, Head First Design Patterns (2020), Rozdz. 4 | pizzeria — od Simple Factory przez FM do AF |
| Robert C. Martin, Agile Software Development (2002) | zasada OCP jako motywacja dla fabryk |
| [Refactoring.Guru: Factory Method](https://refactoring.guru/design-patterns/factory-method) | wizualizacja, porównanie z AF |
| [Refactoring.Guru: Abstract Factory](https://refactoring.guru/design-patterns/abstract-factory) | wizualizacja, przykłady w wielu językach |
