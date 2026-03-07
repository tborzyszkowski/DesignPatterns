namespace StrukturaGoF.Vehicles;

// ============================================================
// BUDOWNICZY (Builder) — klasyczny wzorzec GoF
// Przykład: fabryka pojazdów (na podstawie DoF Patterns in C#)
// ============================================================

// ----- Product -----------------------------------------------

/// <summary>
/// Produkt budowany krok po kroku przez Builder.
/// Przechowuje słownik części — konkretny zestaw zależy od
/// tego, którą implementację Buildera wybrał klient.
/// </summary>
public class Vehicle
{
    private readonly string _vehicleType;
    private readonly Dictionary<string, string> _parts = new();

    public Vehicle(string vehicleType) => _vehicleType = vehicleType;

    public string this[string key]
    {
        get => _parts.TryGetValue(key, out var v) ? v : "(brak)";
        set => _parts[key] = value;
    }

    public void Show()
    {
        Console.WriteLine($"\n  Vehicle Type : {_vehicleType}");
        Console.WriteLine($"  Frame        : {this["frame"]}");
        Console.WriteLine($"  Engine       : {this["engine"]}");
        Console.WriteLine($"  Wheels       : {this["wheels"]}");
        Console.WriteLine($"  Doors        : {this["doors"]}");
    }
}

// ----- Abstract Builder --------------------------------------

/// <summary>
/// Builder (abstrakcyjny) — definiuje interfejs kroków budowania.
/// Każdy krok to osobna metoda; Builder przechowuje referencję
/// do tworzonego produktu.
/// </summary>
public abstract class VehicleBuilder
{
    protected Vehicle _vehicle = null!;

    public Vehicle GetVehicle() => _vehicle;

    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();
}

// ----- Concrete Builders -------------------------------------

public class CarBuilder : VehicleBuilder
{
    public CarBuilder() => _vehicle = new Vehicle("Car");

    public override void BuildFrame()  => _vehicle["frame"]  = "Car Frame — Steel Unibody";
    public override void BuildEngine() => _vehicle["engine"] = "2.0T 204 KM";
    public override void BuildWheels() => _vehicle["wheels"] = "4 × 215/55 R17";
    public override void BuildDoors()  => _vehicle["doors"]  = "4";
}

public class ScooterBuilder : VehicleBuilder
{
    public ScooterBuilder() => _vehicle = new Vehicle("Scooter");

    public override void BuildFrame()  => _vehicle["frame"]  = "Scooter Monocoque";
    public override void BuildEngine() => _vehicle["engine"] = "125 cc";
    public override void BuildWheels() => _vehicle["wheels"] = "2 × 110/70-12";
    public override void BuildDoors()  => _vehicle["doors"]  = "0";
}

public class MotorCycleBuilder : VehicleBuilder
{
    public MotorCycleBuilder() => _vehicle = new Vehicle("MotorCycle");

    public override void BuildFrame()  => _vehicle["frame"]  = "Trellis Frame — Chromoly";
    public override void BuildEngine() => _vehicle["engine"] = "650 cc twin";
    public override void BuildWheels() => _vehicle["wheels"] = "2 × 120/70 ZR17";
    public override void BuildDoors()  => _vehicle["doors"]  = "0";
}

// ----- Director ----------------------------------------------

/// <summary>
/// Dyrektor (Director) — wie jak złożyć pojazd krok po kroku.
/// NIE wie, JAKIEGO rodzaju pojazd powstaje — zna tylko IBuilder.
/// Można go zastąpić bezpośrednim wywołaniem metod Buildera.
/// </summary>
public class Shop
{
    /// <summary>
    /// Procedura składania pojazdu — porządek kroków jest tutaj,
    /// a nie w ConcreteBuilderze.
    /// </summary>
    public void Construct(VehicleBuilder builder)
    {
        builder.BuildFrame();
        builder.BuildEngine();
        builder.BuildWheels();
        builder.BuildDoors();
    }
}
