namespace Concurrency;

/// <summary>
/// Singleton z użyciem Lazy&lt;T&gt; — zalecany sposób w nowoczesnym C#.
/// LazyThreadSafetyMode.ExecutionAndPublication (domyślny tryb):
/// - Tylko jeden wątek wywołuje delegat konstruktora.
/// - Pozostałe wątki czekają na zakończenie inicjalizacji.
/// - Po inicjalizacji: wszystkie wątki odczytują bez blokady.
/// </summary>
public sealed class LazyTSingleton
{
    private static readonly Lazy<LazyTSingleton> _lazy =
        new Lazy<LazyTSingleton>(() => new LazyTSingleton());
    //    ↑ domyślny tryb: LazyThreadSafetyMode.ExecutionAndPublication

    public int Id { get; } = 1;

    private LazyTSingleton()
    {
        Console.WriteLine($"  [LazyTSingleton] Konstruktor wywołany przez wątek {Thread.CurrentThread.ManagedThreadId}");
    }

    public static LazyTSingleton Instance => _lazy.Value;

    public static bool IsCreated => _lazy.IsValueCreated;

    public override string ToString() => $"LazyTSingleton[HashCode={GetHashCode()}]";
}
