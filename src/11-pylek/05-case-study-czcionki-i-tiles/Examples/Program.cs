// Case study A: text rendering (characters as flyweights)
// Case study B: tile map (terrain tiles as flyweights)

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== Case study A: znaki tekstu ===");
Console.WriteLine();

var glyphFactory = new GlyphFactory();
string document = "HELLO WORLD";

for (int i = 0; i < document.Length; i++)
{
    char c = document[i];
    if (c == ' ') { Console.WriteLine(); continue; }

    // Extrinsic: position on screen
    IGlyph glyph = glyphFactory.Get(c, "Consolas");
    glyph.Render(x: i * 10, y: 0);
}

Console.WriteLine();
Console.WriteLine($"Znaków w dokumencie   : {document.Replace(" ", "").Length}");
Console.WriteLine($"Unikalnych flyweightów: {glyphFactory.UniqueCount}");

// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("=== Case study B: kafelki mapy (tiles) ===");
Console.WriteLine();

var tileFactory = new TileFactory();

// A tiny 4x4 map – terrain type is intrinsic, coordinates are extrinsic.
string[,] map =
{
    { "grass", "grass", "water", "water" },
    { "grass", "sand",  "sand",  "water" },
    { "sand",  "sand",  "grass", "grass" },
    { "water", "sand",  "grass", "grass" },
};

for (int row = 0; row < map.GetLength(0); row++)
{
    for (int col = 0; col < map.GetLength(1); col++)
    {
        ITile tile = tileFactory.Get(map[row, col]);
        tile.Render(col, row);
    }
}

Console.WriteLine();
Console.WriteLine($"Komórek mapy          : {map.GetLength(0) * map.GetLength(1)}");
Console.WriteLine($"Unikalnych flyweightów: {tileFactory.UniqueCount}");

// ─────────────────────────────────────────────────────────────────────────────
// Case study A – types
// ─────────────────────────────────────────────────────────────────────────────

internal interface IGlyph
{
    void Render(int x, int y);
}

internal sealed class GlyphFlyweight(char symbol, string font) : IGlyph
{
    private readonly char _symbol = symbol;
    private readonly string _font = font;

    public void Render(int x, int y)
        => Console.WriteLine($"  '{_symbol}' font={_font} at ({x},{y})");
}

internal sealed class GlyphFactory
{
    private readonly Dictionary<GlyphKey, IGlyph> _cache = new();
    public int UniqueCount => _cache.Count;

    public IGlyph Get(char symbol, string font)
    {
        var key = new GlyphKey(symbol, font);
        if (!_cache.TryGetValue(key, out IGlyph? g))
        {
            g = new GlyphFlyweight(symbol, font);
            _cache[key] = g;
        }
        return g;
    }

    private readonly record struct GlyphKey(char Symbol, string Font);
}

// ─────────────────────────────────────────────────────────────────────────────
// Case study B – types
// ─────────────────────────────────────────────────────────────────────────────

internal interface ITile
{
    void Render(int col, int row);
}

internal sealed class TerrainTile(string terrainType) : ITile
{
    private readonly string _terrainType = terrainType;

    public void Render(int col, int row)
        => Console.WriteLine($"  [{_terrainType,6}] at col={col} row={row}");
}

internal sealed class TileFactory
{
    private readonly Dictionary<string, ITile> _cache = new();
    public int UniqueCount => _cache.Count;

    public ITile Get(string terrainType)
    {
        if (!_cache.TryGetValue(terrainType, out ITile? t))
        {
            t = new TerrainTile(terrainType);
            _cache[terrainType] = t;
        }
        return t;
    }
}
