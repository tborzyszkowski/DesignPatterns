using Xunit;

public class ReportFacadeTests
{
    [Fact]
    public void BuildReport_ContainsMonth()
    {
        var facade = new ReportFacade(new DataLoader(), new Aggregator(), new Formatter());

        var report = facade.BuildReport("2026-03");

        Assert.Contains("2026-03", report);
    }

    [Fact]
    public void BuildReport_ContainsCorrectSum()
    {
        var facade = new ReportFacade(new DataLoader(), new Aggregator(), new Formatter());

        var report = facade.BuildReport("2026-03");

        // DataLoader always returns [120, 80, 100, 140] => sum=440
        Assert.Contains("440", report);
    }

    [Fact]
    public void Aggregator_ComputesCorrectSumAndAverage()
    {
        var aggregator = new Aggregator();

        var summary = aggregator.Aggregate([10, 20, 30]);

        Assert.Equal(60, summary.Sum);
        Assert.Equal(20.0, summary.Average);
    }

    [Fact]
    public void Formatter_IncludesAllParts()
    {
        var formatter = new Formatter();
        var summary = new Summary(440, 110.0);

        var result = formatter.Format("2026-01", summary);

        Assert.Contains("2026-01", result);
        Assert.Contains("440", result);
        Assert.Contains("110", result);
    }
}
