using Xunit;

public class DynamicProxyTests
{
    [Fact]
    public void Proxy_LogsStartOkAndElapsed()
    {
        var logs = new List<string>();
        IOrderService real = new RealOrderService();
        IOrderService proxy = ProxyFactory.Create(real, logs.Add);

        var result = proxy.PlaceOrder("ORD-1");

        Assert.Equal("ORDER_ACCEPTED:ORD-1", result);
        Assert.Contains(logs, x => x == "START PlaceOrder");
        Assert.Contains(logs, x => x == "OK PlaceOrder");
        Assert.Contains(logs, x => x.StartsWith("ELAPSED_US PlaceOrder="));
    }

    [Fact]
    public void Proxy_LogsErrorAndRethrowsInnerException()
    {
        var logs = new List<string>();
        IOrderService real = new RealOrderService();
        IOrderService proxy = ProxyFactory.Create(real, logs.Add);

        Assert.Throws<ArgumentException>(() => proxy.PlaceOrder(""));
        Assert.Contains(logs, x => x.StartsWith("ERROR PlaceOrder:"));
    }
}
