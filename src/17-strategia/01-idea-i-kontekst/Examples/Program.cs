// =============================================================================
// Wzorzec Strategia — 01. Idea i kontekst
// Demonstruje: problem eksplozji warunków i rozwiązanie przez wzorzec Strategia
// =============================================================================

// ─── CZĘŚĆ 1: Problem — Navigator BEZ wzorca ─────────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 1: Problem — kod BEZ wzorca Strategia ═══\n");

var badNavigator = new BadNavigator("car");
Console.WriteLine(badNavigator.BuildRoute("Warszawa", "Kraków"));
badNavigator.Transport = "bike";
Console.WriteLine(badNavigator.BuildRoute("Warszawa", "Kraków"));
badNavigator.Transport = "skateboard"; // nieznany typ → "błąd" w kodzie
Console.WriteLine(badNavigator.BuildRoute("Warszawa", "Kraków"));

Console.WriteLine("\nProblem: każdy nowy środek transportu wymaga modyfikacji BadNavigator!");

// ─── CZĘŚĆ 2: Rozwiązanie — Navigator ZE wzorcem Strategia ───────────────────

Console.WriteLine("\n═══ CZĘŚĆ 2: Rozwiązanie — wzorzec Strategia ═══\n");

// Wstrzyknięcie strategii przez konstruktor
Navigator nav = new(new CarStrategy());
Console.WriteLine($"Auto:       {nav.BuildRoute("Warszawa", "Kraków")}");

nav.SetStrategy(new BikeStrategy());
Console.WriteLine($"Rower:      {nav.BuildRoute("Warszawa", "Kraków")}");

nav.SetStrategy(new WalkingStrategy());
Console.WriteLine($"Pieszo:     {nav.BuildRoute("Warszawa", "Kraków")}");

nav.SetStrategy(new PublicTransitStrategy());
Console.WriteLine($"Komunikacja:{nav.BuildRoute("Warszawa", "Kraków")}");

// ─── CZĘŚĆ 3: Rozszerzalność — nowa strategia BEZ modyfikacji Navigatora ─────

Console.WriteLine("\n═══ CZĘŚĆ 3: Rozszerzalność — nowa strategia bez zmiany Navigatora ═══\n");

// Nowa strategia — Navigator nie musi być zmieniany!
nav.SetStrategy(new ScooterStrategy());
Console.WriteLine($"Hulajnoga:  {nav.BuildRoute("Warszawa", "Kraków")}");

// ─── CZĘŚĆ 4: Strategia przez lambdę (Func<>) ─────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 4: Strategia jako delegat (lambda) ═══\n");

// Nowoczesne C# — strategia bez klasy
var funcNavigator = new FuncNavigator(
    strategy: (from, to) => $"[DRONE] {from} → {to}: lot prosty 6h"
);
Console.WriteLine(funcNavigator.BuildRoute("Warszawa", "Kraków"));

// ─── CZĘŚĆ 5: Wzorzec Strategia w .NET BCL ────────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 5: IComparer<T> — strategia wbudowana w .NET ═══\n");

var products = new List<Product>
{
    new("Laptop", 4999m),
    new("Mysz", 89m),
    new("Monitor", 1299m),
    new("Klawiatura", 199m),
};

// Strategia 1: sortuj po cenie rosnąco
products.Sort(new PriceAscendingComparer());
Console.WriteLine("Po cenie rosnąco:  " + string.Join(", ", products.Select(p => $"{p.Name}({p.Price:C}")));

// Strategia 2: sortuj po nazwie
products.Sort(new NameComparer());
Console.WriteLine("Po nazwie alfa:    " + string.Join(", ", products.Select(p => p.Name)));

// Strategia 3: LINQ z lambdą (Func<> jako strategia)
var byPriceDesc = products.OrderByDescending(p => p.Price).ToList();
Console.WriteLine("Po cenie malejąco: " + string.Join(", ", byPriceDesc.Select(p => p.Name)));

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── Problem — BEZ wzorca ────────────────────────────────────────────────────

class BadNavigator(string transport)
{
    public string Transport { get; set; } = transport;

    // PROBLEM: każda nowa opcja = modyfikacja tej metody
    public string BuildRoute(string from, string to)
    {
        if (Transport == "car")
            return $"[CAR] {from} → {to}: trasa autostradami, ~3h";
        else if (Transport == "bike")
            return $"[BIKE] {from} → {to}: ścieżki rowerowe, ~12h";
        else if (Transport == "walking")
            return $"[WALK] {from} → {to}: pieszo, ~40h";
        else if (Transport == "transit")
            return $"[BUS] {from} → {to}: komunikacja miejska, ~5h";
        else
            return $"[???] {from} → {to}: nieznany środek transportu '{Transport}'";
    }
}

// ─── Wzorzec Strategia ────────────────────────────────────────────────────────

// Kontrakt (interfejs strategii)
interface IRouteStrategy
{
    string BuildRoute(string from, string to);
}

// Context
class Navigator(IRouteStrategy strategy)
{
    private IRouteStrategy _strategy = strategy;

    public void SetStrategy(IRouteStrategy s) => _strategy = s;

    public string BuildRoute(string from, string to)
        => _strategy.BuildRoute(from, to);
}

// Konkretne strategie
class CarStrategy : IRouteStrategy
{
    public string BuildRoute(string from, string to)
        => $"[CAR] {from} → {to}: autostrada A1, ~3h";
}

class BikeStrategy : IRouteStrategy
{
    public string BuildRoute(string from, string to)
        => $"[BIKE] {from} → {to}: ścieżki EuroVelo, ~12h";
}

class WalkingStrategy : IRouteStrategy
{
    public string BuildRoute(string from, string to)
        => $"[WALK] {from} → {to}: Szlak Orlich Gniazd, ~40h";
}

class PublicTransitStrategy : IRouteStrategy
{
    public string BuildRoute(string from, string to)
        => $"[BUS+RAIL] {from} → {to}: PKP Intercity, ~2.5h";
}

// Nowa strategia — ZERO zmian w Navigator!
class ScooterStrategy : IRouteStrategy
{
    public string BuildRoute(string from, string to)
        => $"[SCOOTER] {from} → {to}: drogi lokalne, ~8h";
}

// ─── Strategia przez delegat ──────────────────────────────────────────────────

class FuncNavigator(Func<string, string, string> strategy)
{
    public string BuildRoute(string from, string to) => strategy(from, to);
}

// ─── IComparer<T> — wzorzec Strategia w .NET ──────────────────────────────────

record Product(string Name, decimal Price);

class PriceAscendingComparer : IComparer<Product>
{
    public int Compare(Product? x, Product? y)
        => (x?.Price ?? 0).CompareTo(y?.Price ?? 0);
}

class NameComparer : IComparer<Product>
{
    public int Compare(Product? x, Product? y)
        => string.Compare(x?.Name, y?.Name, StringComparison.OrdinalIgnoreCase);
}
