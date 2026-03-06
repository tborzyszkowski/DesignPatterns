namespace ConfigurationExample;

/// <summary>
/// Klasa konfiguracji aplikacji jako Singleton.
/// Wczytuje ustawienia z pliku lub zmiennych środowiskowych dokładnie raz.
/// </summary>
public sealed class AppConfiguration
{
    private static readonly Lazy<AppConfiguration> _lazy = new(() => new AppConfiguration());
    private readonly Dictionary<string, string> _settings;

    private AppConfiguration()
    {
        Console.WriteLine("[Config] Wczytuję konfigurację...");
        // W prawdziwej aplikacji: wczytaj z appsettings.json / zmiennych środowiskowych
        // Tutaj: konfiguracja wbudowana (in-memory) do demonstracji
        _settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["ConnectionString"]   = "Server=localhost;Database=AppDB;User=app;",
            ["ConnectionTimeout"]  = "30",
            ["MaxPoolSize"]        = "10",
            ["Environment"]        = "Development",
            ["LogLevel"]           = "Debug",
            ["MaxRetries"]         = "3",
            ["CacheExpirySeconds"] = "300",
        };
        Console.WriteLine($"[Config] Wczytano {_settings.Count} ustawień.");
    }

    public static AppConfiguration Instance => _lazy.Value;

    /// <summary>Zwraca wartość ustawienia jako string.</summary>
    public string Get(string key) =>
        _settings.TryGetValue(key, out var value) ? value : string.Empty;

    /// <summary>Zwraca wartość ustawienia jako T (np. int, bool) z wartością domyślną.</summary>
    public T Get<T>(string key, T defaultValue) where T : IParsable<T>
    {
        if (_settings.TryGetValue(key, out var str) &&
            T.TryParse(str, null, out var result))
            return result;
        return defaultValue;
    }

    /// <summary>Zwraca wszystkie klucze konfiguracji.</summary>
    public IEnumerable<string> Keys => _settings.Keys;

    public override string ToString() =>
        string.Join(Environment.NewLine, _settings.Select(kv => $"  {kv.Key} = {kv.Value}"));
}
