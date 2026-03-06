using ConfigurationExample;

Console.WriteLine("=== KONFIGURACJA JAKO SINGLETON ===\n");

var config = AppConfiguration.Instance;

Console.WriteLine($"Środowisko:         {config.Get("Environment")}");
Console.WriteLine($"ConnectionTimeout:  {config.Get<int>("ConnectionTimeout", 30)} s");
Console.WriteLine($"MaxPoolSize:        {config.Get<int>("MaxPoolSize", 5)}");
Console.WriteLine($"LogLevel:           {config.Get("LogLevel")}");
Console.WriteLine($"MaxRetries:         {config.Get<int>("MaxRetries", 1)}");
Console.WriteLine($"CacheExpiry:        {config.Get<int>("CacheExpirySeconds", 60)} s");
Console.WriteLine($"Nieistniejący klucz: '{config.Get("NonExistentKey")}'");

Console.WriteLine("\nPełna konfiguracja:");
Console.WriteLine(config.ToString());

// Drugi dostęp — NIE wczytuje pliku ponownie
var config2 = AppConfiguration.Instance;
Console.WriteLine($"\nconfig == config2: {ReferenceEquals(config, config2)}");
