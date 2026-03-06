namespace Concurrency;

/// <summary>
/// Singleton z inicjalizacją statyczną.
/// CLR gwarantuje thread-safe inicjalizację klas statycznych.
///
/// Jawny konstruktor statyczny (static StaticInitSingleton() {}) wyłącza
/// oznaczenie beforefieldinit, co gwarantuje inicjalizację pola dopiero
/// gdy dostęp do klasy jest naprawdę wymagany (Instance lub inna statyczna składowa).
/// </summary>
public sealed class StaticInitSingleton
{
    private static readonly StaticInitSingleton _instance = new StaticInitSingleton();

    // Jawny statyczny konstruktor — kluczowy! Wyłącza beforefieldinit.
    // Bez niego CLR może zainicjalizować pole przed faktycznym pierwszym użyciem.
    static StaticInitSingleton()
    {
        Console.WriteLine($"  [StaticInitSingleton] Inicjalizacja statyczna w wątku {Thread.CurrentThread.ManagedThreadId}");
    }

    private StaticInitSingleton() { }

    public static StaticInitSingleton Instance => _instance;

    public override string ToString() => $"StaticInitSingleton[HashCode={GetHashCode()}]";
}
