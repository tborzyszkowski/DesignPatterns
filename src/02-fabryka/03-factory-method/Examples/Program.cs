using FactoryMethod.Pizza;
using FactoryMethod.Computers;

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║          WZORZEC: METODA WYTWÓRCZA (Factory Method)  ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");

// =====================================================================
// PRZYKŁAD 1: Pizzeria — Head First Design Patterns
// =====================================================================

Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 1: Pizzeria                                │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

PizzaStore nyStore      = new NYPizzaStore();
PizzaStore chicagoStore = new ChicagoPizzaStore();

// Ten sam interfejs, różne realizacje — Creator decyduje jaką pizzę stworzyć
nyStore.OrderPizza("cheese");
chicagoStore.OrderPizza("cheese");
nyStore.OrderPizza("pepperoni");
chicagoStore.OrderPizza("pepperoni");

Console.WriteLine();
Console.WriteLine("WNIOSEK: Kod OrderPizza() NIE zmienił się — tylko CreatePizza() jest inne.");

// =====================================================================
// PRZYKŁAD 2: Fabryki komputerów
// =====================================================================

Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 2: Fabryki komputerów (Dell / HP)          │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

ComputerFactory dellFactory = new DellComputerFactory();
ComputerFactory hpFactory   = new HpComputerFactory();

dellFactory.ShowProductLine();
hpFactory.ShowProductLine();

// Polimorficzne użycie przez klienta (Dependency Injection)
Console.WriteLine("\n--- Konfiguracja stanowiska przez ComputerStore ---");
var store = new ComputerStore(dellFactory);
store.ConfigureWorkplace();

Console.WriteLine("\n--- Podmiana dostawcy (HP) — kod klienta bez zmian ---");
store = new ComputerStore(hpFactory);
store.ConfigureWorkplace();

// =====================================================================
// PRZYKŁAD 3: Demonstracja OCP — dodanie nowej "gałęzi" bez modyfikacji
// =====================================================================

Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 3: OCP — rozszerzenie bez modyfikacji      │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");
Console.WriteLine("Gdybyśmy chcieli dodać TexasPizzaStore, wystarczy:");
Console.WriteLine("  1. Stworzyć klasę 'TexasPizzaStore : PizzaStore'");
Console.WriteLine("  2. Nadpisać CreatePizza().");
Console.WriteLine("  Nie MODYFIKUJEMY istniejącego PizzaStore!");
Console.WriteLine();
Console.WriteLine("Podobnie dla LenovoComputerFactory — dziedziczymy z ComputerFactory");
Console.WriteLine("i implementujemy CreateGamingPC() + CreateWorkStation().");
