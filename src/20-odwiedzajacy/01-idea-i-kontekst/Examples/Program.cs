// ============================================================
// Wzorzec Odwiedzający — Temat 01: Idea i kontekst
// Przykład: figury geometryczne i operacje jako odwiedzający
// ============================================================

// ─── Program główny ──────────────────────────────────────────

var shapes = new List<IShape>
{
    new Circle(5.0),
    new Rectangle(4.0, 6.0),
    new Triangle(3.0, 4.0, 5.0),
    new Circle(2.5),
    new Rectangle(8.0, 3.0),
};

Console.WriteLine("=== Wzorzec Odwiedzający — Idea i kontekst ===\n");

// Operacja 1: Opis
Console.WriteLine("--- Opisy figur ---");
var desc = new DescriptionVisitor();
shapes.ForEach(s => s.Accept(desc));
desc.Lines.ToList().ForEach(Console.WriteLine);

// Operacja 2: Pole powierzchni
Console.WriteLine("\n--- Pole powierzchni ---");
var area = new AreaVisitor();
shapes.ForEach(s => s.Accept(area));
Console.WriteLine($"  Łączne pole = {area.TotalArea:F2}");

// Operacja 3: Obwód
Console.WriteLine("\n--- Obwód ---");
var perim = new PerimeterVisitor();
shapes.ForEach(s => s.Accept(perim));
Console.WriteLine($"  Łączny obwód = {perim.TotalPerimeter:F2}");

// Operacja 4: SVG (nowa, bez modyfikacji klas figur!)
Console.WriteLine("\n--- Eksport SVG ---");
var svg = new SvgExportVisitor();
shapes.ForEach(s => s.Accept(svg));
Console.WriteLine($"  {svg.Svg}");

// ─── Wyjaśnienie mechanizmu double dispatch ───────────────────
Console.WriteLine("""

=== Jak działa double dispatch? ===
Krok 1: shapes[0].Accept(areaVisitor)
        → Circle.Accept(areaVisitor)   [wybór na podstawie typu elementu: Circle]
Krok 2: areaVisitor.Visit(this)
        → AreaVisitor.Visit(Circle c)  [wybór na podstawie typu "this": Circle]

Dwa niezależne wybory metody — stąd nazwa "double dispatch".
""");

// ─── Interfejsy ──────────────────────────────────────────────

/// <summary>Element akceptujący odwiedzającego.</summary>
interface IShape
{
    void Accept(IShapeVisitor visitor);
}

/// <summary>Odwiedzający wykonujący operacje na figurach.</summary>
interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
    void Visit(Triangle triangle);
}

// ─── Elementy (hierarchia figur) ─────────────────────────────

record Circle(double Radius) : IShape
{
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

record Rectangle(double Width, double Height) : IShape
{
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

record Triangle(double A, double B, double C) : IShape
{
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

// ─── Odwiedzający — operacja 1: Pole powierzchni ─────────────

class AreaVisitor : IShapeVisitor
{
    public double TotalArea { get; private set; }

    public void Visit(Circle c)
        => TotalArea += Math.PI * c.Radius * c.Radius;

    public void Visit(Rectangle r)
        => TotalArea += r.Width * r.Height;

    public void Visit(Triangle t)
    {
        double s = (t.A + t.B + t.C) / 2.0;
        TotalArea += Math.Sqrt(s * (s - t.A) * (s - t.B) * (s - t.C));
    }
}

// ─── Odwiedzający — operacja 2: Obwód ────────────────────────

class PerimeterVisitor : IShapeVisitor
{
    public double TotalPerimeter { get; private set; }

    public void Visit(Circle c)    => TotalPerimeter += 2 * Math.PI * c.Radius;
    public void Visit(Rectangle r) => TotalPerimeter += 2 * (r.Width + r.Height);
    public void Visit(Triangle t)  => TotalPerimeter += t.A + t.B + t.C;
}

// ─── Odwiedzający — operacja 3: Opis tekstowy ────────────────

class DescriptionVisitor : IShapeVisitor
{
    private readonly List<string> _lines = [];
    public IReadOnlyList<string> Lines => _lines;

    public void Visit(Circle c)    => _lines.Add($"  Koło       : promień = {c.Radius:F2}");
    public void Visit(Rectangle r) => _lines.Add($"  Prostokąt  : {r.Width:F2} × {r.Height:F2}");
    public void Visit(Triangle t)  => _lines.Add($"  Trójkąt    : boki {t.A:F2}, {t.B:F2}, {t.C:F2}");
}

// ─── Odwiedzający — operacja 4: Eksport SVG ──────────────────

class SvgExportVisitor : IShapeVisitor
{
    private readonly System.Text.StringBuilder _sb = new();
    public string Svg => $"<svg>{_sb}</svg>";

    public void Visit(Circle c)
        => _sb.Append($"<circle cx=\"50\" cy=\"50\" r=\"{c.Radius}\"/>");
    public void Visit(Rectangle r)
        => _sb.Append($"<rect width=\"{r.Width}\" height=\"{r.Height}\"/>");
    public void Visit(Triangle t)
        => _sb.Append($"<polygon points=\"0,{t.A} {t.B},0 {t.C},{t.A}\"/>");
}
