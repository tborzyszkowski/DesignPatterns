namespace OpenClosed.WithoutOcp;

// =====================================================================
// NARUSZENIE OCP — każdy nowy rodzaj przesyłki wymaga modyfikacji tej klasy
// =====================================================================

public enum ShippingType
{
    Standard,
    Express,
    Overnight,
    FreeShipping,       // dodano – wymagało modyfikacji klasy poniżej
    International       // dodano – jw.
}

public record Order(string CustomerId, decimal TotalAmount, string Destination);

/// <summary>
/// ZŁY przykład: klasa naruszająca zasadę OCP.
/// Każde nowe wymaganie dotyczące kosztów wysyłki wymaga modyfikacji
/// metody CalculateShipping – zwiększa ryzyko regresji.
/// </summary>
public class OrderProcessor
{
    public decimal CalculateShipping(Order order, ShippingType type)
    {
        // Każdy nowy typ wysyłki rozbudowuje tę metodę
        if (type == ShippingType.Standard)
            return 10.00m;
        else if (type == ShippingType.Express)
            return 25.00m;
        else if (type == ShippingType.Overnight)
            return 50.00m;
        else if (type == ShippingType.FreeShipping)
            return 0.00m;
        else if (type == ShippingType.International)
            return order.TotalAmount >= 200m ? 50.00m : 80.00m;  // logika biznesowa w środku!
        else
            throw new ArgumentOutOfRangeException(nameof(type), "Nieznany typ przesyłki");
    }

    public void ProcessOrder(Order order, ShippingType type)
    {
        var shipping = CalculateShipping(order, type);
        Console.WriteLine($"Zamówienie {order.CustomerId}: wartość {order.TotalAmount:C}, " +
                          $"wysyłka {type}: {shipping:C}");
    }
}
