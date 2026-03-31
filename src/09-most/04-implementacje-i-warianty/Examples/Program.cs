Console.WriteLine("=== Statyczny ===");
var staticBridge = new MessageBridge(new EmailSender());
staticBridge.Send("Hello static");

Console.WriteLine("=== Dynamiczny ===");
var dynamicBridge = new MessageBridge(new SmsSender());
dynamicBridge.Send("Hello dynamic");
dynamicBridge.Sender = new EmailSender();
dynamicBridge.Send("Hello switched");

Console.WriteLine("=== Factory + Bridge ===");
var sender = SenderFactory.Create("push");
var factoryBridge = new MessageBridge(sender);
factoryBridge.Send("Hello factory");

internal interface IMessageSender
{
    void SendRaw(string text);
}

internal sealed class MessageBridge(IMessageSender sender)
{
    public IMessageSender Sender { get; set; } = sender;

    public void Send(string message)
    {
        Sender.SendRaw($"[Bridge] {message}");
    }
}

internal static class SenderFactory
{
    public static IMessageSender Create(string key) => key switch
    {
        "email" => new EmailSender(),
        "sms" => new SmsSender(),
        _ => new PushSender()
    };
}

internal sealed class EmailSender : IMessageSender
{
    public void SendRaw(string text) => Console.WriteLine($"Email: {text}");
}

internal sealed class SmsSender : IMessageSender
{
    public void SendRaw(string text) => Console.WriteLine($"Sms: {text}");
}

internal sealed class PushSender : IMessageSender
{
    public void SendRaw(string text) => Console.WriteLine($"Push: {text}");
}
