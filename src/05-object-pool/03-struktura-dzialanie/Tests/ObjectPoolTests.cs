using StructureSample;
using Xunit;

namespace StructureSample.Tests;

public class ObjectPoolTests
{
    [Fact]
    public void Acquire_CreatesNewResource()
    {
        var pool = new ObjectPool<ExpensiveResource>(maxSize: 2);

        var resource = pool.Acquire();

        Assert.NotNull(resource);
    }

    [Fact]
    public void Release_ThenAcquire_ReusesResource()
    {
        var pool = new ObjectPool<ExpensiveResource>(maxSize: 2);

        var first = pool.Acquire();
        first.Content = "data";
        pool.Release(first);

        var second = pool.Acquire();

        Assert.Same(first, second);
        Assert.Equal(string.Empty, second.Content);
    }

    [Fact]
    public void Release_ResetsContent()
    {
        var pool = new ObjectPool<ExpensiveResource>(maxSize: 2);

        var resource = pool.Acquire();
        resource.Content = "sensitive";
        pool.Release(resource);

        var reused = pool.Acquire();

        Assert.Equal(string.Empty, reused.Content);
    }

    [Fact]
    public void Acquire_BeyondMaxSize_Throws()
    {
        var pool = new ObjectPool<ExpensiveResource>(maxSize: 1);

        var first = pool.Acquire();

        Assert.Throws<InvalidOperationException>(() => pool.Acquire());
    }

    [Fact]
    public void ExpensiveResource_Reset_ClearsContent()
    {
        var resource = new ExpensiveResource();
        resource.Content = "test";

        resource.Reset();

        Assert.Equal(string.Empty, resource.Content);
    }
}
