// ============================================================
// Sprint 1: 2 alerty x 2 providery = 4 kombinacje, 4 klasy
// ============================================================
Console.WriteLine("=== Sprint 1: MarketingAlert + IncidentAlert / Email + Sms ===");

Alert marketing = new MarketingAlert(new EmailProvider());
marketing.Notify("Nowa promocja -30%.");

Alert incident = new IncidentAlert(new SmsProvider());
incident.Notify("Serwer produkcyjny nie odpowiada.");

// ============================================================
// Sprint 2 (Team Channel): +PushProvider
//   => zero zmian w MarketingAlert / IncidentAlert
// ============================================================
Console.WriteLine("\n=== Sprint 2 (Team Channel): +PushProvider – alerty bez zmian ===");
Alert incidentPush = new IncidentAlert(new PushProvider());
incidentPush.Notify("CPU > 95%.");

// ============================================================
// Sprint 2 (Team Alert): +SecurityIncidentAlert
//   => zero zmian w EmailProvider / SmsProvider / PushProvider
// ============================================================
Console.WriteLine("\n=== Sprint 2 (Team Alert): +SecurityIncidentAlert – providery bez zmian ===");
Alert security = new SecurityIncidentAlert(new PushProvider());
security.Notify("Wykryto podejrzane logowanie.");

// ============================================================
// Sprint 3 (Team Channel): +WhatsAppProvider
//   => zero zmian we wszystkich alertach
// ============================================================
Console.WriteLine("\n=== Sprint 3 (Team Channel): +WhatsAppProvider – zero zmian w alertach ===");
Alert marketingWa = new MarketingAlert(new WhatsAppProvider());
marketingWa.Notify("Flash sale! 50% rabatu przez 2h.");

Alert securityWa = new SecurityIncidentAlert(new WhatsAppProvider());
securityWa.Notify("Blokada konta po blednych logowaniach.");

// ============================================================
// Sprint 3 (Team Alert): +SlaBreachAlert
//   => zero zmian we wszystkich providerach
// ============================================================
Console.WriteLine("\n=== Sprint 3 (Team Alert): +SlaBreachAlert – zero zmian w providerach ===");
Alert sla = new SlaBreachAlert(new SmsProvider());
sla.Notify("Czas odpowiedzi API przekroczyl 2s.");

// ============================================================
// Interfaces & Implementations
// ============================================================

internal interface INotificationProvider
{
    void SendMessage(string payload);
}

internal abstract class Alert(INotificationProvider provider)
{
    protected INotificationProvider Provider { get; } = provider;
    public abstract void Notify(string message);
}

// ---------- Abstraction (os alertow) ----------

internal sealed class MarketingAlert(INotificationProvider provider) : Alert(provider)
{
    public override void Notify(string message) =>
        Provider.SendMessage($"[MARKETING] {message}");
}

internal sealed class IncidentAlert(INotificationProvider provider) : Alert(provider)
{
    public override void Notify(string message) =>
        Provider.SendMessage($"[INCIDENT] {message}");
}

// RefinedAbstraction Sprint 2 — dodany przez Team Alert
internal sealed class SecurityIncidentAlert(INotificationProvider provider) : Alert(provider)
{
    public override void Notify(string message) =>
        Provider.SendMessage($"[SECURITY][HIGH] {message}");
}

// RefinedAbstraction Sprint 3 — dodany przez Team Alert, zero zmian w providerach
internal sealed class SlaBreachAlert(INotificationProvider provider) : Alert(provider)
{
    public override void Notify(string message) =>
        Provider.SendMessage($"[SLA-BREACH] {message}");
}

// ---------- ConcreteImplementors (os kanalow) ----------

internal sealed class EmailProvider : INotificationProvider
{
    public void SendMessage(string payload) =>
        Console.WriteLine($"Email => {payload}");
}

internal sealed class SmsProvider : INotificationProvider
{
    public void SendMessage(string payload) =>
        Console.WriteLine($"Sms => {payload}");
}

// ConcreteImplementor Sprint 2 — dodany przez Team Channel, alerty bez zmian
internal sealed class PushProvider : INotificationProvider
{
    public void SendMessage(string payload) =>
        Console.WriteLine($"Push => {payload}");
}

// ConcreteImplementor Sprint 3 — dodany przez Team Channel, alerty bez zmian
internal sealed class WhatsAppProvider : INotificationProvider
{
    public void SendMessage(string payload) =>
        Console.WriteLine($"WhatsApp => {payload}");
}

