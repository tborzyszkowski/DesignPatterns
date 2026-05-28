Console.WriteLine("=== Clean Architecture — Zależności i wstrzykiwanie zależności ===\n");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 1: Problem — naruszenie DIP
// ─────────────────────────────────────────────────────────────
Console.WriteLine("─── Część 1: Naruszenie DIP (ścisłe sprzężenie) ───");
// Symulujemy kod, który NIE stosuje DIP:
var badService = new BadUserService();
badService.Register("jan@email.com"); // zależy bezpośrednio od konkretnej implementacji

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 2: DIP poprawnie — zależność od abstrakcji
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 2: DIP poprawnie — porty i adaptery ───");

// Use Case zna tylko interfejsy (porty), nie implementacje
IUserRepository  repo  = new InMemoryUserRepository();
IEmailService    email = new ConsoleEmailService();

var registerUseCase = new RegisterUserUseCase(repo, email);
await registerUseCase.ExecuteAsync(new RegisterUserCommand("anna@email.com", "Anna Nowak"));
await registerUseCase.ExecuteAsync(new RegisterUserCommand("piotr@email.com", "Piotr Kowal"));
Console.WriteLine($"Użytkowników w repozytorium: {repo.CountAll()}");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 3: Podmiana adaptera bez zmiany Use Case
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 3: Podmiana adaptera (Fake dla testów) ───");
// Ten sam Use Case, ale z Fake zamiast Console — żaden kod Use Case nie zmienił się!
IEmailService fakeEmail = new FakeEmailService();
var ucWithFake = new RegisterUserUseCase(new InMemoryUserRepository(), fakeEmail);
await ucWithFake.ExecuteAsync(new RegisterUserCommand("test@test.com", "Tester"));
Console.WriteLine($"FakeEmail odebrał: {((FakeEmailService)fakeEmail).SentMessages.Count} wiadomości");
Console.WriteLine($"  → {((FakeEmailService)fakeEmail).SentMessages[0]}");

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 4: Composition Root — centralne miejsce wstrzykiwania
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 4: Composition Root ───");
Console.WriteLine("Composition Root — jedyne miejsce, gdzie tworzysz konkrety:\n");

// W normalnej aplikacji Composition Root to Main() lub Program.cs
// Tu pokazujemy wzorzec wprost:
var app = CompositionRoot.BuildApp(useConsoleEmail: true);
await app.RegisterUseCase.ExecuteAsync(new RegisterUserCommand("root@app.com", "Root User"));

Console.WriteLine("\nZmiana implementacji e-mail na fałszywą (np. dla testów):");
var testApp = CompositionRoot.BuildApp(useConsoleEmail: false);
await testApp.RegisterUseCase.ExecuteAsync(new RegisterUserCommand("test2@app.com", "Test User 2"));

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 5: Wiele portów wyjściowych
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Część 5: Wiele portów — fanout powiadomień ───");
var smsService   = new ConsoleSmsService();
var multiEmail   = new FakeEmailService();
var notifyUseCase = new NotifyUserUseCase(multiEmail, smsService);
await notifyUseCase.ExecuteAsync("jan@email.com", "+48600000001", "Witaj w systemie!");

Console.WriteLine("\n=== Podsumowanie ===");
Console.WriteLine("  DIP:               Moduły wysokiego poziomu nie zależą od niskiego");
Console.WriteLine("  Porty:             Interfejsy zdefiniowane w warstwie Application");
Console.WriteLine("  Adaptery:          Implementacje w warstwie Infrastructure");
Console.WriteLine("  Composition Root:  Jedno miejsce tworzenia zależności");


// ═══════════════════════════════════════════════════════════
// TYPY — wszystkie poniżej kodu top-level
// ═══════════════════════════════════════════════════════════

// ── BEZ DIP — antyprzykład ───────────────────────────────────

class BadUserService
{
    // PROBLEM: bezpośrednia zależność od konkretnej klasy!
    private readonly HardcodedEmailSender _sender = new();

    public void Register(string email)
    {
        Console.WriteLine($"  [BAD] Rejestracja: {email}");
        _sender.Send(email, "Witamy!"); // ścisłe sprzężenie!
    }
}

class HardcodedEmailSender // konkretna klasa — brak interfejsu
{
    public void Send(string to, string msg)
        => Console.WriteLine($"  [BAD EmailSender] → {to}: {msg}");
}

// ── Porty (interfejsy Application) ───────────────────────────

interface IUserRepository
{
    Task<bool> ExistsAsync(string email);
    Task AddAsync(UserEntity user);
    int CountAll();
}

interface IEmailService
{
    Task SendAsync(string to, string subject, string body);
}

interface ISmsService
{
    Task SendSmsAsync(string phoneNumber, string message);
}

// ── Komendy / DTO ────────────────────────────────────────────

record RegisterUserCommand(string Email, string FullName);

// ── Use Cases (Application) ──────────────────────────────────

class RegisterUserUseCase(IUserRepository userRepo, IEmailService emailService)
{
    public async Task ExecuteAsync(RegisterUserCommand cmd)
    {
        if (string.IsNullOrWhiteSpace(cmd.Email))
            throw new ArgumentException("Email jest wymagany");

        if (await userRepo.ExistsAsync(cmd.Email))
            throw new InvalidOperationException($"Użytkownik {cmd.Email} już istnieje");

        var user = new UserEntity(Guid.NewGuid(), cmd.Email, cmd.FullName);
        await userRepo.AddAsync(user);
        await emailService.SendAsync(cmd.Email, "Witamy!", $"Cześć {cmd.FullName}, witamy w systemie!");
        Console.WriteLine($"  Zarejestrowano: {cmd.FullName} ({cmd.Email})");
    }
}

class NotifyUserUseCase(IEmailService emailService, ISmsService smsService)
{
    public async Task ExecuteAsync(string email, string phone, string message)
    {
        await emailService.SendAsync(email, "Powiadomienie", message);
        await smsService.SendSmsAsync(phone, message);
    }
}

// ── Encja Domain ─────────────────────────────────────────────

record UserEntity(Guid Id, string Email, string FullName);

// ── Adaptery Infrastructure ───────────────────────────────────

class InMemoryUserRepository : IUserRepository
{
    private readonly Dictionary<string, UserEntity> _db = [];

    public Task<bool> ExistsAsync(string email)
        => Task.FromResult(_db.ContainsKey(email));

    public Task AddAsync(UserEntity user)
    {
        _db[user.Email] = user;
        return Task.CompletedTask;
    }

    public int CountAll() => _db.Count;
}

class ConsoleEmailService : IEmailService
{
    public Task SendAsync(string to, string subject, string body)
    {
        Console.WriteLine($"  [Email] → {to} | {subject}");
        return Task.CompletedTask;
    }
}

class ConsoleSmsService : ISmsService
{
    public Task SendSmsAsync(string phoneNumber, string message)
    {
        Console.WriteLine($"  [SMS] → {phoneNumber}: {message[..Math.Min(30, message.Length)]}...");
        return Task.CompletedTask;
    }
}

class FakeEmailService : IEmailService
{
    public List<string> SentMessages { get; } = [];

    public Task SendAsync(string to, string subject, string body)
    {
        SentMessages.Add($"To={to}, Subject={subject}");
        return Task.CompletedTask;
    }
}

// ── Composition Root ─────────────────────────────────────────

record AppServices(RegisterUserUseCase RegisterUseCase);

static class CompositionRoot
{
    public static AppServices BuildApp(bool useConsoleEmail)
    {
        // Jedyne miejsce, gdzie tworzymy konkrety:
        IUserRepository repo  = new InMemoryUserRepository();
        IEmailService   email = useConsoleEmail
            ? new ConsoleEmailService()
            : new FakeEmailService();

        var registerUseCase = new RegisterUserUseCase(repo, email);
        return new AppServices(registerUseCase);
    }
}
