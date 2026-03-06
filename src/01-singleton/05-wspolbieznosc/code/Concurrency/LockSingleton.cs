namespace Concurrency;

/// <summary>
/// Singleton z pełną synchronizacją przez lock.
/// Thread-safe, ale blokuje każde wywołanie GetInstance() — nawet po inicjalizacji.
/// </summary>
public class LockSingleton
{
    private static LockSingleton? _instance;
    private static readonly object _lock = new object();

    public int Id { get; } = 1;

    private LockSingleton() { }

    public static LockSingleton GetInstance()
    {
        lock (_lock)  // ZAWSZE blokuje — spadek wydajności przy intensywnych wywołaniach
        {
            _instance ??= new LockSingleton();
            return _instance;
        }
    }

    public override string ToString() => $"LockSingleton[Id={Id}, HashCode={GetHashCode()}]";
}
