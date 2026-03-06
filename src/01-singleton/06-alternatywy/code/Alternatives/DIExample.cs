namespace Alternatives;

// ─────────────────────────────────────────────────────────────────────────────
// Dependency Injection jako alternatywa dla Singletona
// ─────────────────────────────────────────────────────────────────────────────

public interface IEmailSender
{
    void Send(string to, string subject, string body);
    IReadOnlyList<string> SentMessages { get; }
}

/// <summary>
/// Implementacja produkcyjna — rejestrowana jako Singleton w DI container.
/// </summary>
public sealed class SmtpEmailSender : IEmailSender
{
    private readonly List<string> _sent = new();

    public IReadOnlyList<string> SentMessages => _sent;

    public void Send(string to, string subject, string body)
    {
        var msg = $"[SMTP] → {to} | {subject}";
        Console.WriteLine(msg);
        _sent.Add(msg);
    }
}

/// <summary>
/// Implementacja testowa — wstrzykiwana w testach zamiast SmtpEmailSender.
/// Nie wymaga serwera SMTP.
/// </summary>
public sealed class MockEmailSender : IEmailSender
{
    private readonly List<string> _sent = new();

    public IReadOnlyList<string> SentMessages => _sent;

    public void Send(string to, string subject, string body)
    {
        var msg = $"[MOCK] → {to} | {subject}";
        Console.WriteLine(msg);
        _sent.Add(msg);
    }
}

/// <summary>
/// Serwis korzystający z IEmailSender przez Dependency Injection.
/// Nie zna konkretnej implementacji — zależność jest wstrzykiwana z zewnątrz.
/// </summary>
public sealed class OrderService
{
    private readonly IEmailSender _emailSender;

    public OrderService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public void PlaceOrder(string customerEmail, string productName)
    {
        Console.WriteLine($"[OrderService] Przyjmuję zamówienie na: {productName}");
        _emailSender.Send(
            customerEmail,
            $"Potwierdzenie zamówienia: {productName}",
            $"Dziękujemy za zamówienie produktu: {productName}");
    }
}
