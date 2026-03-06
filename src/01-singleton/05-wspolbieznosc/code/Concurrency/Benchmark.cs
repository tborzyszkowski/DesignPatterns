using System.Diagnostics;

namespace Concurrency;

/// <summary>
/// Prosty benchmark porównujący wydajność różnych implementacji Singletona
/// w środowisku wielowątkowym.
/// </summary>
public static class Benchmark
{
    private const int ThreadCount = 8;
    private const int IterationsPerThread = 1_000_000;

    public static void Run()
    {
        Console.WriteLine($"\n── Benchmark: {ThreadCount} wątków × {IterationsPerThread:N0} iteracji ──");
        Console.WriteLine($"{"Implementacja",-28} {"Czas [ms]",10} {"Ops/s",15}");
        Console.WriteLine(new string('-', 58));

        MeasureSingleton("LockSingleton",       () => _ = LockSingleton.GetInstance());
        MeasureSingleton("DCLSingleton",         () => _ = DCLSingleton.GetInstance());
        MeasureSingleton("LazyTSingleton",       () => _ = LazyTSingleton.Instance);
        MeasureSingleton("StaticInitSingleton",  () => _ = StaticInitSingleton.Instance);
    }

    private static void MeasureSingleton(string name, Action action)
    {
        // Rozgrzewka
        for (int i = 0; i < 1000; i++) action();

        var threads = new Thread[ThreadCount];
        var sw = Stopwatch.StartNew();

        for (int t = 0; t < ThreadCount; t++)
        {
            threads[t] = new Thread(() =>
            {
                for (int i = 0; i < IterationsPerThread; i++)
                    action();
            });
        }

        foreach (var thread in threads) thread.Start();
        foreach (var thread in threads) thread.Join();
        sw.Stop();

        long totalOps = (long)ThreadCount * IterationsPerThread;
        double opsPerSec = totalOps / sw.Elapsed.TotalSeconds;
        Console.WriteLine($"{name,-28} {sw.ElapsedMilliseconds,10:N0} {opsPerSec,15:N0}");
    }
}
