using System.Diagnostics;
using System.Reflection;

IOrderService real = new RealOrderService();
IOrderService proxy = ProxyFactory.Create(real, Console.WriteLine);

Console.WriteLine(proxy.PlaceOrder("ORD-100"));

try
{
    proxy.PlaceOrder(string.Empty);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Expected: {ex.Message}");
}

internal interface IOrderService
{
    string PlaceOrder(string orderId);
}

internal sealed class RealOrderService : IOrderService
{
    public string PlaceOrder(string orderId)
    {
        if (string.IsNullOrWhiteSpace(orderId))
        {
            throw new ArgumentException("orderId is required", nameof(orderId));
        }

        return $"ORDER_ACCEPTED:{orderId}";
    }
}

internal static class ProxyFactory
{
    public static T Create<T>(T target, Action<string> logger) where T : class
    {
        if (!typeof(T).IsInterface)
        {
            throw new ArgumentException($"{typeof(T).Name} must be an interface type.", nameof(target));
        }

        var proxy = DispatchProxy.Create<T, MonitoringProxy<T>>();
        var inner = (MonitoringProxy<T>)(object)proxy;
        inner.Target = target;
        inner.Logger = logger;
        return proxy;
    }
}

internal class MonitoringProxy<T> : DispatchProxy where T : class
{
    public required T Target { get; set; }
    public required Action<string> Logger { get; set; }

    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        if (targetMethod is null)
        {
            throw new InvalidOperationException("Method metadata missing.");
        }

        var stopwatch = Stopwatch.StartNew();
        Logger($"START {targetMethod.Name}");

        try
        {
            var result = targetMethod.Invoke(Target, args);
            Logger($"OK {targetMethod.Name}");
            return result;
        }
        catch (TargetInvocationException ex) when (ex.InnerException is not null)
        {
            Logger($"ERROR {targetMethod.Name}: {ex.InnerException.Message}");
            throw ex.InnerException;
        }
        finally
        {
            stopwatch.Stop();
            Logger($"ELAPSED_US {targetMethod.Name}={(stopwatch.ElapsedTicks * 1_000_000L) / Stopwatch.Frequency}");
        }
    }
}
