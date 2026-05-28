// =============================================================================
// Wzorzec Mediator — 02. Kiedy stosować, zalety i wady
// Scenariusze: czat, workflow zatwierdzania, event bus
// =============================================================================

Console.WriteLine("═══ Wariant 1: Czat (klasyczny przykład GoF) ═══\n");

var chatroom = new Chatroom();
chatroom.Register(new Participant("Jan"));
chatroom.Register(new Participant("Anna"));
chatroom.Register(new Participant("Piotr"));

chatroom.Send("Jan",  "Anna",  "Cześć Anno!");
chatroom.Send("Anna", "Jan",   "Hej Janie!");
chatroom.Send("Jan",  null,    "Wszystkim: dobranoc!"); // broadcast

Console.WriteLine("\n═══ Wariant 2: Workflow zatwierdzania zakupów ═══\n");

var approvalWorkflow = new PurchaseApprovalMediator();
var employee  = new Employee("Karolina", budget: 1000);
var manager   = new Manager("Dyrektor Jan", approvalLimit: 10_000);
var cfo       = new CFO("CFO Maria");

approvalWorkflow.Register(employee);
approvalWorkflow.Register(manager);
approvalWorkflow.Register(cfo);

employee.RequestPurchase("Laptop", 3_500);
employee.RequestPurchase("Serwer", 25_000);
employee.RequestPurchase("Długopisy", 50);

Console.WriteLine("\n═══ Wariant 3: Event Bus (publisher-subscriber) ═══\n");

var bus = new SimpleEventBus();

// Subskrybenci nie znają się nawzajem
bus.Subscribe<UserRegisteredEvent>(e =>
    Console.WriteLine($"  [EmailService] Wysyłam powitalny e-mail do {e.Email}"));
bus.Subscribe<UserRegisteredEvent>(e =>
    Console.WriteLine($"  [Analytics] Nowy użytkownik: {e.Email}"));
bus.Subscribe<UserRegisteredEvent>(e =>
    Console.WriteLine($"  [Audit] Zarejestrowano: {e.Email} o {DateTime.Now:HH:mm}"));

// Wydawca nie zna subskrybentów
bus.Publish(new UserRegisteredEvent("jan@firma.pl", "Jan Kowalski"));

Console.WriteLine("\n═══ Kiedy NIE stosować Mediatora ═══\n");
Console.WriteLine("  ✗ Tylko 2 obiekty komunikują się — bezpośrednia ref jest prostsza");
Console.WriteLine("  ✗ Mediator staje się God Object (300+ linii) — podziel na mniejsze");
Console.WriteLine("  ✗ Komunikacja jest jednostronna — wystarczy Facade lub Strategy");

// =============================================================================
// WARIANT 1: Czat
// =============================================================================

interface IChatroom
{
    void Register(Participant participant);
    void Send(string from, string? to, string message);
}

class Chatroom : IChatroom
{
    private readonly Dictionary<string, Participant> _participants = new();

    public void Register(Participant participant)
    {
        _participants[participant.Name] = participant;
        participant.SetChatroom(this);
        Console.WriteLine($"  [{participant.Name}] dołączył do czatu");
    }

    public void Send(string from, string? to, string message)
    {
        if (to is null)
        {
            // Broadcast — mediator rozsyła do wszystkich
            Console.WriteLine($"  [{from}→wszystkich] {message}");
            foreach (var p in _participants.Values.Where(p => p.Name != from))
                p.Receive(from, message);
        }
        else if (_participants.TryGetValue(to, out var recipient))
        {
            Console.WriteLine($"  [{from}→{to}] {message}");
            recipient.Receive(from, message);
        }
    }
}

class Participant(string name)
{
    public string Name => name;
    private IChatroom? _chatroom;

    public void SetChatroom(IChatroom chatroom) => _chatroom = chatroom;
    public void Send(string to, string message) => _chatroom?.Send(Name, to, message);
    public void Receive(string from, string message)
        => Console.WriteLine($"  [{Name} otrzymał od {from}]: {message}");
}

// =============================================================================
// WARIANT 2: Workflow zatwierdzania
// =============================================================================

interface IApprovalMediator
{
    void RequestApproval(string requester, string item, decimal amount);
    void Approve(string approver, string item);
    void Reject(string approver, string item, string reason);
}

class PurchaseApprovalMediator : IApprovalMediator
{
    private readonly List<PurchaseApprover> _approvers = [];

    public void Register(PurchaseApprover approver)
    {
        _approvers.Add(approver);
        approver.SetMediator(this);
    }

    public void RequestApproval(string requester, string item, decimal amount)
    {
        Console.WriteLine($"  [{requester}] Wniosek: '{item}' za {amount:N0} zł");

        // Mediator decyduje, kto ma zatwierdzić
        var approver = _approvers
            .OfType<PurchaseApprover>()
            .Where(a => a.Name != requester)
            .OrderBy(a => a.ApprovalLimit)
            .FirstOrDefault(a => a.ApprovalLimit >= amount);

        if (approver != null)
            approver.ReviewRequest(requester, item, amount);
        else
            Console.WriteLine($"  [Mediator] Brak osoby z uprawnieniami do {amount:N0} zł");
    }

    public void Approve(string approver, string item)
        => Console.WriteLine($"  ✔ [{approver}] Zatwierdził: '{item}'");

    public void Reject(string approver, string item, string reason)
        => Console.WriteLine($"  ✗ [{approver}] Odrzucił: '{item}' — {reason}");
}

abstract class PurchaseApprover(string name, decimal approvalLimit)
{
    public string Name => name;
    public decimal ApprovalLimit => approvalLimit;
    protected IApprovalMediator? Mediator;

    public void SetMediator(IApprovalMediator mediator) => Mediator = mediator;
    public abstract void ReviewRequest(string from, string item, decimal amount);
    public void RequestPurchase(string item, decimal amount)
        => Mediator?.RequestApproval(Name, item, amount);
}

class Employee(string name, decimal budget)
    : PurchaseApprover(name, budget)
{
    public override void ReviewRequest(string from, string item, decimal amount)
        => Mediator?.Reject(Name, item, "Pracownik nie ma uprawnień do zatwierdzania");
}

class Manager(string name, decimal approvalLimit)
    : PurchaseApprover(name, approvalLimit)
{
    public override void ReviewRequest(string from, string item, decimal amount)
    {
        if (amount <= ApprovalLimit)
            Mediator?.Approve(Name, item);
        else
            Mediator?.Reject(Name, item, $"Przekracza limit {ApprovalLimit:N0} zł");
    }
}

class CFO(string name) : PurchaseApprover(name, decimal.MaxValue)
{
    public override void ReviewRequest(string from, string item, decimal amount)
        => Mediator?.Approve(Name, $"{item} (kwota: {amount:N0} zł — zatwierdzone przez CFO)");
}

// =============================================================================
// WARIANT 3: Event Bus
// =============================================================================

record UserRegisteredEvent(string Email, string Name);

class SimpleEventBus
{
    private readonly Dictionary<Type, List<Action<object>>> _handlers = new();

    public void Subscribe<T>(Action<T> handler)
    {
        var type = typeof(T);
        if (!_handlers.ContainsKey(type))
            _handlers[type] = [];
        _handlers[type].Add(e => handler((T)e));
    }

    public void Publish<T>(T @event) where T : notnull
    {
        if (_handlers.TryGetValue(typeof(T), out var handlers))
            foreach (var h in handlers)
                h(@event);
    }
}
