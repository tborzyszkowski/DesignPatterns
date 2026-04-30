// =============================================================================
// Testy jednostkowe — Wzorzec Metoda Szablonowa (wzorzec Report Generator)
// Projekt SAMODZIELNY — nie referencjonuje projektu Examples
// =============================================================================
using System.Text;
using Xunit;

namespace TemplateMethod.Reports.Tests;

// =============================================================================
// MODEL DANYCH (kopia z Examples — projekt jest samodzielny)
// =============================================================================

record SalesRecord(string Product, string Category, decimal Revenue, int Quantity);

// =============================================================================
// IMPLEMENTACJA (kopia/uproszczenie z Examples — na potrzeby testów)
// =============================================================================

abstract class ReportGenerator(string title, IEnumerable<SalesRecord> allData)
{
    public readonly List<string> CallLog = [];

    public string Generate()
    {
        var data = LoadData();
        var filtered = FilterData(data);
        var rows = filtered.ToList();

        var sb = new StringBuilder();
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

    protected IEnumerable<SalesRecord> LoadData()
    {
        CallLog.Add("LoadData");
        return allData;
    }

    protected abstract IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d);
    protected abstract string FormatTitle(string t);
    protected abstract string FormatRow(SalesRecord record);
    protected abstract string GetExtension();

    protected virtual string AddSummary(IList<SalesRecord> rows) => string.Empty;
    protected virtual string GetHeader() { CallLog.Add("GetHeader"); return string.Empty; }
    protected virtual string GetFooter() { CallLog.Add("GetFooter"); return string.Empty; }
}

// ── Implementacje testowe ─────────────────────────────────────────────────────

class TrackingReportGenerator(string title, IEnumerable<SalesRecord> data)
    : ReportGenerator(title, data)
{
    private readonly List<string> _log = [];
    public IReadOnlyList<string> Log => _log;

    protected override IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d)
    {
        _log.Add("FilterData");
        return d;
    }
    protected override string FormatTitle(string t) { _log.Add("FormatTitle"); return $"TITLE:{t}"; }
    protected override string FormatRow(SalesRecord r) { _log.Add("FormatRow"); return $"ROW:{r.Product}"; }
    protected override string GetExtension() { _log.Add("GetExtension"); return ".txt"; }
    protected override string AddSummary(IList<SalesRecord> rows) { _log.Add("AddSummary"); return "SUMMARY"; }
    protected override string GetHeader() { base.GetHeader(); _log.Add("GetHeader"); return "HEADER"; }
    protected override string GetFooter() { base.GetFooter(); _log.Add("GetFooter"); return "FOOTER"; }
}

class HookDisabledReportGenerator(string title, IEnumerable<SalesRecord> data)
    : ReportGenerator(title, data)
{
    public bool SummaryCalled { get; private set; }

    protected override IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d) => d;
    protected override string FormatTitle(string t) => $"# {t}";
    protected override string FormatRow(SalesRecord r) => $"{r.Product}";
    protected override string GetExtension() => ".txt";
    // Nie przesłania AddSummary → hook zwraca string.Empty → summary nie pojawia się w raporcie
}

class HookEnabledReportGenerator(string title, IEnumerable<SalesRecord> data)
    : ReportGenerator(title, data)
{
    public bool SummaryCalled { get; private set; }

    protected override IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d) => d;
    protected override string FormatTitle(string t) => $"# {t}";
    protected override string FormatRow(SalesRecord r) => $"{r.Product}";
    protected override string GetExtension() => ".txt";
    protected override string AddSummary(IList<SalesRecord> rows)
    {
        SummaryCalled = true;
        return $"Total: {rows.Count} rows";
    }
}

class FilteringReportGenerator(
    string title,
    IEnumerable<SalesRecord> data,
    Func<SalesRecord, bool> predicate)
    : ReportGenerator(title, data)
{
    protected override IEnumerable<SalesRecord> FilterData(IEnumerable<SalesRecord> d)
        => d.Where(predicate);
    protected override string FormatTitle(string t) => t;
    protected override string FormatRow(SalesRecord r) => r.Product;
    protected override string GetExtension() => ".txt";
}

// =============================================================================
// TESTY
// =============================================================================

public class ReportGeneratorTests
{
    private static readonly SalesRecord[] SampleData =
    [
        new("Laptop", "Elektronika", 4999m, 5),
        new("Mysz", "Elektronika", 89m, 30),
        new("Biurko", "Meble", 1299m, 10),
    ];

    // ─── Kolejność wywołań ────────────────────────────────────────────────────

    [Fact]
    public void Generate_CallsStepsInCorrectOrder()
    {
        var gen = new TrackingReportGenerator("Test", SampleData);
        gen.Generate();

        var log = gen.Log;
        // FilterData must happen before FormatRow
        int filterIdx = log.ToList().IndexOf("FilterData");
        int firstRowIdx = log.ToList().IndexOf("FormatRow");
        Assert.True(filterIdx < firstRowIdx, "FilterData powinien być wywołany przed FormatRow");

        // FormatTitle must appear in log
        Assert.Contains("FormatTitle", log);
    }

    [Fact]
    public void Generate_CallsFormatRowForEachRecord()
    {
        var gen = new TrackingReportGenerator("Test", SampleData);
        gen.Generate();

        var rowCalls = gen.Log.Count(x => x == "FormatRow");
        Assert.Equal(SampleData.Length, rowCalls);
    }

    [Fact]
    public void Generate_CallsGetHeaderBeforeGetFooter()
    {
        var gen = new TrackingReportGenerator("Test", SampleData);
        gen.Generate();

        var log = gen.Log.ToList();
        int headerIdx = log.IndexOf("GetHeader");
        int footerIdx = log.IndexOf("GetFooter");
        Assert.True(headerIdx < footerIdx, "GetHeader powinien być wywołany przed GetFooter");
    }

    [Fact]
    public void Generate_CallsFilterDataBeforeFormatRow()
    {
        var gen = new TrackingReportGenerator("Test", SampleData);
        gen.Generate();

        var log = gen.Log.ToList();
        int filterIdx = log.IndexOf("FilterData");
        int firstRowIdx = log.IndexOf("FormatRow");
        Assert.True(filterIdx < firstRowIdx, "FilterData powinien być wywołany przed FormatRow");
    }

    // ─── Hook — aktywacja i brak aktywacji ───────────────────────────────────

    [Fact]
    public void Generate_WhenSummaryHookNotOverridden_DoesNotIncludeSummary()
    {
        var gen = new HookDisabledReportGenerator("Test", SampleData);
        var result = gen.Generate();
        Assert.DoesNotContain("Total:", result);
    }

    [Fact]
    public void Generate_WhenSummaryHookOverridden_IncludesSummary()
    {
        var gen = new HookEnabledReportGenerator("Test", SampleData);
        var result = gen.Generate();
        Assert.Contains("Total:", result);
        Assert.True(gen.SummaryCalled);
    }

    // ─── Tytuł w raporcie ────────────────────────────────────────────────────

    [Fact]
    public void Generate_ContainsTitleInOutput()
    {
        const string title = "Raport Q4 2024";
        var gen = new TrackingReportGenerator(title, SampleData);
        var result = gen.Generate();
        Assert.Contains("TITLE:" + title, result);
    }

    // ─── Filtrowanie ─────────────────────────────────────────────────────────

    [Fact]
    public void Generate_WhenFilterExcludesAll_ProducesEmptyRowSection()
    {
        var gen = new FilteringReportGenerator("Test", SampleData, r => false);
        var result = gen.Generate();
        // Nie zawiera żadnego produktu
        Assert.DoesNotContain("Laptop", result);
        Assert.DoesNotContain("Biurko", result);
    }

    [Fact]
    public void Generate_WhenFilterApplied_OnlyMatchingRowsIncluded()
    {
        var gen = new FilteringReportGenerator("Test", SampleData, r => r.Category == "Meble");
        var result = gen.Generate();
        Assert.Contains("Biurko", result);
        Assert.DoesNotContain("Laptop", result);
        Assert.DoesNotContain("Mysz", result);
    }

    // ─── Zawartość — każdy rekord pojawia się w wyjściu ──────────────────────

    [Fact]
    public void Generate_AllRecordsAppearInOutput()
    {
        var gen = new TrackingReportGenerator("Test", SampleData);
        var result = gen.Generate();
        foreach (var record in SampleData)
            Assert.Contains("ROW:" + record.Product, result);
    }

    // ─── Strategia — niezależny test ─────────────────────────────────────────

    [Fact]
    public void StrategyReport_WithCategoryFilter_OnlyMatchingCategoryReturned()
    {
        var filter = new CategoryFilter("Elektronika");
        var filtered = filter.Filter(SampleData).ToList();

        Assert.Equal(2, filtered.Count);
        Assert.All(filtered, r => Assert.Equal("Elektronika", r.Category));
    }

    [Fact]
    public void StrategyReport_AllRecordsFilter_ReturnsAllRecords()
    {
        var filter = new AllRecordsFilter();
        var result = filter.Filter(SampleData).ToList();
        Assert.Equal(SampleData.Length, result.Count);
    }

    // ─── Delegaty — testowalność bez podklas ─────────────────────────────────

    [Fact]
    public void DelegatePipeline_ExecutesAllStepsInOrder()
    {
        var log = new List<string>();

        var pipeline = new DelegatePipeline(
            load: () => { log.Add("load"); return "raw"; },
            process: d => { log.Add("process"); return d.ToUpperInvariant(); },
            save: r => log.Add("save")
        );

        pipeline.Run();

        Assert.Equal(["load", "process", "save"], log);
    }

    [Fact]
    public void DelegatePipeline_TransformedDataPassedToSave()
    {
        string? savedData = null;

        var pipeline = new DelegatePipeline(
            load: () => "original",
            process: d => d.ToUpperInvariant(),
            save: r => savedData = r
        );

        pipeline.Run();

        Assert.Equal("ORIGINAL", savedData);
    }
}

// ─── Klasy pomocnicze dla testów Strategii i Delegatów ───────────────────────

class CategoryFilter(string category)
{
    public IEnumerable<SalesRecord> Filter(IEnumerable<SalesRecord> data)
        => data.Where(r => r.Category == category);
}

class AllRecordsFilter
{
    public IEnumerable<SalesRecord> Filter(IEnumerable<SalesRecord> data) => data;
}

class DelegatePipeline(
    Func<string> load,
    Func<string, string> process,
    Action<string> save)
{
    public void Run()
    {
        var raw = load();
        var result = process(raw);
        save(result);
    }
}
