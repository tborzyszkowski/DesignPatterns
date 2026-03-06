using Consequences;

Console.WriteLine("=== SINGLETON — KONSEKWENCJE STOSOWANIA ===\n");

// ──────────────────────────────────────────────────────────────────────────────
// Konsekwencja 4: Limit liczby egzemplarzy (Multiton)
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── Konsekwencja 4: Limit egzemplarzy (Multiton, max=3) ──");

var conn1 = LimitedInstancesSingleton.GetInstance();
var conn2 = LimitedInstancesSingleton.GetInstance();
var conn3 = LimitedInstancesSingleton.GetInstance();

Console.WriteLine($"Instancje w puli: {LimitedInstancesSingleton.InstanceCount}");
Console.WriteLine($"conn1: {conn1}");
Console.WriteLine($"conn2: {conn2}");
Console.WriteLine($"conn3: {conn3}");

// Czwarte żądanie — zwraca jedną z istniejących
Console.WriteLine("\nCzwarte żądanie (powyżej limitu):");
var conn4 = LimitedInstancesSingleton.GetInstance();
Console.WriteLine($"conn4: {conn4}");
Console.WriteLine($"conn4 == conn1? {ReferenceEquals(conn4, conn1)}");
Console.WriteLine($"conn4 == conn2? {ReferenceEquals(conn4, conn2)}");
Console.WriteLine($"conn4 == conn3? {ReferenceEquals(conn4, conn3)}");

// ──────────────────────────────────────────────────────────────────────────────
// Konsekwencja 5: Singleton vs klasa statyczna
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── Konsekwencja 5: Singleton vs klasa statyczna ──");
Console.WriteLine("Singleton może implementować interfejs:");

ILog logger = AppLogger.Instance;   // Singleton przez interfejs
logger.Log("Test message via interface");

// Klasa statyczna nie może implementować interfejsu — demonstracja przez interfejs
Console.WriteLine("\nPodmiana na mock (niemożliwa ze static class):");
ILog mockLogger = new MockLogger();
mockLogger.Log("Mock test message");

Console.WriteLine("\n=== KONIEC DEMONSTRACJI ===");

// ──────────────────────────────────────────────────────────────────────────────
// Klasy pomocnicze do demonstracji Konsekwencji 5
// ──────────────────────────────────────────────────────────────────────────────
public interface ILog
{
    void Log(string msg);
}

public sealed class AppLogger : ILog
{
    public static AppLogger Instance { get; } = new AppLogger();
    private AppLogger() { }
    public void Log(string msg) => Console.WriteLine($"[AppLogger] {msg}");
}

public sealed class MockLogger : ILog
{
    public void Log(string msg) => Console.WriteLine($"[MockLogger - test] {msg}");
}
