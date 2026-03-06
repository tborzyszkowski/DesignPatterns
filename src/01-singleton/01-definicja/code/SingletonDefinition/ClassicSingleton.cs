// UWAGA: Ta implementacja NIE jest bezpieczna wątkowo.
// Służy wyłącznie do celów ilustracyjnych — pokaz klasycznej definicji GoF.
// W kodzie produkcyjnym używaj LazySingleton lub StaticHolderSingleton.
namespace SingletonDefinition;

/// <summary>
/// Klasyczny Singleton z leniwą inicjalizacją (Lazy Initialization).
/// Implementacja wzorowana na oryginalnej definicji Gang of Four.
/// NIE jest bezpieczna wątkowo — zob. 05-wspolbieznosc.
/// </summary>
public class ClassicSingleton
{
    private static ClassicSingleton? _instance;

    // Prywatny konstruktor — nikt spoza klasy nie może wywołać new ClassicSingleton()
    private ClassicSingleton()
    {
        Console.WriteLine("[ClassicSingleton] Konstruktor wywołany — tworzę instancję.");
    }

    /// <summary>
    /// Globalna metoda dostępu do jedynej instancji.
    /// NIE jest thread-safe!
    /// </summary>
    public static ClassicSingleton GetInstance()
    {
        // PROBLEM WIELOWĄTKOWY: dwa wątki mogą przejść przez ten warunek
        // jednocześnie, gdy _instance jest null, i oba stworzą nowy obiekt.
        if (_instance is null)
        {
            _instance = new ClassicSingleton();
        }
        return _instance;
    }

    public string Greet() => "Cześć od ClassicSingleton!";
}
