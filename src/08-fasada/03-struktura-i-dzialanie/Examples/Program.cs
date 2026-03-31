var facade = new ReportFacade(new DataLoader(), new Aggregator(), new Formatter());
Console.WriteLine(facade.BuildReport("2026-03"));

internal sealed class ReportFacade(DataLoader loader, Aggregator aggregator, Formatter formatter)
{
    public string BuildReport(string month)
    {
        var raw = loader.Load(month);
        var summary = aggregator.Aggregate(raw);
        return formatter.Format(month, summary);
    }
}

internal sealed class DataLoader
{
    public IReadOnlyList<int> Load(string month)
    {
        _ = month;
        return [120, 80, 100, 140];
    }
}

internal sealed class Aggregator
{
    public Summary Aggregate(IReadOnlyList<int> values)
    {
        var sum = values.Sum();
        var avg = values.Average();
        return new Summary(sum, avg);
    }
}

internal sealed class Formatter
{
    public string Format(string month, Summary summary)
        => $"Raport {month}: suma={summary.Sum}, średnia={summary.Average:F2}";
}

internal readonly record struct Summary(int Sum, double Average);
