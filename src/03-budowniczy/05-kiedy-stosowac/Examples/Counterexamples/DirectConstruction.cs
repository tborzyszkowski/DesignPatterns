namespace KiedyStosowac.Counterexamples;

// ── PRZYPADEK 1: Obiekt z 2 polami — Builder to przerost formy ─────────────

// ŹLE — niepotrzebny builder dla prostego obiektu
public sealed class PointBuilder
{
    private double _x, _y;
    public PointBuilder WithX(double x) { _x = x; return this; }
    public PointBuilder WithY(double y) { _y = y; return this; }
    public Point2D Build() => new(_x, _y);
}

// DOBRZE — konstruktor jest wystarczający
public readonly record struct Point2D(double X, double Y);

// ── PRZYPADEK 2: Obiekt z named parameters — żaden builder nie jest potrzebny

// ŹLE
public sealed class ColorBuilder
{
    private byte _r, _g, _b, _a = 255;
    public ColorBuilder Red(byte r) { _r = r; return this; }
    public ColorBuilder Green(byte g) { _g = g; return this; }
    public ColorBuilder Blue(byte b) { _b = b; return this; }
    public ColorBuilder Alpha(byte a) { _a = a; return this; }
    public Color Build() => new(_r, _g, _b, _a);
}

// DOBRZE — C# named arguments zapewniają czytelność
public readonly record struct Color(byte R, byte G, byte B, byte A = 255);

// ── PRZYPADEK 3: Data Transfer Object — object initializer wykstarczy ──────

// ŹLE — builder dla obiektu konfiguracyjnego bez walidacji
public sealed class ApiOptionsBuilder
{
    private string _baseUrl = string.Empty;
    private int _timeout = 30;
    private bool _retry;
    public ApiOptionsBuilder WithBaseUrl(string url) { _baseUrl = url; return this; }
    public ApiOptionsBuilder WithTimeout(int s) { _timeout = s; return this; }
    public ApiOptionsBuilder WithRetry() { _retry = true; return this; }
    public ApiOptions Build() => new() { BaseUrl = _baseUrl, TimeoutSeconds = _timeout, EnableRetry = _retry };
}

// DOBRZE — object initializer jest prostszy gdy nie ma walidacji ani wymaganej kolejności
public class ApiOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; } = 30;
    public bool EnableRetry { get; set; }
}

// ── Klasa demonstracyjna ───────────────────────────────────────────────────

public static class CounterexamplesDemo
{
    public static void Run()
    {
        Console.WriteLine("=== Kiedy Builder jest przerostem formy ===\n");

        // Punkt: konstruktor jest naturalny
        var pointGood = new Point2D(3.0, 4.5);
        var pointBad  = new PointBuilder().WithX(3.0).WithY(4.5).Build();
        Console.WriteLine($"Punkt (konstruktor):  {pointGood}");
        Console.WriteLine($"Punkt (builder):      {pointBad}");
        Console.WriteLine("→ Obie wersje działają, ale konstruktor jest prostszy.\n");

        // Kolor: named arguments eliminują pomyłki kolejności
        var colorGood = new Color(R: 255, G: 128, B:   0);
        var colorBad  = new ColorBuilder().Red(255).Green(128).Blue(0).Build();
        Console.WriteLine($"Kolor (named args):  {colorGood}");
        Console.WriteLine($"Kolor (builder):     {colorBad}");
        Console.WriteLine("→ Named arguments rozwiązują problem czytelności bez dodatkowej klasy.\n");

        // Opcje: object initializer
        var optGood = new ApiOptions { BaseUrl = "https://api.example.com", TimeoutSeconds = 60, EnableRetry = true };
        var optBad  = new ApiOptionsBuilder().WithBaseUrl("https://api.example.com").WithTimeout(60).WithRetry().Build();
        Console.WriteLine($"Opcje (initializer):  BaseUrl={optGood.BaseUrl}, Retry={optGood.EnableRetry}");
        Console.WriteLine($"Opcje (builder):      BaseUrl={optBad.BaseUrl}, Retry={optBad.EnableRetry}");
        Console.WriteLine("→ Object initializer wystarcza gdy walidacja nie jest potrzebna.\n");
    }
}
