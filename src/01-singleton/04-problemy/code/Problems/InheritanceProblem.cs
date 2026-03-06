namespace Problems;

// ─────────────────────────────────────────────────────────────────────────────
// PROBLEM: Dziedziczenie narusza gwarancję unikalności
// ─────────────────────────────────────────────────────────────────────────────

/// <summary>
/// BŁĘDNA implementacja — pokazuje problem dziedziczenia.
/// GetInstance() zawsze zwraca typ bazowy, niezależnie od podklasy.
/// </summary>
public class ProblematicLogger
{
    protected static ProblematicLogger? _instance; // wspólne pole dla wszystkich podklas!

    protected ProblematicLogger() { }

    public static ProblematicLogger GetInstance()
    {
        // PROBLEM: tworzy zawsze ProblematicLogger, nie podklasę
        _instance ??= new ProblematicLogger();
        return _instance;
    }

    public virtual void Log(string msg) => Console.WriteLine($"[ProblematicLogger] {msg}");
}

public class ProblematicFileLogger : ProblematicLogger
{
    protected ProblematicFileLogger() { }
    // Brak własnego GetInstance() → dziedziczy Z PROBLEMEM
    public override void Log(string msg) => Console.WriteLine($"[FileLogger] {msg}");
}

// ─────────────────────────────────────────────────────────────────────────────
// ROZWIĄZANIE 1: Rejestr singletonów (Registry of Singletons)
// ─────────────────────────────────────────────────────────────────────────────

public abstract class BaseLogger
{
    private static readonly Dictionary<string, BaseLogger> _registry =
        new(StringComparer.OrdinalIgnoreCase);

    protected BaseLogger() { }

    public static BaseLogger GetInstance(string type = "console")
    {
        if (!_registry.TryGetValue(type, out var instance))
        {
            instance = type.ToLower() switch
            {
                "file"    => new RegistryFileLogger(),
                "console" => new RegistryConsoleLogger(),
                _         => throw new ArgumentException($"Nieznany typ loggera: {type}")
            };
            _registry[type] = instance;
            Console.WriteLine($"[Registry] Zarejestrowano singleton dla typu: {type}");
        }
        return instance;
    }

    public abstract void Log(string msg);
}

public class RegistryFileLogger : BaseLogger
{
    internal RegistryFileLogger() { }
    public override void Log(string msg) => Console.WriteLine($"[RegistryFileLogger] {msg}");
}

public class RegistryConsoleLogger : BaseLogger
{
    internal RegistryConsoleLogger() { }
    public override void Log(string msg) => Console.WriteLine($"[RegistryConsoleLogger] {msg}");
}

// ─────────────────────────────────────────────────────────────────────────────
// ROZWIĄZANIE 2: Każda podklasa jest własnym, niezależnym singletonem
// ─────────────────────────────────────────────────────────────────────────────

public abstract class IndependentLogger
{
    protected IndependentLogger() { }
    public abstract void Log(string msg);
}

public sealed class IndependentFileLogger : IndependentLogger
{
    // Osobny singleton — niezależny od pozostałych podklas
    public static IndependentFileLogger Instance { get; } = new IndependentFileLogger();
    private IndependentFileLogger() { }
    public override void Log(string msg) => Console.WriteLine($"[IndependentFileLogger] {msg}");
}

public sealed class IndependentDatabaseLogger : IndependentLogger
{
    // Osobny singleton — niezależny od pozostałych podklas
    public static IndependentDatabaseLogger Instance { get; } = new IndependentDatabaseLogger();
    private IndependentDatabaseLogger() { }
    public override void Log(string msg) => Console.WriteLine($"[IndependentDatabaseLogger] {msg}");
}
