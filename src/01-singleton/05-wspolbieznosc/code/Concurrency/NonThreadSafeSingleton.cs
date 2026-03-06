namespace Concurrency;

/// <summary>
/// NIE jest thread-safe — służy do demonstracji problemu race condition.
/// Użyj tylko w celach edukacyjnych.
/// </summary>
public class NonThreadSafeSingleton
{
    private static NonThreadSafeSingleton? _instance;
    private static int _creationCount = 0;

    public int Id { get; }

    private NonThreadSafeSingleton()
    {
        Id = Interlocked.Increment(ref _creationCount);
        // Sztuczne opóźnienie zwiększa prawdopodobieństwo wyścigu w demonstracji
        Thread.Sleep(10);
    }

    public static NonThreadSafeSingleton GetInstance()
    {
        if (_instance is null)
        {
            // OKNO RACE CONDITION: wiele wątków może tu wejść jednocześnie!
            _instance = new NonThreadSafeSingleton();
        }
        return _instance;
    }

    public static int CreationCount => _creationCount;

    public override string ToString() => $"NonThreadSafe[Id={Id}, HashCode={GetHashCode()}]";
}
