using KiedyStosowac.Reports;
using KiedyStosowac.Counterexamples;
using Xunit;

namespace Examples.Tests;

public class ReportBuilderTests
{
    [Fact]
    public void Build_MinimalReport_HasTitleAndDefaults()
    {
        var report = new ReportBuilder()
            .WithTitle("Test Report")
            .Build();

        Assert.Equal("Test Report", report.Title);
        Assert.Equal("Anonimowy", report.Author);
        Assert.Empty(report.Sections);
        Assert.Equal(ReportFormat.Html, report.Format);
    }

    [Fact]
    public void Build_WithAuthor_SetsAuthor()
    {
        var report = new ReportBuilder()
            .WithTitle("Report")
            .WithAuthor("Jan Kowalski")
            .Build();

        Assert.Equal("Jan Kowalski", report.Author);
    }

    [Fact]
    public void Build_WithFormat_SetsFormat()
    {
        var report = new ReportBuilder()
            .WithTitle("Report")
            .AsFormat(ReportFormat.Markdown)
            .Build();

        Assert.Equal(ReportFormat.Markdown, report.Format);
    }

    [Fact]
    public void Build_WithPageNumbers_SetsFlag()
    {
        var report = new ReportBuilder()
            .WithTitle("Report")
            .WithPageNumbers()
            .Build();

        Assert.True(report.PageNumbers);
    }

    [Fact]
    public void Build_WithSections_IncludesAll()
    {
        var report = new ReportBuilder()
            .WithTitle("Report")
            .AddSection("Sekcja 1")
                .WithBody("Treść 1")
                .EndSection()
            .AddSection("Sekcja 2")
                .WithBody("Treść 2")
                .EndSection()
            .Build();

        Assert.Equal(2, report.Sections.Count);
        Assert.Equal("Sekcja 1", report.Sections[0].Heading);
        Assert.Equal("Treść 2", report.Sections[1].Body);
    }

    [Fact]
    public void Build_SectionWithCharts_IncludesCharts()
    {
        var report = new ReportBuilder()
            .WithTitle("Report")
            .AddSection("Dane")
                .WithBody("Analiza")
                .AddChart(ChartType.Bar, "data.csv", "Wykres 1")
                .AddChart(ChartType.Pie, "pie.csv", "Wykres 2")
                .EndSection()
            .Build();

        Assert.Equal(2, report.Sections[0].Charts.Count);
        Assert.Equal(ChartType.Bar, report.Sections[0].Charts[0].Type);
        Assert.Equal("Wykres 2", report.Sections[0].Charts[1].Title);
    }

    [Fact]
    public void Build_WhitespaceTitle_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new ReportBuilder().WithTitle("   ").Build());
    }

    [Fact]
    public void Build_WithFooter_SetsFooter()
    {
        var report = new ReportBuilder()
            .WithTitle("Report")
            .WithFooter("Stopka")
            .Build();

        Assert.Equal("Stopka", report.Footer);
    }

    [Fact]
    public void Render_ContainsTitleAndSections()
    {
        var report = new ReportBuilder()
            .WithTitle("Raport Testowy")
            .AddSection("Intro")
                .WithBody("Wprowadzenie")
                .EndSection()
            .Build();

        var rendered = report.Render();

        Assert.Contains("Raport Testowy", rendered);
        Assert.Contains("## Intro", rendered);
        Assert.Contains("Wprowadzenie", rendered);
    }
}

public class CounterexampleTests
{
    [Fact]
    public void Point2D_Constructor_IsSufficient()
    {
        var point = new Point2D(3.0, 4.5);

        Assert.Equal(3.0, point.X);
        Assert.Equal(4.5, point.Y);
    }

    [Fact]
    public void Color_NamedArgs_AreClear()
    {
        var color = new Color(R: 255, G: 128, B: 0);

        Assert.Equal(255, color.R);
        Assert.Equal(128, color.G);
        Assert.Equal((byte)0, color.B);
        Assert.Equal(255, color.A); // default
    }

    [Fact]
    public void ApiOptions_ObjectInitializer_WorksDirectly()
    {
        var options = new ApiOptions
        {
            BaseUrl = "https://api.example.com",
            TimeoutSeconds = 60,
            EnableRetry = true
        };

        Assert.Equal("https://api.example.com", options.BaseUrl);
        Assert.Equal(60, options.TimeoutSeconds);
        Assert.True(options.EnableRetry);
    }
}
