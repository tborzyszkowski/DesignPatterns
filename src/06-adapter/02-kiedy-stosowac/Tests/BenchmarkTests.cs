using Examples;
using Xunit;

namespace Examples.Tests;

public class BenchmarkTests
{
    [Fact]
    public void DecisionMetrics_RecordStoresValues()
    {
        var metrics = new DecisionMetrics(100, 200);

        Assert.Equal(100, metrics.NoAdapterMs);
        Assert.Equal(200, metrics.AdapterMs);
    }

    [Fact]
    public void DecisionMetrics_EqualityByValue()
    {
        var a = new DecisionMetrics(10, 20);
        var b = new DecisionMetrics(10, 20);

        Assert.Equal(a, b);
    }

    [Fact]
    public void DecisionMetrics_DifferentValues_NotEqual()
    {
        var a = new DecisionMetrics(10, 20);
        var b = new DecisionMetrics(10, 30);

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void Run_ReturnsNonNegativeMetrics()
    {
        var metrics = Benchmark.Run(operations: 10, mapCostMs: 0);

        Assert.True(metrics.NoAdapterMs >= 0);
        Assert.True(metrics.AdapterMs >= 0);
    }
}
