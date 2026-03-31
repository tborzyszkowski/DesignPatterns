Abstraction standard = new StandardReport(new PdfReportImplementor());
standard.Operation("Sprzedaz Q1");

Abstraction premium = new PremiumReport(new CsvReportImplementor());
premium.Operation("Sprzedaz Q1");

internal interface IReportImplementor
{
    string Render(string data);
}

internal abstract class Abstraction(IReportImplementor implementor)
{
    protected IReportImplementor Implementor { get; } = implementor;
    public abstract void Operation(string input);
}

internal sealed class StandardReport(IReportImplementor implementor) : Abstraction(implementor)
{
    public override void Operation(string input)
        => Console.WriteLine($"Standard: {Implementor.Render(input)}");
}

internal sealed class PremiumReport(IReportImplementor implementor) : Abstraction(implementor)
{
    public override void Operation(string input)
        => Console.WriteLine($"Premium: {Implementor.Render(input)} + summary");
}

internal sealed class PdfReportImplementor : IReportImplementor
{
    public string Render(string data) => $"PDF({data})";
}

internal sealed class CsvReportImplementor : IReportImplementor
{
    public string Render(string data) => $"CSV({data})";
}
