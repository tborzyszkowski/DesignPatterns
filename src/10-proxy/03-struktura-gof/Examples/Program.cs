// Demonstrates the canonical GoF Proxy structure with all four named roles.
//
// GoF roles visible in this file:
//   ISubject        -> Subject    (shared contract for Client and RealSubject)
//   RealSubject     -> RealSubject (performs the actual operation)
//   Proxy           -> Proxy       (controls access and delegates to RealSubject)
//   top-level code  -> Client      (uses only ISubject, unaware of Proxy internals)
//
// The Proxy here is a Caching Proxy: it stores the result of the first
// Request() call and returns it from cache on subsequent calls.

Console.WriteLine("=== Proxy - struktura GoF ===");
Console.WriteLine();
Console.WriteLine("Roles: ISubject | RealSubject | Proxy | Client");
Console.WriteLine();

// Client receives an ISubject — could be RealSubject or Proxy, doesn't matter.
ISubject subject = new Proxy(new RealSubject());

Console.WriteLine("--- Call 1 (cache miss) ---");
string result1 = subject.Request("order-42");
Console.WriteLine($"Result: {result1}");
Console.WriteLine();

Console.WriteLine("--- Call 2 (cache hit, no delegation) ---");
string result2 = subject.Request("order-42");
Console.WriteLine($"Result: {result2}");
Console.WriteLine();

Console.WriteLine("--- Call 3 (different key, cache miss) ---");
string result3 = subject.Request("order-99");
Console.WriteLine($"Result: {result3}");
Console.WriteLine();

Console.WriteLine("---");
Console.WriteLine("Klient uzywal tylko ISubject.");
Console.WriteLine("Proxy wykonal pre-check, cache i post-check bez wiedzy klienta.");

// ── Subject (shared contract) ────────────────────────────────────────────────

internal interface ISubject
{
    string Request(string key);
}

// ── RealSubject (actual implementation) ──────────────────────────────────────

internal sealed class RealSubject : ISubject
{
    public string Request(string key)
    {
        Console.WriteLine($"  RealSubject: executing Request({key})");
        return $"DATA:{key}";
    }
}

// ── Proxy (caching + logging) ─────────────────────────────────────────────────

internal sealed class Proxy(ISubject inner) : ISubject
{
    private readonly ISubject _inner = inner;
    private readonly Dictionary<string, string> _cache = new();

    public string Request(string key)
    {
        // Pre-check
        Console.WriteLine($"  Proxy: Request({key}) — checking cache...");

        if (_cache.TryGetValue(key, out string? cached))
        {
            Console.WriteLine($"  Proxy: cache HIT for '{key}'");
            return cached;
        }

        Console.WriteLine($"  Proxy: cache MISS — delegating to RealSubject");

        // Delegation
        string result = _inner.Request(key);

        // Post-check / caching
        _cache[key] = result;
        Console.WriteLine($"  Proxy: result cached for '{key}'");

        return result;
    }
}
