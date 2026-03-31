using Xunit;

namespace Examples.Tests;

public class AsyncCapPoolTests
{
    [Fact]
    public void Acquire_ReturnsPreloadedItems()
    {
        using var pool = new AsyncCapPool<string>(
            create: () => "item",
            reset: _ => { },
            capacity: 3);

        var item = pool.Acquire();

        Assert.Equal("item", item);
    }

    [Fact]
    public void Release_ThenAcquire_ReturnsReleased()
    {
        using var pool = new AsyncCapPool<TestResource>(
            create: () => new TestResource(),
            reset: r => r.State = 0,
            capacity: 1);

        var first = pool.Acquire();
        first.State = 42;
        pool.Release(first);

        var second = pool.Acquire();

        Assert.Same(first, second);
        Assert.Equal(0, second.State);
    }

    [Fact]
    public void Acquire_RespectsCapacity()
    {
        using var pool = new AsyncCapPool<string>(
            create: () => "x",
            reset: _ => { },
            capacity: 2);

        var a = pool.Acquire();
        var b = pool.Acquire();

        Assert.NotNull(a);
        Assert.NotNull(b);
    }
}

internal class TestResource
{
    public int State { get; set; }
}
