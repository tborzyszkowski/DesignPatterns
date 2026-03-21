using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool; // Wymaga pakietu NuGet: Microsoft.Extensions.ObjectPool

namespace VariantsSample
{
    // Wzorzec nakazuje nam mieć sposób na resetowanie stanu.
    // Wbudowany system .NET ma interfejs IPooledObjectPolicy<T>.
    public class StringBuilderPooledObjectPolicy : IPooledObjectPolicy<StringBuilder>
    {
        public StringBuilder Create()
        {
            Console.WriteLine("[Policy] Zbudowano nową instancję StringBuilder.");
            return new StringBuilder();
        }

        public bool Return(StringBuilder obj)
        {
            Console.WriteLine($"[Policy] Zwrócono. Długość: {obj.Length}. Czyszczenie...");
            // Czyszczenie stanu do ponownego użycia
            obj.Clear();
            return true; // true = można zwrócić do puli. false = wyrzuć do Garbage Collectora
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("--- Warianty: Microsoft.Extensions.ObjectPool Demo ---");

            // Inicjalizujemy wbudowaną pulę dla StringBuildera wykorzystując własną politykę rządzacą tworzeniem/czyszczeniem.
            var policy = new StringBuilderPooledObjectPolicy();
            // MaximumRetained określa jak dużo elementów zatrzymujemy w buforze (resztę pożre GC)
            var pool = new DefaultObjectPool<StringBuilder>(policy, maximumRetained: 2);

            // Symulacja żądań asynchronicznych do naszego mechanizmu
            var tasks = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                int taskId = i;
                tasks[i] = Task.Run(() => DoFormatWork(pool, taskId));
            }

            await Task.WhenAll(tasks);
            
            Console.WriteLine("Wszystkie zadania ukończone.");
        }

        static void DoFormatWork(ObjectPool<StringBuilder> pool, int id)
        {
            // POBIERAMY (Zablokuje się / stworzy i zwróci)
            StringBuilder buffer = pool.Get();
            try
            {
                buffer.Append($"Zadanie [{id}] zaczyna przygotowywać raport...");
                Task.Delay(100).Wait(); // symulacja obróbki
                buffer.Append(" Zakończono pomyślnie.");
                
                Console.WriteLine($"Wynik taskId={id} -> {buffer.ToString()}");
            }
            finally
            {
                // ZWRACAMY (Wykona się logika z polityki: "Return" i czyszczenie)
                pool.Return(buffer);
            }
        }
    }
}
