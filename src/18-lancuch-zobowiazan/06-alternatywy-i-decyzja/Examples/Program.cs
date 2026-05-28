// =============================================================================
// Wzorzec Łańcuch Zobowiązań — 06. Alternatywy i decyzja
// Ten sam problem (powiadomienia o zdarzeniach) rozwiązany 4 wzorcami
// =============================================================================

Console.WriteLine("═══ Problem: powiadomienie o nowym zamówieniu ═══\n");

// Scenariusz: nowe zamówienie → zapis do bazy + e-mail + SMS + analityka
var order = new Order(42, "jan@firma.pl", 350.00m, Priority.Normal);

Console.WriteLine("─── Wariant 1: Chain of Responsibility ───");
Console.WriteLine("(pierwsze ogniwo, które może obsłużyć, zatrzymuje łańcuch)\n");

IOrderHandler emailHandler = new EmailNotificationHandler();
IOrderHandler smsHandler   = new SmsNotificationHandler();
IOrderHandler dbHandler    = new DatabaseSaveHandler();

// Tylko Email i DB — SMS jest opcjonalny i filtrujemy po priorytecie
emailHandler.SetNext(dbHandler);

emailHandler.Handle(order);

Console.WriteLine("\n─── Wariant 2: Observer / Event ───");
Console.WriteLine("(WSZYSCY subskrybenci są powiadamiani)\n");

var eventBus = new SimpleEventBus<Order>();
eventBus.Subscribe(o => Console.WriteLine($"  [EmailSub]  → wysyłam e-mail do {o.CustomerEmail}"));
eventBus.Subscribe(o => Console.WriteLine($"  [SmsSub]    → wysyłam SMS dla zamówienia #{o.Id}"));
eventBus.Subscribe(o => Console.WriteLine($"  [DbSub]     → zapisuję zamówienie #{o.Id} do bazy"));
eventBus.Subscribe(o => Console.WriteLine($"  [Analytics] → zdarzenie OrderPlaced: {o.Total} zł"));

eventBus.Publish(order);

Console.WriteLine("\n─── Wariant 3: Strategy ───");
Console.WriteLine("(jeden wybrany algorytm powiadomień)\n");

INotificationStrategy strategy = order.Priority == Priority.Urgent
    ? new UrgentNotificationStrategy()
    : new StandardNotificationStrategy();

strategy.Notify(order);

Console.WriteLine("\n─── Wariant 4: Decorator ───");
Console.WriteLine("(każdy dekorator wzbogaca obsługę, wszystkie działają)\n");

IOrderProcessor processor = new CoreOrderProcessor();
processor = new EmailDecorator(processor);
processor = new SmsDecorator(processor);
processor = new AuditDecorator(processor);

processor.Process(order);

Console.WriteLine("\n─── Porównanie ───");
Console.WriteLine("""
  ┌──────────────────────┬────────┬───────────┬────────────┬──────────────────────┐
  │ Cecha                │ CoR    │ Observer  │ Strategy   │ Decorator            │
  ├──────────────────────┼────────┼───────────┼────────────┼──────────────────────┤
  │ Kto obsługuje?       │ jeden  │ wszyscy   │ jeden      │ wszyscy              │
  │ Łańcuch sekwencyjny? │ tak    │ nie       │ nie        │ tak (owijanie)       │
  │ Można przerwać?      │ tak    │ nie       │ nie        │ nie                  │
  │ Zmiana w runtime?    │ tak    │ tak       │ tak        │ ograniczona          │
  │ Wzorzec strukturalny │ nie    │ nie       │ nie        │ TAK                  │
  └──────────────────────┴────────┴───────────┴────────────┴──────────────────────┘
""");

// =============================================================================
// MODELE
// =============================================================================

record Order(int Id, string CustomerEmail, decimal Total, Priority Priority);
enum Priority { Normal, High, Urgent }

// =============================================================================
// WARIANT 1: CoR
// =============================================================================

interface IOrderHandler
{
    IOrderHandler SetNext(IOrderHandler next);
    bool Handle(Order order);
}

abstract class BaseOrderHandler : IOrderHandler
{
    private IOrderHandler? _next;
    public IOrderHandler SetNext(IOrderHandler next) { _next = next; return next; }
    protected bool PassToNext(Order order) => _next?.Handle(order) ?? false;
    public abstract bool Handle(Order order);
}

class EmailNotificationHandler : BaseOrderHandler
{
    public override bool Handle(Order order)
    {
        Console.WriteLine($"  [CoR/Email] → wysyłam e-mail do {order.CustomerEmail}");
        return PassToNext(order);
    }
}

class SmsNotificationHandler : BaseOrderHandler
{
    public override bool Handle(Order order)
    {
        if (order.Priority < Priority.High)
        {
            Console.WriteLine($"  [CoR/SMS]   ↷ pominięto (priorytet zbyt niski)");
            return PassToNext(order);
        }
        Console.WriteLine($"  [CoR/SMS]   → wysyłam SMS dla #{order.Id}");
        return PassToNext(order);
    }
}

class DatabaseSaveHandler : BaseOrderHandler
{
    public override bool Handle(Order order)
    {
        Console.WriteLine($"  [CoR/DB]    → zapisuję zamówienie #{order.Id}");
        return true;
    }
}

// =============================================================================
// WARIANT 2: Observer
// =============================================================================

class SimpleEventBus<T>
{
    private readonly List<Action<T>> _subscribers = [];
    public void Subscribe(Action<T> handler) => _subscribers.Add(handler);
    public void Publish(T @event)
    {
        foreach (var sub in _subscribers)
            sub(@event);
    }
}

// =============================================================================
// WARIANT 3: Strategy
// =============================================================================

interface INotificationStrategy
{
    void Notify(Order order);
}

class StandardNotificationStrategy : INotificationStrategy
{
    public void Notify(Order order)
    {
        Console.WriteLine($"  [Strategy/Standard] → e-mail do {order.CustomerEmail}");
        Console.WriteLine($"  [Strategy/Standard] → zapis do bazy");
    }
}

class UrgentNotificationStrategy : INotificationStrategy
{
    public void Notify(Order order)
    {
        Console.WriteLine($"  [Strategy/Urgent] → PILNY e-mail + SMS + powiadomienie push");
        Console.WriteLine($"  [Strategy/Urgent] → natychmiastowy zapis + alert do managera");
    }
}

// =============================================================================
// WARIANT 4: Decorator
// =============================================================================

interface IOrderProcessor
{
    void Process(Order order);
}

class CoreOrderProcessor : IOrderProcessor
{
    public void Process(Order order)
        => Console.WriteLine($"  [Core]  → przetwarzam zamówienie #{order.Id} ({order.Total} zł)");
}

abstract class OrderProcessorDecorator(IOrderProcessor inner) : IOrderProcessor
{
    public abstract void Process(Order order);
    protected void ProcessNext(Order order) => inner.Process(order);
}

class EmailDecorator(IOrderProcessor inner) : OrderProcessorDecorator(inner)
{
    public override void Process(Order order)
    {
        ProcessNext(order);
        Console.WriteLine($"  [EmailDec] → wysyłam e-mail do {order.CustomerEmail}");
    }
}

class SmsDecorator(IOrderProcessor inner) : OrderProcessorDecorator(inner)
{
    public override void Process(Order order)
    {
        ProcessNext(order);
        Console.WriteLine($"  [SmsDec]   → wysyłam SMS dla #{order.Id}");
    }
}

class AuditDecorator(IOrderProcessor inner) : OrderProcessorDecorator(inner)
{
    public override void Process(Order order)
    {
        Console.WriteLine($"  [Audit]    → START {DateTime.Now:HH:mm:ss}");
        ProcessNext(order);
        Console.WriteLine($"  [Audit]    → KONIEC — zamówienie przetworzone");
    }
}
