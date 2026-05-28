Console.WriteLine("=== Clean Architecture — Encje i przypadki użycia ===\n");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 1: Value Objects — niezmienność i równość przez wartość
// ─────────────────────────────────────────────────────────────
Console.WriteLine("─── Część 1: Value Objects ───");
var m1 = new Money(100m, "PLN");
var m2 = new Money(50m, "PLN");
var m3 = m1.Add(m2);
Console.WriteLine($"m1 = {m1}");
Console.WriteLine($"m2 = {m2}");
Console.WriteLine($"m1 + m2 = {m3}");
Console.WriteLine($"Równość: {m1 == new Money(100m, "PLN")}"); // true — wartość, nie referencja

try
{
    var mEur = new Money(100m, "EUR");
    m1.Add(mEur); // różne waluty — błąd!
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Ochrona: {ex.Message}");
}

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 2: Encje — tożsamość i niezmienniki
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 2: Encje (Aggregate Root) — niezmienniki ───");
var orderId = OrderId.New();
var order = new Order(orderId, Guid.NewGuid());
Console.WriteLine($"Nowe zamówienie: {order.Id} | Status: {order.Status}");

var laptop = new ProductInfo(Guid.NewGuid(), "Laptop", new Money(2999.99m, "PLN"));
var mouse   = new ProductInfo(Guid.NewGuid(), "Mysz",  new Money(49.99m,   "PLN"));

order.AddLine(laptop, 2);
order.AddLine(mouse, 1);
Console.WriteLine($"Pozycje: {order.Lines.Count}");
Console.WriteLine($"Suma: {order.TotalAmount}");

// Ochrona niezmiennika: zduplikowana pozycja
try { order.AddLine(laptop, 1); }
catch (InvalidOperationException ex) { Console.WriteLine($"Niezmiennik: {ex.Message}"); }

// Zatwierdzenie zamówienia
order.Confirm();
Console.WriteLine($"Status po potwierdzeniu: {order.Status}");

// Ochrona niezmiennika: modyfikacja po potwierdzeniu
try { order.AddLine(mouse, 5); }
catch (InvalidOperationException ex) { Console.WriteLine($"Niezmiennik: {ex.Message}"); }

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 3: Use Cases — orchestracja encji
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 3: Use Cases — PlaceOrder ───");
IOrderRepository orderRepo = new InMemoryOrderRepository();
IProductCatalog  catalog   = new InMemoryProductCatalog();

// Załaduj produkty do katalogu
catalog.Add(new ProductInfo(Guid.NewGuid(), "Klawiatura", new Money(199.99m, "PLN")));
catalog.Add(new ProductInfo(Guid.NewGuid(), "Monitor",    new Money(1299.00m, "PLN")));

var placeOrderUseCase = new PlaceOrderUseCase(orderRepo, catalog);
var result = await placeOrderUseCase.ExecuteAsync(new PlaceOrderCommand(
    CustomerId: Guid.NewGuid(),
    Items: [
        new("Klawiatura", 2),
        new("Monitor", 1),
    ]
));

Console.WriteLine($"Zamówienie złożone: {result.OrderId.ToString()[..8]}...");
Console.WriteLine($"Suma: {result.TotalAmount}");
Console.WriteLine($"Status: {result.Status}");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 4: Walidacja w warstwie domeny vs warstwie aplikacji
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 4: Walidacja — gdzie powinna być? ───");
Console.WriteLine("  Domain:      niezmienniki encji (nie można dodać 0 szt.)");
Console.WriteLine("  Application: walidacja danych wejściowych (komenda musi mieć CustomerId)");
Console.WriteLine("  Infrastructure: brak walidacji biznesowej");

try
{
    await placeOrderUseCase.ExecuteAsync(new PlaceOrderCommand(
        CustomerId: Guid.Empty,  // nieprawidłowe ID — walidacja w Use Case
        Items: []
    ));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"  Walidacja Use Case: {ex.Message}");
}

// ═══════════════════════════════════════════════════════════
// TYPY
// ═══════════════════════════════════════════════════════════

// ── Value Objects ───────────────────────────────────────────

record Money(decimal Amount, string Currency)
{
    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"Nie można dodać {Currency} i {other.Currency}");
        return new Money(Amount + other.Amount, Currency);
    }

    public override string ToString() => $"{Amount:F2} {Currency}";
}

record OrderId(Guid Value)
{
    public static OrderId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}

record ProductInfo(Guid Id, string Name, Money Price);

// ── Encja Order (Aggregate Root) ─────────────────────────────

enum OrderStatus { Draft, Confirmed, Cancelled }

class Order
{
    private readonly List<OrderLine> _lines = [];

    public OrderId    Id         { get; }
    public Guid       CustomerId { get; }
    public OrderStatus Status    { get; private set; }

    public IReadOnlyList<OrderLine> Lines => _lines.AsReadOnly();

    public Money TotalAmount => _lines.Aggregate(
        new Money(0, "PLN"), (sum, l) => sum.Add(l.Subtotal));

    public Order(OrderId id, Guid customerId)
    {
        Id = id;
        CustomerId = customerId;
        Status = OrderStatus.Draft;
    }

    public void AddLine(ProductInfo product, int qty)
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Nie można modyfikować potwierdzonego zamówienia");
        if (qty <= 0)
            throw new ArgumentException("Ilość musi być większa od zera");
        if (_lines.Any(l => l.ProductId == product.Id))
            throw new InvalidOperationException($"Produkt '{product.Name}' już istnieje w zamówieniu");

        _lines.Add(new OrderLine(product.Id, product.Name, qty, product.Price));
    }

    public void Confirm()
    {
        if (!_lines.Any())
            throw new InvalidOperationException("Nie można potwierdzić pustego zamówienia");
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException($"Zamówienie w stanie {Status} nie może być potwierdzone");
        Status = OrderStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Cancelled)
            throw new InvalidOperationException("Zamówienie jest już anulowane");
        Status = OrderStatus.Cancelled;
    }
}

record OrderLine(Guid ProductId, string ProductName, int Quantity, Money UnitPrice)
{
    public Money Subtotal => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);
}

// ── Warstwa Application — porty (interfejsy) ─────────────────

interface IOrderRepository
{
    Task<Order?> FindByIdAsync(OrderId id);
    Task SaveAsync(Order order);
}

interface IProductCatalog
{
    void Add(ProductInfo product);
    ProductInfo? FindByName(string name);
}

// ── Warstwa Application — komendy i wyniki ───────────────────

record OrderItemInput(string ProductName, int Quantity);

record PlaceOrderCommand(Guid CustomerId, IReadOnlyList<OrderItemInput> Items);

record PlaceOrderResult(OrderId OrderId, Money TotalAmount, string Status);

// ── Warstwa Application — Use Case ───────────────────────────

class PlaceOrderUseCase(IOrderRepository orders, IProductCatalog catalog)
{
    public async Task<PlaceOrderResult> ExecuteAsync(PlaceOrderCommand cmd)
    {
        // Walidacja danych wejściowych (Application layer)
        if (cmd.CustomerId == Guid.Empty)
            throw new ArgumentException("CustomerId jest wymagane");
        if (!cmd.Items.Any())
            throw new ArgumentException("Zamówienie musi zawierać co najmniej jedną pozycję");

        var order = new Order(OrderId.New(), cmd.CustomerId);

        foreach (var item in cmd.Items)
        {
            var product = catalog.FindByName(item.ProductName)
                ?? throw new InvalidOperationException($"Produkt '{item.ProductName}' nie istnieje");
            order.AddLine(product, item.Quantity);
        }

        order.Confirm();
        await orders.SaveAsync(order);

        return new PlaceOrderResult(order.Id, order.TotalAmount, order.Status.ToString());
    }
}

// ── Warstwa Infrastructure — adaptery ────────────────────────

class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _db = [];

    public Task<Order?> FindByIdAsync(OrderId id)
    {
        _db.TryGetValue(id.Value, out var o);
        return Task.FromResult(o);
    }

    public Task SaveAsync(Order order)
    {
        _db[order.Id.Value] = order;
        return Task.CompletedTask;
    }
}

class InMemoryProductCatalog : IProductCatalog
{
    private readonly List<ProductInfo> _products = [];

    public void Add(ProductInfo product) => _products.Add(product);

    public ProductInfo? FindByName(string name) =>
        _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}
