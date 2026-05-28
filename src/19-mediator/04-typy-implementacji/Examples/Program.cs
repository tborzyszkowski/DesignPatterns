// =============================================================================
// Wzorzec Mediator — 04. Typy implementacji
// Cztery sposoby implementacji Mediatora w C# .NET 9
// =============================================================================

Console.WriteLine("═══ Typ 1: Klasyczny GoF ═══\n");

var dialog = new LoginDialog();
dialog.LoginButton.Click();

Console.WriteLine("\n═══ Typ 2: Mediator oparty na delegatach ═══\n");

var eventMediator = new EventMediator();

// Rejestracja handlerów
eventMediator.Subscribe("order_placed", data => Console.WriteLine($"  [Email] Zamówienie {data}"));
eventMediator.Subscribe("order_placed", data => Console.WriteLine($"  [Stock] Rezerwacja dla {data}"));
eventMediator.Subscribe("order_shipped", data => Console.WriteLine($"  [Tracking] Paczka wysłana: {data}"));

eventMediator.Publish("order_placed", "ORD-001");
eventMediator.Publish("order_shipped", "ORD-001");

Console.WriteLine("\n═══ Typ 3: MediatR-style (Request/Response) ═══\n");

var mediator = new SimpleMediator();
mediator.Register<CreateUserCommand, UserDto>(new CreateUserHandler());
mediator.Register<GetUserQuery, UserDto?>(new GetUserHandler());

var newUser = await mediator.Send<CreateUserCommand, UserDto>(
    new CreateUserCommand("jan@firma.pl", "Jan Kowalski"));
Console.WriteLine($"  Stworzono: {newUser}");

var found = await mediator.Send<GetUserQuery, UserDto?>(new GetUserQuery(newUser.Id));
Console.WriteLine($"  Znaleziono: {found}");

Console.WriteLine("\n═══ Typ 4: Mediator funkcyjny (lambda pipeline) ═══\n");

var pipeline = new FunctionalMediator();

// Budowanie pipeline — każda funkcja może przetworzyć i przekazać dalej
pipeline.Use(async (msg, next) =>
{
    Console.WriteLine($"  [Logger] Przed: {msg.Type}");
    var result = await next(msg);
    Console.WriteLine($"  [Logger] Po: {msg.Type}");
    return result;
});

pipeline.Use(async (msg, next) =>
{
    if (string.IsNullOrEmpty(msg.Payload))
        return "Błąd: brak danych";
    return await next(msg);
});

pipeline.Handle(async msg =>
{
    await Task.Delay(1); // symulacja pracy
    return $"Wynik: {msg.Payload.ToUpper()}";
});

var output = await pipeline.Execute(new Message("process", "hello world"));
Console.WriteLine($"  {output}");

// =============================================================================
// TYP 1: Klasyczny GoF
// =============================================================================

interface IDialogMediator
{
    void Notify(object sender, string @event);
}

abstract class DialogComponent(string name)
{
    public string Name => name;
    protected IDialogMediator? Mediator;
    public void SetMediator(IDialogMediator m) => Mediator = m;
    protected void Notify(string @event) => Mediator?.Notify(this, @event);
}

class LoginButton(string name) : DialogComponent(name)
{
    public void Click() { Console.WriteLine($"  [{Name}] Kliknięto"); Notify("click"); }
    public void Enable()  => Console.WriteLine($"  [{Name}] Aktywny");
    public void Disable() => Console.WriteLine($"  [{Name}] Nieaktywny");
}

class UsernameInput(string name) : DialogComponent(name)
{
    public string Text { get; private set; } = "";
    public void SetText(string text) { Text = text; Notify("input"); }
}

class PasswordInput(string name) : DialogComponent(name)
{
    public string Value { get; private set; } = "";
    public void SetValue(string v) { Value = v; Notify("input"); }
}

class StatusLabel(string name) : DialogComponent(name)
{
    public void Show(string msg) => Console.WriteLine($"  [{Name}]: {msg}");
}

class LoginDialog
{
    public LoginButton   LoginButton { get; } = new("LoginBtn");
    private UsernameInput _username   = new("UsernameInput");
    private PasswordInput _password   = new("PasswordInput");
    private StatusLabel   _status     = new("StatusLabel");

    private IDialogMediator _mediator;

    public LoginDialog()
    {
        _mediator = new LoginMediator(LoginButton, _username, _password, _status);
        LoginButton.SetMediator(_mediator);
        _username.SetMediator(_mediator);
        _password.SetMediator(_mediator);
        _status.SetMediator(_mediator);

        // Inicjalizacja — formularz pusty
        _username.SetText("jan");
        _password.SetValue("secret123");
    }
}

class LoginMediator(LoginButton btn, UsernameInput user, PasswordInput pass, StatusLabel status)
    : IDialogMediator
{
    public void Notify(object sender, string @event)
    {
        switch (sender, @event)
        {
            case (LoginButton, "click"):
                if (string.IsNullOrWhiteSpace(user.Text) || string.IsNullOrWhiteSpace(pass.Value))
                    status.Show("Uzupełnij login i hasło");
                else
                    status.Show($"Logowanie jako '{user.Text}'...");
                break;

            case (UsernameInput, "input") or (PasswordInput, "input"):
                // Aktywuj przycisk tylko gdy oba pola mają wartości
                if (!string.IsNullOrWhiteSpace(user.Text) && !string.IsNullOrWhiteSpace(pass.Value))
                    btn.Enable();
                else
                    btn.Disable();
                break;
        }
    }
}

// =============================================================================
// TYP 2: Mediator oparty na delegatach
// =============================================================================

class EventMediator
{
    private readonly Dictionary<string, List<Action<string>>> _handlers = new();

    public void Subscribe(string @event, Action<string> handler)
    {
        if (!_handlers.TryGetValue(@event, out var list))
            _handlers[@event] = list = [];
        list.Add(handler);
    }

    public void Publish(string @event, string data)
    {
        if (_handlers.TryGetValue(@event, out var handlers))
            foreach (var h in handlers)
                h(data);
    }
}

// =============================================================================
// TYP 3: MediatR-style
// =============================================================================

interface IRequest<TResponse> { }

interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request);
}

class SimpleMediator
{
    private readonly Dictionary<Type, object> _handlers = new();

    public void Register<TRequest, TResponse>(IRequestHandler<TRequest, TResponse> handler)
        where TRequest : IRequest<TResponse>
        => _handlers[typeof(TRequest)] = handler;

    public Task<TResponse> Send<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
    {
        var handler = (IRequestHandler<TRequest, TResponse>)_handlers[typeof(TRequest)];
        return handler.Handle(request);
    }
}

record UserDto(Guid Id, string Email, string Name);

record CreateUserCommand(string Email, string Name) : IRequest<UserDto>;
record GetUserQuery(Guid Id) : IRequest<UserDto?>;

class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private static readonly List<UserDto> _db = [];

    public Task<UserDto> Handle(CreateUserCommand request)
    {
        var user = new UserDto(Guid.NewGuid(), request.Email, request.Name);
        _db.Add(user);
        Console.WriteLine($"  [CreateUserHandler] Stworzono użytkownika {user.Email}");
        return Task.FromResult(user);
    }
}

class GetUserHandler : IRequestHandler<GetUserQuery, UserDto?>
{
    private static readonly List<UserDto> _db = [];

    public Task<UserDto?> Handle(GetUserQuery request)
    {
        // W rzeczywistości szukamy w bazie; tu symulujemy
        var user = new UserDto(request.Id, "jan@firma.pl", "Jan Kowalski");
        Console.WriteLine($"  [GetUserHandler] Pobrano użytkownika {user.Email}");
        return Task.FromResult<UserDto?>(user);
    }
}

// =============================================================================
// TYP 4: Mediator funkcyjny (lambda pipeline)
// =============================================================================

record Message(string Type, string Payload);

delegate Task<string> MessageDelegate(Message message);
delegate Task<string> MiddlewareDelegate(Message message, MessageDelegate next);

class FunctionalMediator
{
    private readonly List<MiddlewareDelegate> _middlewares = [];
    private MessageDelegate? _finalHandler;

    public void Use(MiddlewareDelegate middleware) => _middlewares.Add(middleware);

    public void Handle(MessageDelegate handler) => _finalHandler = handler;

    public Task<string> Execute(Message message)
    {
        MessageDelegate pipeline = _finalHandler
            ?? (_ => Task.FromResult("Brak handlera"));

        // Zbuduj pipeline od końca
        for (int i = _middlewares.Count - 1; i >= 0; i--)
        {
            var next = pipeline;
            var mw = _middlewares[i];
            pipeline = msg => mw(msg, next);
        }

        return pipeline(message);
    }
}
