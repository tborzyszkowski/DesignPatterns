using Xunit;

namespace Examples.Tests;

public class SimpleObjectPoolTests
{
    [Fact]
    public void Acquire_WhenPoolEmpty_CreatesNewObject()
    {
        var pool = new SimpleObjectPool<TestItem>(
            factory: () => new TestItem(),
            reset: item => item.Value = 0,
            maxRetained: 2);

        var item = pool.Acquire();

        Assert.NotNull(item);
    }

    [Fact]
    public void Release_AndAcquire_ReusesObject()
    {
        var pool = new SimpleObjectPool<TestItem>(
            factory: () => new TestItem(),
            reset: item => item.Value = 0,
            maxRetained: 2);

        var first = pool.Acquire();
        first.Value = 42;
        pool.Release(first);

        var second = pool.Acquire();

        Assert.Same(first, second);
        Assert.Equal(0, second.Value);
    }

    [Fact]
    public void Release_ResetsState()
    {
        var pool = new SimpleObjectPool<TestItem>(
            factory: () => new TestItem(),
            reset: item => item.Value = 0,
            maxRetained: 2);

        var item = pool.Acquire();
        item.Value = 99;
        pool.Release(item);

        var reused = pool.Acquire();

        Assert.Equal(0, reused.Value);
    }

    [Fact]
    public void Release_BeyondMax_DoesNotGrow()
    {
        var created = 0;
        var pool = new SimpleObjectPool<TestItem>(
            factory: () => { created++; return new TestItem(); },
            reset: _ => { },
            maxRetained: 1);

        var a = pool.Acquire();
        var b = pool.Acquire();
        pool.Release(a);
        pool.Release(b);

        var c = pool.Acquire();
        var d = pool.Acquire();

        Assert.Equal(3, created);
    }
}

internal class TestItem
{
    public int Value { get; set; }
}
