// =========================================================================
// Zasada Otwarte-Zamknięte (OCP) — demonstracja
// =========================================================================

using OpenClosed.WithoutOcp;
using WithoutOcp = OpenClosed.WithoutOcp;
using WithOcp = OpenClosed.WithOcp;

Console.WriteLine("=== BEZ OCP (naruszenie) ===");
Console.WriteLine("Dodanie nowego typu przesyłki wymaga MODYFIKACJI OrderProcessor\n");

var badProcessor = new WithoutOcp.OrderProcessor();
var order1 = new WithoutOcp.Order("C001", 150m, "Warszawa");

badProcessor.ProcessOrder(order1, ShippingType.Standard);
badProcessor.ProcessOrder(order1, ShippingType.Express);
badProcessor.ProcessOrder(order1, ShippingType.International);

Console.WriteLine();
Console.WriteLine("=== Z OCP (poprawnie) ===");
Console.WriteLine("Nowy typ przesyłki = nowa klasa, zero ingerencji w OrderProcessor\n");

// Rejestracja dostępnych strategii — można ją łatwo przenieść do konfiguracji DI
var calculators = new WithOcp.IShippingCalculator[]
{
    new WithOcp.StandardShipping(),
    new WithOcp.ExpressShipping(),
    new WithOcp.OvernightShipping(),
    new WithOcp.FreeShipping(),
    new WithOcp.InternationalShipping(),
    new WithOcp.SameDayShipping()   // ← new! OrderProcessor nie wie, że to dodano
};

var goodProcessor = new WithOcp.OrderProcessor(calculators);
var order2 = new WithOcp.Order("C002", 250m, "Berlin");

goodProcessor.ProcessOrder(order2, "Standard");
goodProcessor.ProcessOrder(order2, "Express");
goodProcessor.ProcessOrder(order2, "International");   // >= 200, więc 50
goodProcessor.ProcessOrder(order2, "SameDay");

Console.WriteLine();
Console.WriteLine("=== Przykład II: Kształty ===");
DemoShapes();

static void DemoShapes()
{
    // --- BEZ OCP ---
    Console.WriteLine("\n--- BEZ OCP ---");
    var badRenderer = new ShapeRendererBad();
    badRenderer.Draw("Circle");
    badRenderer.Draw("Rectangle");
    // badRenderer.Draw("Hexagon"); // <-- trzeba MODYFIKOWAĆ renderer

    // --- Z OCP ---
    Console.WriteLine("\n--- Z OCP ---");
    var goodRenderer = new ShapeRendererGood();
    IShape[] shapes = [ new Circle(), new Rectangle(), new Triangle(), new Hexagon() ];
    foreach (var shape in shapes)
        goodRenderer.Draw(shape);
}

// ---- Shapes demo classes (inline for brevity) ----

class ShapeRendererBad
{
    public void Draw(string shape)
    {
        if (shape == "Circle")    Console.WriteLine("Rysuję koło");
        else if (shape == "Rectangle") Console.WriteLine("Rysuję prostokąt");
        // Nowy kształt → modyfikacja tego kodu!
        else Console.WriteLine($"Nieznany kształt: {shape}");
    }
}

interface IShape { void Draw(); }

class Circle    : IShape { public void Draw() => Console.WriteLine("Rysuję koło");        }
class Rectangle : IShape { public void Draw() => Console.WriteLine("Rysuję prostokąt");   }
class Triangle  : IShape { public void Draw() => Console.WriteLine("Rysuję trójkąt");     }
class Hexagon   : IShape { public void Draw() => Console.WriteLine("Rysuję sześciokąt");  }

class ShapeRendererGood
{
    // Ta metoda NIGDY nie musi być zmieniana
    public void Draw(IShape shape) => shape.Draw();
}
