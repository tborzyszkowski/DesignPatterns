Console.WriteLine("=== Clean Architecture — Porównanie architektur ===\n");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 1: N-Tier — tradycyjna architektura warstwowa
// ─────────────────────────────────────────────────────────────
Console.WriteLine("─── Część 1: N-Tier (tradycyjny) ───");
Console.WriteLine("Zalety: prostota, znana konwencja");
Console.WriteLine("Wady:   ścisłe sprzężenie z DB, trudne testowanie, logika w BLL zależy od DAL\n");

// N-Tier: Business Logic Layer bezpośrednio używa Data Access Layer
var ntierService = new NTierProductService(new NTierProductRepository());
var products = ntierService.GetActiveProducts();
Console.WriteLine($"N-Tier: znaleziono {products.Count} produktów");
Console.WriteLine($"  Problem: ProductService zna szczegóły repozytorium. Chcesz zmienić ORM? Zmień całą BLL.");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 2: Onion Architecture
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 2: Onion Architecture ───");
Console.WriteLine("Zalety: Domain w centrum, bez zależności od UI/DB");
Console.WriteLine("Wady:   mniej precyzyjne wytyczne dla Use Cases vs Domain Services\n");

// Onion: Domain services pośrodku, Infrastructure na zewnątrz
var onionRepo    = new OnionProductRepo();
var onionService = new OnionProductDomainService(onionRepo);
var onionResult  = await onionService.GetActiveProductsAsync();
Console.WriteLine($"Onion: znaleziono {onionResult.Count} produktów");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 3: Hexagonal (Ports & Adapters)
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 3: Hexagonal (Ports & Adapters) ───");
Console.WriteLine("Zalety: porty i adaptery — łatwa podmiana, testy bez infrastruktury");
Console.WriteLine("Wady:   brak jasnego podziału wewnątrz hexagonu (co to Use Case, co Domain?)\n");

// Hexagonal: Application Core komunikuje się tylko przez porty
IProductPort hexPort = new HexInMemoryProductAdapter();
var hexCore = new HexagonalProductCore(hexPort);
var hexResult = await hexCore.GetActiveProductsAsync();
Console.WriteLine($"Hexagonal: znaleziono {hexResult.Count} produktów");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 4: Clean Architecture
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 4: Clean Architecture (Uncle Bob) ───");
Console.WriteLine("Zalety: precyzyjny podział (Entities/Use Cases/Adapters/Frameworks)");
Console.WriteLine("        Zasada Zależności, niezależność od UI/DB/frameworka");
Console.WriteLine("Wady:   więcej klas/plików, overhead dla małych projektów\n");

// Clean: Entities → Use Cases → Adapters → Frameworks
ICleanProductRepository cleanRepo = new CleanInMemoryProductRepository();
var getActiveUseCase = new GetActiveProductsUseCase(cleanRepo);
var cleanResult = await getActiveUseCase.ExecuteAsync();
Console.WriteLine($"Clean: znaleziono {cleanResult.Count} produktów");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 5: Porównanie — ten sam problem, 4 implementacje
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 5: Porównanie sprzężenia ───");
ShowComparison();

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 6: Kiedy stosować Clean Architecture?
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 6: Kiedy stosować ───");
ShowDecisionCriteria();

void ShowComparison()
{
    Console.WriteLine("""
    +------------------+------------------+------------------+------------------+
    | Kryterium        | N-Tier           | Onion            | Clean            |
    +------------------+------------------+------------------+------------------+
    | Testowanie       | Trudne (DB)      | Łatwe            | Bardzo łatwe     |
    | Podmiana DB      | Zmiana BLL       | Łatwa            | Łatwa (adapter)  |
    | Złożoność kodu   | Niska            | Średnia          | Wysoka           |
    | Dla małych proj. | Idealne          | OK               | Overkill         |
    | Dla dużych proj. | Problematyczne   | Dobre            | Idealne          |
    | Krzywa uczenia   | Niska            | Średnia          | Wysoka           |
    +------------------+------------------+------------------+------------------+
    """);
}

void ShowDecisionCriteria()
{
    var scenarios = new[]
    {
        ("Prosta aplikacja CRUD (todo list, blog)", "N-Tier lub Minimal API wystarczy"),
        ("Startup MVP (szybkie dostarczenie)", "N-Tier, ale z interfejsami na repo"),
        ("Złożona domena biznesowa (banking, insurance)", "Clean Architecture — inwestycja się zwróci"),
        ("Mikroserwis (mały, dedykowany)", "Hexagonal lub uproszczony Clean"),
        ("Legacy monolith refaktoryzacja", "Strangler Fig + stopniowe wprowadzanie Clean"),
        ("Duży zespół (> 5 dev)", "Clean — czytelne granice, łatwiej dzielić pracę"),
    };

    foreach (var (scenario, recommendation) in scenarios)
        Console.WriteLine($"  Scenariusz: {scenario}\n  → {recommendation}\n");
}


// ═══════════════════════════════════════════════════════════
// TYPY
// ═══════════════════════════════════════════════════════════

// ── N-Tier ───────────────────────────────────────────────────

class NTierProductRepository   // DAL — Data Access Layer
{
    public List<string> GetAll() => ["Laptop", "Monitor", "Klawiatura"];
}

class NTierProductService      // BLL — bezpośrednio zależy od DAL
{
    private readonly NTierProductRepository _repo; // PROBLEM: zależy od konkretu!

    public NTierProductService(NTierProductRepository repo) => _repo = repo;

    public List<string> GetActiveProducts() => _repo.GetAll(); // BLL = "wrapper" DAL
}

// ── Onion Architecture ────────────────────────────────────────

interface IOnionProductRepo
{
    Task<List<string>> GetAllAsync();
}

class OnionProductRepo : IOnionProductRepo  // Infrastructure (zewnątrz)
{
    public Task<List<string>> GetAllAsync() =>
        Task.FromResult(new List<string> { "Laptop", "Monitor" });
}

class OnionProductDomainService(IOnionProductRepo repo)  // Domain Service (środek)
{
    public async Task<List<string>> GetActiveProductsAsync() => await repo.GetAllAsync();
}

// ── Hexagonal Architecture ────────────────────────────────────

interface IProductPort            // Port (wejściowy lub wyjściowy)
{
    Task<List<string>> GetProductsAsync();
}

class HexInMemoryProductAdapter : IProductPort  // Driven Adapter (Infrastructure)
{
    public Task<List<string>> GetProductsAsync() =>
        Task.FromResult(new List<string> { "Laptop" });
}

class HexagonalProductCore(IProductPort port)   // Application Core (Hexagon)
{
    public async Task<List<string>> GetActiveProductsAsync() => await port.GetProductsAsync();
}

// ── Clean Architecture ────────────────────────────────────────

record ProductEntity(Guid Id, string Name, bool IsActive);

interface ICleanProductRepository  // Port zdefiniowany w Application
{
    Task<List<ProductEntity>> GetAllActiveAsync();
}

class CleanInMemoryProductRepository : ICleanProductRepository  // Infrastructure Adapter
{
    public Task<List<ProductEntity>> GetAllActiveAsync() => Task.FromResult(new List<ProductEntity>
    {
        new(Guid.NewGuid(), "Laptop",    true),
        new(Guid.NewGuid(), "Monitor",   true),
        new(Guid.NewGuid(), "Drukarka",  false),
    }.Where(p => p.IsActive).ToList());
}

class GetActiveProductsUseCase(ICleanProductRepository repo)  // Use Case (Application)
{
    public async Task<List<ProductEntity>> ExecuteAsync() => await repo.GetAllActiveAsync();
}
