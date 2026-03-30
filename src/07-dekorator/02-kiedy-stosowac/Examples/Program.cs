using System.Diagnostics;

namespace Examples;

public interface IReportExporter
{
    byte[] Export(string payload);
}

public sealed class BaseExporter : IReportExporter
{
    public byte[] Export(string payload)
    {
        Thread.SpinWait(12_000);
        return System.Text.Encoding.UTF8.GetBytes(payload);
    }
}

public abstract class ExporterDecorator(IReportExporter inner) : IReportExporter
{
    protected IReportExporter Inner { get; } = inner;
    public abstract byte[] Export(string payload);
}

public sealed class ValidationDecorator(IReportExporter inner) : ExporterDecorator(inner)
{
    public override byte[] Export(string payload)
    {
        if (string.IsNullOrWhiteSpace(payload))
        {
            throw new ArgumentException("Payload cannot be empty.");
        }
        Thread.SpinWait(8_000);
        return Inner.Export(payload);
    }
}

public sealed class AuditDecorator(IReportExporter inner) : ExporterDecorator(inner)
{
    public override byte[] Export(string payload)
    {
        Thread.SpinWait(10_000);
        return Inner.Export(payload);
    }
}

public sealed class EncryptionDecorator(IReportExporter inner) : ExporterDecorator(inner)
{
    public override byte[] Export(string payload)
    {
        Thread.SpinWait(15_000);
        var encrypted = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(payload));
        return Inner.Export(encrypted);
    }
}

public static class Program
{
    private const int Iterations = 4000;

    public static void Main()
    {
        Console.WriteLine("=== 02. Kiedy stosowac Dekorator ===");

        var lean = new BaseExporter();
        var rich = new ValidationDecorator(
            new AuditDecorator(
                new EncryptionDecorator(
                    new BaseExporter())));

        var leanMs = Measure(lean, "minimal-payload");
        var richMs = Measure(rich, "minimal-payload");

        Console.WriteLine($"Lean chain : {leanMs} ms");
        Console.WriteLine($"Rich chain : {richMs} ms");
        Console.WriteLine($"Overhead   : {((double)(richMs - leanMs) / leanMs) * 100:0.00}%");
    }

    private static long Measure(IReportExporter exporter, string payload)
    {
        var sw = Stopwatch.StartNew();
        Parallel.For(0, Iterations, _ => exporter.Export(payload));
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
