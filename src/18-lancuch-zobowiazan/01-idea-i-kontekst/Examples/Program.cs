// =============================================================================
// Wzorzec Łańcuch Zobowiązań — 01. Idea i kontekst
// Demonstruje: problem "boga obsługi" i rozwiązanie przez Łańcuch Zobowiązań
// =============================================================================

Console.WriteLine("═══ CZĘŚĆ 1: Problem — jeden obiekt obsługuje wszystko ═══\n");

// ANTYPATTERN: jeden GodHandler ze stosem if/else
var god = new GodHandler();
god.HandleRequest(new AuthRequest("jan@firma.pl", "pass123", "192.168.1.1", mfaPassed: false));
Console.WriteLine();

Console.WriteLine("═══ CZĘŚĆ 2: Rozwiązanie — Łańcuch Zobowiązań ═══\n");

// Buduj łańcuch: IPBlockHandler → PasswordHandler → MfaHandler → RolesHandler
var ipBlock  = new IpBlockHandler(blockedIps: ["10.0.0.99"]);
var password = new PasswordHandler();
var mfa      = new MfaHandler();
var roles    = new RolesHandler(requiredRole: "Admin");

// Łańcuch — każdy handler zwraca siebie, co pozwala na budowanie fluent
ipBlock.SetNext(password).SetNext(mfa).SetNext(roles);

Console.WriteLine("Próba 1 — poprawne żądanie:");
var ok = ipBlock.Handle(new AuthRequest("jan@firma.pl", "pass123", "192.168.1.1", mfaPassed: true, role: "Admin"));
Console.WriteLine(ok != null ? $"  ✅ Autoryzacja zakończona sukcesem: {ok}" : "  ❌ Odrzucono");

Console.WriteLine("\nPróba 2 — zablokowany adres IP:");
var blockedIp = ipBlock.Handle(new AuthRequest("hacker@evil.com", "pass", "10.0.0.99", mfaPassed: true));
Console.WriteLine(blockedIp != null ? $"  ✅ Sukces: {blockedIp}" : "  ❌ Odrzucono (zablokowany IP)");

Console.WriteLine("\nPróba 3 — błędne hasło:");
var badPwd = ipBlock.Handle(new AuthRequest("jan@firma.pl", "wrong", "192.168.1.1", mfaPassed: true));
Console.WriteLine(badPwd != null ? $"  ✅ Sukces: {badPwd}" : "  ❌ Odrzucono (błędne hasło)");

Console.WriteLine("\nPróba 4 — brak MFA:");
var noMfa = ipBlock.Handle(new AuthRequest("jan@firma.pl", "pass123", "192.168.1.1", mfaPassed: false));
Console.WriteLine(noMfa != null ? $"  ✅ Sukces: {noMfa}" : "  ❌ Odrzucono (brak MFA)");

Console.WriteLine("\nPróba 5 — zła rola:");
var wrongRole = ipBlock.Handle(new AuthRequest("jan@firma.pl", "pass123", "192.168.1.1", mfaPassed: true, role: "Viewer"));
Console.WriteLine(wrongRole != null ? $"  ✅ Sukces: {wrongRole}" : "  ❌ Odrzucono (niewystarczająca rola)");

Console.WriteLine("\n═══ CZĘŚĆ 3: Dynamiczne dodawanie ogniwa do łańcucha ═══\n");

// Dodaj nowy handler BEZ modyfikacji istniejących
var audit = new AuditLogHandler();
// Wstaw audit na początku łańcucha
audit.SetNext(ipBlock);

Console.WriteLine("Z audit logiem na początku:");
audit.Handle(new AuthRequest("jan@firma.pl", "pass123", "192.168.1.1", mfaPassed: true, role: "Admin"));

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── Model żądania ──────────────────────────────────────────────────────────

record AuthRequest(
    string Email,
    string Password,
    string IpAddress,
    bool MfaPassed,
    string Role = "User");

// ─── ANTYPATTERN: GodHandler ─────────────────────────────────────────────────

class GodHandler
{
    private static readonly HashSet<string> _validUsers = new() { "jan@firma.pl" };
    private static readonly HashSet<string> _blocked    = new() { "10.0.0.99" };

    // PROBLEM: każdy nowy warunek = modyfikacja tej metody
    public void HandleRequest(AuthRequest req)
    {
        Console.WriteLine($"  GodHandler sprawdza żądanie od {req.Email}...");

        if (_blocked.Contains(req.IpAddress))
        {
            Console.WriteLine("  ❌ Zablokowany adres IP");
            return;
        }

        if (!_validUsers.Contains(req.Email) || req.Password != "pass123")
        {
            Console.WriteLine("  ❌ Błędne dane logowania");
            return;
        }

        if (!req.MfaPassed)
        {
            Console.WriteLine("  ❌ Wymagana weryfikacja MFA");
            return;
        }

        Console.WriteLine("  ✅ GodHandler: dostęp przyznany");
    }
}

// ─── WZORZEC: interfejs łańcucha ─────────────────────────────────────────────

interface IAuthHandler
{
    IAuthHandler SetNext(IAuthHandler next);
    string? Handle(AuthRequest request);
}

// ─── Klasa bazowa z domyślną logikę przekazywania ────────────────────────────

abstract class BaseAuthHandler : IAuthHandler
{
    private IAuthHandler? _next;

    public IAuthHandler SetNext(IAuthHandler next)
    {
        _next = next;
        return next;          // fluent builder — można pisać h1.SetNext(h2).SetNext(h3)
    }

    // Metoda szablonowa: podklasa decyduje — obsłuż lub przekaż
    public abstract string? Handle(AuthRequest request);

    protected string? PassToNext(AuthRequest request)
        => _next?.Handle(request);
}

// ─── Konkretne ogniwa ────────────────────────────────────────────────────────

class IpBlockHandler(IEnumerable<string> blockedIps) : BaseAuthHandler
{
    private readonly HashSet<string> _blocked = new(blockedIps);

    public override string? Handle(AuthRequest request)
    {
        if (_blocked.Contains(request.IpAddress))
        {
            Console.WriteLine($"  [IpBlock] 🚫 Zablokowany IP: {request.IpAddress}");
            return null;
        }
        Console.WriteLine($"  [IpBlock] ✔ IP {request.IpAddress} dozwolony");
        return PassToNext(request);
    }
}

class PasswordHandler : BaseAuthHandler
{
    private static readonly Dictionary<string, string> _credentials = new()
    {
        { "jan@firma.pl", "pass123" },
        { "anna@firma.pl", "secret!" },
    };

    public override string? Handle(AuthRequest request)
    {
        if (!_credentials.TryGetValue(request.Email, out var pwd) || pwd != request.Password)
        {
            Console.WriteLine($"  [Password] 🚫 Błędne hasło dla {request.Email}");
            return null;
        }
        Console.WriteLine($"  [Password] ✔ Hasło poprawne dla {request.Email}");
        return PassToNext(request);
    }
}

class MfaHandler : BaseAuthHandler
{
    public override string? Handle(AuthRequest request)
    {
        if (!request.MfaPassed)
        {
            Console.WriteLine($"  [MFA] 🚫 Wymagana weryfikacja dwuetapowa");
            return null;
        }
        Console.WriteLine($"  [MFA] ✔ MFA zaliczone");
        return PassToNext(request);
    }
}

class RolesHandler(string requiredRole) : BaseAuthHandler
{
    public override string? Handle(AuthRequest request)
    {
        if (request.Role != requiredRole)
        {
            Console.WriteLine($"  [Roles] 🚫 Rola '{request.Role}' nie spełnia wymogu '{requiredRole}'");
            return null;
        }
        Console.WriteLine($"  [Roles] ✔ Rola '{request.Role}' OK");
        return $"Token:{request.Email}:{request.Role}";   // sukces — koniec łańcucha
    }
}

class AuditLogHandler : BaseAuthHandler
{
    public override string? Handle(AuthRequest request)
    {
        Console.WriteLine($"  [Audit] 📋 Żądanie od {request.Email} z IP {request.IpAddress}");
        var result = PassToNext(request);
        Console.WriteLine($"  [Audit] 📋 Wynik: {(result != null ? "SUKCES" : "ODRZUCONO")}");
        return result;
    }
}
