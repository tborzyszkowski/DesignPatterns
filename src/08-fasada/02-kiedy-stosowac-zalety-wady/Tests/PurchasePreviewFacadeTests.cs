using Xunit;

public class PurchasePreviewFacadeTests
{
    [Fact]
    public void BuildPreview_AuthorizedCustomer_ReturnsPreview()
    {
        var facade = new PurchasePreviewFacade(
            new AuthService(),
            new PricingService(),
            new ShippingService());

        var result = facade.BuildPreview("C-101", 249.00m, "SPRING", "PL-WAW", "PL-GDN");

        Assert.Contains("Podsumowanie", result);
        Assert.Contains("224", result);
        Assert.Contains("2", result);
    }

    [Fact]
    public void BuildPreview_UnauthorizedCustomer_ReturnsNoAccess()
    {
        var facade = new PurchasePreviewFacade(
            new AuthService(),
            new PricingService(),
            new ShippingService());

        var result = facade.BuildPreview("X-999", 100m, "SPRING", "PL-WAW", "PL-GDN");

        Assert.Contains("autoryzacji", result);
    }

    [Fact]
    public void PricingService_WithSpringCoupon_AppliesDiscount()
    {
        var pricing = new PricingService();

        var result = pricing.CalculateFinalPrice(100m, "SPRING");

        Assert.Equal(90m, result);
    }

    [Fact]
    public void PricingService_WithoutCoupon_ReturnsBasePrice()
    {
        var pricing = new PricingService();

        var result = pricing.CalculateFinalPrice(100m, "NONE");

        Assert.Equal(100m, result);
    }

    [Fact]
    public void ShippingService_SameCity_ReturnsOneDay()
    {
        var shipping = new ShippingService();

        var days = shipping.EstimateDays("PL-WAW", "PL-WAW");

        Assert.Equal(1, days);
    }

    [Fact]
    public void ShippingService_DifferentCities_ReturnsTwoDays()
    {
        var shipping = new ShippingService();

        var days = shipping.EstimateDays("PL-WAW", "PL-GDN");

        Assert.Equal(2, days);
    }
}
