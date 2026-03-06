namespace SingletonDefinition;

/// <summary>
/// Singleton z użyciem wzorca Static Holder (Bill Pugh pattern adaptowany do C#).
/// Zagnieżdżona klasa statyczna Nested jest inicjalizowana dopiero przy pierwszym
/// odwołaniu do StaticHolderSingleton.Instance — bez żadnych jawnych blokad.
///
/// CLR gwarantuje thread-safe inicjalizację klas statycznych (beforefieldinit semantics).
/// Jawny statyczny konstruktor w Nested wyłącza beforefieldinit, co zapewnia
/// inicjalizację dokładnie przy pierwszym odwołaniu.
/// </summary>
public class StaticHolderSingleton
{
    private StaticHolderSingleton()
    {
        Console.WriteLine("[StaticHolderSingleton] Konstruktor wywołany — inicjalizacja przez Static Holder.");
    }

    /// <summary>
    /// Zagnieżdżona klasa statyczna — inicjalizowana leniwie przez CLR.
    /// Jawny konstruktor statyczny zapobiega optymalizacji beforefieldinit.
    /// </summary>
    private static class Nested
    {
        // Jawny konstruktor statyczny — kluczowy element wzorca
        static Nested() { }

        internal static readonly StaticHolderSingleton Instance = new StaticHolderSingleton();
    }

    public static StaticHolderSingleton Instance => Nested.Instance;

    public string Greet() => "Cześć od StaticHolderSingleton!";
}
