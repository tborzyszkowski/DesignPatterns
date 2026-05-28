Console.WriteLine("=== Clean Architecture — Idea i warstwy ===\n");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 1: Problem z tradycyjną architekturą N-Tier
// Warstwa biznesowa „wie" o bazie danych, e-mailu, itd.
// ─────────────────────────────────────────────────────────────
Console.WriteLine("─── Część 1: Problem z N-Tier (ścisłe sprzężenie) ───");
var tradSvc = new TraditionalOrderService();
tradSvc.ShowProblems();

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 2: Clean Architecture — Warstwa Domain
// Encja z regułami biznesowymi, zero zależności zewnętrznych
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 2: Warstwa Domain (Encje) ───");
var p1 = new Product(Guid.NewGuid(), "Laptop", 2999.99m, 10);
var p2 = new Product(Guid.NewGuid(), "Mysz", 49.99m, 50);
Console.WriteLine($"Produkt: {p1.Name} | Cena: {p1.Price} PLN | Stan: {p1.Stock}");
Console.WriteLine($"IsValid: {p1.IsValid()} | CzyDostepny: {p1.IsAvailable}");

try
{
    p1.Reserve(15); // więcej niż w magazynie!
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Ochrona reguł biznesowych: {ex.Message}");
}
p1.Reserve(3);
Console.WriteLine($"Po rezerwacji 3 szt.: stan={p1.Stock}");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 3: Clean Architecture — Warstwa Application (Use Case)
// Use Case zależy tylko od interfejsów, nie od implementacji
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 3: Warstwa Application (Use Case) ───");
IProductRepository repo = new InMemoryProductRepository();
var addUseCase = new AddProductUseCase(repo);
var reserveUseCase = new ReserveProductUseCase(repo);

addUseCase.Execute("Klawiatura", 199.99m, 25);
addUseCase.Execute("Monitor", 1299.00m, 5);

var allProducts = repo.GetAll().ToList();
Console.WriteLine($"Produkty w magazynie: {allProducts.Count}");

var keyboard = allProducts.First(p => p.Name == "Klawiatura");
var result = reserveUseCase.Execute(keyboard.Id, 3);
Console.WriteLine($"Zarezerwowano: {result.ProductName} x{result.Reserved}");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 4: Zasada Zależności w praktyce
// Zmiana implementacji bez zmiany logiki biznesowej!
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 4: Zasada Zależności — podmiana implementacji ───");
IProductRepository fakeRepo = new FakeProductRepository();  // inny adapter!
var addUseCase2 = new AddProductUseCase(fakeRepo);          // ten sam Use Case!

addUseCase2.Execute("Słuchawki", 299.99m, 20);
Console.WriteLine("Use Case działa identycznie z inną implementacją repozytorium.");

Console.WriteLine("\n─── Podsumowanie warstw ───");
Console.WriteLine("  Domain:      Product (encja z regułami biznesowymi)");
Console.WriteLine("  Application: AddProductUseCase, ReserveProductUseCase (logika aplikacji)");
Console.WriteLine("               IProductRepository (port — interfejs)");
Console.WriteLine("  Infrastructure: InMemoryProductRepository, FakeProductRepository (adaptery)");
Console.WriteLine("  Zależności: Infrastructure → Application → Domain");

// ═══════════════════════════════════════════════════════════
// TYPY — WARSTWY
// ═══════════════════════════════════════════════════════════

// ── Warstwa Domain ──────────────────────────────────────────

record ReserveResult(Guid ProductId, string ProductName, int Reserved);

class Product(Guid id, string name, decimal price, int stock)
{
    public Guid    Id    { get; } = id;
    public string  Name  { get; } = name;
    public decimal Price { get; } = price;
    public int     Stock { get; private set; } = stock;

    public bool IsValid() => Price > 0 && !string.IsNullOrWhiteSpace(Name) && Stock >= 0;
    public bool IsAvailable => Stock > 0;

    public void Reserve(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Ilość rezerwacji musi być dodatnia");
        if (quantity > Stock)
            throw new InvalidOperationException(
                $"Niewystarczający stan magazynu (dostępne: {Stock}, żądane: {quantity})");
        Stock -= quantity;
    }
}

// ── Warstwa Application — port (interfejs) ──────────────────

interface IProductRepository
{
    void Save(Product product);
    Product? FindById(Guid id);
    IEnumerable<Product> GetAll();
}

// ── Warstwa Application — Use Cases ─────────────────────────

class AddProductUseCase(IProductRepository repository)
{
    public Product Execute(string name, decimal price, int stock)
    {
        var product = new Product(Guid.NewGuid(), name, price, stock);
        if (!product.IsValid())
            throw new ArgumentException("Nieprawidłowe dane produktu");
        repository.Save(product);
        return product;
    }
}

class ReserveProductUseCase(IProductRepository repository)
{
    public ReserveResult Execute(Guid productId, int quantity)
    {
        var product = repository.FindById(productId)
            ?? throw new InvalidOperationException($"Produkt {productId} nie istnieje");
        product.Reserve(quantity);
        repository.Save(product);
        return new ReserveResult(product.Id, product.Name, quantity);
    }
}

// ── Warstwa Infrastructure — adaptery ───────────────────────

class InMemoryProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _db = [];

    public void Save(Product p)     => _db[p.Id] = p;
    public Product? FindById(Guid id) => _db.TryGetValue(id, out var p) ? p : null;
    public IEnumerable<Product> GetAll() => _db.Values;
}

class FakeProductRepository : IProductRepository
{
    private readonly List<Product> _list = [];

    public void Save(Product p)
    {
        _list.RemoveAll(x => x.Id == p.Id);
        _list.Add(p);
        Console.WriteLine($"  [Fake] Zapisano: {p.Name}");
    }

    public Product? FindById(Guid id) => _list.FirstOrDefault(p => p.Id == id);
    public IEnumerable<Product> GetAll() => _list;
}

// ── (Klasyczna) Tradycyjna architektura N-Tier — problem ────

class TraditionalOrderService
{
    // PROBLEM 1: warstwa biznesowa „zna" szczegóły techniczne
    private readonly string _connectionString = "Server=prod;Database=shop;User=sa;Pwd=...";
    private readonly string _smtpServer = "smtp.firma.pl";

    public void ShowProblems()
    {
        Console.WriteLine("  PROBLEM 1: Logika biznesowa przeplata się z infrastrukturą:");
        Console.WriteLine($"    Connection string: '{_connectionString}'");
        Console.WriteLine($"    SMTP server: '{_smtpServer}'");
        Console.WriteLine("  PROBLEM 2: Niemożliwy do przetestowania bez prawdziwej bazy!");
        Console.WriteLine("  PROBLEM 3: Zmiana bazy danych = zmiana w klasie biznesowej.");
        Console.WriteLine("  PROBLEM 4: Kod podatny na SQL injection (brak parametryzacji).");
    }
}
