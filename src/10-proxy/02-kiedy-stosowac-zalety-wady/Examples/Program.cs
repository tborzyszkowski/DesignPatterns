// Demonstrates a Virtual Proxy: the heavy RealSubject is created lazily,
// only when the client actually calls Display() for the first time.
//
// This illustrates why Proxy is the right choice when:
//   - Creation is expensive (disk I/O, network, DB connection …)
//   - The client should not care about when initialisation happens.
//   - You want to defer cost without changing the client contract.

Console.WriteLine("=== Virtual Proxy - kiedy stosowac ===");
Console.WriteLine();

// Client works only on IImage — no knowledge of how/when loading occurs.
IImage banner = new ImageProxy("hero-banner.png");
IImage logo   = new ImageProxy("company-logo.png");

Console.WriteLine("Proxy objects created. No disk load yet.");
Console.WriteLine();

// First Display: RealImage is created here (lazy init).
Console.WriteLine("--- First Display (lazy init triggers) ---");
banner.Display();
Console.WriteLine();

// Second Display: RealImage already exists, no loading cost.
Console.WriteLine("--- Second Display (no reload) ---");
banner.Display();
Console.WriteLine();

// logo was never displayed — RealImage was never created.
Console.WriteLine("logo was referenced but never displayed: no I/O performed.");
_ = logo; // suppress unused variable warning — intentional non-use shown to student.

Console.WriteLine();
Console.WriteLine("Wniosek: Proxy odroczyl koszt inicjalizacji do momentu rzeczywistego uzycia.");

// ── Subject ───────────────────────────────────────────────────────────────────

internal interface IImage
{
    void Display();
}

// ── RealSubject (expensive to create) ────────────────────────────────────────

internal sealed class RealImage(string path) : IImage
{
    private readonly string _path = path;

    // Simulates expensive I/O during construction.
    static RealImage()
    {
        // no-op: static ctor present only to mark the type deliberate
    }

    public static RealImage Load(string path)
    {
        Console.WriteLine($"Loading image from disk: {path}");
        Thread.Sleep(200); // simulate I/O cost
        return new RealImage(path);
    }

    public void Display()
        => Console.WriteLine($"Displaying {_path}");
}

// ── Virtual Proxy ─────────────────────────────────────────────────────────────

internal sealed class ImageProxy(string path) : IImage
{
    private readonly string _path = path;
    private RealImage? _real;

    public void Display()
    {
        _real ??= RealImage.Load(_path); // lazy init: only when first needed
        _real.Display();
    }
}
