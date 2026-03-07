using KiedyStosowac.Reports;
using KiedyStosowac.Counterexamples;

// ─────────────────────────────────────────────────────────────────────────────
// 1. Prosty obiekt — builder jest zbędny
// ─────────────────────────────────────────────────────────────────────────────
CounterexamplesDemo.Run();

// ─────────────────────────────────────────────────────────────────────────────
// 2. Złożony raport — Builder się opłaca
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== Złożony raport — ReportBuilder ===\n");

Report monthlyReport = new ReportBuilder()
    .WithTitle("Raport Sprzedaży — Styczeń 2024")
    .WithAuthor("Jan Kowalski")
    .AsFormat(ReportFormat.Html)
    .WithPageNumbers()
    .AddSection("Podsumowanie Wykonawcze")
        .WithBody("Sprzedaż wzrosła o 12% r/r. Główny wzrost w segmencie B2B.")
        .AddChart(ChartType.Bar, "sales_2024_01.csv", "Sprzedaż wg regionów")
        .EndSection()
    .AddSection("Szczegółowa Analiza")
        .WithBody("Region Północny: +18%, Region Południowy: +7%, Eksport: +21%")
        .AddChart(ChartType.Line, "trend_2024.csv", "Trend miesięczny")
        .AddChart(ChartType.Pie, "segments_2024_01.csv", "Podział wg segmentów")
        .EndSection()
    .AddSection("Rekomendacje")
        .WithBody("Zwiększyć budżet marketingowy w regionie wschodnim o 15%.")
        .EndSection()
    .WithFooter("Przygotował Dział Analiz | Dokument poufny")
    .Build();

Console.WriteLine(monthlyReport.Render());

// ─────────────────────────────────────────────────────────────────────────────
// 3. Ten sam builder, inny zestaw danych → inny raport
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== Raport minimalny (bez sekcji i bez stopki) ===\n");

Report minimalReport = new ReportBuilder()
    .WithTitle("Szybki przegląd")
    .AsFormat(ReportFormat.Markdown)
    .Build();

Console.WriteLine(minimalReport.Render());

// ─────────────────────────────────────────────────────────────────────────────
// 4. Walidacja — brak tytułu rzuca wyjątek
// ─────────────────────────────────────────────────────────────────────────────
Console.WriteLine("=== Walidacja — pusty tytuł ===");
try
{
    Report _ = new ReportBuilder()
        .WithTitle("   ")   // whitespace-only
        .Build();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Błąd (oczekiwany): {ex.Message}");
}
