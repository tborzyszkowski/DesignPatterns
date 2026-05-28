// ============================================================
// Wzorzec Odwiedzający — Temat 04: Cztery typy implementacji
// Ten sam problem (obliczanie pola figur) w czterech stylach
// ============================================================

var shapes = new List<IShape>
{
    new Circle(5.0),
    new Rectangle(4.0, 6.0),
    new Triangle(3.0, 4.0, 5.0),
};

// ═══════════════════════════════════════════════════════════
// TYP 1: Klasyczny GoF (void + akumulacja stanu)
// ═══════════════════════════════════════════════════════════

Console.WriteLine("── Typ 1: Klasyczny GoF (void + stan) ──");

var v1 = new AreaVisitorVoid();
shapes.ForEach(s => s.Accept(v1));
Console.WriteLine($"  Łączne pole (GoF void) = {v1.TotalArea:F2}\n");

// ═══════════════════════════════════════════════════════════
// TYP 2: Generyczny Visitor (zwraca TResult)
// ═══════════════════════════════════════════════════════════

Console.WriteLine("── Typ 2: Generyczny Visitor (IVisitor<TResult>) ──");

var areaV2 = new AreaVisitorGeneric();
var descV2 = new DescriptionVisitorGeneric();
double totalV2 = shapes.Sum(s => s.Accept(areaV2));
Console.WriteLine($"  Łączne pole (generyczny) = {totalV2:F2}");
Console.WriteLine($"  Opisy: {string.Join(", ", shapes.Select(s => s.Accept(descV2)))}\n");

// ═══════════════════════════════════════════════════════════
// TYP 3: Funkcyjny Visitor (delegaty w słowniku)
// ═══════════════════════════════════════════════════════════

Console.WriteLine("── Typ 3: Funkcyjny Visitor (Dictionary<Type, Func>) ──");

var areaFuncV = new FuncVisitor<double>()
    .Register<Circle>(c => Math.PI * c.Radius * c.Radius)
    .Register<Rectangle>(r => r.Width * r.Height)
    .Register<Triangle>(t => { double s = (t.A + t.B + t.C) / 2; return Math.Sqrt(s * (s - t.A) * (s - t.B) * (s - t.C)); });

double totalV3 = shapes.Sum(s => areaFuncV.Visit(s));
Console.WriteLine($"  Łączne pole (funkcyjny) = {totalV3:F2}");
Console.WriteLine("  Zaleta: nie wymaga interfejsu na elementach!");
Console.WriteLine("  Wada: brak weryfikacji w czasie kompilacji.\n");

// ═══════════════════════════════════════════════════════════
// TYP 4: C# pattern matching (switch expression)
// ═══════════════════════════════════════════════════════════

Console.WriteLine("── Typ 4: C# pattern matching (switch expression) ──");

static double TriangleArea(double a, double b, double c) { double s = (a + b + c) / 2.0; return Math.Sqrt(s * (s - a) * (s - b) * (s - c)); }

static double CalculateArea(IShape shape) => shape switch
{
    Circle c    => Math.PI * c.Radius * c.Radius,
    Rectangle r => r.Width * r.Height,
    Triangle t  => TriangleArea(t.A, t.B, t.C),
    _           => throw new ArgumentException($"Nieznany kształt: {shape}")
};

static string Describe(IShape shape) => shape switch
{
    Circle c    => $"Koło(r={c.Radius:F2})",
    Rectangle r => $"Prostokąt({r.Width:F2}x{r.Height:F2})",
    Triangle t  => $"Trójkąt({t.A:F2},{t.B:F2},{t.C:F2})",
    _           => "Nieznany"
};

double totalV4 = shapes.Sum(CalculateArea);
Console.WriteLine($"  Łączne pole (pattern matching) = {totalV4:F2}");
Console.WriteLine($"  Opisy: {string.Join(", ", shapes.Select(Describe))}");
Console.WriteLine("  Zaleta: zwięzły kod. Wada: rozproszone przy wielu operacjach.\n");

Console.WriteLine("""
══════════════════════════════════════════════════════
PODSUMOWANIE: wszystkie 4 podejścia dają ten sam wynik

  Typ 1 (GoF void)      → użyj gdy: gromadzisz stan, large hierarchia
  Typ 2 (Generyczny)    → użyj gdy: operacja zwraca wartość, czyste funkcje
  Typ 3 (Funkcyjny)     → użyj gdy: nie masz kontroli nad elementami
  Typ 4 (switch/match)  → użyj gdy: prosta operacja, małe hierarchie
══════════════════════════════════════════════════════
""");

// ─── Typy ──────────────────────────────────────────────────

interface IShape { }
record Circle(double Radius) : IShape;
record Rectangle(double Width, double Height) : IShape;
record Triangle(double A, double B, double C) : IShape;

// Typ 1: GoF void
interface IShapeVisitorVoid
{
    void Visit(Circle c);
    void Visit(Rectangle r);
    void Visit(Triangle t);
}

static class ShapeExtensions
{
    public static void Accept(this IShape shape, IShapeVisitorVoid v)
    {
        switch (shape)
        {
            case Circle c:    v.Visit(c); break;
            case Rectangle r: v.Visit(r); break;
            case Triangle t:  v.Visit(t); break;
        }
    }
}

class AreaVisitorVoid : IShapeVisitorVoid
{
    public double TotalArea { get; private set; }

    public void Visit(Circle c)    => TotalArea += Math.PI * c.Radius * c.Radius;
    public void Visit(Rectangle r) => TotalArea += r.Width * r.Height;
    public void Visit(Triangle t)
    {
        double s = (t.A + t.B + t.C) / 2.0;
        TotalArea += Math.Sqrt(s * (s - t.A) * (s - t.B) * (s - t.C));
    }
}

// Typ 2: Generyczny
interface IShapeVisitor<TResult>
{
    TResult Visit(Circle c);
    TResult Visit(Rectangle r);
    TResult Visit(Triangle t);
}

static class ShapeExtensions2
{
    public static TResult Accept<TResult>(this IShape shape, IShapeVisitor<TResult> v)
        => shape switch
        {
            Circle c    => v.Visit(c),
            Rectangle r => v.Visit(r),
            Triangle t  => v.Visit(t),
            _           => throw new ArgumentException($"Nieznany kształt: {shape}")
        };
}

class AreaVisitorGeneric : IShapeVisitor<double>
{
    public double Visit(Circle c)    => Math.PI * c.Radius * c.Radius;
    public double Visit(Rectangle r) => r.Width * r.Height;
    public double Visit(Triangle t)
    {
        double s = (t.A + t.B + t.C) / 2.0;
        return Math.Sqrt(s * (s - t.A) * (s - t.B) * (s - t.C));
    }
}

class DescriptionVisitorGeneric : IShapeVisitor<string>
{
    public string Visit(Circle c)    => $"Koło(r={c.Radius:F2})";
    public string Visit(Rectangle r) => $"Prostokąt({r.Width:F2}x{r.Height:F2})";
    public string Visit(Triangle t)  => $"Trójkąt({t.A:F2},{t.B:F2},{t.C:F2})";
}

// Typ 3: Funkcyjny
class FuncVisitor<TResult>
{
    private readonly Dictionary<Type, Func<object, TResult>> _handlers = [];

    public FuncVisitor<TResult> Register<T>(Func<T, TResult> handler)
    {
        _handlers[typeof(T)] = obj => handler((T)obj);
        return this;
    }

    public TResult Visit(object element)
    {
        if (_handlers.TryGetValue(element.GetType(), out var handler))
            return handler(element);
        throw new InvalidOperationException($"Brak handlera dla {element.GetType().Name}");
    }
}
