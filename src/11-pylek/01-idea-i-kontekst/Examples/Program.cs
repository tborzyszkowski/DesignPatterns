using System.Collections.Concurrent;

Console.WriteLine("=== Flyweight - idea i kontekst ===");

var factory = new GlyphFactory();
var text = "AABACA";

for (int i = 0; i < text.Length; i++)
{
    char symbol = text[i];
    IGlyph glyph = factory.Get(symbol, "Arial");

    // Position and color are extrinsic state provided by the client.
    int x = 10 + i * 12;
    int y = 20;
    string color = i % 2 == 0 ? "black" : "blue";

    glyph.Draw(x, y, 14, color);
}

Console.WriteLine();
Console.WriteLine($"Unique flyweights: {factory.UniqueCount}");
Console.WriteLine($"Total draw calls: {text.Length}");

internal interface IGlyph
{
    void Draw(int x, int y, int pointSize, string color);
}

internal sealed class GlyphFlyweight(char symbol, string fontFamily) : IGlyph
{
    private readonly char _symbol = symbol;
    private readonly string _fontFamily = fontFamily;

    public void Draw(int x, int y, int pointSize, string color)
    {
        Console.WriteLine(
            $"Draw '{_symbol}' font={_fontFamily} at ({x},{y}) size={pointSize} color={color}");
    }
}

internal sealed class GlyphFactory
{
    private readonly ConcurrentDictionary<GlyphKey, IGlyph> _cache = new();

    public int UniqueCount => _cache.Count;

    public IGlyph Get(char symbol, string fontFamily)
    {
        var key = new GlyphKey(symbol, fontFamily);
        return _cache.GetOrAdd(key, k => new GlyphFlyweight(k.Symbol, k.FontFamily));
    }

    internal readonly record struct GlyphKey(char Symbol, string FontFamily);
}
