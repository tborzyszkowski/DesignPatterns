using System.Globalization;

var facade = new CheckoutFacade(
    new InventoryService(),
    new PaymentService(),
    new NotificationService());

var result = facade.PlaceOrder("C-100", "SKU-1", 2, 199.99m);
Console.WriteLine(result);

internal sealed class CheckoutFacade(
    InventoryService inventory,
    PaymentService payment,
    NotificationService notification)
{
    public CheckoutResult PlaceOrder(string customerId, string sku, int quantity, decimal unitPrice)
    {
        var total = unitPrice * quantity;

        if (!inventory.HasStock(sku, quantity))
        {
            return CheckoutResult.Fail("Brak towaru na magazynie.");
        }

        if (!payment.Charge(customerId, total))
        {
            return CheckoutResult.Fail("Płatność odrzucona.");
        }

        notification.SendOrderConfirmation(customerId, total);
        return CheckoutResult.Ok(total);
    }
}

internal sealed class InventoryService
{
    public bool HasStock(string sku, int quantity) => sku == "SKU-1" && quantity <= 5;
}

internal sealed class PaymentService
{
    public bool Charge(string customerId, decimal total) => customerId.StartsWith("C-") && total <= 1000m;
}

internal sealed class NotificationService
{
    public void SendOrderConfirmation(string customerId, decimal total)
    {
        Console.WriteLine($"Wysłano potwierdzenie do {customerId}; kwota: {total.ToString("C", CultureInfo.GetCultureInfo("pl-PL"))}");
    }
}

internal readonly record struct CheckoutResult(bool Success, decimal Total, string Message)
{
    public static CheckoutResult Ok(decimal total) => new(true, total, "OK");
    public static CheckoutResult Fail(string message) => new(false, 0m, message);

    public override string ToString() => Success
        ? $"Sukces: kwota {Total.ToString("C", CultureInfo.GetCultureInfo("pl-PL"))}"
        : $"Błąd: {Message}";
}
