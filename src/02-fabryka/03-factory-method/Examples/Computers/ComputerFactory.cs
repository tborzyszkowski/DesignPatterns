namespace FactoryMethod.Computers;

// =====================================================================
// FACTORY METHOD — fabryka komputerów (przykład domenowy)
// =====================================================================

// ----- Produkty (Products) -------------------------------------------

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

// Dell
public class DellGamingPC : IGamingPC
{
    public string Brand  => "Dell";
    public string GPU    => "RTX 5090";
    public void Render() => Console.WriteLine($"  {Brand} Gaming PC (GPU: {GPU}): rendering ultra 4K...");
}

public class DellWorkStation : IWorkStation
{
    public string Brand    => "Dell";
    public string CPU      => "Xeon W-2400";
    public void Compute()  => Console.WriteLine($"  {Brand} WorkStation (CPU: {CPU}): scientific computing...");
}

// HP
public class HpGamingPC : IGamingPC
{
    public string Brand  => "HP";
    public string GPU    => "RX 9900 XTX";
    public void Render() => Console.WriteLine($"  {Brand} Gaming PC (GPU: {GPU}): rendering high-quality...");
}

public class HpWorkStation : IWorkStation
{
    public string Brand    => "HP";
    public string CPU      => "Threadripper PRO";
    public void Compute()  => Console.WriteLine($"  {Brand} WorkStation (CPU: {CPU}): CAD processing...");
}

// ----- Creator (AbstractCreator) -------------------------------------

/// <summary>
/// Twórca abstrakcyjny — definiuje dwie metody wytwórcze.
/// Podklasy decydują, jakie konkretne produkty dostarczają.
/// </summary>
public abstract class ComputerFactory
{
    // Metody wytwórcze
    public abstract IGamingPC   CreateGamingPC();
    public abstract IWorkStation CreateWorkStation();

    // Metoda kliencka — używa fabryk, nie zna konkretnych klas
    public void ShowProductLine()
    {
        Console.WriteLine($"\n--- Linia produktów: {GetType().Name} ---");
        var gaming = CreateGamingPC();
        var work   = CreateWorkStation();

        Console.WriteLine($"  Gaming PC : {gaming.Brand} / GPU: {gaming.GPU}");
        Console.WriteLine($"  WorkStation: {work.Brand} / CPU: {work.CPU}");

        gaming.Render();
        work.Compute();
    }
}

// ----- ConcreteCreators ----------------------------------------------

public class DellComputerFactory : ComputerFactory
{
    public override IGamingPC    CreateGamingPC()    => new DellGamingPC();
    public override IWorkStation CreateWorkStation() => new DellWorkStation();
}

public class HpComputerFactory : ComputerFactory
{
    public override IGamingPC    CreateGamingPC()    => new HpGamingPC();
    public override IWorkStation CreateWorkStation() => new HpWorkStation();
}

// ----- Logika kliencka -----------------------------------------------

/// <summary>
/// Klient (Client) — zna tylko abstrakcyjne typy.
/// Która fabryka jest wstrzykiwana — decyduje kod konfiguracyjny.
/// </summary>
public class ComputerStore
{
    private readonly ComputerFactory _factory;
    public ComputerStore(ComputerFactory factory) => _factory = factory;

    public void ConfigureWorkplace()
    {
        Console.WriteLine("Konfiguracja stanowiska pracy:");
        var workStation = _factory.CreateWorkStation();
        workStation.Compute();

        Console.WriteLine("Stanowisko do gier:");
        var gamingPC = _factory.CreateGamingPC();
        gamingPC.Render();
    }
}
