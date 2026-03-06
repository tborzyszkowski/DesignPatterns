using LoggerExample;

Console.WriteLine("=== LOGGER JAKO SINGLETON ===\n");

// Logowanie z różnych "modułów" aplikacji — wszystko trafia do tej samej instancji
var logger = AppLogger.Instance;
logger.LogInfo("Aplikacja uruchomiona");
logger.LogDebug("Tryb debugowania aktywny");

// Symulacja logowania z różnych serwisów
SimulateOrderService();
SimulatePaymentService();

logger.LogInfo("Aplikacja zakończona");

// Weryfikacja, że to ten sam obiekt
var logger2 = AppLogger.Instance;
Console.WriteLine($"\nlogger == logger2: {ReferenceEquals(logger, logger2)}");

static void SimulateOrderService()
{
    AppLogger.Instance.LogInfo("[OrderService] Tworzę nowe zamówienie #1001");
    AppLogger.Instance.LogDebug("[OrderService] Walidacja produktów...");
    AppLogger.Instance.LogInfo("[OrderService] Zamówienie #1001 gotowe");
}

static void SimulatePaymentService()
{
    AppLogger.Instance.LogInfo("[PaymentService] Przetważam płatność...");
    AppLogger.Instance.LogWarning("[PaymentService] Karta zbliża się do limitu");
    AppLogger.Instance.LogInfo("[PaymentService] Płatność zatwierdzona");
}
