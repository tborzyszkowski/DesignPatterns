namespace LoggerExample;

public enum LogLevel { Debug, Info, Warning, Error, Critical }

/// <summary>
/// Logger jako Singleton — jeden punkt zapisu logów dla całej aplikacji.
/// Implementacja thread-safe dzięki Lazy&lt;T&gt;.
/// W środowisku produkcyjnym zastąp przez ILogger z Microsoft.Extensions.Logging.
/// </summary>
public sealed class AppLogger : IDisposable
{
    private static readonly Lazy<AppLogger> _lazy = new(() => new AppLogger());

    private readonly StreamWriter _writer;
    private readonly object _writeLock = new();
    private bool _disposed;

    private AppLogger()
    {
        var logPath = Path.Combine(AppContext.BaseDirectory, "app.log");
        _writer = new StreamWriter(logPath, append: true, System.Text.Encoding.UTF8)
        {
            AutoFlush = true
        };
        Log(LogLevel.Info, "=== Logger uruchomiony ===");
    }

    public static AppLogger Instance => _lazy.Value;

    public void Log(LogLevel level, string message)
    {
        var entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level,-8}] {message}";
        lock (_writeLock)
        {
            Console.WriteLine(entry);
            if (!_disposed)
                _writer.WriteLine(entry);
        }
    }

    public void LogDebug(string msg)    => Log(LogLevel.Debug,    msg);
    public void LogInfo(string msg)     => Log(LogLevel.Info,     msg);
    public void LogWarning(string msg)  => Log(LogLevel.Warning,  msg);
    public void LogError(string msg)    => Log(LogLevel.Error,    msg);
    public void LogCritical(string msg) => Log(LogLevel.Critical, msg);

    public void Dispose()
    {
        lock (_writeLock)
        {
            if (_disposed) return;
            _disposed = true;
            _writer.Dispose();
        }
    }
}
