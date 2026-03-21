using System;
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
        const int Iterations = 5_000_000;

        static void Main(string[] args)
        {
            Console.WriteLine("Porównanie kosztów alokacji: GC vs Słabo uzasadniony Object Pool...\n");

            // Rozgrzewka dla JIT
            RunGCBased(); 
            RunPoolBased();

            var sw = new Stopwatch();

            // 1. Zwykła, naiwna alokacja - 5 milionów krótkotrwałych elementów
            sw.Start();
            RunGCBased();
            sw.Stop();
            long newTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"> Standardowa alokacja (new obj) zajęła: \t{newTime} ms");

            // 2. Te same elementy używające "wspaniałej" puli
            sw.Restart();
            RunPoolBased();
            sw.Stop();
            long poolTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"> Własny Object Pool zajął: \t\t{poolTime} ms");

            Console.WriteLine("\nWnioski: Narzut synchronizacji na ConcurrentBag i logika współbieżna");
            Console.WriteLine("są dużo droższe niż po prostu poproszenie nowoczesnego GC o mały obszar w pamięci 0-tej generacji.");
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
    }
}
