namespace Consequences;

/// <summary>
/// Multiton — uogólnienie wzorca Singleton na N instancji.
/// Demonstruje Konsekwencję 4: możliwość określenia dowolnego limitu egzemplarzy.
/// </summary>
public sealed class LimitedInstancesSingleton
{
    private static readonly int MaxInstances = 3;
    private static readonly List<LimitedInstancesSingleton> _instances = new();
    private static int _totalCreated = 0;
    private static readonly object _lock = new();

    public int Id { get; }
    public int UseCount { get; private set; }

    private LimitedInstancesSingleton(int id)
    {
        Id = id;
        UseCount = 0;
    }

    /// <summary>
    /// Zwraca jedną z maksymalnie <see cref="MaxInstances"/> instancji.
    /// Jeżeli pula nie jest pełna — tworzy nową. W przeciwnym razie — algorytm round-robin.
    /// </summary>
    public static LimitedInstancesSingleton GetInstance()
    {
        lock (_lock)
        {
            if (_instances.Count < MaxInstances)
            {
                var newInstance = new LimitedInstancesSingleton(++_totalCreated);
                _instances.Add(newInstance);
                Console.WriteLine($"[Multiton] Tworzę instancję #{newInstance.Id}");
                newInstance.UseCount++;
                return newInstance;
            }

            // Round-robin: wybieramy instancję z najmniejszą liczbą użyć
            var selected = _instances.MinBy(i => i.UseCount)!;
            selected.UseCount++;
            Console.WriteLine($"[Multiton] Zwracam istniejącą instancję #{selected.Id} (użycia: {selected.UseCount})");
            return selected;
        }
    }

    public static int InstanceCount => _instances.Count;

    public override string ToString() => $"LimitedInstance[Id={Id}, UseCount={UseCount}]";
}
