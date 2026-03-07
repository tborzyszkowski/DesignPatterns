namespace KiedyStosowac.Reports;

public enum ReportFormat { Pdf, Html, Markdown }
public enum ChartType { Bar, Line, Pie }

public sealed class ChartConfig
{
    public ChartType Type { get; }
    public string DataSource { get; }
    public string Title { get; }

    internal ChartConfig(ChartType type, string dataSource, string title)
        => (Type, DataSource, Title) = (type, dataSource, title);
}

public sealed class ReportSection
{
    public string Heading { get; }
    public string Body { get; }
    public IReadOnlyList<ChartConfig> Charts { get; }

    internal ReportSection(string heading, string body, List<ChartConfig> charts)
        => (Heading, Body, Charts) = (heading, body, charts.AsReadOnly());
}

public sealed class Report
{
    public string Title { get; }
    public string Author { get; }
    public DateTime CreatedAt { get; }
    public IReadOnlyList<ReportSection> Sections { get; }
    public string Footer { get; }
    public bool PageNumbers { get; }
    public ReportFormat Format { get; }

    internal Report(string title, string author, List<ReportSection> sections,
        string footer, bool pageNumbers, ReportFormat format)
    {
        Title = title;
        Author = author;
        CreatedAt = DateTime.UtcNow;
        Sections = sections.AsReadOnly();
        Footer = footer;
        PageNumbers = pageNumbers;
        Format = format;
    }

    public string Render()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"=== {Title} ===");
        sb.AppendLine($"Autor: {Author}  |  Data: {CreatedAt:yyyy-MM-dd}  |  Format: {Format}");
        sb.AppendLine(new string('-', 50));
        foreach (var section in Sections)
        {
            sb.AppendLine($"\n## {section.Heading}");
            sb.AppendLine(section.Body);
            foreach (var chart in section.Charts)
                sb.AppendLine($"  [Wykres {chart.Type}: {chart.Title} <- {chart.DataSource}]");
        }
        if (!string.IsNullOrEmpty(Footer))
            sb.AppendLine($"\n---\n{Footer}");
        if (PageNumbers)
            sb.AppendLine("[Numery stron: włączone]");
        return sb.ToString();
    }
}

// ── Zagnieżdżony builder sekcji ────────────────────────────────────────────

public sealed class SectionBuilder
{
    private readonly ReportBuilder _parent;
    private readonly string _heading;
    private string _body = string.Empty;
    private readonly List<ChartConfig> _charts = [];

    internal SectionBuilder(ReportBuilder parent, string heading)
        => (_parent, _heading) = (parent, heading);

    public SectionBuilder WithBody(string body) { _body = body; return this; }

    public SectionBuilder AddChart(ChartType type, string dataSource, string title)
    {
        _charts.Add(new ChartConfig(type, dataSource, title));
        return this;
    }

    public ReportBuilder EndSection()
    {
        _parent.AddBuiltSection(new ReportSection(_heading, _body, _charts));
        return _parent;
    }
}

// ── Główny builder raportu ─────────────────────────────────────────────────

public sealed class ReportBuilder
{
    private string _title = "Bez tytułu";
    private string _author = "Anonimowy";
    private readonly List<ReportSection> _sections = [];
    private string _footer = string.Empty;
    private bool _pageNumbers;
    private ReportFormat _format = ReportFormat.Html;

    public ReportBuilder WithTitle(string title) { _title = title; return this; }
    public ReportBuilder WithAuthor(string author) { _author = author; return this; }
    public ReportBuilder WithFooter(string footer) { _footer = footer; return this; }
    public ReportBuilder WithPageNumbers() { _pageNumbers = true; return this; }
    public ReportBuilder AsFormat(ReportFormat format) { _format = format; return this; }

    public SectionBuilder AddSection(string heading)
        => new SectionBuilder(this, heading);

    internal void AddBuiltSection(ReportSection section)
        => _sections.Add(section);

    public Report Build()
    {
        if (string.IsNullOrWhiteSpace(_title))
            throw new InvalidOperationException("Raport musi mieć tytuł.");
        return new Report(_title, _author, _sections, _footer, _pageNumbers, _format);
    }
}
