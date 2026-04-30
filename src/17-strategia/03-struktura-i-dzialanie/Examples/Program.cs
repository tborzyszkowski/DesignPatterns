// =============================================================================
// Wzorzec Strategia — 03. Struktura i działanie (GoF)
// Demonstruje: kanoniczny GoF, śledzenie wywołań, DocumentProcessor
// =============================================================================

// ─── CZĘŚĆ 1: Kanoniczny GoF — Context z IStrategy ───────────────────────────

Console.WriteLine("═══ CZĘŚĆ 1: Kanoniczny GoF — Context i IStrategy ═══\n");

// Klient tworzy strategie i kontekst
var strategyA = new ConcreteStrategyA();
var context = new Context(strategyA);

context.ExecuteStrategy("dane-wejściowe");
context.ExecuteStrategy("inne-dane");

Console.WriteLine("\n--- Podmiana strategii ---");
context.SetStrategy(new ConcreteStrategyB());
context.ExecuteStrategy("dane-po-podmianie");

context.SetStrategy(new ConcreteStrategyC());
context.ExecuteStrategy("ostatnie-dane");

// ─── CZĘŚĆ 2: Śledzenie przepływu wywołań ─────────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 2: Śledzenie przepływu wywołań ═══\n");

var log = new List<string>();
var tracingCtx = new TracingContext(new StrategyAlpha(log), log);
tracingCtx.Execute("payload-1");

Console.WriteLine("\nLog wywołań:");
log.ForEach(e => Console.WriteLine($"  {e}"));

// ─── CZĘŚĆ 3: DocumentProcessor — Context z wieloma operacjami ───────────────

Console.WriteLine("\n═══ CZĘŚĆ 3: DocumentProcessor — bardziej realistyczny Context ═══\n");

var doc = new Document("Raport sprzedaży Q3", "Dane: 1M PLN, wzrost 15%...");

var processor = new DocumentProcessor(new MarkdownExportStrategy());
Console.WriteLine(processor.Process(doc));

processor.SetExport(new HtmlExportStrategy());
Console.WriteLine(processor.Process(doc));

processor.SetExport(new PlainTextExportStrategy());
Console.WriteLine(processor.Process(doc));

// ─── CZĘŚĆ 4: Konsekwencje — dane przekazywane do strategii ──────────────────

Console.WriteLine("\n═══ CZĘŚĆ 4: Konsekwencje — sposoby przekazywania danych ═══\n");

// Sposób A: dane przez parametr metody Execute
var sorterA = new SorterContext<int>(new AscendingSort<int>());
var resultA = sorterA.Sort([5, 1, 3, 2, 4]);
Console.WriteLine("Rosnąco:  " + string.Join(", ", resultA));

// Sposób B: dane przez właściwości kontekstu (Context jako parametr)
var sorterB = new SorterContext<int>(new DescendingSort<int>());
var resultB = sorterB.Sort([5, 1, 3, 2, 4]);
Console.WriteLine("Malejąco: " + string.Join(", ", resultB));

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── Kanoniczny GoF ───────────────────────────────────────────────────────────

interface IStrategy
{
    string Execute(string context);
}

class ConcreteStrategyA : IStrategy
{
    public string Execute(string data)
    {
        var result = string.Join(",", data.Split('-').Reverse());
        Console.WriteLine($"  [A] Odwracam segmenty: '{data}' → '{result}'");
        return result;
    }
}

class ConcreteStrategyB : IStrategy
{
    public string Execute(string data)
    {
        var result = data.ToUpperInvariant();
        Console.WriteLine($"  [B] Duże litery: '{data}' → '{result}'");
        return result;
    }
}

class ConcreteStrategyC : IStrategy
{
    public string Execute(string data)
    {
        var result = new string(data.Reverse().ToArray());
        Console.WriteLine($"  [C] Odwracam znaki: '{data}' → '{result}'");
        return result;
    }
}

class Context(IStrategy strategy)
{
    private IStrategy _strategy = strategy;

    public void SetStrategy(IStrategy s) => _strategy = s;

    public string ExecuteStrategy(string data)
    {
        Console.WriteLine($"  Context.ExecuteStrategy('{data}')");
        return _strategy.Execute(data);
    }
}

// ─── Śledzenie ────────────────────────────────────────────────────────────────

interface ITracingStrategy
{
    string Execute(string payload, List<string> log);
}

class StrategyAlpha(List<string> _log) : ITracingStrategy
{
    public string Execute(string payload, List<string> log)
    {
        log.Add($"[StrategyAlpha] → Przetwarzam: {payload}");
        var result = payload.ToUpperInvariant();
        log.Add($"[StrategyAlpha] ← Wynik: {result}");
        return result;
    }
}

class TracingContext(ITracingStrategy strategy, List<string> log)
{
    public void Execute(string payload)
    {
        log.Add($"[Context] → Execute({payload})");
        var result = strategy.Execute(payload, log);
        log.Add($"[Context] ← Gotowe: {result}");
    }
}

// ─── DocumentProcessor ────────────────────────────────────────────────────────

record Document(string Title, string Content);

interface IExportStrategy
{
    string Export(Document doc);
}

class MarkdownExportStrategy : IExportStrategy
{
    public string Export(Document doc)
        => $"# {doc.Title}\n\n{doc.Content}";
}

class HtmlExportStrategy : IExportStrategy
{
    public string Export(Document doc)
        => $"<h1>{doc.Title}</h1><p>{doc.Content}</p>";
}

class PlainTextExportStrategy : IExportStrategy
{
    public string Export(Document doc)
        => $"{doc.Title.ToUpperInvariant()}\n{new string('=', doc.Title.Length)}\n{doc.Content}";
}

class DocumentProcessor(IExportStrategy exportStrategy)
{
    private IExportStrategy _export = exportStrategy;

    public void SetExport(IExportStrategy s) => _export = s;

    public string Process(Document doc)
    {
        // Context może mieć własną logikę przed/po delegacji
        var header = $"--- [{_export.GetType().Name.Replace("Strategy", "")}] ---";
        var content = _export.Export(doc);
        return $"{header}\n{content}\n";
    }
}

// ─── Sposoby przekazywania danych ─────────────────────────────────────────────

interface ISortStrategy<T> where T : IComparable<T>
{
    IList<T> Sort(IList<T> data);
}

class AscendingSort<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IList<T> data) => data.OrderBy(x => x).ToList();
}

class DescendingSort<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IList<T> data) => data.OrderByDescending(x => x).ToList();
}

class SorterContext<T>(ISortStrategy<T> strategy) where T : IComparable<T>
{
    private ISortStrategy<T> _strategy = strategy;

    public IList<T> Sort(IList<T> data) => _strategy.Sort(data);
}
