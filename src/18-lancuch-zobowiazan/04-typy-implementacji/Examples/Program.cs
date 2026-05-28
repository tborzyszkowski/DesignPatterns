// =============================================================================
// Wzorzec Łańcuch Zobowiązań — 04. Typy implementacji
// Demonstruje: 4 typy implementacji CoR w nowoczesnym C#
// =============================================================================

// ─── TYP 1: Klasyczny OOP ────────────────────────────────────────────────────

Console.WriteLine("═══ TYP 1: Klasyczny OOP — walidacja formularza ═══\n");

IValidator requiredField = new RequiredFieldValidator("Email");
IValidator emailFormat   = new EmailFormatValidator("Email");
IValidator uniqueEmail   = new UniqueEmailValidator("Email",
    existing: ["jan@firma.pl", "anna@firma.pl"]);

requiredField.SetNext(emailFormat).SetNext(uniqueEmail);

string[] testEmails = ["", "not-an-email", "jan@firma.pl", "nowy@firma.pl"];
foreach (var email in testEmails)
{
    Console.Write($"  '{email}': ");
    var result = requiredField.Validate(email);
    Console.WriteLine(result?.ErrorMessage ?? "✔ poprawny");
}

// ─── TYP 2: Delegatowy Pipeline (Func<>) ────────────────────────────────────

Console.WriteLine("\n═══ TYP 2: Delegatowy Pipeline — przetwarzanie tekstu ═══\n");

var textPipeline = new DelegatePipeline<string, string>();

textPipeline
    .Use((input, next) =>
    {
        Console.WriteLine("  [Trim]");
        return next(input.Trim());
    })
    .Use((input, next) =>
    {
        Console.WriteLine("  [ToLower]");
        return next(input.ToLowerInvariant());
    })
    .Use((input, next) =>
    {
        Console.WriteLine("  [RemoveDoubleSpaces]");
        var cleaned = System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ");
        return next(cleaned);
    });

var processedText = textPipeline.Execute("  Witaj  Świecie  ");
Console.WriteLine($"  Wejście:  '  Witaj  Świecie  '");
Console.WriteLine($"  Wyjście: '{processedText}'");

// ─── TYP 3: Middleware-style z kontekstem (symulacja ASP.NET Core) ───────────

Console.WriteLine("\n═══ TYP 3: Middleware pipeline — symulacja ASP.NET Core ═══\n");

var app = new MiddlewareApp();

app.Use(async (ctx, next) =>
{
    Console.WriteLine($"  [Logger] → {ctx.Path}");
    await next(ctx);
    Console.WriteLine($"  [Logger] ← {ctx.StatusCode}");
});

app.Use(async (ctx, next) =>
{
    if (ctx.Path == "/secret")
    {
        ctx.StatusCode = 401;
        Console.WriteLine("  [Auth] 🚫 Nieautoryzowany dostęp");
        return;
    }
    await next(ctx);
});

app.Use(async (ctx, next) =>
{
    Console.WriteLine($"  [Router] Obsługa {ctx.Path}");
    ctx.StatusCode = 200;
    ctx.Response = $"<html>Strona: {ctx.Path}</html>";
    await next(ctx);
});

Console.WriteLine("  Żądanie: GET /home");
await app.RunAsync(new HttpContext("/home"));

Console.WriteLine();
Console.WriteLine("  Żądanie: GET /secret");
await app.RunAsync(new HttpContext("/secret"));

// ─── TYP 4: IPipelineBehavior — symulacja MediatR ───────────────────────────

Console.WriteLine("\n═══ TYP 4: IPipelineBehavior — CQRS pipeline ═══\n");

var pipeline = new MediatRSimulator();
pipeline.AddBehavior(new LoggingBehavior<CreateUserCommand, UserCreatedResult>());
pipeline.AddBehavior(new ValidationBehaviorSim<CreateUserCommand, UserCreatedResult>());
pipeline.AddBehavior(new RetryBehavior<CreateUserCommand, UserCreatedResult>(maxRetries: 2));

var cmd = new CreateUserCommand("jan@firma.pl", "Jan Kowalski");
var result = await pipeline.SendAsync<CreateUserCommand, UserCreatedResult>(
    cmd,
    _ => Task.FromResult(new UserCreatedResult(Guid.NewGuid(), "jan@firma.pl")));

Console.WriteLine($"\n  Wynik: UserId={result?.UserId}");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── TYP 1: Klasyczny OOP — walidacja ────────────────────────────────────────

record ValidationResult(string FieldName, string ErrorMessage);

interface IValidator
{
    IValidator SetNext(IValidator next);
    ValidationResult? Validate(string value);
}

abstract class BaseValidator(string fieldName) : IValidator
{
    private IValidator? _next;

    public IValidator SetNext(IValidator next)
    {
        _next = next;
        return next;
    }

    public abstract ValidationResult? Validate(string value);

    protected ValidationResult? PassToNext(string value)
        => _next?.Validate(value);

    protected string FieldName => fieldName;
}

class RequiredFieldValidator(string fieldName) : BaseValidator(fieldName)
{
    public override ValidationResult? Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new(FieldName, $"{FieldName} jest wymagany");
        return PassToNext(value);
    }
}

class EmailFormatValidator(string fieldName) : BaseValidator(fieldName)
{
    private static readonly System.Text.RegularExpressions.Regex _emailRe =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    public override ValidationResult? Validate(string value)
    {
        if (!_emailRe.IsMatch(value))
            return new(FieldName, $"Niepoprawny format adresu email: '{value}'");
        return PassToNext(value);
    }
}

class UniqueEmailValidator(string fieldName, IEnumerable<string> existing) : BaseValidator(fieldName)
{
    private readonly HashSet<string> _existing = new(existing, StringComparer.OrdinalIgnoreCase);

    public override ValidationResult? Validate(string value)
    {
        if (_existing.Contains(value))
            return new(FieldName, $"Adres email '{value}' jest już zajęty");
        return PassToNext(value);
    }
}

// ─── TYP 2: Delegatowy Pipeline ───────────────────────────────────────────────

class DelegatePipeline<TInput, TOutput>
{
    private readonly List<Func<TInput, Func<TInput, TOutput>, TOutput>> _handlers = [];

    public DelegatePipeline<TInput, TOutput> Use(
        Func<TInput, Func<TInput, TOutput>, TOutput> handler)
    {
        _handlers.Add(handler);
        return this;
    }

    public TOutput Execute(TInput input)
    {
        // Zbuduj łańcuch wywołań od końca (fold right)
        Func<TInput, TOutput> next = _ => throw new InvalidOperationException("Brak handlera końcowego");

        for (int i = _handlers.Count - 1; i >= 0; i--)
        {
            var current = _handlers[i];
            var capturedNext = next;
            next = inp => current(inp, capturedNext);
        }

        return next(input);
    }
}

// ─── TYP 3: Middleware pipeline ───────────────────────────────────────────────

class HttpContext(string path)
{
    public string Path { get; } = path;
    public int StatusCode { get; set; }
    public string? Response { get; set; }
}

class MiddlewareApp
{
    private readonly List<Func<HttpContext, Func<HttpContext, Task>, Task>> _middlewares = [];

    public void Use(Func<HttpContext, Func<HttpContext, Task>, Task> middleware)
        => _middlewares.Add(middleware);

    public Task RunAsync(HttpContext ctx)
    {
        Func<HttpContext, Task> next = _ => Task.CompletedTask;

        for (int i = _middlewares.Count - 1; i >= 0; i--)
        {
            var current = _middlewares[i];
            var capturedNext = next;
            next = c => current(c, capturedNext);
        }

        return next(ctx);
    }
}

// ─── TYP 4: IPipelineBehavior (MediatR-style) ────────────────────────────────

record CreateUserCommand(string Email, string Name);
record UserCreatedResult(Guid UserId, string Email);

interface IPipelineBehaviorSim<TRequest, TResponse>
{
    Task<TResponse> Handle(
        TRequest request,
        Func<TRequest, Task<TResponse>> next,
        CancellationToken ct = default);
}

class MediatRSimulator
{
    private readonly List<object> _behaviors = [];

    public void AddBehavior<TReq, TRes>(IPipelineBehaviorSim<TReq, TRes> behavior)
        => _behaviors.Add(behavior);

    public Task<TRes> SendAsync<TReq, TRes>(TReq request, Func<TReq, Task<TRes>> handler)
    {
        Func<TReq, Task<TRes>> next = handler;

        for (int i = _behaviors.Count - 1; i >= 0; i--)
        {
            if (_behaviors[i] is IPipelineBehaviorSim<TReq, TRes> behavior)
            {
                var capturedNext = next;
                next = req => behavior.Handle(req, capturedNext);
            }
        }

        return next(request);
    }
}

class LoggingBehavior<TReq, TRes> : IPipelineBehaviorSim<TReq, TRes>
{
    public async Task<TRes> Handle(TReq request, Func<TReq, Task<TRes>> next, CancellationToken ct = default)
    {
        Console.WriteLine($"  [Log] → {typeof(TReq).Name}");
        var result = await next(request);
        Console.WriteLine($"  [Log] ← {typeof(TRes).Name}");
        return result;
    }
}

class ValidationBehaviorSim<TReq, TRes> : IPipelineBehaviorSim<TReq, TRes>
{
    public async Task<TRes> Handle(TReq request, Func<TReq, Task<TRes>> next, CancellationToken ct = default)
    {
        Console.WriteLine($"  [Validation] Sprawdzam {typeof(TReq).Name}...");
        // Tutaj byłaby prawdziwa walidacja (np. FluentValidation)
        return await next(request);
    }
}

class RetryBehavior<TReq, TRes>(int maxRetries) : IPipelineBehaviorSim<TReq, TRes>
{
    public async Task<TRes> Handle(TReq request, Func<TReq, Task<TRes>> next, CancellationToken ct = default)
    {
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                Console.WriteLine($"  [Retry] Próba {attempt}/{maxRetries}");
                return await next(request);
            }
            catch when (attempt < maxRetries)
            {
                Console.WriteLine($"  [Retry] Błąd — powtarzam");
            }
        }
        return await next(request);
    }
}
