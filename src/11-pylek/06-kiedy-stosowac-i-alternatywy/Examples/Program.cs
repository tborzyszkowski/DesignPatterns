// Compares three approaches for the same domain (particle system):
// 1. Naive – every particle holds full state (lots of duplicated data).
// 2. Flyweight – shared type data + per-instance position.
// 3. Flat model – no hierarchy needed when objects have no shared state.

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== Wariant 1: Naiwny (każdy obiekt trzyma pełny stan) ===");
Console.WriteLine();

var naiveParticles = new List<NaiveParticle>
{
    new("fire",  "red",    "fire.png",  x: 10, y: 20),
    new("fire",  "red",    "fire.png",  x: 30, y: 40),
    new("smoke", "grey",   "smoke.png", x: 50, y: 10),
    new("fire",  "red",    "fire.png",  x: 70, y: 80),
    new("snow",  "white",  "snow.png",  x: 15, y: 55),
    new("smoke", "grey",   "smoke.png", x: 90, y: 30),
    new("snow",  "white",  "snow.png",  x: 25, y: 65),
    new("fire",  "red",    "fire.png",  x: 60, y: 70),
};

foreach (NaiveParticle p in naiveParticles) p.Display();

Console.WriteLine();
Console.WriteLine($"  Instancji: {naiveParticles.Count} — każda duplikuje type+color+texture");

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("=== Wariant 2: Flyweight (współdzielony typ cząstki) ===");
Console.WriteLine();

var typeFactory = new ParticleTypeFactory();

(string type, int x, int y)[] positions =
[
    ("fire",  10, 20), ("fire",  30, 40), ("smoke", 50, 10), ("fire",  70, 80),
    ("snow",  15, 55), ("smoke", 90, 30), ("snow",  25, 65), ("fire",  60, 70),
];

foreach ((string type, int x, int y) in positions)
{
    IParticleType fw = typeFactory.Get(type);
    fw.Display(x, y); // x, y = extrinsic state
}

Console.WriteLine();
Console.WriteLine($"  Instancji renderowanych  : {positions.Length}");
Console.WriteLine($"  Unikalnych flyweightów   : {typeFactory.UniqueCount}");
Console.WriteLine($"  Oszczędność duplikatów   : {positions.Length - typeFactory.UniqueCount} zduplikowanych obiektów zastąpiono referencjami");

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("=== Wariant 3: Płaski model listy (gdy obiekty nie mają wspólnego stanu) ===");
Console.WriteLine();

// When every object is truly unique, Flyweight adds no value.
var uniqueItems = new List<UniqueOrder>
{
    new(1, "Laptop",      2, 3499m),
    new(2, "Monitor",     1, 1299m),
    new(3, "Klawiatura",  3,  199m),
};

foreach (UniqueOrder o in uniqueItems)
    Console.WriteLine($"  Zamówienie #{o.Id}: {o.Product} x{o.Qty} = {o.Qty * o.Price:C2}");

Console.WriteLine();
Console.WriteLine("  Wniosek: Flyweight niepotrzebny — każde zamówienie jest unikalne.");

// ─────────────────────────────────────────────────────────────────────────────
// Naive particle (all state stored per-instance)
// ─────────────────────────────────────────────────────────────────────────────

internal sealed class NaiveParticle(string type, string color, string texture, int x, int y)
{
    public void Display()
        => Console.WriteLine($"  [{type,5}] color={color,5} texture={texture,-10} at ({x},{y})");
}

// ─────────────────────────────────────────────────────────────────────────────
// Flyweight particle type (intrinsic only)
// ─────────────────────────────────────────────────────────────────────────────

internal interface IParticleType
{
    void Display(int x, int y);
}

internal sealed class ParticleTypeFlyweight(string type, string color, string texture) : IParticleType
{
    private readonly string _type = type;
    private readonly string _color = color;
    private readonly string _texture = texture;

    public void Display(int x, int y)
        => Console.WriteLine($"  [{_type,5}] color={_color,5} texture={_texture,-10} at ({x},{y})");
}

internal sealed class ParticleTypeFactory
{
    private readonly Dictionary<string, IParticleType> _cache = new();
    public int UniqueCount => _cache.Count;

    public IParticleType Get(string type)
    {
        if (!_cache.TryGetValue(type, out IParticleType? fw))
        {
            (string color, string texture) = type switch
            {
                "fire"  => ("red",   "fire.png"),
                "smoke" => ("grey",  "smoke.png"),
                "snow"  => ("white", "snow.png"),
                _       => ("black", "default.png"),
            };
            fw = new ParticleTypeFlyweight(type, color, texture);
            _cache[type] = fw;
        }
        return fw;
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// Flat model record
// ─────────────────────────────────────────────────────────────────────────────

internal sealed record UniqueOrder(int Id, string Product, int Qty, decimal Price);
