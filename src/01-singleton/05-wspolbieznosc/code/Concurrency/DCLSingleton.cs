namespace Concurrency;

/// <summary>
/// Singleton z Double-Checked Locking (DCL).
/// - Pierwsze sprawdzenie: bez blokady (szybkie po inicjalizacji).
/// - Drugie sprawdzenie: z blokadą (bezpieczna inicjalizacja).
/// - volatile: zapobiega reorderingowi instrukcji przez CPU/kompilator.
///
/// WAŻNE: volatile jest konieczne w C#/.NET. Bez niego DCL może być niezgodne
/// z modelem pamięci (memory model) na architekturach z niesilną spójnością pamięci.
/// </summary>
public class DCLSingleton
{
    // volatile gwarantuje, że zapis do _instance jest w pełni widoczny dla wszystkich
    // wątków przed tym, jak jakikolwiek wątek przejdzie przez pierwsze sprawdzenie.
    private static volatile DCLSingleton? _instance;
    private static readonly object _lock = new object();

    public int Id { get; } = 1;

    private DCLSingleton() { }

    public static DCLSingleton GetInstance()
    {
        if (_instance is null)              // Pierwsze sprawdzenie — BEZ locka (szybkie)
        {
            lock (_lock)
            {
                if (_instance is null)      // Drugie sprawdzenie — Z lockiem (bezpieczne)
                {
                    _instance = new DCLSingleton();
                }
            }
        }
        return _instance;
    }

    public override string ToString() => $"DCLSingleton[Id={Id}, HashCode={GetHashCode()}]";
}
