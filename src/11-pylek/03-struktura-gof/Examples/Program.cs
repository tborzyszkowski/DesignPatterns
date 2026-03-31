// Demonstrates the canonical GoF Flyweight structure:
// - IFlyweight (Component interface)
// - ConcreteFlyweight (stores intrinsic state)
// - FlyweightFactory (cache / returns shared instances)
// - Client (holds extrinsic state and calls Operation)

Console.WriteLine("=== Struktura GoF - Flyweight ===");
Console.WriteLine();

var factory = new FlyweightFactory();

// Client simulates rendering a sequence of shapes.
// Intrinsic: shape type. Extrinsic: size passed by client.
(string shape, int size)[] renderQueue =
[
    ("circle", 10),
    ("circle", 20),
    ("square", 10),
    ("circle", 15),
    ("triangle", 10),
    ("square", 30),
];

foreach ((string shape, int size) in renderQueue)
{
    IFlyweight fw = factory.GetFlyweight(shape);
    fw.Operation(size); // size = extrinsic state
}

Console.WriteLine();
Console.WriteLine($"Żądań renderowania: {renderQueue.Length}");
Console.WriteLine($"Unikalnych flyweightów w cache: {factory.CacheSize}");

// ── Flyweight interface ───────────────────────────────────────────────────────

internal interface IFlyweight
{
    // extrinsicState is provided by the client, not stored in the flyweight.
    void Operation(int extrinsicState);
}

// ── Concrete flyweight (immutable intrinsic state) ───────────────────────────

internal sealed class ConcreteFlyweight(string shapeType) : IFlyweight
{
    private readonly string _shapeType = shapeType;

    public void Operation(int extrinsicState)
    {
        Console.WriteLine($"  Render '{_shapeType}' [intrinsic] size={extrinsicState} [extrinsic]");
    }
}

// ── Flyweight factory ─────────────────────────────────────────────────────────

internal sealed class FlyweightFactory
{
    private readonly Dictionary<string, IFlyweight> _cache = new();

    public int CacheSize => _cache.Count;

    public IFlyweight GetFlyweight(string key)
    {
        if (!_cache.TryGetValue(key, out IFlyweight? fw))
        {
            fw = new ConcreteFlyweight(key);
            _cache[key] = fw;
            Console.WriteLine($"  [factory] Tworzę nowy flyweight dla '{key}'");
        }
        return fw;
    }
}
