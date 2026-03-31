using Examples;
using Xunit;

namespace Examples.Tests;

public class PaymentGatewayAdapterTests
{
    [Fact]
    public void Charge_ReturnsLegacyOkPrefix()
    {
        IPaymentGateway gateway = new LegacyGatewayAdapter(new LegacyPaymentSystem());

        var result = gateway.Charge(100.00m, "PLN");

        Assert.StartsWith("LEGACY_OK:", result);
    }

    [Fact]
    public void Charge_ContainsCurrencyCode()
    {
        IPaymentGateway gateway = new LegacyGatewayAdapter(new LegacyPaymentSystem());

        var result = gateway.Charge(50.00m, "EUR");

        Assert.Contains("EUR", result);
    }

    [Fact]
    public void Charge_ContainsFormattedAmount()
    {
        IPaymentGateway gateway = new LegacyGatewayAdapter(new LegacyPaymentSystem());

        var result = gateway.Charge(120.50m, "PLN");

        Assert.Contains("120", result);
        Assert.Contains("50", result);
    }

    [Fact]
    public void LegacyPaymentSystem_MakePayment_ReturnsExpectedFormat()
    {
        var legacy = new LegacyPaymentSystem();

        var result = legacy.MakePayment(99.99, "USD");

        Assert.StartsWith("LEGACY_OK:", result);
        Assert.EndsWith(":USD", result);
        Assert.Contains("99", result);
    }

    [Fact]
    public void Adapter_DelegatesToLegacy_SameResult()
    {
        var legacy = new LegacyPaymentSystem();
        IPaymentGateway gateway = new LegacyGatewayAdapter(legacy);

        var adapterResult = gateway.Charge(75.00m, "GBP");
        var directResult = legacy.MakePayment(75.00, "GBP");

        Assert.Equal(directResult, adapterResult);
    }
}
