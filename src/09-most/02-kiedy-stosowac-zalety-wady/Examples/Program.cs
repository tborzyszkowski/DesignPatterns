Console.WriteLine("=== Bez Mostu (eksplozja klas) ===");
var legacy = new IncidentViaEmail();
legacy.Send("Baza danych niedostepna");

Console.WriteLine();
Console.WriteLine("=== Z Mostem ===");
Notification abstraction = new IncidentNotification(new EmailChannel());
abstraction.Send("Baza danych niedostepna");
abstraction.Channel = new SmsChannel();
abstraction.Send("Timeout API");

internal sealed class IncidentViaEmail
{
    public void Send(string message) => Console.WriteLine($"Legacy Incident/Email: {message}");
}

internal interface IChannel
{
    void Deliver(string payload);
}

internal abstract class Notification(IChannel channel)
{
    public IChannel Channel { get; set; } = channel;
    public abstract void Send(string message);
}

internal sealed class IncidentNotification(IChannel channel) : Notification(channel)
{
    public override void Send(string message)
        => Channel.Deliver($"[INCIDENT] {message}");
}

internal sealed class EmailChannel : IChannel
{
    public void Deliver(string payload) => Console.WriteLine($"Email -> {payload}");
}

internal sealed class SmsChannel : IChannel
{
    public void Deliver(string payload) => Console.WriteLine($"Sms -> {payload}");
}
