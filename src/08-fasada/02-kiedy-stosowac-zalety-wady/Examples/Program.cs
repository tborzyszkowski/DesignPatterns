Console.WriteLine("=== Bez fasady ===");
var auth = new AuthService();
var pricing = new PricingService();
var shipping = new ShippingService();

if (auth.IsAuthorized("C-101"))
{
    var finalPrice = pricing.CalculateFinalPrice(249.00m, "SPRING");
    var eta = shipping.EstimateDays("PL-WAW", "PL-GDN");
    Console.WriteLine($"Cena: {finalPrice:F2}; ETA: {eta} dni");
}

Console.WriteLine();
Console.WriteLine("=== Z fasadą ===");
var facade = new PurchasePreviewFacade(auth, pricing, shipping);
Console.WriteLine(facade.BuildPreview("C-101", 249.00m, "SPRING", "PL-WAW", "PL-GDN"));

internal sealed class PurchasePreviewFacade(AuthService auth, PricingService pricing, ShippingService shipping)
{
    public string BuildPreview(string customerId, decimal basePrice, string coupon, string from, string to)
    {
        if (!auth.IsAuthorized(customerId))
        {
            return "Brak autoryzacji.";
        }

        var price = pricing.CalculateFinalPrice(basePrice, coupon);
        var eta = shipping.EstimateDays(from, to);
        return $"Podsumowanie: cena={price:F2}, dostawa={eta} dni";
    }
}

internal sealed class AuthService
{
    public bool IsAuthorized(string customerId) => customerId.StartsWith("C-");
}

internal sealed class PricingService
{
    public decimal CalculateFinalPrice(decimal basePrice, string coupon)
        => coupon == "SPRING" ? basePrice * 0.9m : basePrice;
}

internal sealed class ShippingService
{
    public int EstimateDays(string from, string to) => from == to ? 1 : 2;
}
