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

    public readonly record struct AcquireResult(HeavyWorker Worker, long WaitMs);

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

        public async Task<AcquireResult?> AcquireWorkerAsync(TimeSpan timeout)
        {
            var sw = Stopwatch.StartNew();
            // Oczekuje asynchronicznie, aż zwolni się w puli co najmniej jedno miejsce
            var entered = await _semaphore.WaitAsync(timeout);
            sw.Stop();

            if (!entered)
            {
                return null;
            }

            if (_workers.TryDequeue(out var worker))
            {
                return new AcquireResult(worker, sw.ElapsedMilliseconds);
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

            int maxConnections = ParseArg(args, "--workers", 3);
            int jobsCount = ParseArg(args, "--jobs", 20);
            int timeoutMs = ParseArg(args, "--timeoutMs", 1000);

            var workerPool = new AsyncWorkerPool(maxConnections);

            Console.WriteLine($"[System] workers={maxConnections}, jobs={jobsCount}, timeoutMs={timeoutMs}");

            var stopwatch = Stopwatch.StartNew();
            long totalWaitMs = 0;
            int completed = 0;
            int timeouts = 0;

            var tasks = new Task[jobsCount];
            // Symulujemy równoczesny napływ żądań.
            for (int i = 0; i < jobsCount; i++)
            {
                int id = i;
                tasks[i] = HandleClientRequestAsync(workerPool, id, TimeSpan.FromMilliseconds(timeoutMs),
                    onSuccess: waitMs =>
                    {
                        Interlocked.Add(ref totalWaitMs, waitMs);
                        Interlocked.Increment(ref completed);
                    },
                    onTimeout: () => Interlocked.Increment(ref timeouts));
            }

            // Czekamy na wykonanie wszystkich
            await Task.WhenAll(tasks);

            stopwatch.Stop();

            var elapsedSec = Math.Max(0.001, stopwatch.Elapsed.TotalSeconds);
            var qps = completed / elapsedSec;
            var avgWait = completed == 0 ? 0 : (double)totalWaitMs / completed;

            Console.WriteLine($"\n[System] Czas całkowity: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"[System] Ukończone zadania: {completed}/{jobsCount}");
            Console.WriteLine($"[System] Timeouty: {timeouts}");
            Console.WriteLine($"[System] Średni wait-time: {avgWait:F2} ms");
            Console.WriteLine($"[System] Szacowany throughput: {qps:F2} req/s");
        }

        static async Task HandleClientRequestAsync(
            AsyncWorkerPool pool,
            int requestJobId,
            TimeSpan timeout,
            Action<long> onSuccess,
            Action onTimeout)
        {
            // Żądanie oczekuje asynchronicznie bez blokowania Wątków CPU
            var acquired = await pool.AcquireWorkerAsync(timeout);
            if (acquired is null)
            {
                Console.WriteLine($"!! Timeout dla zadania [{requestJobId}] po {timeout.TotalMilliseconds} ms");
                onTimeout();
                return;
            }

            var result = acquired.Value;
            try
            {
                await result.Worker.ProcessJobAsync(requestJobId);
                onSuccess(result.WaitMs);
            }
            finally
            {
                pool.ReleaseWorker(result.Worker);
            }
        }

        static int ParseArg(string[] args, string key, int fallback)
        {
            for (var i = 0; i < args.Length - 1; i++)
            {
                if (args[i].Equals(key, StringComparison.OrdinalIgnoreCase) && int.TryParse(args[i + 1], out var value))
                {
                    return value;
                }
            }

            return fallback;
        }
    }
}
