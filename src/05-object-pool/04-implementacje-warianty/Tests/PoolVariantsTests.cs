using System.Text;
using Microsoft.Extensions.ObjectPool;
using VariantsSample;
using Xunit;

namespace VariantsSample.Tests;

public class PoolVariantsTests
{
    [Fact]
    public void ManualPool_Acquire_ReturnsStringBuilder()
    {
        var pool = new ManualStringBuilderPool(preload: 2);

        var sb = pool.Acquire();

        Assert.NotNull(sb);
        Assert.IsType<StringBuilder>(sb);
    }

    [Fact]
    public void ManualPool_Release_ClearsContent()
    {
        var pool = new ManualStringBuilderPool(preload: 1);

        var sb = pool.Acquire();
        sb.Append("hello");
        pool.Release(sb);

        var reused = pool.Acquire();

        Assert.Equal(0, reused.Length);
    }

    [Fact]
    public void ManualPool_Acquire_BeyondPreload_CreatesNew()
    {
        var pool = new ManualStringBuilderPool(preload: 1);

        var first = pool.Acquire();
        var second = pool.Acquire();

        Assert.NotNull(second);
    }

    [Fact]
    public void StringBuilderPolicy_Create_ReturnsStringBuilder()
    {
        var policy = new StringBuilderPolicy();

        var sb = policy.Create();

        Assert.NotNull(sb);
        Assert.Equal(0, sb.Length);
    }

    [Fact]
    public void StringBuilderPolicy_Return_ClearsAndReturnsTrue()
    {
        var policy = new StringBuilderPolicy();
        var sb = new StringBuilder();
        sb.Append("data");

        var result = policy.Return(sb);

        Assert.True(result);
        Assert.Equal(0, sb.Length);
    }

    [Fact]
    public void DotnetObjectPool_GetAndReturn_Works()
    {
        var pool = new DefaultObjectPool<StringBuilder>(new StringBuilderPolicy(), maximumRetained: 4);

        var sb = pool.Get();
        sb.Append("test");
        pool.Return(sb);

        var reused = pool.Get();

        Assert.Equal(0, reused.Length);
    }
}
