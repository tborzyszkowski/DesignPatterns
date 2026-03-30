namespace Examples;

public interface IMessageSender
{
    string Send(string message);
}

public sealed class EmailSender : IMessageSender
{
    public string Send(string message) => $"EMAIL:{message}";
}

public abstract class SenderDecorator(IMessageSender inner) : IMessageSender
{
    protected IMessageSender Inner { get; } = inner;
    public abstract string Send(string message);
}

public sealed class LoggingDecorator(IMessageSender inner) : SenderDecorator(inner)
{
    public override string Send(string message)
    {
        Console.WriteLine($"[LOG] Before send: {message}");
        var result = Inner.Send(message);
        Console.WriteLine($"[LOG] After send: {result}");
        return result;
    }
}

public sealed class SignatureDecorator(IMessageSender inner) : SenderDecorator(inner)
{
    public override string Send(string message)
    {
        var withSignature = $"{message}\n-- Sent from Decorator Demo";
        return Inner.Send(withSignature);
    }
}

public static class Program
{
    public static void Main()
    {
        IMessageSender sender = new LoggingDecorator(
            new SignatureDecorator(
                new EmailSender()));

        var output = sender.Send("Witaj na wykladzie o Dekoratorze");
        Console.WriteLine(output);
    }
}
