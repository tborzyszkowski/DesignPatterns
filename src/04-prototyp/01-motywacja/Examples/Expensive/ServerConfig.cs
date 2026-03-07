namespace Motywacja.Expensive;

/// <summary>
/// Symuluje kosztowny obiekt, którego inicjalizacja wymaga dostępu do zewnętrznego zasobu.
/// W praktyce to może być: pobranie konfiguracji z serwera, parsowanie dużego pliku,
/// inicjalizacja modelu ML, zapytanie do bazy danych itp.
/// </summary>
public sealed class ServerConfig
{
    public string Host       { get; private set; }
    public int    Port       { get; private set; }
    public string Database   { get; private set; }
    public int    PoolSize   { get; private set; }
    public IReadOnlyList<string> AllowedIps { get; private set; }
    public TimeSpan InitTime { get; }

    // Prywatny konstruktor — używany zarówno przez fabrykę jak i przez Clone()
    private ServerConfig(string host, int port, string database,
        int poolSize, List<string> allowedIps, TimeSpan initTime)
    {
        Host       = host;
        Port       = port;
        Database   = database;
        PoolSize   = poolSize;
        AllowedIps = allowedIps.AsReadOnly();
        InitTime   = initTime;
    }

    /// <summary>
    /// Fabryka ładująca konfigurację — symuluje kosztowną operację.
    /// </summary>
    public static ServerConfig LoadFromServer(string environment = "production")
    {
        var start = DateTime.UtcNow;

        // Symulacja kosztownej operacji: np. wywołanie REST API, odczyt z bazy
        Console.WriteLine($"  [ServerConfig] Łączenie z serwerem konfiguracji ({environment})...");
        Thread.Sleep(300);   // symulacja 300ms opóźnienia sieciowego

        Console.WriteLine($"  [ServerConfig] Pobieram ustawienia...");
        Thread.Sleep(200);   // symulacja parsowania/przetwarzania

        var config = new ServerConfig(
            host: $"db-{environment}.firma.pl",
            port: 5432,
            database: $"app_{environment}",
            poolSize: environment == "production" ? 20 : 5,
            allowedIps: ["10.0.0.1", "10.0.0.2", "10.0.1.0/24"],
            initTime: DateTime.UtcNow - start
        );

        Console.WriteLine($"  [ServerConfig] Gotowe (czas: {config.InitTime.TotalMilliseconds:F0} ms)");
        return config;
    }

    /// <summary>
    /// Klonowanie — tworzy nową konfigurację na bazie istniejącej.
    /// Kosztuje ~0 ms zamiast ~500 ms.
    /// </summary>
    public ServerConfig Clone() => new ServerConfig(
        Host, Port, Database, PoolSize,
        new List<string>(AllowedIps),   // głęboka kopia listy
        TimeSpan.Zero
    );

    /// <summary>
    /// Klonowanie z nadpisaniem wybranych pól — typowy use case Prototype.
    /// </summary>
    public ServerConfig CloneWith(int? port = null, int? poolSize = null)
        => new ServerConfig(
            Host,
            port ?? Port,
            Database,
            poolSize ?? PoolSize,
            new List<string>(AllowedIps),
            TimeSpan.Zero
        );

    public override string ToString() =>
        $"ServerConfig {{ Host={Host}, Port={Port}, DB={Database}, Pool={PoolSize}, IPs=[{string.Join(", ", AllowedIps)}] }}";
}
