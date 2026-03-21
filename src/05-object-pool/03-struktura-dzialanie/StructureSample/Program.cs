using System;
using System.Collections.Concurrent;
using System.Threading;

namespace StructureSample
{
    // 1. Definiujemy co jest w Puli (Zasób, np. Połączenie lub Złożony Obiekt).
    public class ExpensiveResource
    {
        public string Content { get; set; } = string.Empty;
        
        public ExpensiveResource()
        {
            // Symulacja kosztownej inicjalizacji (np. Socket, duże alokacje)
            Console.WriteLine("[*] Inicjalizacja nowego, drogiego zasobu...");
            Thread.Sleep(500); 
        }

        public void Reset()
        {
            // Bardzo ważne w Object Poolu!
            this.Content = string.Empty;
        }

        public void PerformWork(int taskId)
        {
            Console.WriteLine($"    [Zasób] {taskId}: Pracuję... Wnętrze={Content}");
            Thread.Sleep(200); // praca
        }
    }

    // 2. Object Pool sam w sobie
    public class ObjectPool<T> where T : ExpensiveResource, new()
    {
        private readonly ConcurrentBag<T> _items = new ConcurrentBag<T>();
        private readonly int _maxSize;
        private int _currentCount = 0;

        public ObjectPool(int maxSize = 5)
        {
            _maxSize = maxSize;
        }

        public T Acquire()
        {
            if (_items.TryTake(out var item) && item is not null)
            {
                Console.WriteLine("[Pool] Wypożyczono wolny zasób z puli.");
                return item;
            }

            // Ustawiamy sztywne limity (Dla prostoty: można też blokować wątek)
            if (_currentCount >= _maxSize)
            {
                throw new InvalidOperationException("[Pool] Pula wyczerpana! Zbyt duże zapotrzebowanie!");
            }

            Interlocked.Increment(ref _currentCount);
            return new T();
        }

        public void Release(T item)
        {
            // Czyszczenie stanu przed oddaniem z powrotem do użycia (żeby kolejna porcja logiki nie miała cudzych danych)
            item.Reset();
            _items.Add(item);
            Console.WriteLine("[Pool] Oddano zasób do puli. Został zresetowany.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Object Pool Pattern Demo ---");
            
            var pool = new ObjectPool<ExpensiveResource>(3); // Max limit: 3

            // Work 1 -> Tworzy pierwszy
            var res1 = pool.Acquire();
            res1.Content = "Praca A";
            res1.PerformWork(1);

            // Work 2 -> Tworzy drugi, chociaż jest tylko np. 1 użytkownik. Nie oddaliśmy go jeszcze.
            var res2 = pool.Acquire();
            res2.Content = "Praca B";
            res2.PerformWork(2);

            pool.Release(res1); // Res1 wraca!

            // Work 3 -> Zamiast tworzyć trzeci zasób z kosztem 500ms, natychmiast wraca res1
            var res3 = pool.Acquire();
            res3.Content = "Praca C (z reuse'u)";
            res3.PerformWork(3);

            pool.Release(res2);
            pool.Release(res3);

            Console.WriteLine("--------------------------------");
        }
    }
}
