// ============================================================
// Wzorzec Odwiedzający — Temat 02: Kiedy stosować, zalety i wady
// Przykłady sygnałów wskazujących i kontra-przykłady
// ============================================================

// ═══════════════════════════════════════════════════════════
// SYGNAŁ 1: Wiele operacji na stabilnej hierarchii — DOBRY przypadek
// ═══════════════════════════════════════════════════════════

Console.WriteLine("══════════════════════════════════════════");
Console.WriteLine(" DOBRY PRZYPADEK: wiele operacji, stabilna hierarchia");
Console.WriteLine("══════════════════════════════════════════\n");

var doc = new List<IDocElement>
{
    new TextNode("Witaj na stronie wzorców projektowych"),
    new ImageNode("visitor.png", 800),
    new LinkNode("https://refactoring.guru", "Refactoring Guru"),
    new ImageNode("broken.jpg", -1),
    new TextNode(""),
};

var wc = new WordCountVisitor(); doc.ForEach(d => d.Accept(wc));
Console.WriteLine($"Liczba słów: {wc.Count}");

var html = new HtmlVisitor(); doc.ForEach(d => d.Accept(html));
Console.WriteLine($"HTML:\n  {html.Html}\n");

var val = new ValidateVisitor(); doc.ForEach(d => d.Accept(val));
Console.WriteLine($"Błędy walidacji ({val.Errors.Count}):");
val.Errors.ForEach(e => Console.WriteLine($"  [!] {e}"));

// ═══════════════════════════════════════════════════════════
// SYGNAŁ 2: Wada — dodanie nowego elementu łamie odwiedzających
// ═══════════════════════════════════════════════════════════

Console.WriteLine("\n══════════════════════════════════════════");
Console.WriteLine(" WADA: niestabilna hierarchia");
Console.WriteLine("══════════════════════════════════════════\n");

Console.WriteLine("""
  SCENARIUSZ: co jeśli dodamy 'VideoNode' do dokumentu?

  interface IDocVisitor {
      void Visit(TextNode n);
      void Visit(ImageNode n);
      void Visit(LinkNode n);
      void Visit(VideoNode n);  // <-- NOWA LINIA
  }

  Skutek: WSZYSTKIE klasy implementujące IDocVisitor
  (WordCountVisitor, HtmlVisitor, ValidateVisitor, ...)
  muszą teraz dodać metodę Visit(VideoNode n)!

  To jest koszt wzorca. Warto go stosować gdy:
  - hierarchia elementów jest STABILNA
  - operacji przybywa często
""");

// ═══════════════════════════════════════════════════════════
// ZALETA: gromadzenie stanu przez odwiedzającego
// ═══════════════════════════════════════════════════════════

Console.WriteLine("══════════════════════════════════════════");
Console.WriteLine(" ZALETA: odwiedzający może gromadzić stan");
Console.WriteLine("══════════════════════════════════════════\n");

var stats = new StatsVisitor();
doc.ForEach(d => d.Accept(stats));
stats.Print();

// ─── Typy ──────────────────────────────────────────────────

interface IDocElement { void Accept(IDocVisitor v); }
record TextNode(string Content) : IDocElement   { public void Accept(IDocVisitor v) => v.Visit(this); }
record ImageNode(string Src, int Width) : IDocElement { public void Accept(IDocVisitor v) => v.Visit(this); }
record LinkNode(string Href, string Text) : IDocElement { public void Accept(IDocVisitor v) => v.Visit(this); }

interface IDocVisitor
{
    void Visit(TextNode n);
    void Visit(ImageNode n);
    void Visit(LinkNode n);
}

class WordCountVisitor : IDocVisitor
{
    public int Count { get; private set; }
    public void Visit(TextNode n)  => Count += n.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    public void Visit(ImageNode n) { }
    public void Visit(LinkNode n)  => Count += n.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
}

class HtmlVisitor : IDocVisitor
{
    public System.Text.StringBuilder Html { get; } = new();
    public void Visit(TextNode n)  => Html.Append($"<p>{n.Content}</p>");
    public void Visit(ImageNode n) => Html.Append($"<img src=\"{n.Src}\" width=\"{n.Width}\">");
    public void Visit(LinkNode n)  => Html.Append($"<a href=\"{n.Href}\">{n.Text}</a>");
}

class ValidateVisitor : IDocVisitor
{
    public List<string> Errors { get; } = [];
    public void Visit(TextNode n)  { if (string.IsNullOrWhiteSpace(n.Content)) Errors.Add("Pusty węzeł tekstu!"); }
    public void Visit(ImageNode n) { if (n.Width <= 0) Errors.Add($"Obraz {n.Src}: nieprawidłowa szerokość {n.Width}"); }
    public void Visit(LinkNode n)  { if (!n.Href.StartsWith("http")) Errors.Add($"Link {n.Href}: brak protokołu"); }
}

class StatsVisitor : IDocVisitor
{
    public int TextCount  { get; private set; }
    public int ImageCount { get; private set; }
    public int LinkCount  { get; private set; }
    public int TotalWords { get; private set; }

    public void Visit(TextNode n)  { TextCount++;  TotalWords += n.Content.Split(' ').Length; }
    public void Visit(ImageNode n) { ImageCount++; }
    public void Visit(LinkNode n)  { LinkCount++;  TotalWords += n.Text.Split(' ').Length; }

    public void Print()
    {
        Console.WriteLine($"  Tekst: {TextCount}, Obrazy: {ImageCount}, Linki: {LinkCount}");
        Console.WriteLine($"  Łączna liczba słów: {TotalWords}");
    }
}
