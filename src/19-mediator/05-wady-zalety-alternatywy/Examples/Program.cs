// =============================================================================
// Wzorzec Mediator — 05. Wady, zalety i alternatywy
// Ten sam problem (zarządzanie zdarzeniami zamówienia) rozwiązany 3 wzorcami
// =============================================================================

Console.WriteLine("═══ Podejście 1: MEDIATOR ═══\n");
Console.WriteLine("  Użycie: wiele komponentów koordynuje się wzajemnie\n");

var orderMediator = new OrderCoordinatorMediator();
orderMediator.Register(new InventoryService());
orderMediator.Register(new EmailService());
orderMediator.Register(new InvoiceService());
orderMediator.Register(new LogService());

var order = new Order(Guid.NewGuid(), "LOT-001", 1500m);
orderMediator.PlaceOrder(order);

Console.WriteLine("\n═══ Podejście 2: OBSERVER ═══\n");
Console.WriteLine("  Użycie: powiadom wszystkich zainteresowanych (broadcast)\n");

var orderEvent = new OrderPlacedEvent();
orderEvent.Subscribe(o => Console.WriteLine($"  [Email] Potwierdzenie dla {o.CustomerRef}"));
orderEvent.Subscribe(o => Console.WriteLine($"  [Stock] Rezerwacja dla {o.Id}"));
orderEvent.Subscribe(o => Console.WriteLine($"  [Log] Zamówienie {o.Id} złożone"));

orderEvent.Raise(order);

Console.WriteLine("\n═══ Podejście 3: ŁAŃCUCH ZOBOWIĄZAŃ ═══\n");
Console.WriteLine("  Użycie: sekwencyjna walidacja + przetwarzanie z możliwością zatrzymania\n");

var validationChain = new FraudCheckHandler();
validationChain
    .SetNext(new StockCheckHandler())
    .SetNext(new PaymentHandler())
    .SetNext(new ConfirmationHandler());

validationChain.Handle(new Order(Guid.NewGuid(), "LEGIT-002", 500m));
Console.WriteLine();
validationChain.Handle(new Order(Guid.NewGuid(), "FRAUD-999", 99999m)); // zatrzyma CoR

// =============================================================================
// WSPÓLNE TYPY
// =============================================================================

record Order(Guid Id, string CustomerRef, decimal Amount);

// =============================================================================
// PODEJŚCIE 1: Mediator
// =============================================================================

interface IOrderComponent
{
    void SetMediator(OrderCoordinatorMediator m);
    void OnOrderPlaced(Order order);
}

class OrderCoordinatorMediator
{
    private readonly List<IOrderComponent> _components = [];

    public void Register(IOrderComponent c) { _components.Add(c); c.SetMediator(this); }

    public void PlaceOrder(Order order)
    {
        Console.WriteLine($"  [Mediator] Koordynuję zamówienie {order.Id}");
        // Mediator decyduje o kolejności i warunkach
        foreach (var c in _components)
            c.OnOrderPlaced(order);
    }

    // Mediator może selektywnie notyfikować:
    public void NotifyType<T>(Order order) where T : IOrderComponent
    {
        foreach (var c in _components.OfType<T>())
            c.OnOrderPlaced(order);
    }
}

class InventoryService : IOrderComponent
{
    private OrderCoordinatorMediator? _mediator;
    public void SetMediator(OrderCoordinatorMediator m) => _mediator = m;
    public void OnOrderPlaced(Order o) => Console.WriteLine($"  [Inventory] Rezerwuję towar dla {o.Id}");
}

class EmailService : IOrderComponent
{
    private OrderCoordinatorMediator? _mediator;
    public void SetMediator(OrderCoordinatorMediator m) => _mediator = m;
    public void OnOrderPlaced(Order o) => Console.WriteLine($"  [Email] Wysyłam potwierdzenie do {o.CustomerRef}");
}

class InvoiceService : IOrderComponent
{
    private OrderCoordinatorMediator? _mediator;
    public void SetMediator(OrderCoordinatorMediator m) => _mediator = m;
    public void OnOrderPlaced(Order o) => Console.WriteLine($"  [Invoice] Generuję fakturę za {o.Amount:N0} zł");
}

class LogService : IOrderComponent
{
    private OrderCoordinatorMediator? _mediator;
    public void SetMediator(OrderCoordinatorMediator m) => _mediator = m;
    public void OnOrderPlaced(Order o) => Console.WriteLine($"  [Log] Zamówienie {o.Id} zarejestrowane");
}

// =============================================================================
// PODEJŚCIE 2: Observer
// =============================================================================

class OrderPlacedEvent
{
    private readonly List<Action<Order>> _subscribers = [];
    public void Subscribe(Action<Order> handler) => _subscribers.Add(handler);
    public void Raise(Order order)
    {
        Console.WriteLine($"  [Event] Zdarzenie: zamówienie {order.Id}");
        foreach (var h in _subscribers)
            h(order);
    }
}

// =============================================================================
// PODEJŚCIE 3: Łańcuch Zobowiązań
// =============================================================================

abstract class OrderHandler
{
    protected OrderHandler? Next;
    public OrderHandler SetNext(OrderHandler next) { Next = next; return next; }
    public abstract bool Handle(Order order);
}

class FraudCheckHandler : OrderHandler
{
    public override bool Handle(Order order)
    {
        if (order.Amount > 50_000)
        {
            Console.WriteLine($"  [FraudCheck] ⛔ Odrzucono: kwota {order.Amount:N0} zł podejrzana");
            return false;
        }
        Console.WriteLine($"  [FraudCheck] ✔ OK");
        return Next?.Handle(order) ?? true;
    }
}

class StockCheckHandler : OrderHandler
{
    public override bool Handle(Order order)
    {
        Console.WriteLine($"  [StockCheck] ✔ Towar dostępny");
        return Next?.Handle(order) ?? true;
    }
}

class PaymentHandler : OrderHandler
{
    public override bool Handle(Order order)
    {
        Console.WriteLine($"  [Payment] ✔ Płatność {order.Amount:N0} zł przetworzona");
        return Next?.Handle(order) ?? true;
    }
}

class ConfirmationHandler : OrderHandler
{
    public override bool Handle(Order order)
    {
        Console.WriteLine($"  [Confirmation] ✔ Zamówienie {order.Id} potwierdzone");
        return true;
    }
}
