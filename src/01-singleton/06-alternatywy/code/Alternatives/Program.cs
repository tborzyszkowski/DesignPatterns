using Alternatives;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("=== SINGLETON — ALTERNATYWY ===\n");

// ──────────────────────────────────────────────────────────────────────────────
// Alternatywa 1: Dependency Injection
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── Alternatywa 1: Dependency Injection ──");

// --- Środowisko produkcyjne: SmtpEmailSender jako singleton w DI ---
Console.WriteLine("\nProdukcyjny DI Container (SmtpEmailSender jako Singleton):");
var prodServices = new ServiceCollection();
prodServices.AddSingleton<IEmailSender, SmtpEmailSender>();
prodServices.AddTransient<OrderService>();
var prodContainer = prodServices.BuildServiceProvider();

var orderService1 = prodContainer.GetRequiredService<OrderService>();
var orderService2 = prodContainer.GetRequiredService<OrderService>();

orderService1.PlaceOrder("jan@example.com", "Laptop");
orderService2.PlaceOrder("anna@example.com", "Tablet");

// Oba OrderService używają tego samego IEmailSender (singleton w DI)
var sender1 = prodContainer.GetRequiredService<IEmailSender>();
var sender2 = prodContainer.GetRequiredService<IEmailSender>();
Console.WriteLine($"DI Singleton: sender1 == sender2: {ReferenceEquals(sender1, sender2)}");
Console.WriteLine($"Wysłanych maili: {sender1.SentMessages.Count}");

// --- Testy: MockEmailSender ---
Console.WriteLine("\nW testach — podmiana na MockEmailSender:");
var mockSender = new MockEmailSender();
var testOrderService = new OrderService(mockSender); // wstrzyknięcie mock
testOrderService.PlaceOrder("test@example.com", "TestProduct");
Console.WriteLine($"Mock przechwycił {mockSender.SentMessages.Count} wiadomości:");
foreach (var msg in mockSender.SentMessages)
    Console.WriteLine($"  {msg}");

// ──────────────────────────────────────────────────────────────────────────────
// Alternatywa 2: Monostate
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── Alternatywa 2: Monostate ──");

var logger1 = new MonostateLogger();
var logger2 = new MonostateLogger();
var logger3 = new MonostateLogger();

// Zmiana przez logger1 — widoczna przez logger2 i logger3
logger1.MinimumLevel = LogLevel.Debug;
logger2.Log(LogLevel.Debug,   "Debug przez logger2");
logger3.Log(LogLevel.Info,    "Info przez logger3");
logger1.Log(LogLevel.Warning, "Warning przez logger1");

Console.WriteLine($"\nLiczba wiadomości (statyczna): {MonostateLogger.MessageCount}");
Console.WriteLine($"logger1 == logger2: {ReferenceEquals(logger1, logger2)} ← inne obiekty, ale wspólny stan");

// ──────────────────────────────────────────────────────────────────────────────
// Alternatywa 3: Ambient Context (TimeProvider)
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── Alternatywa 3: Ambient Context (TimeProvider) ──");

// Produkcja: systemowy czas
Console.WriteLine($"Produkcja - Now: {AppTimeProvider.Current.Now:yyyy-MM-dd HH:mm:ss}");

// Test: podmiana na stały czas — bez mockowania, bez DI
AppTimeProvider.Current = new FixedAppTimeProvider(new DateTime(2025, 1, 1, 12, 0, 0));
Console.WriteLine($"Test - Now (fixed): {AppTimeProvider.Current.Now:yyyy-MM-dd HH:mm:ss}");

// Izolacja per wątek dzięki AsyncLocal
var threadResult = "";
var t = new Thread(() =>
{
    // Ten wątek ma własny kontekst — podmiana tutaj nie wpływa na główny wątek
    AppTimeProvider.Current = new FixedAppTimeProvider(new DateTime(2000, 6, 15));
    threadResult = AppTimeProvider.Current.Now.ToString("yyyy-MM-dd");
});
t.Start();
t.Join();
Console.WriteLine($"Wątek tła użył: {threadResult}");
Console.WriteLine($"Główny wątek dalej: {AppTimeProvider.Current.Now:yyyy-MM-dd HH:mm:ss} (izolacja!)");

Console.WriteLine("\n=== KONIEC DEMONSTRACJI ===");
