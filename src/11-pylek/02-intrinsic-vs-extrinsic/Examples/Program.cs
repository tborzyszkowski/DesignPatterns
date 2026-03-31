// Demonstrates the intrinsic/extrinsic state split.
// Intrinsic (shared): icon type and color theme.
// Extrinsic (per call): screen position and label.

Console.WriteLine("=== Intrinsic vs Extrinsic ===");
Console.WriteLine();

var factory = new ButtonIconFactory();

// Client provides extrinsic state (x, y, label) at draw time.
factory.Get("save", "blue").Draw(10, 20, "Zapisz");
factory.Get("save", "blue").Draw(50, 20, "Zapisz jako");
factory.Get("delete", "red").Draw(10, 60, "Usuń");
factory.Get("delete", "red").Draw(50, 60, "Usuń zaznaczone");
factory.Get("save", "green").Draw(10, 100, "Eksportuj");

Console.WriteLine();
Console.WriteLine($"Łącznie wywołań: 5");
Console.WriteLine($"Unikalnych flyweightów (intrinsic): {factory.UniqueCount}");
Console.WriteLine();
Console.WriteLine("Wniosek: intrinsic (iconType+theme) jest współdzielony,");
Console.WriteLine("         extrinsic (x, y, label) podaje klient przy każdym Draw().");

// ── Flyweight interface ───────────────────────────────────────────────────────

internal interface IButtonIcon
{
    // extrinsic state: x, y, label
    void Draw(int x, int y, string label);
}

// ── Concrete flyweight (stores only immutable intrinsic state) ────────────────

internal sealed class ButtonIconFlyweight(string iconType, string colorTheme) : IButtonIcon
{
    private readonly string _iconType = iconType;
    private readonly string _colorTheme = colorTheme;

    public void Draw(int x, int y, string label)
    {
        Console.WriteLine(
            $"[icon={_iconType}, theme={_colorTheme}] at ({x},{y}) label='{label}'");
    }
}

// ── Factory with cache ────────────────────────────────────────────────────────

internal sealed class ButtonIconFactory
{
    private readonly Dictionary<IconKey, IButtonIcon> _cache = new();

    public int UniqueCount => _cache.Count;

    public IButtonIcon Get(string iconType, string colorTheme)
    {
        var key = new IconKey(iconType, colorTheme);
        if (!_cache.TryGetValue(key, out IButtonIcon? icon))
        {
            icon = new ButtonIconFlyweight(iconType, colorTheme);
            _cache[key] = icon;
        }
        return icon;
    }

    private readonly record struct IconKey(string IconType, string ColorTheme);
}
