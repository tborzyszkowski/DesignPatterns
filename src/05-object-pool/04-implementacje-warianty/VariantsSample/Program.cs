using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool;

namespace VariantsSample;

public sealed class StringBuilderPolicy : IPooledObjectPolicy<StringBuilder>
{
    public StringBuilder Create() => new(capacity: 256);

    public bool Return(StringBuilder obj)
    {
        obj.Clear();
        return true;
    }
}

public sealed class ManualStringBuilderPool
{
    private readonly ConcurrentBag<StringBuilder> _items = new();

    public ManualStringBuilderPool(int preload)
    {
        for (var i = 0; i < preload; i++)
        {
            _items.Add(new StringBuilder(capacity: 256));
        }
    }

    public StringBuilder Acquire()
    {
        return _items.TryTake(out var item) ? item : new StringBuilder(capacity: 256);
    }

    public void Release(StringBuilder item)
    {
        item.Clear();
        _items.Add(item);
    }
}

public static class Program
{
    private const int Parallelism = 8;
    private const int Operations = 60_000;

    public static void Main(string[] args)
    {
        Console.WriteLine("=== 04. Implementacje i warianty Object Pool ===");
        Console.WriteLine($"Parallelism={Parallelism}, Operations={Operations}");

        var manualPool = new ManualStringBuilderPool(preload: Parallelism);
        var dotnetPool = new DefaultObjectPool<StringBuilder>(new StringBuilderPolicy(), maximumRetained: Parallelism);

        Warmup(manualPool, dotnetPool);

        var noPoolMs = MeasureNoPool();
        var manualMs = MeasureManualPool(manualPool);
        var dotnetMs = MeasureDotnetPool(dotnetPool);

        Console.WriteLine();
        Console.WriteLine($"new StringBuilder   : {noPoolMs,5} ms");
        Console.WriteLine($"manual ConcurrentBag: {manualMs,5} ms");
        Console.WriteLine($"ObjectPool<T>       : {dotnetMs,5} ms");
        Console.WriteLine();
        Console.WriteLine("Interpretacja:");
        Console.WriteLine("- wariant manualny jest prosty, ale łatwiej o błędy semantyczne resetu i limitów,");
        Console.WriteLine("- biblioteczny ObjectPool<T> upraszcza kod i zwykle lepiej skaluje się pod współbieżnością,");
        Console.WriteLine("- baseline bez puli pokazuje, czy pooling jest tu w ogóle potrzebny.");
    }

    private static void Warmup(ManualStringBuilderPool manualPool, ObjectPool<StringBuilder> dotnetPool)
    {
        _ = MeasureManualPool(manualPool);
        _ = MeasureDotnetPool(dotnetPool);
        _ = MeasureNoPool();
    }

    private static long MeasureNoPool()
    {
        var sw = Stopwatch.StartNew();
        Parallel.For(0, Operations, new ParallelOptions { MaxDegreeOfParallelism = Parallelism }, i =>
        {
            var sb = new StringBuilder(capacity: 256);
            BuildMessage(sb, i);
        });
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    private static long MeasureManualPool(ManualStringBuilderPool pool)
    {
        var sw = Stopwatch.StartNew();
        Parallel.For(0, Operations, new ParallelOptions { MaxDegreeOfParallelism = Parallelism }, i =>
        {
            var sb = pool.Acquire();
            try
            {
                BuildMessage(sb, i);
            }
            finally
            {
                pool.Release(sb);
            }
        });
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    private static long MeasureDotnetPool(ObjectPool<StringBuilder> pool)
    {
        var sw = Stopwatch.StartNew();
        Parallel.For(0, Operations, new ParallelOptions { MaxDegreeOfParallelism = Parallelism }, i =>
        {
            var sb = pool.Get();
            try
            {
                BuildMessage(sb, i);
            }
            finally
            {
                pool.Return(sb);
            }
        });
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    private static void BuildMessage(StringBuilder sb, int i)
    {
        sb.Append("Task[").Append(i).Append("] ");
        sb.Append("payload=").Append(i % 17).Append(" ");
        sb.Append("status=OK");
        _ = sb.Length;
    }
}
