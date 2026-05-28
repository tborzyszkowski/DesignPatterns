// =============================================================================
// Wzorzec Łańcuch Zobowiązań — 03. Struktura GoF
// Demonstruje: klasyczną strukturę GoF (Handler, BaseHandler, ConcreteHandler)
// oraz konsekwencje stosowania wzorca
// =============================================================================

Console.WriteLine("═══ Klasyczna struktura GoF — raportowanie ═══\n");

// ─── BUDOWANIE ŁAŃCUCHA ───────────────────────────────────────────────────────
// Wzorzec fluent — SetNext zwraca przekazany handler
IReportHandler htmlHandler   = new HtmlReportHandler();
IReportHandler csvHandler    = new CsvReportHandler();
IReportHandler jsonHandler   = new JsonReportHandler();
IReportHandler defaultHandler = new UnsupportedFormatHandler();

htmlHandler
    .SetNext(csvHandler)
    .SetNext(jsonHandler)
    .SetNext(defaultHandler);

// ─── WYSYŁANIE ŻĄDAŃ ──────────────────────────────────────────────────────────
string[] formats = ["html", "csv", "json", "xml", "pdf"];

foreach (var format in formats)
{
    Console.Write($"  Format '{format}': ");
    var result = htmlHandler.Handle(new ReportRequest(format, "Raport sprzedaży Q1"));
    Console.WriteLine(result ?? "(brak obsługi)");
}

Console.WriteLine("\n═══ Konsekwencja 1: Zmiana kolejności ═══\n");

// Zmiana kolejności — json handler teraz pierwszy
jsonHandler
    .SetNext(new HtmlReportHandler())
    .SetNext(new CsvReportHandler())
    .SetNext(new UnsupportedFormatHandler());

Console.Write("  Format 'html' (json jest pierwszy w łańcuchu): ");
Console.WriteLine(jsonHandler.Handle(new ReportRequest("html", "Raport")) ?? "(brak)");

Console.WriteLine("\n═══ Konsekwencja 2: Dynamiczne dodanie ogniwa ═══\n");

// Dodaj nowy handler BEZ modyfikacji istniejących klas
IReportHandler pdfHandler = new PdfReportHandler();
// Wstaw pdf między json a defaultHandler w pierwotnym łańcuchu
var chain2Html  = new HtmlReportHandler();
var chain2Csv   = new CsvReportHandler();
var chain2Json  = new JsonReportHandler();
var chain2Pdf   = new PdfReportHandler();
var chain2Def   = new UnsupportedFormatHandler();

chain2Html.SetNext(chain2Csv).SetNext(chain2Json).SetNext(chain2Pdf).SetNext(chain2Def);

foreach (var fmt in new[] { "json", "pdf", "xml" })
{
    Console.Write($"  Format '{fmt}': ");
    Console.WriteLine(chain2Html.Handle(new ReportRequest(fmt, "Raport")) ?? "(brak)");
}

Console.WriteLine("\n═══ Konsekwencja 3: Brak obsługi = null (Null Object) ═══\n");

// Łańcuch bez defaultHandler — null na końcu
var partialChain = new HtmlReportHandler();
partialChain.SetNext(new CsvReportHandler());   // brak jsonHandler!

var missing = partialChain.Handle(new ReportRequest("json", "Raport"));
Console.WriteLine($"  Format 'json' (brak handlera): {missing ?? "null — obsłuż na poziomie klienta!"}");

// =============================================================================
// IMPLEMENTACJE — klasyczna struktura GoF
// =============================================================================

// ─── Żądanie (Request) ────────────────────────────────────────────────────────
record ReportRequest(string Format, string Title);

// ─── GoF: Handler (interfejs) ─────────────────────────────────────────────────
interface IReportHandler
{
    // SetNext zwraca przekazany handler — umożliwia fluent chaining
    IReportHandler SetNext(IReportHandler handler);
    string? Handle(ReportRequest request);
}

// ─── GoF: BaseHandler (klasa abstrakcyjna z logiką przekazywania) ─────────────
abstract class BaseReportHandler : IReportHandler
{
    private IReportHandler? _next;

    // Fluent builder: h1.SetNext(h2).SetNext(h3)
    public IReportHandler SetNext(IReportHandler handler)
    {
        _next = handler;
        return handler;    // ← kluczowe: zwróć przekazany handler, nie this
    }

    public abstract string? Handle(ReportRequest request);

    // Metoda pomocnicza dla podklas
    protected string? PassToNext(ReportRequest request)
        => _next?.Handle(request);
}

// ─── GoF: ConcreteHandler ─────────────────────────────────────────────────────

class HtmlReportHandler : BaseReportHandler
{
    public override string? Handle(ReportRequest request)
    {
        if (request.Format == "html")
            return $"<html><body><h1>{request.Title}</h1></body></html>";
        return PassToNext(request);
    }
}

class CsvReportHandler : BaseReportHandler
{
    public override string? Handle(ReportRequest request)
    {
        if (request.Format == "csv")
            return $"\"title\"\n\"{request.Title}\"";
        return PassToNext(request);
    }
}

class JsonReportHandler : BaseReportHandler
{
    public override string? Handle(ReportRequest request)
    {
        if (request.Format == "json")
            return $"{{\"title\":\"{request.Title}\"}}";
        return PassToNext(request);
    }
}

class PdfReportHandler : BaseReportHandler
{
    public override string? Handle(ReportRequest request)
    {
        if (request.Format == "pdf")
            return $"[PDF] {request.Title} (strony: 1)";
        return PassToNext(request);
    }
}

// Null Object na końcu łańcucha — nigdy nie zwraca null, zawsze obsługuje
class UnsupportedFormatHandler : BaseReportHandler
{
    public override string? Handle(ReportRequest request)
        => $"[ERROR] Nieobsługiwany format: '{request.Format}'";
}
