Alert marketing = new MarketingAlert(new EmailProvider());
marketing.Notify("Nowa promocja -30%.");

Alert incident = new IncidentAlert(new SmsProvider());
incident.Notify("Serwer produkcyjny nie odpowiada.");

Alert security = new SecurityIncidentAlert(new PushProvider());
security.Notify("Wykryto podejrzane logowanie.");

internal interface INotificationProvider
{
    void SendMessage(string payload);
}

internal abstract class Alert(INotificationProvider provider)
{
    protected INotificationProvider Provider { get; } = provider;
    public abstract void Notify(string message);
}

internal sealed class MarketingAlert(INotificationProvider provider) : Alert(provider)
{
    public override void Notify(string message) => Provider.SendMessage($"[MARKETING] {message}");
}

internal sealed class IncidentAlert(INotificationProvider provider) : Alert(provider)
{
    public override void Notify(string message) => Provider.SendMessage($"[INCIDENT] {message}");
}

internal sealed class SecurityIncidentAlert(INotificationProvider provider) : Alert(provider)
{
    public override void Notify(string message) => Provider.SendMessage($"[SECURITY] {message}");
}

internal sealed class EmailProvider : INotificationProvider
{
    public void SendMessage(string payload) => Console.WriteLine($"Email provider => {payload}");
}

internal sealed class SmsProvider : INotificationProvider
{
    public void SendMessage(string payload) => Console.WriteLine($"Sms provider => {payload}");
}

internal sealed class PushProvider : INotificationProvider
{
    public void SendMessage(string payload) => Console.WriteLine($"Push provider => {payload}");
}
