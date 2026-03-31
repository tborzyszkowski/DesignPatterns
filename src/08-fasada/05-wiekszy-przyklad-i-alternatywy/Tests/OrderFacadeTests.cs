using Xunit;

public class OrderFacadeTests
{
    private static OrderFacade BuildFacade() => new(
        new CustomerService(),
        new InventoryService(),
        new PaymentService(),
        new ShippingService(),
        new NotificationService());

    [Fact]
    public void PlaceOrder_ValidRequest_ReturnsSuccess()
    {
        var facade = BuildFacade();

        var result = facade.PlaceOrder(new OrderRequest("REQ-1", "C-555", "SKU-OK", 1, 99.99m));

        Assert.True(result.Success);
        Assert.Contains("SHP-", result.ShipmentId);
        Assert.Equal(99.99m, result.Amount);
    }

    [Fact]
    public void PlaceOrder_UnknownCustomer_ReturnsFail()
    {
        var facade = BuildFacade();

        var result = facade.PlaceOrder(new OrderRequest("REQ-2", "X-999", "SKU-OK", 1, 10m));

        Assert.False(result.Success);
        Assert.Contains("klient", result.Message);
    }

    [Fact]
    public void PlaceOrder_OutOfStock_ReturnsFail()
    {
        var facade = BuildFacade();

        var result = facade.PlaceOrder(new OrderRequest("REQ-3", "C-555", "SKU-OUT", 1, 10m));

        Assert.False(result.Success);
        Assert.Contains("towar", result.Message);
    }

    [Fact]
    public void PlaceOrder_PaymentRejected_ReturnsFail()
    {
        var facade = BuildFacade();

        // amount >= 5000m triggers rejection
        var result = facade.PlaceOrder(new OrderRequest("REQ-4", "C-555", "SKU-OK", 1, 5000m));

        Assert.False(result.Success);
        Assert.Contains("atno", result.Message);
    }

    [Fact]
    public void OrderResult_Ok_HasCorrectShape()
    {
        var result = OrderResult.Ok("SHP-1", 199m);

        Assert.True(result.Success);
        Assert.Equal("SHP-1", result.ShipmentId);
        Assert.Equal(199m, result.Amount);
    }

    [Fact]
    public void OrderResult_Fail_HasEmptyShipmentId()
    {
        var result = OrderResult.Fail("error");

        Assert.False(result.Success);
        Assert.Equal(string.Empty, result.ShipmentId);
    }
}
