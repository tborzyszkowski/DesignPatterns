using System.Collections.Concurrent;

// Demonstrates a production-ready FlyweightFactory in C#:
// - ConcurrentDictionary for thread safety
// - Strongly-typed key with value-equality (record struct)
// - Hit/miss metrics

Console.WriteLine("=== Implementacja C# - FlyweightFactory ===");
Console.WriteLine();

var factory = new TokenFactory();

// Simulate parsing tokens from source code.
string[] tokens = ["int", "string", "int", "bool", "string", "int", "int", "bool"];

int lineNumber = 1;
foreach (string token in tokens)
{
    IToken fw = factory.Get(token, "keyword");
    fw.Render(lineNumber++, column: 1);
}

Console.WriteLine();
Console.WriteLine($"Tokenów przetworzonych : {tokens.Length}");
Console.WriteLine($"Unikalnych flyweightów : {factory.UniqueCount}");
Console.WriteLine($"Cache trafień          : {factory.Hits}");
Console.WriteLine($"Cache pudłów           : {factory.Misses}");
Console.WriteLine($"Hit ratio              : {factory.HitRatio:P0}");

// ── Flyweight interface ───────────────────────────────────────────────────────

internal interface IToken
{
    void Render(int line, int column);
}

// ── Concrete flyweight ────────────────────────────────────────────────────────

internal sealed class TokenFlyweight(string text, string category) : IToken
{
    private readonly string _text = text;
    private readonly string _category = category;

    public void Render(int line, int column)
    {
        Console.WriteLine($"  [{_category}] '{_text}' @ line={line} col={column}");
    }
}

// ── Strongly-typed key with value equality ────────────────────────────────────

internal readonly record struct TokenKey(string Text, string Category);

// ── Thread-safe factory with metrics ────────────────────────────────────────

internal sealed class TokenFactory
{
    private readonly ConcurrentDictionary<TokenKey, IToken> _cache = new();
    private int _hits;
    private int _misses;

    public int UniqueCount => _cache.Count;
    public int Hits => _hits;
    public int Misses => _misses;
    public double HitRatio => (_hits + _misses) == 0 ? 0 : (double)_hits / (_hits + _misses);

    public IToken Get(string text, string category)
    {
        var key = new TokenKey(text, category);
        bool wasAdded = false;

        IToken fw = _cache.GetOrAdd(key, k =>
        {
            wasAdded = true;
            return new TokenFlyweight(k.Text, k.Category);
        });

        if (wasAdded)
            Interlocked.Increment(ref _misses);
        else
            Interlocked.Increment(ref _hits);

        return fw;
    }
}
