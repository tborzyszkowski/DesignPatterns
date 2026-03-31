using OverEngineeringSample;
using Xunit;

namespace OverEngineeringSample.Tests;

public class OverEngineeringTests
{
    [Fact]
    public void SmallLightweightAction_Compute_DoublesNumber()
    {
        var action = new SmallLightweightAction();
        action.Number = 5;

        action.Compute();

        Assert.Equal(10, action.Number);
    }

    [Fact]
    public void SmallLightweightAction_DefaultNumber_IsZero()
    {
        var action = new SmallLightweightAction();

        Assert.Equal(0, action.Number);
    }

    [Fact]
    public void PoolOfLightweightObjects_Get_ReturnsObject()
    {
        var pool = new PoolOfLightweightObjects();

        var item = pool.Get();

        Assert.NotNull(item);
    }

    [Fact]
    public void PoolOfLightweightObjects_Return_ResetsNumber()
    {
        var pool = new PoolOfLightweightObjects();

        var item = pool.Get();
        item.Number = 42;
        pool.Return(item);

        var reused = pool.Get();

        Assert.Equal(0, reused.Number);
    }

    [Fact]
    public void PoolOfLightweightObjects_GetTwice_ReturnsDifferentWithoutReturn()
    {
        var pool = new PoolOfLightweightObjects();

        var a = pool.Get();
        var b = pool.Get();

        Assert.NotSame(a, b);
    }
}
