namespace SimpleFactory.Notifications;

// =====================================================================
// PROSTA FABRYKA — przykład z powiadomieniami
// =====================================================================

public interface INotification
{
    string Channel { get; }
    void Send(string recipient, string message);
}

public class EmailNotification : INotification
{
    public string Channel => "Email";
    public void Send(string recipient, string message)
        => Console.WriteLine($"[Email → {recipient}] {message}");
}

public class SmsNotification : INotification
{
    public string Channel => "SMS";
    public void Send(string recipient, string message)
        => Console.WriteLine($"[SMS → {recipient}] {message}");
}

public class PushNotification : INotification
{
    public string Channel => "Push";
    public void Send(string recipient, string message)
        => Console.WriteLine($"[Push → {recipient}] {message}");
}

// Nowy typ — żeby go dodać, musimy zmienić fabrykę (naruszenie OCP)
public class SlackNotification : INotification
{
    public string Channel => "Slack";
    public void Send(string recipient, string message)
        => Console.WriteLine($"[Slack → #{recipient}] {message}");
}

/// <summary>
/// Prosta fabryka powiadomień.
/// Akceptowalna, gdy kanały są stabilne lub zmiana fabryki jest prosta i izolowana.
/// </summary>
public class NotificationFactory
{
    public INotification Create(string channel)
    {
        return channel.ToLower() switch
        {
            "email" => new EmailNotification(),
            "sms"   => new SmsNotification(),
            "push"  => new PushNotification(),
            "slack" => new SlackNotification(),
            _ => throw new ArgumentException($"Nieznany kanał: {channel}")
        };
    }
}

public class NotificationService
{
    private readonly NotificationFactory _factory;

    public NotificationService(NotificationFactory factory)
    {
        _factory = factory;
    }

    public void Notify(string channel, string recipient, string message)
    {
        var notification = _factory.Create(channel);
        notification.Send(recipient, message);
    }
}
