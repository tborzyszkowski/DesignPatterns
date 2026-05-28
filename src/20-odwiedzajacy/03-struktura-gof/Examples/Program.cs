// ============================================================
// Wzorzec Odwiedzający — Temat 03: Struktura GoF
// Kompletny przykład: elementy dokumentu + odwiedzający
// ============================================================

// ─── Program główny ──────────────────────────────────────────

var doc = new Document();
doc.Add(new Heading("Wzorzec Odwiedzający", 1));
doc.Add(new Paragraph("Wzorzec Visitor pozwala definiować nowe operacje bez modyfikacji klas elementów."));
doc.Add(new Heading("Przykład kodu", 2));
doc.Add(new CodeBlock("""
    shapes.ForEach(s => s.Accept(areaVisitor));
    Console.WriteLine(areaVisitor.TotalArea);
    """, "csharp"));
doc.Add(new Paragraph("Powyższy kod oblicza łączne pole wszystkich figur."));
doc.Add(new Image("diagrams/visitor_class.png", "Diagram klas wzorca Visitor"));

Console.WriteLine("=== Wzorzec Odwiedzający — Struktura GoF ===\n");

// Odwiedzający 1: HTML
Console.WriteLine("--- Eksport HTML ---");
var htmlVisitor = new HtmlExportVisitor();
doc.Accept(htmlVisitor);
Console.WriteLine(htmlVisitor.Html);

// Odwiedzający 2: Markdown
Console.WriteLine("\n--- Eksport Markdown ---");
var mdVisitor = new MarkdownExportVisitor();
doc.Accept(mdVisitor);
Console.WriteLine(mdVisitor.Markdown);

// Odwiedzający 3: Statystyki
Console.WriteLine("--- Statystyki dokumentu ---");
var statsVisitor = new DocumentStatsVisitor();
doc.Accept(statsVisitor);
statsVisitor.PrintStats();

Console.WriteLine("""

=== Struktura GoF w tym przykładzie ===
  IDocVisitor         → IDocVisitor (interfejs)
  HtmlExportVisitor   → ConcreteVisitor1
  MarkdownExportVisitor → ConcreteVisitor2
  DocumentStatsVisitor → ConcreteVisitor3
  IDocElement         → IElement (interfejs)
  Paragraph, Heading,
  CodeBlock, Image    → ConcreteElement*
  Document            → ObjectStructure
""");

// ─── Typy ──────────────────────────────────────────────────

interface IDocVisitor
{
    void Visit(Paragraph p);
    void Visit(Heading h);
    void Visit(CodeBlock cb);
    void Visit(Image img);
}

interface IDocElement
{
    void Accept(IDocVisitor visitor);
}

record Paragraph(string Text) : IDocElement
{
    public void Accept(IDocVisitor visitor) => visitor.Visit(this);
}

record Heading(string Text, int Level) : IDocElement
{
    public void Accept(IDocVisitor visitor) => visitor.Visit(this);
}

record CodeBlock(string Code, string Language) : IDocElement
{
    public void Accept(IDocVisitor visitor) => visitor.Visit(this);
}

record Image(string Path, string AltText) : IDocElement
{
    public void Accept(IDocVisitor visitor) => visitor.Visit(this);
}

class Document
{
    private readonly List<IDocElement> _elements = [];
    public void Add(IDocElement element) => _elements.Add(element);
    public void Accept(IDocVisitor visitor) => _elements.ForEach(e => e.Accept(visitor));
}

class HtmlExportVisitor : IDocVisitor
{
    private readonly System.Text.StringBuilder _html = new();
    public string Html => $"<!DOCTYPE html><html><body>\n{_html}</body></html>";

    public void Visit(Paragraph p)  => _html.AppendLine($"  <p>{p.Text}</p>");
    public void Visit(Heading h)    => _html.AppendLine($"  <h{h.Level}>{h.Text}</h{h.Level}>");
    public void Visit(CodeBlock cb) => _html.AppendLine($"  <pre><code class=\"{cb.Language}\">{cb.Code}</code></pre>");
    public void Visit(Image img)    => _html.AppendLine($"  <img src=\"{img.Path}\" alt=\"{img.AltText}\">");
}

class MarkdownExportVisitor : IDocVisitor
{
    private readonly System.Text.StringBuilder _md = new();
    public string Markdown => _md.ToString();

    public void Visit(Paragraph p)  => _md.AppendLine(p.Text).AppendLine();
    public void Visit(Heading h)    => _md.AppendLine($"{new string('#', h.Level)} {h.Text}").AppendLine();
    public void Visit(CodeBlock cb) => _md.AppendLine($"```{cb.Language}").AppendLine(cb.Code).AppendLine("```").AppendLine();
    public void Visit(Image img)    => _md.AppendLine($"![{img.AltText}]({img.Path})").AppendLine();
}

class DocumentStatsVisitor : IDocVisitor
{
    public int ParagraphCount { get; private set; }
    public int HeadingCount   { get; private set; }
    public int CodeBlockCount { get; private set; }
    public int ImageCount     { get; private set; }
    public int WordCount      { get; private set; }

    public void Visit(Paragraph p)  { ParagraphCount++; WordCount += CountWords(p.Text); }
    public void Visit(Heading h)    { HeadingCount++;   WordCount += CountWords(h.Text); }
    public void Visit(CodeBlock cb) => CodeBlockCount++;
    public void Visit(Image img)    => ImageCount++;

    private static int CountWords(string text)
        => text.Split([' ', '\t', '\n'], StringSplitOptions.RemoveEmptyEntries).Length;

    public void PrintStats()
    {
        Console.WriteLine($"  Paragrafy:  {ParagraphCount}");
        Console.WriteLine($"  Nagłówki:   {HeadingCount}");
        Console.WriteLine($"  Bloki kodu: {CodeBlockCount}");
        Console.WriteLine($"  Obrazy:     {ImageCount}");
        Console.WriteLine($"  Słowa:      {WordCount}");
    }
}
