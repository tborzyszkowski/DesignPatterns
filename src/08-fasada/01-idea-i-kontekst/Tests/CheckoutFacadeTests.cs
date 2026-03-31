using Xunit;

public class CheckoutFacadeTests
{
    [Fact]
    public void PlaceOrder_ValidRequest_ReturnsSuccess()
    {
        var facade = new CheckoutFacade(
            new InventoryService(),
            new PaymentService(),
            new NotificationService());

        var result = facade.PlaceOrder("C-100", "SKU-1", 2, 199.99m);

        Assert.True(result.Success);
        Assert.Equal(399.98m, result.Total);
    }

    [Fact]
    public void PlaceOrder_NoStock_ReturnsFail()
    {
        var facade = new CheckoutFacade(
            new InventoryService(),
            new PaymentService(),
            new NotificationService());

        var result = facade.PlaceOrder("C-100", "SKU-1", 10, 10m);

        Assert.False(result.Success);
        Assert.Contains("magazyn", result.Message);
    }

    [Fact]
    public void PlaceOrder_PaymentRejected_ReturnsFail()
    {
        var facade = new CheckoutFacade(
            new InventoryService(),
            new PaymentService(),
            new NotificationService());

        // 2 * 600m = 1200m > 1000m limit triggers rejection
        var result = facade.PlaceOrder("C-100", "SKU-1", 2, 600m);

        Assert.False(result.Success);
        Assert.Contains("atno", result.Message);
    }

    [Fact]
    public void CheckoutResult_Ok_HasCorrectShape()
    {
        var result = CheckoutResult.Ok(250m);

        Assert.True(result.Success);
        Assert.Equal(250m, result.Total);
        Assert.Equal("OK", result.Message);
    }

    [Fact]
    public void CheckoutResult_Fail_HasZeroTotal()
    {
        var result = CheckoutResult.Fail("error");

        Assert.False(result.Success);
        Assert.Equal(0m, result.Total);
    }
}
