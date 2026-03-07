namespace OpenClosed.WithOcp;

// =====================================================================
// POPRAWNA IMPLEMENTACJA OCP — rozszerzanie bez modyfikacji istniejącego kodu
// =====================================================================

public record Order(string CustomerId, decimal TotalAmount, string Destination);

/// <summary>
/// Abstrakcja punktu rozszerzenia.
/// Nowy rodzaj wysyłki = nowa implementacja tego interfejsu.
/// </summary>
public interface IShippingCalculator
{
    string ShippingType { get; }
    decimal Calculate(Order order);
}

// ----- Konkretne implementacje (można dodawać bez limitów) -----------

public class StandardShipping : IShippingCalculator
{
    public string ShippingType => "Standard";
    public decimal Calculate(Order order) => 10.00m;
}

public class ExpressShipping : IShippingCalculator
{
    public string ShippingType => "Express";
    public decimal Calculate(Order order) => 25.00m;
}

public class OvernightShipping : IShippingCalculator
{
    public string ShippingType => "Overnight";
    public decimal Calculate(Order order) => 50.00m;
}

public class FreeShipping : IShippingCalculator
{
    public string ShippingType => "Free";
    public decimal Calculate(Order order) => 0.00m;
}

// Nowy typ wysyłki — ŻADEN istniejący kod nie jest modyfikowany
public class InternationalShipping : IShippingCalculator
{
    public string ShippingType => "International";

    public decimal Calculate(Order order)
        => order.TotalAmount >= 200m ? 50.00m : 80.00m;
}

// Kolejny nowy typ — też bez modyfikacji
public class SameDayShipping : IShippingCalculator
{
    public string ShippingType => "SameDay";
    public decimal Calculate(Order order) => 99.00m + order.TotalAmount * 0.01m;
}

/// <summary>
/// Klasa ZAMKNIĘTA na modyfikacje.
/// Nie zna konkretnych typów przesyłek — działa przez abstrakcję.
/// </summary>
public class OrderProcessor
{
    private readonly IEnumerable<IShippingCalculator> _calculators;

    public OrderProcessor(IEnumerable<IShippingCalculator> calculators)
    {
        _calculators = calculators;
    }

    public decimal CalculateShipping(Order order, string shippingType)
    {
        var calculator = _calculators
            .FirstOrDefault(c => c.ShippingType == shippingType);

        if (calculator is null)
            throw new InvalidOperationException($"Nieznany rodzaj wysyłki: {shippingType}");

        return calculator.Calculate(order);
    }

    public void ProcessOrder(Order order, string shippingType)
    {
        var shipping = CalculateShipping(order, shippingType);
        Console.WriteLine($"Zamówienie {order.CustomerId}: wartość {order.TotalAmount:C}, " +
                          $"wysyłka {shippingType}: {shipping:C}");
    }
}
