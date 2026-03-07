namespace AbstractFactory.Computers;

// =====================================================================
// FABRYKA ABSTRAKCYJNA — rodziny komputerów (Dell / HP)
// =====================================================================

// ----- Produkty abstrakcyjne -----------------------------------------

public interface IGamingPC
{
    string Brand  { get; }
    string GPU    { get; }
    void   Render();
}

public interface IWorkStation
{
    string Brand  { get; }
    string CPU    { get; }
    void   Compute();
}

public interface ILaptop
{
    string Brand  { get; }
    string Screen { get; }
    void   PowerOn();
}

// ----- Rodzina Dell --------------------------------------------------

public class DellGamingPC : IGamingPC
{
    public string Brand  => "Dell";
    public string GPU    => "RTX 5090";
    public void Render() => Console.WriteLine($"  Dell Gaming PC [{GPU}]: ultra 4K rendering...");
}

public class DellWorkStation : IWorkStation
{
    public string Brand    => "Dell";
    public string CPU      => "Xeon W-2400";
    public void Compute()  => Console.WriteLine($"  Dell WorkStation [{CPU}]: scientific computing...");
}

public class DellLaptop : ILaptop
{
    public string Brand   => "Dell";
    public string Screen  => "15.6\" OLED 4K";
    public void PowerOn() => Console.WriteLine($"  Dell Laptop [{Screen}]: booting...");
}

// ----- Rodzina HP ----------------------------------------------------

public class HpGamingPC : IGamingPC
{
    public string Brand  => "HP";
    public string GPU    => "RX 9900 XTX";
    public void Render() => Console.WriteLine($"  HP Gaming PC [{GPU}]: high-quality rendering...");
}

public class HpWorkStation : IWorkStation
{
    public string Brand    => "HP";
    public string CPU      => "Threadripper Pro";
    public void Compute()  => Console.WriteLine($"  HP WorkStation [{CPU}]: CAD processing...");
}

public class HpLaptop : ILaptop
{
    public string Brand   => "HP";
    public string Screen  => "14\" IPS 2K";
    public void PowerOn() => Console.WriteLine($"  HP Laptop [{Screen}]: booting...");
}

// ----- Fabryka Abstrakcyjna (AbstractFactory) ------------------------

/// <summary>
/// AbstractFactory — interfejs tworzenia CAŁEJ rodziny produktów.
/// Wymuszamy kompatybilność: Dell-factory tworzy tylko Dell-produkty.
/// </summary>
public interface IComputerFactory
{
    IGamingPC    CreateGamingPC();
    IWorkStation CreateWorkStation();
    ILaptop      CreateLaptop();
}

// ----- Fabryki konkretne (ConcreteFactories) -------------------------

public class DellComputerFactory : IComputerFactory
{
    public IGamingPC    CreateGamingPC()    => new DellGamingPC();
    public IWorkStation CreateWorkStation() => new DellWorkStation();
    public ILaptop      CreateLaptop()      => new DellLaptop();
}

public class HpComputerFactory : IComputerFactory
{
    public IGamingPC    CreateGamingPC()    => new HpGamingPC();
    public IWorkStation CreateWorkStation() => new HpWorkStation();
    public ILaptop      CreateLaptop()      => new HpLaptop();
}

// ----- Klient (Client) -----------------------------------------------

/// <summary>
/// Biuro konfiguruje stanowiska pracy i sale konferencyjne.
/// Zna tylko IComputerFactory — żadnych konkretnych klas!
/// Podmiana dostawcy = podmiana fabryki.
/// </summary>
public class Office
{
    private readonly IComputerFactory _factory;
    public Office(IComputerFactory factory) => _factory = factory;

    public void SetupDeveloperWorkplace()
    {
        Console.WriteLine($"\n-- Stanowisko dewelopera ({_factory.GetType().Name}) --");
        var ws = _factory.CreateWorkStation();
        var laptop = _factory.CreateLaptop();
        ws.Compute();
        laptop.PowerOn();
    }

    public void SetupGameRoom()
    {
        Console.WriteLine($"\n-- Sala gier ({_factory.GetType().Name}) --");
        var gaming = _factory.CreateGamingPC();
        gaming.Render();
    }

    public void SetupAllEquipment()
    {
        Console.WriteLine($"\n-- Kompletne wyposażenie ({_factory.GetType().Name}) --");
        _factory.CreateGamingPC().Render();
        _factory.CreateWorkStation().Compute();
        _factory.CreateLaptop().PowerOn();
    }
}
