using Xunit;

public class AlertTests
{
    [Fact]
    public void MarketingAlert_UsesMarketingPrefix()
    {
        var provider = new FakeProvider();
        Alert alert = new MarketingAlert(provider);

        alert.Notify("promo");

        Assert.Equal("[MARKETING] promo", provider.LastPayload);
    }

    [Fact]
    public void IncidentAlert_UsesIncidentPrefix()
    {
        var provider = new FakeProvider();
        Alert alert = new IncidentAlert(provider);

        alert.Notify("db down");

        Assert.Equal("[INCIDENT] db down", provider.LastPayload);
    }

    [Fact]
    public void SecurityIncidentAlert_UsesSecurityPrefix()
    {
        var provider = new FakeProvider();
        Alert alert = new SecurityIncidentAlert(provider);

        alert.Notify("login");

        Assert.Equal("[SECURITY][HIGH] login", provider.LastPayload);
    }

    private sealed class FakeProvider : INotificationProvider
    {
        public string? LastPayload { get; private set; }

        public void SendMessage(string payload) => LastPayload = payload;
    }
}