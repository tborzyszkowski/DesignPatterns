// =============================================================
//  Wzorzec gry: szablony wrogów klonowane przez Prototype Registry
//  Plik: GameEntities/EnemyPrototype.cs
// =============================================================

namespace KiedyStosowac;

// ─────────────────────────────────────────────────────────────
//  INTERFEJS PROTOTYPU
// ─────────────────────────────────────────────────────────────

/// <summary>Wspólny interfejs wszystkich wrogów w grze.</summary>
public interface IEnemy
{
    string Name        { get; }
    int    MaxHp       { get; }
    int    AttackPower { get; }
    float  Speed       { get; }
    IReadOnlyList<string>         Abilities { get; }
    IReadOnlyDictionary<string, float> DropTable { get; }

    // Pozycja na mapie — ustawiana przy spawn, nie w szablonie
    int X { get; set; }
    int Y { get; set; }

    /// <summary>Tworzy głęboką kopię szablonu.</summary>
    IEnemy Clone();

    /// <summary>Klonuje i ustawia pozycję startową.</summary>
    IEnemy Spawn(int x, int y);

    void PrintStats();
}

// ─────────────────────────────────────────────────────────────
//  ABSTRAKCYJNY SZABLON WROGA
// ─────────────────────────────────────────────────────────────

public abstract class EnemyTemplate : IEnemy
{
    // Init-only: szablon nie jest modyfikowany po załadowaniu
    public string Name        { get; protected init; } = "Unknown";
    public int    MaxHp       { get; protected init; }
    public int    AttackPower { get; protected init; }
    public float  Speed       { get; protected init; }

    // Kolekcje: lista zdolności i tabela łupów
    protected List<string> _abilities = [];
    protected Dictionary<string, float> _dropTable = [];

    public IReadOnlyList<string>              Abilities => _abilities;
    public IReadOnlyDictionary<string, float> DropTable => _dropTable;

    // Pozycja — mutable, zmieniana przy spawn
    public int X { get; set; }
    public int Y { get; set; }

    /// <summary>Konstruktor kopiujący — głęboka kopia kolekcji.</summary>
    protected EnemyTemplate(EnemyTemplate source)
    {
        Name        = source.Name;
        MaxHp       = source.MaxHp;
        AttackPower = source.AttackPower;
        Speed       = source.Speed;
        _abilities  = [.. source._abilities];          // nowa lista
        _dropTable  = new Dictionary<string, float>(source._dropTable); // nowy słownik
        X = source.X;
        Y = source.Y;
    }

    protected EnemyTemplate() { }

    public abstract IEnemy Clone();

    public IEnemy Spawn(int x, int y)
    {
        var spawned = Clone();
        spawned.X = x;
        spawned.Y = y;
        return spawned;
    }

    public void PrintStats()
    {
        Console.WriteLine($"  [{Name}] at ({X},{Y})  HP:{MaxHp}  ATK:{AttackPower}  SPD:{Speed:F1}");
        Console.WriteLine($"    Abilities: [{string.Join(", ", Abilities)}]");
        Console.WriteLine($"    DropTable: [{string.Join(", ", DropTable.Select(kv => $"{kv.Key}:{kv.Value:P0}"))}]");
    }
}

// ─────────────────────────────────────────────────────────────
//  KONKRETNE KLASY WROGÓW
// ─────────────────────────────────────────────────────────────

public sealed class Goblin : EnemyTemplate
{
    private Goblin(Goblin source) : base(source) { }

    public Goblin()
    {
        Name        = "Goblin";
        MaxHp       = 30;
        AttackPower = 5;
        Speed       = 1.5f;
        _abilities  = ["Sneak", "Steal"];
        _dropTable  = new() { ["gold"] = 0.50f, ["dagger"] = 0.10f };
    }

    public override IEnemy Clone() => new Goblin(this);
}

public sealed class Orc : EnemyTemplate
{
    private Orc(Orc source) : base(source) { }

    public Orc()
    {
        Name        = "Orc";
        MaxHp       = 120;
        AttackPower = 20;
        Speed       = 0.8f;
        _abilities  = ["Rage", "Bash", "War Cry"];
        _dropTable  = new() { ["axe"] = 0.25f, ["orcish armor"] = 0.05f, ["gold"] = 0.30f };
    }

    public override IEnemy Clone() => new Orc(this);
}

public sealed class Dragon : EnemyTemplate
{
    public int FireDamage { get; private init; }

    private Dragon(Dragon source) : base(source)
    {
        FireDamage = source.FireDamage;
    }

    public Dragon()
    {
        Name        = "Dragon";
        MaxHp       = 500;
        AttackPower = 60;
        Speed       = 1.2f;
        FireDamage  = 40;
        _abilities  = ["Fire Breath", "Fly", "Tail Sweep", "Intimidate"];
        _dropTable  = new()
        {
            ["dragon scale"]    = 0.80f,
            ["dragon heart"]    = 0.20f,
            ["legendary sword"] = 0.03f
        };
    }

    public override IEnemy Clone() => new Dragon(this);
}

// ─────────────────────────────────────────────────────────────
//  PROTOTYPE REGISTRY — rejestr szablonów wrogów
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Przechowuje szablony wrogów i produkuje ich kopie na żądanie.
/// Szablony są ładowane raz (np. z JSON) — spawn jest tani.
/// </summary>
public sealed class EnemyRegistry
{
    private readonly Dictionary<string, IEnemy> _prototypes = [];

    public void Register(string key, IEnemy prototype)
    {
        ArgumentException.ThrowIfNullOrEmpty(key);
        _prototypes[key] = prototype;
    }

    public void Unregister(string key) => _prototypes.Remove(key);

    /// <summary>Klonuje szablon i ustawia pozycję.</summary>
    public IEnemy Spawn(string key, int x, int y)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new KeyNotFoundException($"Brak wroga o kluczu: '{key}'");

        return prototype.Spawn(x, y);
    }

    public IEnumerable<string> Keys => _prototypes.Keys;
}
