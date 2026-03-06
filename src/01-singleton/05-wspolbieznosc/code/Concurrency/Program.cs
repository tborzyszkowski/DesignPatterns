using Concurrency;

Console.WriteLine("=== SINGLETON — WSPÓŁBIEŻNOŚĆ ===\n");

// ──────────────────────────────────────────────────────────────────────────────
// Demo 1: Problem z nie-thread-safe singletonem
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── Demo 1: Race Condition (NonThreadSafeSingleton) ──");
Console.WriteLine("Uruchamiam 5 wątków jednocześnie...");

var instances = new NonThreadSafeSingleton[5];
var threads = Enumerable.Range(0, 5).Select(i => new Thread(() =>
{
    instances[i] = NonThreadSafeSingleton.GetInstance();
})).ToArray();

foreach (var t in threads) t.Start();
foreach (var t in threads) t.Join();

Console.WriteLine($"Liczba wywołań konstruktora: {NonThreadSafeSingleton.CreationCount}");
Console.WriteLine("Unikalne HashCode:");
var unique = instances.Select(x => x.GetHashCode()).Distinct().Count();
Console.WriteLine($"  Unikalnych instancji (hash): {unique} {(unique > 1 ? "← PROBLEM! Więcej niż 1 instancja!" : "← OK")}");

// ──────────────────────────────────────────────────────────────────────────────
// Demo 2: LazyT — poprawna implementacja
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── Demo 2: LazyT Singleton (thread-safe) ──");
Console.WriteLine($"Przed inicjalizacją: LazyTSingleton.IsCreated = {LazyTSingleton.IsCreated}");

var lazyInstances = new LazyTSingleton[5];
var lazyThreads = Enumerable.Range(0, 5).Select(i => new Thread(() =>
{
    Thread.Sleep(5); // wszystkie wątki startują razem
    lazyInstances[i] = LazyTSingleton.Instance;
})).ToArray();

Console.WriteLine("Uruchamiam 5 wątków jednocześnie...");
foreach (var t in lazyThreads) t.Start();
foreach (var t in lazyThreads) t.Join();

Console.WriteLine($"Po inicjalizacji: LazyTSingleton.IsCreated = {LazyTSingleton.IsCreated}");
var lazyUnique = lazyInstances.Select(x => x.GetHashCode()).Distinct().Count();
Console.WriteLine($"Unikalnych instancji: {lazyUnique} {(lazyUnique == 1 ? "← OK: singleton zachowany!" : "← PROBLEM!")}");

// ──────────────────────────────────────────────────────────────────────────────
// Demo 3: Benchmark
// ──────────────────────────────────────────────────────────────────────────────
Benchmark.Run();

Console.WriteLine("\n=== KONIEC DEMONSTRACJI ===");
