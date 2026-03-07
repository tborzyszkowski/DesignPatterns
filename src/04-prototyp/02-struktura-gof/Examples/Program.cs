using StrukturaGoF.Shapes;

// ─────────────────────────────────────────────────────────────────────────────
// 1. Klasyczny GoF Prototype — klonowanie pojedynczych obiektów
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== 1. Klasyczny GoF Prototype ===\n");

var originalCircle = new Circle(0, 0, "red", radius: 50);
Console.WriteLine($"Oryginał:  {originalCircle.Draw()}");

// Klon — klient używa IShape.Clone(), nie zna konkretnego typu
IShape cloneA = originalCircle.Clone();
cloneA.MoveTo(100, 200);
Console.WriteLine($"Klon A:    {cloneA.Draw()}");
Console.WriteLine($"Oryginał po przesunięciu klonu: {originalCircle.Draw()}");
Console.WriteLine($"(oryginał nienaruszony: X={((Circle)originalCircle).X}, Y={((Circle)originalCircle).Y})\n");

// Klonowanie kształtu złożonego (Polygon z listą punktów)
var triangle = new Polygon(10, 10, "blue", [(0,0), (50,0), (25,43)]);
var cloneTriangle = triangle.Clone();
Console.WriteLine($"Trójkąt oryg.: {triangle.Draw()}");
Console.WriteLine($"Trójkąt klon:  {cloneTriangle.Draw()}\n");

// ─────────────────────────────────────────────────────────────────────────────
// 2. Prototype Registry (Prototype Manager)
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== 2. Prototype Registry ===\n");

var registry = new ShapeRegistry();

// Rejestracja szablonów (robi się raz, np. przy starcie aplikacji)
registry.Register("mały-czerwony-okrąg",    new Circle(0, 0, "red",   25));
registry.Register("duży-niebieski-okrąg",   new Circle(0, 0, "blue", 100));
registry.Register("szary-prostokąt",        new Rectangle(0, 0, "gray", 80, 40));
registry.Register("zielony-trójkąt",        new Polygon(0, 0, "green", [(0,0),(60,0),(30,52)]));

Console.WriteLine($"Zarejestrowane prototypy: {string.Join(", ", registry.Keys)}\n");

// Klient klonuje po kluczu — nie wie, że to Circle, Rectangle czy Polygon
var shapes = new List<IShape>();
for (int i = 0; i < 3; i++)
{
    IShape s = registry.Clone("mały-czerwony-okrąg");
    s.MoveTo(i * 60, i * 30);
    shapes.Add(s);
}

Console.WriteLine("Trzy klony 'mały-czerwony-okrąg' w różnych pozycjach:");
foreach (var s in shapes)
    Console.WriteLine($"  {s.Draw()}");

Console.WriteLine();

// ─────────────────────────────────────────────────────────────────────────────
// 3. Kluczowa zaleta: klient nie zna konkretnych typów
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== 3. Polimorficzne klonowanie bez znajomości typów ===\n");

// Wszystkie kształty − niezależnie od tego, czy to Circle, Rectangle czy Polygon
// − klonujemy i rysujemy identycznie przez interfejs IShape
Console.WriteLine("Klonowanie wszystkich prototypów z rejestru:");
foreach (var key in registry.Keys)
{
    IShape clone = registry.Clone(key);
    clone.MoveTo(500, 500);
    Console.WriteLine($"  [{key}] → {clone.Draw()}");
}
