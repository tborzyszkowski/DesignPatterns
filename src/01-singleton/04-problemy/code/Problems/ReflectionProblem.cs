using System.Reflection;

namespace Problems;

// ─────────────────────────────────────────────────────────────────────────────
// PROBLEM: Refleksja pozwala ominąć prywatny konstruktor
// ─────────────────────────────────────────────────────────────────────────────

public sealed class VulnerableSingleton
{
    private static readonly VulnerableSingleton _instance = new VulnerableSingleton();
    private VulnerableSingleton() { }
    public static VulnerableSingleton Instance => _instance;
    public override string ToString() => $"VulnerableSingleton[{GetHashCode()}]";
}

// ─────────────────────────────────────────────────────────────────────────────
// ROZWIĄZANIE: Guard w konstruktorze — rzuca wyjątek przy próbie drugiej instancji
// ─────────────────────────────────────────────────────────────────────────────

/// <summary>
/// Singleton chroniony przed refleksją.
/// Konstruktor rzuca wyjątek, jeśli próbuje się go wywołać więcej niż raz.
/// Używa <see cref="Interlocked.Increment"/> dla thread-safety.
/// </summary>
public sealed class HardenedSingleton
{
    private static int _instanceCount = 0;
    private static readonly HardenedSingleton _instance = new HardenedSingleton();

    private HardenedSingleton()
    {
        if (Interlocked.Increment(ref _instanceCount) > 1)
        {
            Interlocked.Decrement(ref _instanceCount);
            throw new InvalidOperationException(
                "Naruszenie wzorca Singleton: próba stworzenia drugiej instancji. " +
                "Użyj HardenedSingleton.Instance.");
        }
        Console.WriteLine("[HardenedSingleton] Instancja stworzona poprawnie.");
    }

    public static HardenedSingleton Instance => _instance;

    public override string ToString() => $"HardenedSingleton[{GetHashCode()}]";
}
