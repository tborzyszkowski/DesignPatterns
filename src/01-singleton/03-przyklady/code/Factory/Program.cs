using FactoryExample;

Console.WriteLine("=== FABRYKA JAKO SINGLETON ===\n");

var factory = VehicleFactory.Instance;
Console.WriteLine($"Zarejestrowane typy: {string.Join(", ", factory.RegisteredTypes)}\n");

// Tworzenie pojazdów
var car   = factory.Create("car");
var truck = factory.Create("truck");
var bike  = factory.Create("bike");

Console.WriteLine(car.Describe());
Console.WriteLine(truck.Describe());
Console.WriteLine(bike.Describe());

// Rejestracja nowego typu — rozszerzenie fabryki
Console.WriteLine("\n── Rejestracja nowego typu (ElectricScooter) ──");
factory.Register("scooter", () => new ElectricScooter());
var scooter = factory.Create("scooter");
Console.WriteLine(scooter.Describe());

// Fabryki są tym samym obiektem
var factory2 = VehicleFactory.Instance;
Console.WriteLine($"\nfactory == factory2: {ReferenceEquals(factory, factory2)}");

// Próba stworzenia nieznanego typu
try
{
    factory.Create("helicopter");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"\nOczekiwany wyjątek: {ex.Message}");
}

// Klasa pomocnicza do demonstracji rozszerzalności fabryki
public sealed class ElectricScooter : IVehicle
{
    public string Type => "ElectricScooter";
    public string Describe() => "Hulajnoga elektryczna: lekka, miejska, zero emisji.";
}
