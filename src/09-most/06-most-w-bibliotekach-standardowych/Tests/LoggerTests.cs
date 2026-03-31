using System.IO;
using Xunit;

public class LoggerTests
{
    [Fact]
    public void AuditLogger_PrefixesAndForwardsMessage()
    {
        var sink = new FakeSink();
        AppLogger logger = new AuditLogger(sink);

        logger.Log("Start");

        Assert.NotNull(sink.LastLine);
        Assert.StartsWith("AUDIT ", sink.LastLine);
        Assert.Contains("Start", sink.LastLine);
    }

    [Fact]
    public void MemorySink_IncrementsCounter()
    {
        var sink = new MemorySink();

        var output = CaptureConsole(() =>
        {
            sink.Write("line-1");
            sink.Write("line-2");
        });

        Assert.Contains("MemorySink count=1", output);
        Assert.Contains("MemorySink count=2", output);
    }

    [Fact]
    public void ConsoleSink_WritesExpectedPrefix()
    {
        var sink = new ConsoleSink();
        var output = CaptureConsole(() => sink.Write("hello"));

        Assert.Contains("ConsoleSink => hello", output);
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

    private sealed class FakeSink : ILogSink
    {
        public string? LastLine { get; private set; }

        public void Write(string line) => LastLine = line;
    }
}