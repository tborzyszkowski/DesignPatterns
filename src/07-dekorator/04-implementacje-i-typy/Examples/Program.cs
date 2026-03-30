namespace Examples;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== 04. Typy implementacji Dekoratora ===");

        var classic = new TimestampDecorator(new ConsoleNotifier());
        Console.WriteLine(classic.Notify("Wariant klasyczny"));

        Func<string, string> baseFunc = msg => $"[BASE]{msg}";
        Func<string, string> withPrefix = msg => $"[PFX]{baseFunc(msg)}";
        Func<string, string> withSuffix = msg => $"{withPrefix(msg)}[SFX]";
        Console.WriteLine(withSuffix(" Wariant funkcyjny"));

        var pipeline = new List<Func<string, string>>
        {
            m => $"[VALID]{m}",
            m => $"[AUDIT]{m}",
            m => $"[TRACE]{m}"
        };

        var message = "Wariant pipeline/DI";
        foreach (var step in pipeline)
        {
            message = step(message);
        }
        Console.WriteLine(message);
    }
}

public interface INotifier
{
    string Notify(string message);
}

public sealed class ConsoleNotifier : INotifier
{
    public string Notify(string message) => $"NOTIFY:{message}";
}

public sealed class TimestampDecorator(INotifier inner) : INotifier
{
    public string Notify(string message) => inner.Notify($"[{DateTime.UtcNow:HH:mm:ss}] {message}");
}
