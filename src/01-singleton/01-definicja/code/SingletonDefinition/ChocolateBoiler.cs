namespace SingletonDefinition;

/// <summary>
/// Praktyczny przykład Singletona — sterownik kotła czekoladowego.
/// Oparty na przykładzie z książki "Head First Design Patterns" (Freeman, Robson).
///
/// W fabryce czekolady może być tylko jeden kocioł. Dwie instancje kontrolera
/// mogłyby doprowadzić do katastrofy (przepełnienie, niegotowa masa itp.).
/// </summary>
public class ChocolateBoiler
{
    private bool _empty;
    private bool _boiled;

    private static readonly Lazy<ChocolateBoiler> _lazy =
        new Lazy<ChocolateBoiler>(() => new ChocolateBoiler());

    private ChocolateBoiler()
    {
        _empty = true;
        _boiled = false;
        Console.WriteLine("[ChocolateBoiler] Inicjalizacja kotła — jest pusty i zimny.");
    }

    public static ChocolateBoiler GetInstance() => _lazy.Value;

    /// <summary>Napełnia kocioł surowcami — tylko gdy jest pusty.</summary>
    public void Fill()
    {
        if (IsEmpty)
        {
            _empty = false;
            _boiled = false;
            Console.WriteLine("[ChocolateBoiler] Napełniam kocioł surowcami.");
        }
        else
        {
            Console.WriteLine("[ChocolateBoiler] Kocioł jest już pełny — nie napełniam.");
        }
    }

    /// <summary>Podgrzewa masę — tylko gdy kocioł jest pełny i niepodgrzany.</summary>
    public void Boil()
    {
        if (!IsEmpty && !IsBoiled)
        {
            _boiled = true;
            Console.WriteLine("[ChocolateBoiler] Podgrzewam masę czekoladową...");
        }
        else
        {
            Console.WriteLine("[ChocolateBoiler] Nie mogę podgrzewać — kocioł pusty lub już podgrzany.");
        }
    }

    /// <summary>Spuszcza gotową masę — tylko gdy kocioł jest pełny i podgrzany.</summary>
    public void Drain()
    {
        if (!IsEmpty && IsBoiled)
        {
            _empty = true;
            Console.WriteLine("[ChocolateBoiler] Spuszczam gotową masę czekoladową.");
        }
        else
        {
            Console.WriteLine("[ChocolateBoiler] Nie mogę spuszczać — kocioł pusty lub niepodgrzany.");
        }
    }

    public bool IsEmpty => _empty;
    public bool IsBoiled => _boiled;

    public override string ToString() =>
        $"ChocolateBoiler [Empty={_empty}, Boiled={_boiled}, Id={GetHashCode()}]";
}
