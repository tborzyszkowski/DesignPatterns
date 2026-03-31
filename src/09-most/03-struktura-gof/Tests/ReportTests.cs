using System.IO;
using Xunit;

public class ReportTests
{
    [Fact]
    public void StandardReport_PrintsRenderResult()
    {
        var report = new StandardReport(new FakeImplementor("FAKE"));

        var output = CaptureConsole(() => report.Operation("Sales"));

        Assert.Contains("Standard: FAKE(Sales)", output);
    }

    [Fact]
    public void PremiumReport_AppendsSummary()
    {
        var report = new PremiumReport(new FakeImplementor("FAKE"));

        var output = CaptureConsole(() => report.Operation("Sales"));

        Assert.Contains("Premium: FAKE(Sales) + summary", output);
    }

    private static string CaptureConsole(Action action)
    {
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);

        try
        {
            action();
            return writer.ToString();
        }
        finally
        {
            Console.SetOut(original);
        }
    }

    private sealed class FakeImplementor(string tag) : IReportImplementor
    {
        public string Render(string data) => $"{tag}({data})";
    }
}