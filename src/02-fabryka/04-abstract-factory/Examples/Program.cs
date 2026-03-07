using AbstractFactory.Pizza;
using AbstractFactory.Computers;

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║       WZORZEC: FABRYKA ABSTRAKCYJNA (Abstract Factory)║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");

// =====================================================================
// PRZYKŁAD 1: Pizzeria z fabrykiami składników
// =====================================================================

Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 1: Pizzeria — rodziny składników           │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

PizzaStore nyStore = new NYPizzaStore();
PizzaStore chiStore = new ChicagoPizzaStore();

// Ta sama pizza, ale INNE składniki (inna rodzina produktów)
nyStore.OrderPizza("cheese");
chiStore.OrderPizza("cheese");
nyStore.OrderPizza("clam");
chiStore.OrderPizza("clam");

Console.WriteLine();
Console.WriteLine("WNIOSEK: CheesePizza/ClamPizza nie wie SKĄD biorą się składniki.");
Console.WriteLine("         Zmiana rodziny = podmiana IPizzaIngredientFactory.");

// =====================================================================
// PRZYKŁAD 2: Fabryki komputerów — rodziny sprzętowe
// =====================================================================

Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 2: Komputery — rodziny produktów           │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

IComputerFactory dellFactory = new DellComputerFactory();
IComputerFactory hpFactory   = new HpComputerFactory();

var dellOffice = new Office(dellFactory);
var hpOffice   = new Office(hpFactory);

dellOffice.SetupAllEquipment();
hpOffice.SetupAllEquipment();

// =====================================================================
// PRZYKŁAD 3: Podmiana dostawcy — kod klienta bez zmian
// =====================================================================

Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 3: Podmiana dostawcy (Dell → HP)           │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

// Konfiguracja zależy od środowiska — np. appsettings, DI container
IComputerFactory factory = Environment.GetEnvironmentVariable("VENDOR") == "HP"
    ? new HpComputerFactory()
    : new DellComputerFactory();

var office = new Office(factory);
office.SetupDeveloperWorkplace();
office.SetupGameRoom();

Console.WriteLine();
Console.WriteLine("WNIOSEK: Office nie zna DellGamingPC, HpLaptop itp.");
Console.WriteLine("         Zmiana zmiennej środowiskowej VENDOR zmienia całą rodzinę.");

// =====================================================================
// PRZYKŁAD 4: Różnica między Factory Method a Abstract Factory
// =====================================================================

Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PODSUMOWANIE: FM vs AF                              │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");
Console.WriteLine("Factory Method   — jedna metoda wytwórcza w klasie bazowej");
Console.WriteLine("                   podklasa tworzy JEDEN produkt");
Console.WriteLine("Abstract Factory — interfejs z wieloma metodami wytwórczymi");
Console.WriteLine("                   jedna implementacja = CAŁA RODZINA produktów");
