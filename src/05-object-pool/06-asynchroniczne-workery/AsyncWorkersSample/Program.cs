using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWorkersSample
{
    // Obiekt puli, który jest potężnym workerem.
    public class HeavyWorker
    {
        public int WorkerId { get; }

        public HeavyWorker(int id)
        {
            WorkerId = id;
            Console.WriteLine($"[Ciężki Aktor] --- Inicjowanie wielkiego workera nr {WorkerId}... ---");
            Task.Delay(500).Wait(); // symulacja np. połączenia do chmury (start takes time)
        }

        public async Task ProcessJobAsync(int jobId)
        {
            Console.WriteLine($"-> Worker {WorkerId} rozpoczął zadanie [{jobId}]");
            // Symulacja ciężkiej pracy, np. scraping, wywołanie API chmurowego, przetwarzanie ML
            await Task.Delay(200); 
            Console.WriteLine($"<- Worker {WorkerId} SKOŃCZYŁ zadanie [{jobId}]");
        }
    }

    public class AsyncWorkerPool
    {
        private readonly ConcurrentQueue<HeavyWorker> _workers = new ConcurrentQueue<HeavyWorker>();
        private readonly SemaphoreSlim _semaphore;

        public AsyncWorkerPool(int maxPoolSize)
        {
            _semaphore = new SemaphoreSlim(maxPoolSize, maxPoolSize);

            // Pre-alokacja początkowa (Zachłanna / Eager) 
            for (int i = 1; i <= maxPoolSize; i++)
            {
                _workers.Enqueue(new HeavyWorker(i));
            }
        }

        public async Task<HeavyWorker> AcquireWorkerAsync()
        {
            // Oczekuje asynchronicznie, aż zwolni się w puli co najmniej jedno miejsce
            await _semaphore.WaitAsync();

            if (_workers.TryDequeue(out var worker))
            {
                return worker;
            }

            // Jeśli program tu dotarł, coś jest bardzo źle z pulą (semafor puścił, a bag był pusty)
            throw new InvalidOperationException("Błąd we wskaźnikach puli.");
        }

        public void ReleaseWorker(HeavyWorker worker)
        {
            // Oczyszczenie Workera nastąpiłoby tutaj...
            // worker.ClearState();

            _workers.Enqueue(worker);
            
            // Otwieramy bramkę – wpuszczamy kolejne zadanie czekające z wiersza 46
            _semaphore.Release();
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Demonstacja Async Object Pool (Wielowątkowi Workerzy) ===\n");
            
            int maxConnections = 3;
            var workerPool = new AsyncWorkerPool(maxConnections);

            Console.WriteLine($"[System] Pula {maxConnections} workerów utworzona. Zaczynamy nalot 20 żądań klienta.");
            
            var stopwatch = Stopwatch.StartNew();

            var tasks = new Task[20];
            // Symulujemy strzał z 20 miejsc w aplikacji na raz 
            for (int i = 0; i < 20; i++)
            {
                int id = i;
                tasks[i] = HandleClientRequestAsync(workerPool, id);
            }

            // Czekamy na wykonanie wszystkich
            await Task.WhenAll(tasks);
            
            stopwatch.Stop();
            Console.WriteLine($"\n[System] Wszystkie 20 żądań obsłużone wziętym czasem: {stopwatch.ElapsedMilliseconds} ms.");
            Console.WriteLine("[System] Mimo zapytania 20 klientów na raz, powołaliśmy tylko 3 drogie obiekty łączące się do API, zgodnie z limitem licencji.");
        }

        static async Task HandleClientRequestAsync(AsyncWorkerPool pool, int requestJobId)
        {
            // Żądanie oczekuje asynchronicznie bez blokowania Wątków CPU
            var worker = await pool.AcquireWorkerAsync();
            try
            {
                await worker.ProcessJobAsync(requestJobId);
            }
            finally
            {
                pool.ReleaseWorker(worker);
            }
        }
    }
}
