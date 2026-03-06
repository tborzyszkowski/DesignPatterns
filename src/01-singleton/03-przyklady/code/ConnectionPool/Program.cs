using ConnectionPoolExample;

Console.WriteLine("=== PULA POŁĄCZEŃ JAKO SINGLETON ===\n");

var pool = DbConnectionPool.Instance;

// Sekwencyjne użycie
Console.WriteLine("── Sekwencyjne pobieranie i zwalnianie połączeń ──");
var conn1 = await pool.AcquireAsync();
Console.WriteLine($"Zapytanie: {conn1.ExecuteQuery("SELECT * FROM Orders")}");
pool.Release(conn1);

var conn2 = await pool.AcquireAsync();
Console.WriteLine($"Zapytanie: {conn2.ExecuteQuery("SELECT * FROM Products")}");
pool.Release(conn2);

// Współbieżne użycie — 5 zadań walczy o 3 połączenia
Console.WriteLine("\n── Współbieżne żądania (5 zadań, 3 połączenia w puli) ──");
var tasks = Enumerable.Range(1, 5).Select(async i =>
{
    Console.WriteLine($"  [Zadanie {i}] Proszę o połączenie...");
    var connection = await pool.AcquireAsync();
    Console.WriteLine($"  [Zadanie {i}] Wykonuję zapytanie...");
    await Task.Delay(100); // symulacja pracy
    pool.Release(connection);
    Console.WriteLine($"  [Zadanie {i}] Gotowe.");
});

await Task.WhenAll(tasks);

Console.WriteLine("\npool == DbConnectionPool.Instance: " +
                  ReferenceEquals(pool, DbConnectionPool.Instance));
