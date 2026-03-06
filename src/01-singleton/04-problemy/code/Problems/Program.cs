using System.Reflection;
using System.Text.Json;
using Problems;

Console.WriteLine("=== SINGLETON — PROBLEMY: DZIEDZICZENIE, SERIALIZACJA, REFLEKSJA ===\n");

// ──────────────────────────────────────────────────────────────────────────────
// Problem 1: Dziedziczenie
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── Problem 1: Dziedziczenie ──");
var badLogger = ProblematicLogger.GetInstance();
var badFileLogger = ProblematicFileLogger.GetInstance(); // zwraca ProblematicLogger!

Console.WriteLine($"badLogger.GetType():     {badLogger.GetType().Name}");
Console.WriteLine($"badFileLogger.GetType(): {badFileLogger.GetType().Name}  ← BUG: oczekiwano FileLogger!");
Console.WriteLine($"Obiekty są identyczne: {ReferenceEquals(badLogger, badFileLogger)}");

Console.WriteLine("\nRozwiązanie 1 — Rejestr singletonów:");
var fileLogger = BaseLogger.GetInstance("file");
var consoleLogger = BaseLogger.GetInstance("console");
var fileLogger2 = BaseLogger.GetInstance("file"); // ten sam obiekt co fileLogger
Console.WriteLine($"fileLogger.GetType():    {fileLogger.GetType().Name}");
Console.WriteLine($"consoleLogger.GetType(): {consoleLogger.GetType().Name}");
Console.WriteLine($"fileLogger == fileLogger2: {ReferenceEquals(fileLogger, fileLogger2)}");
fileLogger.Log("Test message via registry");

Console.WriteLine("\nRozwiązanie 2 — Każda podklasa jest własnym singletonem:");
IndependentFileLogger.Instance.Log("Test message 1");
IndependentDatabaseLogger.Instance.Log("Test message 2");
Console.WriteLine($"FileLogger == FileLogger: {ReferenceEquals(IndependentFileLogger.Instance, IndependentFileLogger.Instance)}");

// ──────────────────────────────────────────────────────────────────────────────
// Problem 2: Serializacja
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── Problem 2: Serializacja ──");
Console.WriteLine("BEZ ochrony:");
var original = UnprotectedConfig.Instance;
original.Environment = "Staging";
var json = JsonSerializer.Serialize(original);
Console.WriteLine($"Serialized: {json}");

var deserialized = JsonSerializer.Deserialize<UnprotectedConfig>(json);
Console.WriteLine($"original == deserialized: {ReferenceEquals(original, deserialized)}  ← NARUSZONA GWARANCJA!");
Console.WriteLine($"deserialized.GetHashCode(): {deserialized?.GetHashCode()} vs original: {original.GetHashCode()}");

Console.WriteLine("\nZ ochroną (ProtectedConfig + custom JsonConverter):");
var protectedOriginal = ProtectedConfig.Instance;
protectedOriginal.Environment = "Development";
var protectedJson = JsonSerializer.Serialize(protectedOriginal);
Console.WriteLine($"Serialized: {protectedJson}");
var protectedDeserialized = JsonSerializer.Deserialize<ProtectedConfig>(protectedJson);
Console.WriteLine($"original == deserialized: {ReferenceEquals(protectedOriginal, protectedDeserialized)}  ← SINGLETON ZACHOWANY");

// ──────────────────────────────────────────────────────────────────────────────
// Problem 3: Refleksja
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("\n── Problem 3: Refleksja ──");
Console.WriteLine("BEZ ochrony:");
var instance1 = VulnerableSingleton.Instance;
var ctor = typeof(VulnerableSingleton)
    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, [], null);
var hackedInstance = ctor?.Invoke(null);
Console.WriteLine($"VulnerableSingleton.Instance: {instance1}");
Console.WriteLine($"Hacked instance:              {hackedInstance}");
Console.WriteLine($"Są identyczne: {ReferenceEquals(instance1, hackedInstance)}  ← NARUSZONA GWARANCJA!");

Console.WriteLine("\nZ ochroną (HardenedSingleton):");
var hardened = HardenedSingleton.Instance;
Console.WriteLine($"HardenedSingleton.Instance: {hardened}");

var hardenedCtor = typeof(HardenedSingleton)
    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, [], null);
try
{
    hardenedCtor?.Invoke(null);
    Console.WriteLine("BŁĄD: Singleton nie zablokował refleksji!");
}
catch (TargetInvocationException ex)
{
    Console.WriteLine($"Oczekiwany wyjątek: {ex.InnerException?.Message}");
    Console.WriteLine("Singleton poprawnie zablokował refleksję!");
}

Console.WriteLine("\n=== KONIEC DEMONSTRACJI ===");
