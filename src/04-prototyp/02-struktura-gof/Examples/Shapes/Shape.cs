namespace StrukturaGoF.Shapes;

// ── GoF: Prototype interface ─────────────────────────────────────────────────

/// <summary>
/// Interfejs Prototype — deklaruje kontrakt klonowania.
/// Klient programuje do tego interfejsu, nie zna konkretnych typów kształtów.
/// </summary>
public interface IShape
{
    IShape Clone();
    string Draw();
    void   MoveTo(int x, int y);
}

// ── Abstrakcyjna klasa bazowa z konstruktorem kopiującym ─────────────────────

/// <summary>
/// Bazowy kształt. Kluczowy element: protected copy constructor.
/// Każda klasa pochodna wywołuje base(source) zamiast duplikować logikę kopiowania.
/// </summary>
public abstract class Shape : IShape
{
    public int    X     { get; protected set; }
    public int    Y     { get; protected set; }
    public string Color { get; protected set; }

    // Normalny konstruktor
    protected Shape(int x, int y, string color)
        => (X, Y, Color) = (x, y, color);

    // Konstruktor kopiujący — tylko do użytku przez Clone()
    protected Shape(Shape source)
        => (X, Y, Color) = (source.X, source.Y, source.Color);

    public abstract IShape Clone();
    public abstract string Draw();

    public void MoveTo(int x, int y) => (X, Y) = (x, y);
}

// ── Konkretne kształty ───────────────────────────────────────────────────────

public sealed class Circle : Shape
{
    public double Radius { get; private set; }

    public Circle(int x, int y, string color, double radius)
        : base(x, y, color) => Radius = radius;

    // Konstruktor kopiujący — wywoływany przez Clone()
    private Circle(Circle source) : base(source) => Radius = source.Radius;

    public override IShape Clone() => new Circle(this);

    public override string Draw() =>
        $"Koło: środek=({X},{Y}), promień={Radius}, kolor={Color}";
}

public sealed class Rectangle : Shape
{
    public double Width  { get; private set; }
    public double Height { get; private set; }

    public Rectangle(int x, int y, string color, double width, double height)
        : base(x, y, color) => (Width, Height) = (width, height);

    private Rectangle(Rectangle source) : base(source)
        => (Width, Height) = (source.Width, source.Height);

    public override IShape Clone() => new Rectangle(this);

    public override string Draw() =>
        $"Prostokąt: lewy-górny=({X},{Y}), {Width}×{Height}, kolor={Color}";
}

public sealed class Polygon : Shape
{
    // Uwaga: lista punktów — musimy ją głęboko skopiować!
    public IReadOnlyList<(int X, int Y)> Points { get; private set; }

    public Polygon(int x, int y, string color, IEnumerable<(int, int)> points)
        : base(x, y, color)
        => Points = points.ToList().AsReadOnly();

    private Polygon(Polygon source) : base(source)
        // głęboka kopia listy punktów (krotki są value type, więc to wystarczy)
        => Points = new List<(int, int)>(source.Points).AsReadOnly();

    public override IShape Clone() => new Polygon(this);

    public override string Draw()
    {
        var pts = string.Join(", ", Points.Select(p => $"({p.X},{p.Y})"));
        return $"Wielokąt: przesunięcie=({X},{Y}), punkty=[{pts}], kolor={Color}";
    }
}

// ── Prototype Registry (wzorzec "Prototype Manager") ─────────────────────────

/// <summary>
/// Rejestr prototypów — przechowuje szablonowe egzemplarze.
/// Klient pobiera klon przez klucz (nazwę), nie tworząc obiektu ręcznie.
/// </summary>
public sealed class ShapeRegistry
{
    private readonly Dictionary<string, IShape> _registry = [];

    public void Register(string key, IShape prototype)
        => _registry[key] = prototype;

    /// <summary>Zwraca oryginalny prototyp (nie klon).</summary>
    public IShape GetPrototype(string key) => _registry[key];

    /// <summary>Zwraca KLON prototypu — gotowy do użycia.</summary>
    public IShape Clone(string key) => _registry[key].Clone();

    public IReadOnlyCollection<string> Keys => _registry.Keys;
}
