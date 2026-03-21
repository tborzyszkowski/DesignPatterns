using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OverEngineeringSample
{
    // Mały i niewiele ważący obiekt (np. DTO lub prosta paczka logiki)
    class SmallLightweightAction
    {
        public int Number { get; set; }
        public void Compute() { Number = Number * 2; }
    }

    class PoolOfLightweightObjects
    {
        private ConcurrentBag<SmallLightweightAction> _pool = new ConcurrentBag<SmallLightweightAction>();
        
        public SmallLightweightAction Get()
        {
            if (_pool.TryTake(out var item)) return item;
            return new SmallLightweightAction();
        }

        public void Return(SmallLightweightAction item)
        {
            item.Number = 0; // Czyszczenie
            _pool.Add(item);
        }
    }

    class Program
    {
        const int Iterations = 2_000_000;
        const int BufferSize = 256;

        static void Main(string[] args)
        {
            Console.WriteLine("=== 05. Over-engineering i alternatywy ===\n");

            // Rozgrzewka dla JIT
            RunGCBased();
            RunPoolBased();
            RunArrayPoolBased();

            var sw = new Stopwatch();
            var gcNewBefore = GC.CollectionCount(0);
            var gcPoolBefore = GC.CollectionCount(0);
            var gcArrayPoolBefore = GC.CollectionCount(0);

            // 1. Zwykła, naiwna alokacja - 5 milionów krótkotrwałych elementów
            sw.Start();
            RunGCBased();
            sw.Stop();
            long newTime = sw.ElapsedMilliseconds;
            var gcNewAfter = GC.CollectionCount(0);
            Console.WriteLine($"> Standardowa alokacja (new obj) zajęła:\t{newTime} ms | Gen0={gcNewAfter - gcNewBefore}");

            // 2. Te same elementy używające "wspaniałej" puli
            gcPoolBefore = GC.CollectionCount(0);
            sw.Restart();
            RunPoolBased();
            sw.Stop();
            long poolTime = sw.ElapsedMilliseconds;
            var gcPoolAfter = GC.CollectionCount(0);
            Console.WriteLine($"> Własny Object Pool zajął:\t\t{poolTime} ms | Gen0={gcPoolAfter - gcPoolBefore}");

            // 3. Alternatywa platformowa dla buforów - ArrayPool<T>
            gcArrayPoolBefore = GC.CollectionCount(0);
            sw.Restart();
            RunArrayPoolBased();
            sw.Stop();
            long arrayPoolTime = sw.ElapsedMilliseconds;
            var gcArrayPoolAfter = GC.CollectionCount(0);
            Console.WriteLine($"> Alternatywa ArrayPool<byte>:\t{arrayPoolTime} ms | Gen0={gcArrayPoolAfter - gcArrayPoolBefore}");

            Console.WriteLine("\nWnioski: Narzut synchronizacji na ConcurrentBag i logika współbieżna");
            Console.WriteLine("są dużo droższe niż po prostu poproszenie nowoczesnego GC o mały obszar w pamięci 0-tej generacji.");
            Console.WriteLine("Dla buforów platformowych zwykle lepiej sprawdza się ArrayPool<T> niż ręcznie pisany Object Pool.");
        }

        static void RunGCBased()
        {
            Parallel.For(0, Iterations, i =>
            {
                var action = new SmallLightweightAction();
                action.Number = i;
                action.Compute();
            });
        }

        static void RunPoolBased()
        {
            var pool = new PoolOfLightweightObjects();
            Parallel.For(0, Iterations, i =>
            {
                var action = pool.Get();
                action.Number = i;
                action.Compute();
                pool.Return(action);
            });
        }

        static void RunArrayPoolBased()
        {
            var pool = ArrayPool<byte>.Shared;
            Parallel.For(0, Iterations, i =>
            {
                var buffer = pool.Rent(BufferSize);
                try
                {
                    buffer[0] = (byte)(i % 251);
                    buffer[1] = (byte)((i * 7) % 251);
                }
                finally
                {
                    pool.Return(buffer, clearArray: false);
                }
            });
        }
    }
}
