var facade = new OrderFacade(
    new CustomerService(),
    new InventoryService(),
    new PaymentService(),
    new ShippingService(),
    new NotificationService());

var ok = facade.PlaceOrder(new OrderRequest("REQ-1", "C-555", "SKU-OK", 1, 99.99m));
Console.WriteLine(ok);

var fail = facade.PlaceOrder(new OrderRequest("REQ-2", "C-555", "SKU-OUT", 1, 99.99m));
Console.WriteLine(fail);

internal sealed class OrderFacade(
    CustomerService customerService,
    InventoryService inventory,
    PaymentService payment,
    ShippingService shipping,
    NotificationService notification)
{
    public OrderResult PlaceOrder(OrderRequest request)
    {
        if (!customerService.Exists(request.CustomerId))
        {
            return OrderResult.Fail("Nieznany klient.");
        }

        if (!inventory.Reserve(request.Sku, request.Quantity))
        {
            return OrderResult.Fail("Brak towaru.");
        }

        var amount = request.Quantity * request.UnitPrice;
        if (!payment.Charge(request.CustomerId, amount))
        {
            return OrderResult.Fail("Płatność odrzucona.");
        }

        var shipmentId = shipping.CreateShipment(request.CustomerId, request.Sku, request.Quantity);
        notification.Send(request.CustomerId, $"Zamówienie przyjęte. Wysyłka: {shipmentId}");

        return OrderResult.Ok(shipmentId, amount);
    }
}

internal sealed class CustomerService
{
    public bool Exists(string customerId) => customerId.StartsWith("C-");
}

internal sealed class InventoryService
{
    public bool Reserve(string sku, int quantity) => sku != "SKU-OUT" && quantity > 0;
}

internal sealed class PaymentService
{
    public bool Charge(string customerId, decimal amount) => customerId.Length > 2 && amount < 5000m;
}

internal sealed class ShippingService
{
    public string CreateShipment(string customerId, string sku, int quantity)
        => $"SHP-{customerId}-{sku}-{quantity}";
}

internal sealed class NotificationService
{
    public void Send(string customerId, string message)
        => Console.WriteLine($"[Notify:{customerId}] {message}");
}

internal readonly record struct OrderRequest(string RequestId, string CustomerId, string Sku, int Quantity, decimal UnitPrice);

internal readonly record struct OrderResult(bool Success, string Message, string ShipmentId, decimal Amount)
{
    public static OrderResult Ok(string shipmentId, decimal amount)
        => new(true, "OK", shipmentId, amount);

    public static OrderResult Fail(string message)
        => new(false, message, string.Empty, 0m);

    public override string ToString() => Success
        ? $"Sukces: shipment={ShipmentId}, amount={Amount:F2}"
        : $"Błąd: {Message}";
}
