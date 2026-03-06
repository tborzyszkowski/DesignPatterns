namespace FactoryExample;

public interface IVehicle
{
    string Type { get; }
    string Describe();
}

public sealed class Car : IVehicle
{
    public string Type => "Car";
    public string Describe() => "Samochód osobowy: 4 koła, silnik spalinowy lub elektryczny.";
}

public sealed class Truck : IVehicle
{
    public string Type => "Truck";
    public string Describe() => "Ciężarówka: duży ładunek, silnik Diesel.";
}

public sealed class Bike : IVehicle
{
    public string Type => "Bike";
    public string Describe() => "Rower: 2 koła, napęd ludzki.";
}

/// <summary>
/// Fabryka pojazdów jako Singleton — centralny rejestr twórców obiektów.
/// Fabryka jest kosztowna do stworzenia (rejestracja, konfiguracja) —
/// dlatego tworzymy ją tylko raz.
/// </summary>
public sealed class VehicleFactory
{
    private static readonly Lazy<VehicleFactory> _lazy = new(() => new VehicleFactory());
    private readonly Dictionary<string, Func<IVehicle>> _creators = new(StringComparer.OrdinalIgnoreCase);

    private VehicleFactory()
    {
        // Wbudowane typy — rejestrowane przy inicjalizacji fabryki
        Register("car",   () => new Car());
        Register("truck", () => new Truck());
        Register("bike",  () => new Bike());
        Console.WriteLine("[VehicleFactory] Inicjalizacja — zarejestrowano typy: car, truck, bike.");
    }

    public static VehicleFactory Instance => _lazy.Value;

    /// <summary>Rejestruje nowy typ pojazdu pod podaną nazwą.</summary>
    public void Register(string type, Func<IVehicle> creator)
    {
        _creators[type] = creator;
    }

    /// <summary>Tworzy pojazd podanego typu.</summary>
    public IVehicle Create(string type)
    {
        if (_creators.TryGetValue(type, out var creator))
            return creator();
        throw new ArgumentException($"Nieznany typ pojazdu: '{type}'. " +
            $"Dostępne: {string.Join(", ", _creators.Keys)}");
    }

    /// <summary>Zwraca listę zarejestrowanych typów.</summary>
    public IEnumerable<string> RegisteredTypes => _creators.Keys;
}
