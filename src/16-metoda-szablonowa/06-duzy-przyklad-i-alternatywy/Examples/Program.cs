// =============================================================================
// Wzorzec Metoda Szablonowa — 06. Duży przykład: System generowania raportów
// Demonstruje: pełny przykład + alternatywy (Strategia, delegaty)
// =============================================================================

var salesData = new[]
{
    new SalesRecord("Laptop Pro 15", "Elektronika", 4999.99m, 12),
    new SalesRecord("Mysz bezprzewodowa", "Elektronika", 89.99m, 85),
    new SalesRecord("Biurko regulowane", "Meble", 1299.00m, 23),
    new SalesRecord("Krzesło ergonomiczne", "Meble", 799.00m, 41),
    new SalesRecord("Monitor 4K 27\"", "Elektronika", 2199.00m, 7),
    new SalesRecord("Lampa biurkowa LED", "Oświetlenie", 149.00m, 63),
};

// ─── CZĘŚĆ 1: Template Method — różne generatory ────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 1: Template Method — generatory raportów ═══\n");

ReportGenerator[] generators =
[
    new HtmlReportGenerator("Raport Sprzedaży Q4 2024", salesData),
    new CsvReportGenerator("Raport Sprzedaży Q4 2024", salesData),
    new MarkdownReportGenerator("Raport Sprzedaży Q4 2024", salesData),
];

foreach (var gen in generators)
{
    Console.WriteLine($"▸ {gen.GetType().Name}:");
    var report = gen.Generate();
    // Pokazujemy tylko fragment — raporty mogą być duże
    var lines = report.Split('\n');
    foreach (var line in lines.Take(8))
        Console.WriteLine($"  {line}");
    if (lines.Length > 8)
        Console.WriteLine($"  ... ({lines.Length - 8} więcej linii)");
    Console.WriteLine();
}

// ─── CZĘŚĆ 2: Alternatywa — Strategia ────────────────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 2: Alternatywa — wzorzec Strategia ═══\n");

var strategyReports = new[]
{
    new StrategyReportGenerator(
        new HtmlFormatStrategy(),
        new AllRecordsFilter(),
        "Raport Strategia HTML"),
    new StrategyReportGenerator(
        new CsvFormatStrategy(),
        new CategoryFilter("Elektronika"),
        "Raport Strategia CSV (Elektronika)"),
};

foreach (var sr in strategyReports)
{
    Console.WriteLine($"▸ {sr.Title}:");
    var report = sr.Generate(salesData);
    var lines = report.Split('\n');
    foreach (var line in lines.Take(6))
        Console.WriteLine($"  {line}");
    if (lines.Length > 6)
        Console.WriteLine($"  ... ({lines.Length - 6} więcej linii)");
    Console.WriteLine();
}

// ─── CZĘŚĆ 3: Alternatywa — Delegaty ─────────────────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 3: Alternatywa — delegaty (Func<>) ═══\n");

var delegateReport = new DelegateReportGenerator(
    title: "Raport Delegatowy",
    filter: records => records.Where(r => r.Revenue > 500m),
    formatTitle: t => $"# {t.ToUpperInvariant()}",
    formatRow: r => $"  | {r.Product,-30} | {r.Revenue,12:C} | {r.Quantity,4} szt. |",
    addSummary: rows =>
    {
        var total = rows.Sum(r => r.Revenue * r.Quantity);
        return $"  Suma: {total:C}";
    }
);

var delegateResult = delegateReport.Generate(salesData);
foreach (var line in delegateResult.Split('\n').Take(10))
    Console.WriteLine($"  {line}");
Console.WriteLine();

// ─── CZĘŚĆ 4: Porównanie ─────────────────────────────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 4: Porównanie Template Method vs Strategia vs Delegaty ═══\n");
Console.WriteLine("Template Method (dziedziczenie):");
Console.WriteLine("  + Wspólna logika w jednym miejscu");
Console.WriteLine("  + Wymuszona kolejność kroków (sealed)");
Console.WriteLine("  - Głęboka hierarchia klas przy wielu wariantach");
Console.WriteLine("  - Trudniejszy test (wymaga podklasy)");
Console.WriteLine();
Console.WriteLine("Strategia (kompozycja):");
Console.WriteLine("  + Zmiana formattera/filtru w runtime (bez nowej klasy)");
Console.WriteLine("  + Łatwy mock w testach");
Console.WriteLine("  - Brak zapewnienia kolejności kroków");
Console.WriteLine("  - Więcej klas/interfejsów");
Console.WriteLine();
Console.WriteLine("Delegaty (Func<>):");
Console.WriteLine("  + Maksymalna elastyczność, lambdy inline");
Console.WriteLine("  + Łatwy test bez podklas");
Console.WriteLine("  - Brak nazwanego kontraktu (interfejsu)");
Console.WriteLine("  - Trudniejsza dokumentacja");

// =============================================================================
// MODEL DANYCH
// =============================================================================

record SalesRecord(string Product, string Category, decimal Revenue, int Quantity);

// =============================================================================
// TEMPLATE METHOD — wzorzec (dziedziczenie)
// =============================================================================

abstract class ReportGenerator(string title, IEnumerable<SalesRecord> allData)
{
    // ── Metoda szablonowa ──────────────────────────────────────────────────
    public string Generate()
    {
        var data = LoadData();
        var filtered = FilterData(data);
        var rows = filtered.ToList();

        var sb = new System.Text.StringBuilder();
        sb.AppendLine(GetHeader());
        sb.AppendLine(FormatTitle(title));
        foreach (var row in rows)
            sb.AppendLine(FormatRow(row));
        var summary = AddSummary(rows);
        if (!string.IsNullOrEmpty(summary))
            sb.AppendLine(summary);
        sb.AppendLine(GetFooter());
        return sb.ToString();
    }

    // ── Primitive Operations (obowiązkowe) ────────────────────────────────
    protected abstract IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> data);
    protected abstract string FormatTitle(string t);
    protected abstract string FormatRow(SalesRecord record);
    protected abstract string GetExtension();

    // ── Krok wspólny (nie abstract) ───────────────────────────────────────
    protected IEnumerable<SalesRecord> LoadData() => allData;

    // ── Hooki (opcjonalne) ────────────────────────────────────────────────
    protected virtual string AddSummary(IList<SalesRecord> rows) => string.Empty;
    protected virtual string GetHeader() => string.Empty;
    protected virtual string GetFooter() => string.Empty;
}

// ── Konkretne generatory ──────────────────────────────────────────────────────

class HtmlReportGenerator(string title, IEnumerable<SalesRecord> data)
    : ReportGenerator(title, data)
{
    protected override IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d)
        => d.Where(r => r.Revenue > 100m).OrderByDescending(r => r.Revenue * r.Quantity);

    protected override string FormatTitle(string t)
        => $"<h1>{System.Net.WebUtility.HtmlEncode(t)}</h1>";

    protected override string FormatRow(SalesRecord r)
        => $"  <tr><td>{System.Net.WebUtility.HtmlEncode(r.Product)}</td><td>{r.Revenue:C}</td><td>{r.Quantity}</td></tr>";

    protected override string GetExtension() => ".html";

    protected override string GetHeader()
        => "<!DOCTYPE html><html><body><table>";

    protected override string GetFooter()
        => "</table></body></html>";

    // Hook: HTML raporty mają podsumowanie
    protected override string AddSummary(IList<SalesRecord> rows)
    {
        var total = rows.Sum(r => r.Revenue * r.Quantity);
        return $"  <tfoot><tr><td colspan='3'><strong>Suma: {total:C}</strong></td></tr></tfoot>";
    }
}

class CsvReportGenerator(string title, IEnumerable<SalesRecord> data)
    : ReportGenerator(title, data)
{
    protected override IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d)
        => d.OrderBy(r => r.Category).ThenBy(r => r.Product);

    protected override string FormatTitle(string t)
        => $"# {t}";

    protected override string FormatRow(SalesRecord r)
        => $"{r.Product},{r.Category},{r.Revenue},{r.Quantity}";

    protected override string GetExtension() => ".csv";

    protected override string GetHeader()
        => "Produkt,Kategoria,Przychód,Ilość";

    // Brak AddSummary — domyślna (pusta)
}

class MarkdownReportGenerator(string title, IEnumerable<SalesRecord> data)
    : ReportGenerator(title, data)
{
    protected override IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d)
        => d.Where(r => r.Quantity >= 10).OrderByDescending(r => r.Quantity);

    protected override string FormatTitle(string t) => $"# {t}";

    protected override string FormatRow(SalesRecord r)
        => $"| {r.Product,-32} | {r.Revenue,12:C} | {r.Quantity,6} |";

    protected override string GetExtension() => ".md";

    protected override string GetHeader()
        => "| Produkt                           |    Przychód  | Ilość |\n" +
           "|-----------------------------------|-------------|-------|";

    protected override string AddSummary(IList<SalesRecord> rows)
    {
        var total = rows.Sum(r => r.Revenue * r.Quantity);
        return $"\n**Łączna wartość sprzedaży: {total:C}**";
    }
}

// =============================================================================
// ALTERNATYWA — Strategia (kompozycja)
// =============================================================================

interface IReportFormatStrategy
{
    string FormatTitle(string title);
    string FormatRow(SalesRecord record);
    string GetHeader();
    string GetFooter();
    string AddSummary(IList<SalesRecord> rows);
}

interface IReportFilterStrategy
{
    IEnumerable<SalesRecord> Filter(IEnumerable<SalesRecord> data);
}

class HtmlFormatStrategy : IReportFormatStrategy
{
    public string FormatTitle(string t) => $"<h1>{t}</h1>";
    public string FormatRow(SalesRecord r)
        => $"<tr><td>{r.Product}</td><td>{r.Revenue:C}</td></tr>";
    public string GetHeader() => "<table>";
    public string GetFooter() => "</table>";
    public string AddSummary(IList<SalesRecord> rows)
        => $"<p>Suma: {rows.Sum(r => r.Revenue * r.Quantity):C}</p>";
}

class CsvFormatStrategy : IReportFormatStrategy
{
    public string FormatTitle(string t) => $"# {t}";
    public string FormatRow(SalesRecord r) => $"{r.Product},{r.Revenue},{r.Quantity}";
    public string GetHeader() => "Produkt,Przychód,Ilość";
    public string GetFooter() => string.Empty;
    public string AddSummary(IList<SalesRecord> rows) => string.Empty;
}

class AllRecordsFilter : IReportFilterStrategy
{
    public IEnumerable<SalesRecord> Filter(IEnumerable<SalesRecord> data) => data;
}

class CategoryFilter(string category) : IReportFilterStrategy
{
    public IEnumerable<SalesRecord> Filter(IEnumerable<SalesRecord> data)
        => data.Where(r => r.Category == category);
}

class StrategyReportGenerator(
    IReportFormatStrategy format,
    IReportFilterStrategy filter,
    string title)
{
    public string Title { get; } = title;

    public string Generate(IEnumerable<SalesRecord> allData)
    {
        var filtered = filter.Filter(allData).ToList();
        var sb = new System.Text.StringBuilder();
        sb.AppendLine(format.GetHeader());
        sb.AppendLine(format.FormatTitle(Title));
        foreach (var row in filtered)
            sb.AppendLine(format.FormatRow(row));
        sb.AppendLine(format.AddSummary(filtered));
        sb.AppendLine(format.GetFooter());
        return sb.ToString();
    }
}

// =============================================================================
// ALTERNATYWA — Delegaty (Func<>)
// =============================================================================

class DelegateReportGenerator(
    string title,
    Func<IEnumerable<SalesRecord>, IEnumerable<SalesRecord>> filter,
    Func<string, string> formatTitle,
    Func<SalesRecord, string> formatRow,
    Func<IEnumerable<SalesRecord>, string>? addSummary = null)
{
    public string Generate(IEnumerable<SalesRecord> allData)
    {
        var rows = filter(allData).ToList();
        var sb = new System.Text.StringBuilder();
        sb.AppendLine(formatTitle(title));
        foreach (var row in rows)
            sb.AppendLine(formatRow(row));
        if (addSummary is not null)
            sb.AppendLine(addSummary(rows));
        return sb.ToString();
    }
}

