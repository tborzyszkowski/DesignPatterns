namespace Alternatives;

public enum LogLevel { Debug, Info, Warning, Error }

// ─────────────────────────────────────────────────────────────────────────────
// Wzorzec Monostate — wiele instancji, jeden wspólny stan
// ─────────────────────────────────────────────────────────────────────────────

/// <summary>
/// Wzorzec Monostate: wiele instancji, ale wszystkie współdzielą ten sam stan
/// (pola statyczne). Efekt jest podobny do Singletona, ale:
/// - Implementacja jest przezroczysta dla klienta (nie wie, że jest "singleton").
/// - Łatwiejsza do rozszerzenia przez dziedziczenie.
/// - Trudniejsza do zresetowania stanu (np. w testach).
/// </summary>
public class MonostateLogger
{
    // Wspólny stan dla wszystkich instancji — pola statyczne
    private static string _logFile = "app.log";
    private static LogLevel _minimumLevel = LogLevel.Info;
    private static int _messageCount = 0;
    private static readonly object _lock = new();

    // Publiczny konstruktor — można tworzyć wiele instancji
    public MonostateLogger() { }

    public string LogFile
    {
        get => _logFile;
        set { lock (_lock) _logFile = value; }
    }

    public LogLevel MinimumLevel
    {
        get => _minimumLevel;
        set { lock (_lock) _minimumLevel = value; }
    }

    public static int MessageCount => _messageCount;

    public void Log(LogLevel level, string message)
    {
        if (level < _minimumLevel) return;

        lock (_lock)
        {
            _messageCount++;
            Console.WriteLine($"[MonostateLogger][{level}]({_messageCount}) {message}");
        }
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// Ambient Context — testowalny, wymienny kontekst globalny
// ─────────────────────────────────────────────────────────────────────────────

/// <summary>
/// Ambient Context dla dostawcy czasu — pozwala na podmiany w testach
/// bez konieczności wstrzykiwania przez konstruktor.
/// AsyncLocal zapewnia izolację per wątek / per zadanie.
/// 
/// UWAGA: Nazwany AppTimeProvider, aby uniknąć konfliktu z System.TimeProvider (.NET 8).
/// </summary>
public abstract class AppTimeProvider
{
    private static readonly AsyncLocal<AppTimeProvider?> _current = new();

    public static AppTimeProvider Current
    {
        get => _current.Value ?? Default;
        set => _current.Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static readonly AppTimeProvider Default = new SystemAppTimeProvider();

    public abstract DateTime Now { get; }
    public abstract DateTime UtcNow { get; }

    public override string ToString() => $"{GetType().Name}(Now={Now:HH:mm:ss})";
}

public sealed class SystemAppTimeProvider : AppTimeProvider
{
    public override DateTime Now    => DateTime.Now;
    public override DateTime UtcNow => DateTime.UtcNow;
}

public sealed class FixedAppTimeProvider : AppTimeProvider
{
    private readonly DateTime _fixedTime;
    public FixedAppTimeProvider(DateTime fixedTime) => _fixedTime = fixedTime;
    public override DateTime Now    => _fixedTime;
    public override DateTime UtcNow => _fixedTime.ToUniversalTime();
}
