// =============================================================
// ILogger + ILoggerProvider — Most w Microsoft.Extensions.Logging
// =============================================================
// Abstrakcja:  ILogger<T>  — kod aplikacji zalezy tylko od niej
// Implementor: ILoggerProvider — pisze do konkretnego celu
// =============================================================

using Microsoft.Extensions.Logging;

// ---- Kompozycja: podpinamy dwa Concrete Implementors -----------
using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder
        .SetMinimumLevel(LogLevel.Debug)
        .AddConsole()   // Concrete Implementor A: ConsoleLoggerProvider
        .AddDebug();    // Concrete Implementor B: DebugLoggerProvider
});

// ---- Kod aplikacji: zalezy TYLKO od ILogger<T> ----------------
ILogger<OrderService> logger = factory.CreateLogger<OrderService>();

logger.LogInformation("Zamówienie {OrderId} złożone przez {User}", 42, "jan@example.com");
logger.LogWarning("Stan magazynowy niski: {Product}", "Widget");
logger.LogError("Płatność odrzucona dla zamówienia {OrderId}", 42);

Console.WriteLine();

// ---- Własny Concrete Implementor: InMemoryLoggerProvider ------
var memProvider = new InMemoryLoggerProvider();
using ILoggerFactory factory2 = LoggerFactory.Create(builder =>
{
    builder
        .SetMinimumLevel(LogLevel.Debug)
        .AddProvider(memProvider);  // Concrete Implementor C
});

ILogger<OrderService> logger2 = factory2.CreateLogger<OrderService>();
logger2.LogInformation("Sesja {SessionId} rozpoczęta", "abc-123");
logger2.LogDebug("Krok {Step} zakończony", 1);

Console.WriteLine($"\nInMemoryLoggerProvider zebrał {memProvider.Entries.Count} wpisów:");
foreach (var entry in memProvider.Entries)
    Console.WriteLine($"  {entry}");

// =============================================================
// Klasy domeny (bez wiedzy o konkretnych providerach)
// =============================================================
class OrderService { }

// =============================================================
// Własny Concrete Implementor — rozszerzenie bez zmiany kodu app
// =============================================================
class InMemoryLoggerProvider : ILoggerProvider
{
    public List<string> Entries { get; } = new();

    public ILogger CreateLogger(string categoryName) =>
        new InMemoryLogger(categoryName, Entries);

    public void Dispose() { }
}

class InMemoryLogger(string category, List<string> entries) : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
    public bool IsEnabled(LogLevel level) => true;

    public void Log<TState>(LogLevel level, EventId id, TState state,
        Exception? ex, Func<TState, Exception?, string> formatter)
    {
        entries.Add($"[{level}] {category}: {formatter(state, ex)}");
    }
}
