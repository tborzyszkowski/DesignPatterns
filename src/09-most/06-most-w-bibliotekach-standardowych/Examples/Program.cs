AppLogger logger = new AuditLogger(new ConsoleSink());
logger.Log("Start aplikacji");

logger = new AuditLogger(new MemorySink());
logger.Log("Utworzono sesje");

internal interface ILogSink
{
    void Write(string line);
}

internal abstract class AppLogger(ILogSink sink)
{
    protected ILogSink Sink { get; } = sink;
    public abstract void Log(string text);
}

internal sealed class AuditLogger(ILogSink sink) : AppLogger(sink)
{
    public override void Log(string text)
    {
        Sink.Write($"AUDIT {DateTime.UtcNow:O} {text}");
    }
}

internal sealed class ConsoleSink : ILogSink
{
    public void Write(string line) => Console.WriteLine($"ConsoleSink => {line}");
}

internal sealed class MemorySink : ILogSink
{
    private readonly List<string> _buffer = [];

    public void Write(string line)
    {
        _buffer.Add(line);
        Console.WriteLine($"MemorySink count={_buffer.Count} last={line}");
    }
}
