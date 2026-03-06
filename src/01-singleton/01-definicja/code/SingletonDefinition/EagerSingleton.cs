namespace SingletonDefinition;

/// <summary>
/// Singleton z inicjalizacją zachłanną (Eager Initialization).
/// Pole statyczne jest inicjalizowane przez CLR przed pierwszym użyciem klasy.
/// CLR gwarantuje, że inicjalizacja pól statycznych jest thread-safe.
/// </summary>
public class EagerSingleton
{
    // CLR inicjalizuje to pole dokładnie raz, przed pierwszym użyciem klasy.
    // Inicjalizacja jest thread-safe z gwarancji CLR.
    private static readonly EagerSingleton _instance = new EagerSingleton();

    private EagerSingleton()
    {
        Console.WriteLine("[EagerSingleton] Konstruktor wywołany — inicjalizacja zachłanna przy ładowaniu klasy.");
    }

    // Właściwość zamiast metody — idiom C#
    public static EagerSingleton Instance => _instance;

    public string Greet() => "Cześć od EagerSingleton!";
}
