// =============================================================================
// Wzorzec Strategia — 06. Duży przykład: System zamówień e-commerce
// Demonstruje: 3 rodziny strategii, podmiana w runtime, alternatywy
// =============================================================================

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ─── Scenariusz 1: Zwykły klient, standardowa wysyłka, karta ─────────────────

Console.WriteLine("═══ Scenariusz 1: Zwykły klient ═══\n");

var regularCustomer = new Customer("Jan Kowalski", "jan@example.com", IsMember: false, OrderCount: 2);
var order1 = new Order(regularCustomer, [
    new OrderItem("Laptop", 1, 3999m),
    new OrderItem("Mysz", 1, 89m),
]);

var processor = new OrderProcessor(
    discount: new NoDiscount(),
    shipping: new StandardShipping(),
    payment: new CreditCardPayment("4111-****-****-1111")
);

var confirmation1 = processor.Process(order1);
PrintConfirmation(confirmation1);

// ─── Scenariusz 2: Członek z rabatem, ekspresowa wysyłka, PayPal ──────────────

Console.WriteLine("═══ Scenariusz 2: Klient VIP ═══\n");

var vipCustomer = new Customer("Anna Nowak", "anna@example.com", IsMember: true, OrderCount: 15);
var order2 = new Order(vipCustomer, [
    new OrderItem("Monitor", 2, 1299m),
    new OrderItem("Klawiatura", 1, 299m),
]);

processor.SetDiscount(new LoyaltyDiscount(vipCustomer.OrderCount));
processor.SetShipping(new ExpressShipping());
processor.SetPayment(new PayPalPayment("anna@example.com"));

var confirmation2 = processor.Process(order2);
PrintConfirmation(confirmation2);

// ─── Scenariusz 3: Duże zamówienie — darmowa wysyłka, przelew ────────────────

Console.WriteLine("═══ Scenariusz 3: Duże zamówienie (>500 PLN = darmowa wysyłka) ═══\n");

var bulkCustomer = new Customer("Firma ABC", "zakupy@abc.pl", IsMember: true, OrderCount: 50);
var order3 = new Order(bulkCustomer, [
    new OrderItem("Komputer", 5, 4999m),
    new OrderItem("Słuchawki", 5, 399m),
]);

processor.SetDiscount(new BulkDiscount(minItems: 5, discountPercent: 15));
processor.SetShipping(new FreeShippingAbove(threshold: 500m));
processor.SetPayment(new BankTransferPayment("PL61109010140000071219812874"));

var confirmation3 = processor.Process(order3);
PrintConfirmation(confirmation3);

// ─── Scenariusz 4: Podmiana strategii w runtime ───────────────────────────────

Console.WriteLine("═══ Scenariusz 4: Podmiana strategii na podstawie daty ═══\n");

var today = DateTime.Now;
var isWeekend = today.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
var isEndOfMonth = today.Day >= 25;

Console.WriteLine($"  Dziś: {today:dddd, dd MMMM} — weekend: {isWeekend}, koniec miesiąca: {isEndOfMonth}");

// Automatyczny wybór strategii na podstawie kontekstu biznesowego
IDiscountStrategy autoDiscount = (isWeekend, isEndOfMonth) switch
{
    (true, _) => new PercentageDiscount(10, "Weekend -10%"),
    (_, true) => new PercentageDiscount(20, "Koniec miesiąca -20%"),
    _ => new NoDiscount(),
};

Console.WriteLine($"  Aktywna strategia rabatu: {autoDiscount.Name}");
Console.WriteLine($"  Rabat na 1000 PLN: {autoDiscount.Apply(1000m):C}");

// ─── ALTERNATYWY ──────────────────────────────────────────────────────────────

Console.WriteLine("\n═══ ALTERNATYWA 1: Metoda Szablonowa ═══\n");

AbstractOrderProcessor[] templateProcessors = [
    new StandardOrderProcessor(),
    new PremiumOrderProcessor(),
];

var templateOrder = new Order(regularCustomer, [new OrderItem("Produkt", 1, 100m)]);
foreach (var p in templateProcessors)
{
    var result = p.Process(templateOrder);
    Console.WriteLine($"  [{p.GetType().Name}]: {result}");
}

Console.WriteLine("\n═══ ALTERNATYWA 2: Func<> zamiast klas strategii ═══\n");

var funcProcessor = new FuncOrderProcessor(
    discountFn: amount => amount * 0.9m,
    shippingFn: order => order.TotalValue > 500m ? 0m : 15m,
    paymentFn: amount => new PaymentResult(true, $"Zapłacono {amount:C} przez Func<>")
);

var funcResult = funcProcessor.Process(order1);
Console.WriteLine($"  Wynik: {funcResult.PaymentStatus}, Razem: {funcResult.Total:C}");

// ─── Helper ───────────────────────────────────────────────────────────────────

static void PrintConfirmation(OrderConfirmation c)
{
    Console.WriteLine($"  Klient:    {c.CustomerName}");
    Console.WriteLine($"  Produkty:  {c.ItemsSummary}");
    Console.WriteLine($"  Wartość:   {c.BaseValue:C}");
    Console.WriteLine($"  Rabat:     {c.DiscountName} → {c.AfterDiscount:C}");
    Console.WriteLine($"  Wysyłka:   {c.ShippingName} → +{c.ShippingCost:C}");
    Console.WriteLine($"  Razem:     {c.Total:C}");
    Console.WriteLine($"  Płatność:  {c.PaymentName} → {c.PaymentStatus}");
    Console.WriteLine();
}

// =============================================================================
// DOMENY I IMPLEMENTACJE
// =============================================================================

// ─── Model domeny ─────────────────────────────────────────────────────────────

record Customer(string Name, string Email, bool IsMember, int OrderCount);
record OrderItem(string ProductName, int Quantity, decimal UnitPrice)
{
    public decimal Subtotal => Quantity * UnitPrice;
}

class Order(Customer customer, IList<OrderItem> items)
{
    public Customer Customer { get; } = customer;
    public IReadOnlyList<OrderItem> Items { get; } = [.. items];
    public decimal TotalValue => Items.Sum(i => i.Subtotal);
}

record PaymentResult(bool Success, string Message);
record OrderConfirmation(
    string CustomerName,
    string ItemsSummary,
    decimal BaseValue,
    string DiscountName,
    decimal AfterDiscount,
    string ShippingName,
    decimal ShippingCost,
    decimal Total,
    string PaymentName,
    string PaymentStatus
);

// ─── Interfejsy strategii ─────────────────────────────────────────────────────

interface IDiscountStrategy
{
    string Name { get; }
    decimal Apply(decimal orderValue);
}

interface IShippingStrategy
{
    string Name { get; }
    decimal Calculate(Order order);
}

interface IPaymentStrategy
{
    string Name { get; }
    PaymentResult Process(decimal amount);
}

// ─── Strategie rabatów ────────────────────────────────────────────────────────

class NoDiscount : IDiscountStrategy
{
    public string Name => "Brak rabatu";
    public decimal Apply(decimal orderValue) => orderValue;
}

class PercentageDiscount(decimal percent, string? label = null) : IDiscountStrategy
{
    public string Name => label ?? $"-{percent}%";
    public decimal Apply(decimal orderValue) => orderValue * (1 - percent / 100);
}

class LoyaltyDiscount(int orderCount) : IDiscountStrategy
{
    private decimal _percent = orderCount switch
    {
        >= 20 => 20,
        >= 10 => 15,
        >= 5 => 10,
        _ => 5,
    };

    public string Name => $"Lojalność {_percent}% ({orderCount} zamówień)";
    public decimal Apply(decimal orderValue) => orderValue * (1 - _percent / 100);
}

class BulkDiscount(int minItems, decimal discountPercent) : IDiscountStrategy
{
    public string Name => $"Hurtowy -{discountPercent}% (min {minItems} szt.)";
    public decimal Apply(decimal orderValue) => orderValue * (1 - discountPercent / 100);
}

// ─── Strategie wysyłki ────────────────────────────────────────────────────────

class StandardShipping : IShippingStrategy
{
    public string Name => "Standardowa (3-5 dni)";
    public decimal Calculate(Order order) => 15m;
}

class ExpressShipping : IShippingStrategy
{
    public string Name => "Ekspresowa (24h)";
    public decimal Calculate(Order order) => 35m;
}

class FreeShippingAbove(decimal threshold) : IShippingStrategy
{
    public string Name => $"Darmowa (zamówienia >{threshold:C})";
    public decimal Calculate(Order order)
        => order.TotalValue >= threshold ? 0m : 15m;
}

// ─── Strategie płatności ──────────────────────────────────────────────────────

class CreditCardPayment(string maskedCard) : IPaymentStrategy
{
    public string Name => $"Karta {maskedCard}";
    public PaymentResult Process(decimal amount)
        => new(true, $"Autoryzowano {amount:C} kartą {maskedCard}");
}

class PayPalPayment(string email) : IPaymentStrategy
{
    public string Name => $"PayPal ({email})";
    public PaymentResult Process(decimal amount)
        => new(true, $"Przelano {amount:C} przez PayPal na {email}");
}

class BankTransferPayment(string iban) : IPaymentStrategy
{
    public string Name => $"Przelew ({iban[..10]}...)";
    public PaymentResult Process(decimal amount)
        => new(true, $"Oczekiwanie na przelew {amount:C} na {iban}");
}

// ─── Context: OrderProcessor ──────────────────────────────────────────────────

class OrderProcessor(
    IDiscountStrategy discount,
    IShippingStrategy shipping,
    IPaymentStrategy payment)
{
    private IDiscountStrategy _discount = discount;
    private IShippingStrategy _shipping = shipping;
    private IPaymentStrategy _payment = payment;

    public void SetDiscount(IDiscountStrategy s) => _discount = s;
    public void SetShipping(IShippingStrategy s) => _shipping = s;
    public void SetPayment(IPaymentStrategy s) => _payment = s;

    public OrderConfirmation Process(Order order)
    {
        var baseValue = order.TotalValue;
        var afterDiscount = _discount.Apply(baseValue);
        var shippingCost = _shipping.Calculate(order);
        var total = afterDiscount + shippingCost;
        var paymentResult = _payment.Process(total);
        var itemsSummary = string.Join(", ", order.Items.Select(i => $"{i.ProductName}x{i.Quantity}"));

        return new OrderConfirmation(
            order.Customer.Name,
            itemsSummary,
            baseValue,
            _discount.Name,
            afterDiscount,
            _shipping.Name,
            shippingCost,
            total,
            _payment.Name,
            paymentResult.Message
        );
    }
}

// ─── ALTERNATYWA 1: Metoda Szablonowa ─────────────────────────────────────────

abstract class AbstractOrderProcessor
{
    // Szkielet algorytmu — Template Method
    public string Process(Order order)
    {
        var discounted = ApplyDiscount(order.TotalValue);
        var shipping = CalculateShipping(order);
        var total = discounted + shipping;
        var paymentOk = Pay(total);
        return FormatResult(order, total, paymentOk);
    }

    protected abstract decimal ApplyDiscount(decimal value);
    protected abstract decimal CalculateShipping(Order order);
    protected abstract bool Pay(decimal amount);

    private static string FormatResult(Order order, decimal total, bool ok)
        => $"Klient: {order.Customer.Name}, Razem: {total:C}, OK: {ok}";
}

class StandardOrderProcessor : AbstractOrderProcessor
{
    protected override decimal ApplyDiscount(decimal value) => value;
    protected override decimal CalculateShipping(Order order) => 15m;
    protected override bool Pay(decimal amount) => true;
}

class PremiumOrderProcessor : AbstractOrderProcessor
{
    protected override decimal ApplyDiscount(decimal value) => value * 0.9m;
    protected override decimal CalculateShipping(Order order) => 0m; // gratis
    protected override bool Pay(decimal amount) => true;
}

// ─── ALTERNATYWA 2: Func<> ────────────────────────────────────────────────────

class FuncOrderProcessor(
    Func<decimal, decimal> discountFn,
    Func<Order, decimal> shippingFn,
    Func<decimal, PaymentResult> paymentFn)
{
    public OrderConfirmation Process(Order order)
    {
        var afterDiscount = discountFn(order.TotalValue);
        var shipping = shippingFn(order);
        var total = afterDiscount + shipping;
        var payment = paymentFn(total);
        var itemsSummary = string.Join(", ", order.Items.Select(i => i.ProductName));

        return new OrderConfirmation(
            order.Customer.Name, itemsSummary,
            order.TotalValue, "Func<>", afterDiscount,
            "Func<>", shipping, total,
            "Func<>", payment.Message
        );
    }
}
