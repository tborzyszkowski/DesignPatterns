using Xunit;

// =============================================================================
// Testy wzorca Strategia — system zamówień e-commerce
// Projekt jest self-contained — zawiera duplikaty modelu domeny
// =============================================================================

// ─── Model domeny (duplikat z Examples dla izolacji) ─────────────────────────

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

class PercentageDiscount(decimal percent) : IDiscountStrategy
{
    public string Name => $"-{percent}%";
    public decimal Apply(decimal orderValue) => orderValue * (1 - percent / 100);
}

class LoyaltyDiscount(int orderCount) : IDiscountStrategy
{
    private readonly decimal _percent = orderCount switch
    {
        >= 20 => 20,
        >= 10 => 15,
        >= 5 => 10,
        _ => 5,
    };

    public string Name => $"Lojalność {_percent}%";
    public decimal Apply(decimal orderValue) => orderValue * (1 - _percent / 100);
}

class BulkDiscount(int minItems, decimal discountPercent) : IDiscountStrategy
{
    public string Name => $"Hurtowy -{discountPercent}%";
    public decimal Apply(decimal orderValue) => orderValue * (1 - discountPercent / 100);
}

// ─── Strategie wysyłki ────────────────────────────────────────────────────────

class StandardShipping : IShippingStrategy
{
    public string Name => "Standardowa";
    public decimal Calculate(Order order) => 15m;
}

class ExpressShipping : IShippingStrategy
{
    public string Name => "Ekspresowa";
    public decimal Calculate(Order order) => 35m;
}

class FreeShippingAbove(decimal threshold) : IShippingStrategy
{
    public string Name => $"Darmowa (>{threshold:C})";
    public decimal Calculate(Order order)
        => order.TotalValue >= threshold ? 0m : 15m;
}

// ─── Strategie płatności ──────────────────────────────────────────────────────

class CreditCardPayment(string maskedCard) : IPaymentStrategy
{
    public string Name => $"Karta {maskedCard}";
    public PaymentResult Process(decimal amount)
        => new(true, $"Autoryzowano {amount:C}");
}

class PayPalPayment(string email) : IPaymentStrategy
{
    public string Name => $"PayPal ({email})";
    public PaymentResult Process(decimal amount)
        => new(true, $"PayPal {amount:C}");
}

class BankTransferPayment(string iban) : IPaymentStrategy
{
    public string Name => $"Przelew";
    public PaymentResult Process(decimal amount)
        => new(true, $"Przelew {amount:C} na {iban}");
}

// ─── Stub strategii do testów ─────────────────────────────────────────────────

class StubDiscount(decimal result) : IDiscountStrategy
{
    public string Name => "Stub";
    public decimal Apply(decimal orderValue) => result;
}

class StubShipping(decimal cost) : IShippingStrategy
{
    public string Name => "Stub";
    public decimal Calculate(Order order) => cost;
}

class StubPayment(bool success) : IPaymentStrategy
{
    public string Name => "Stub";
    public PaymentResult Process(decimal amount) => new(success, "stub");
}

// ─── Context ──────────────────────────────────────────────────────────────────

record OrderSummary(decimal BaseValue, decimal AfterDiscount, decimal ShippingCost, decimal Total, bool PaymentSuccess);

class OrderProcessor(IDiscountStrategy discount, IShippingStrategy shipping, IPaymentStrategy payment)
{
    private IDiscountStrategy _discount = discount;
    private IShippingStrategy _shipping = shipping;
    private IPaymentStrategy _payment = payment;

    public void SetDiscount(IDiscountStrategy s) => _discount = s;
    public void SetShipping(IShippingStrategy s) => _shipping = s;
    public void SetPayment(IPaymentStrategy s) => _payment = s;

    public OrderSummary Process(Order order)
    {
        var baseValue = order.TotalValue;
        var afterDiscount = _discount.Apply(baseValue);
        var shippingCost = _shipping.Calculate(order);
        var total = afterDiscount + shippingCost;
        var paymentResult = _payment.Process(total);
        return new OrderSummary(baseValue, afterDiscount, shippingCost, total, paymentResult.Success);
    }
}

// =============================================================================
// TESTY
// =============================================================================

public class DiscountStrategyTests
{
    private static Order CreateOrder(decimal unitPrice, int qty = 1)
    {
        var customer = new Customer("Test", "test@test.com", false, 0);
        return new Order(customer, [new OrderItem("Produkt", qty, unitPrice)]);
    }

    [Fact]
    public void NoDiscount_ReturnsOriginalPrice()
    {
        var strategy = new NoDiscount();
        Assert.Equal(1000m, strategy.Apply(1000m));
    }

    [Theory]
    [InlineData(10, 1000, 900)]
    [InlineData(20, 1000, 800)]
    [InlineData(50, 200, 100)]
    public void PercentageDiscount_AppliesCorrectly(decimal percent, decimal price, decimal expected)
    {
        var strategy = new PercentageDiscount(percent);
        Assert.Equal(expected, strategy.Apply(price));
    }

    [Theory]
    [InlineData(1, 5)]      // <5 zamówień → 5%
    [InlineData(5, 10)]     // ≥5 zamówień → 10%
    [InlineData(10, 15)]    // ≥10 zamówień → 15%
    [InlineData(20, 20)]    // ≥20 zamówień → 20%
    [InlineData(25, 20)]    // ≥20 zamówień → 20%
    public void LoyaltyDiscount_ScalesByOrderCount(int orderCount, decimal expectedPercent)
    {
        var strategy = new LoyaltyDiscount(orderCount);
        var result = strategy.Apply(1000m);
        var expected = 1000m * (1 - expectedPercent / 100);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BulkDiscount_AppliesDiscountPercent()
    {
        var strategy = new BulkDiscount(minItems: 5, discountPercent: 15);
        Assert.Equal(850m, strategy.Apply(1000m));
    }
}

public class ShippingStrategyTests
{
    private static Customer DefaultCustomer => new("Test", "t@t.com", false, 0);

    [Fact]
    public void StandardShipping_AlwaysCosts15()
    {
        var strategy = new StandardShipping();
        var order = new Order(DefaultCustomer, [new OrderItem("A", 1, 50m)]);
        Assert.Equal(15m, strategy.Calculate(order));
    }

    [Fact]
    public void ExpressShipping_AlwaysCosts35()
    {
        var strategy = new ExpressShipping();
        var order = new Order(DefaultCustomer, [new OrderItem("A", 1, 50m)]);
        Assert.Equal(35m, strategy.Calculate(order));
    }

    [Theory]
    [InlineData(499, 15)]   // poniżej progu → płatna
    [InlineData(500, 0)]    // dokładnie próg → darmowa
    [InlineData(1000, 0)]   // powyżej → darmowa
    public void FreeShippingAbove_ChecksThreshold(decimal orderValue, decimal expectedShipping)
    {
        var strategy = new FreeShippingAbove(threshold: 500m);
        var order = new Order(DefaultCustomer, [new OrderItem("X", 1, orderValue)]);
        Assert.Equal(expectedShipping, strategy.Calculate(order));
    }
}

public class PaymentStrategyTests
{
    [Fact]
    public void CreditCardPayment_ReturnsSuccess()
    {
        var strategy = new CreditCardPayment("4111-****");
        var result = strategy.Process(100m);
        Assert.True(result.Success);
        Assert.Contains("100", result.Message);
    }

    [Fact]
    public void PayPalPayment_ReturnsSuccess()
    {
        var strategy = new PayPalPayment("user@test.com");
        var result = strategy.Process(250m);
        Assert.True(result.Success);
    }

    [Fact]
    public void BankTransfer_ReturnsSuccess()
    {
        var strategy = new BankTransferPayment("PL61109010140000071219812874");
        var result = strategy.Process(500m);
        Assert.True(result.Success);
    }
}

public class OrderProcessorTests
{
    private static Customer TestCustomer => new("Jan", "jan@test.com", false, 0);

    [Fact]
    public void Process_NoDiscount_StandardShipping_ReturnsCorrectTotal()
    {
        var order = new Order(TestCustomer, [new OrderItem("Laptop", 1, 1000m)]);
        var processor = new OrderProcessor(new NoDiscount(), new StandardShipping(), new CreditCardPayment("****"));

        var summary = processor.Process(order);

        Assert.Equal(1000m, summary.BaseValue);
        Assert.Equal(1000m, summary.AfterDiscount);
        Assert.Equal(15m, summary.ShippingCost);
        Assert.Equal(1015m, summary.Total);
        Assert.True(summary.PaymentSuccess);
    }

    [Fact]
    public void Process_WithDiscount_ReducesPrice()
    {
        var order = new Order(TestCustomer, [new OrderItem("Monitor", 1, 1000m)]);
        var processor = new OrderProcessor(
            new PercentageDiscount(10),
            new StubShipping(0m),
            new StubPayment(true));

        var summary = processor.Process(order);

        Assert.Equal(900m, summary.AfterDiscount);
    }

    [Fact]
    public void SetStrategy_SwitchesStrategyAtRuntime()
    {
        var order = new Order(TestCustomer, [new OrderItem("X", 1, 1000m)]);
        var processor = new OrderProcessor(new NoDiscount(), new StandardShipping(), new StubPayment(true));

        var summaryBefore = processor.Process(order);

        // Podmiana strategii w runtime
        processor.SetDiscount(new PercentageDiscount(20));
        processor.SetShipping(new ExpressShipping());

        var summaryAfter = processor.Process(order);

        Assert.Equal(1015m, summaryBefore.Total);
        Assert.Equal(800m + 35m, summaryAfter.Total);
    }

    [Fact]
    public void Process_FreeShippingAboveThreshold_ZeroShipping()
    {
        var order = new Order(TestCustomer, [new OrderItem("Komputer", 1, 600m)]);
        var processor = new OrderProcessor(
            new NoDiscount(),
            new FreeShippingAbove(500m),
            new StubPayment(true));

        var summary = processor.Process(order);

        Assert.Equal(0m, summary.ShippingCost);
        Assert.Equal(600m, summary.Total);
    }

    [Fact]
    public void Process_LoyaltyDiscount_MultipleItems_CorrectBaseValue()
    {
        var order = new Order(TestCustomer, [
            new OrderItem("A", 2, 100m),
            new OrderItem("B", 3, 200m),
        ]);
        var processor = new OrderProcessor(
            new LoyaltyDiscount(orderCount: 15), // 15%
            new StubShipping(0m),
            new StubPayment(true));

        var summary = processor.Process(order);

        Assert.Equal(800m, summary.BaseValue); // 2*100 + 3*200 = 800
        Assert.Equal(680m, summary.AfterDiscount); // 800 * 0.85 = 680
    }

    [Fact]
    public void Process_StubPaymentFails_ReturnsFailure()
    {
        var order = new Order(TestCustomer, [new OrderItem("X", 1, 100m)]);
        var processor = new OrderProcessor(new NoDiscount(), new StubShipping(0m), new StubPayment(false));

        var summary = processor.Process(order);

        Assert.False(summary.PaymentSuccess);
    }
}
