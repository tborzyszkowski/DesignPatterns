namespace ConnectionPoolExample;

/// <summary>
/// Symulacja połączenia z bazą danych.
/// </summary>
public sealed class DbConnection
{
    public int Id { get; }
    public bool IsOpen { get; private set; }

    public DbConnection(int id) { Id = id; }

    public void Open()
    {
        IsOpen = true;
        Console.WriteLine($"    [DbConnection #{Id}] Otwarto połączenie.");
    }

    public void Close()
    {
        IsOpen = false;
        Console.WriteLine($"    [DbConnection #{Id}] Zamknięto połączenie.");
    }

    public string ExecuteQuery(string sql)
    {
        if (!IsOpen) throw new InvalidOperationException("Połączenie nie jest otwarte.");
        return $"[Result of '{sql}' via connection #{Id}]";
    }

    public override string ToString() => $"DbConnection[Id={Id}, Open={IsOpen}]";
}

/// <summary>
/// Pula połączeń jako Singleton — jeden globalny zarządca połączeń.
/// Ogranicza liczbę równoczesnych połączeń do PoolSize.
/// Thread-safe dzięki SemaphoreSlim + lock na kolejce.
/// </summary>
public sealed class DbConnectionPool
{
    private static readonly Lazy<DbConnectionPool> _lazy = new(() => new DbConnectionPool());

    public const int PoolSize = 3; // mała pula do czytelnej demonstracji
    private readonly SemaphoreSlim _semaphore = new(PoolSize, PoolSize);
    private readonly Queue<DbConnection> _available;

    private DbConnectionPool()
    {
        _available = new Queue<DbConnection>(
            Enumerable.Range(1, PoolSize).Select(i => new DbConnection(i)));
        Console.WriteLine($"[Pool] Zainicjalizowano pulę z {PoolSize} połączeniami.");
    }

    public static DbConnectionPool Instance => _lazy.Value;

    public int AvailableCount
    {
        get { lock (_available) return _available.Count; }
    }

    /// <summary>
    /// Pobiera połączenie z puli. Blokuje wątek, jeśli pula jest wyczerpana.
    /// </summary>
    public async Task<DbConnection> AcquireAsync(CancellationToken ct = default)
    {
        Console.WriteLine($"[Pool] Oczekiwanie na połączenie... (dostępne: {AvailableCount}/{PoolSize})");
        await _semaphore.WaitAsync(ct);
        DbConnection connection;
        lock (_available)
            connection = _available.Dequeue();
        connection.Open();
        return connection;
    }

    /// <summary>
    /// Zwraca połączenie do puli po użyciu.
    /// </summary>
    public void Release(DbConnection connection)
    {
        connection.Close();
        lock (_available)
            _available.Enqueue(connection);
        _semaphore.Release();
        Console.WriteLine($"[Pool] Połączenie #{connection.Id} zwrócone. Dostępne: {AvailableCount}/{PoolSize}");
    }
}
