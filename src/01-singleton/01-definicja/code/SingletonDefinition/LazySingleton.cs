namespace SingletonDefinition;

/// <summary>
/// Singleton z leniwą, bezpieczną wątkowo inicjalizacją przy użyciu Lazy&lt;T&gt;.
/// To jest zalecany sposób implementacji Singletona w nowoczesnym C#/.NET.
/// </summary>
public class LazySingleton
{
    // Lazy<T> z domyślnym trybem LazyThreadSafetyMode.ExecutionAndPublication
    // gwarantuje: leniwe tworzenie + bezpieczeństwo wątkowe.
    private static readonly Lazy<LazySingleton> _lazy =
        new Lazy<LazySingleton>(() => new LazySingleton());

    private LazySingleton()
    {
        Console.WriteLine("[LazySingleton] Konstruktor wywołany — pierwsze odwołanie do Instance.");
    }

    public static LazySingleton Instance => _lazy.Value;

    // Pomocnicza właściwość do demonstracji stanu inicjalizacji
    public static bool IsCreated => _lazy.IsValueCreated;

    public string Greet() => "Cześć od LazySingleton!";

    public string GetStatus() =>
        $"Lazy<T>.IsValueCreated = {_lazy.IsValueCreated}, ThreadSafetyMode = ExecutionAndPublication";
}
