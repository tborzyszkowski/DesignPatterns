using Concurrency;
using Xunit;

namespace Concurrency.Tests;

// =====================================================================
// Testy: Implementacje thread-safe Singletona
// =====================================================================

public class LockSingletonTests
{
    [Fact]
    public void GetInstance_ReturnsSameInstance()
    {
        var s1 = LockSingleton.GetInstance();
        var s2 = LockSingleton.GetInstance();
        Assert.Same(s1, s2);
    }

    [Fact]
    public void GetInstance_MultipleThreads_ReturnsSameInstance()
    {
        var instances = new LockSingleton[10];
        var threads = Enumerable.Range(0, 10)
            .Select(i => new Thread(() => instances[i] = LockSingleton.GetInstance()))
            .ToArray();

        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();

        Assert.All(instances, inst => Assert.Same(instances[0], inst));
    }
}

public class DCLSingletonTests
{
    [Fact]
    public void GetInstance_ReturnsSameInstance()
    {
        var s1 = DCLSingleton.GetInstance();
        var s2 = DCLSingleton.GetInstance();
        Assert.Same(s1, s2);
    }

    [Fact]
    public void GetInstance_MultipleThreads_ReturnsSameInstance()
    {
        var instances = new DCLSingleton[10];
        var threads = Enumerable.Range(0, 10)
            .Select(i => new Thread(() => instances[i] = DCLSingleton.GetInstance()))
            .ToArray();

        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();

        Assert.All(instances, inst => Assert.Same(instances[0], inst));
    }
}

public class LazyTSingletonTests
{
    [Fact]
    public void Instance_ReturnsSameInstance()
    {
        var s1 = LazyTSingleton.Instance;
        var s2 = LazyTSingleton.Instance;
        Assert.Same(s1, s2);
    }

    [Fact]
    public void IsCreated_True_AfterAccess()
    {
        _ = LazyTSingleton.Instance;
        Assert.True(LazyTSingleton.IsCreated);
    }

    [Fact]
    public void Instance_MultipleThreads_ReturnsSameInstance()
    {
        var instances = new LazyTSingleton[10];
        var threads = Enumerable.Range(0, 10)
            .Select(i => new Thread(() => instances[i] = LazyTSingleton.Instance))
            .ToArray();

        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();

        Assert.All(instances, inst => Assert.Same(instances[0], inst));
    }
}

public class StaticInitSingletonTests
{
    [Fact]
    public void Instance_ReturnsSameInstance()
    {
        var s1 = StaticInitSingleton.Instance;
        var s2 = StaticInitSingleton.Instance;
        Assert.Same(s1, s2);
    }

    [Fact]
    public void Instance_MultipleThreads_ReturnsSameInstance()
    {
        var instances = new StaticInitSingleton[10];
        var threads = Enumerable.Range(0, 10)
            .Select(i => new Thread(() => instances[i] = StaticInitSingleton.Instance))
            .ToArray();

        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();

        Assert.All(instances, inst => Assert.Same(instances[0], inst));
    }
}
