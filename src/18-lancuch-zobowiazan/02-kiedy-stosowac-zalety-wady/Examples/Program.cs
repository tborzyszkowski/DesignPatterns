// =============================================================================
// Wzorzec Łańcuch Zobowiązań — 02. Kiedy stosować, zalety i wady
// Demonstruje: 4 odmiany CoR oraz scenariusze, w których wzorzec pomaga
// =============================================================================

// ─── ODMIANA 1: Pure CoR (zatrzymaj się, gdy obsłużono) ──────────────────────

Console.WriteLine("═══ ODMIANA 1: Pure CoR — wniosek urlopowy ═══\n");

// Buduj hierarchię zatwierdzeń zakupów
Approver teamLead     = new TeamLeadApprover(limit: 1_000m);
Approver manager      = new ManagerApprover(limit: 10_000m);
Approver director     = new DirectorApprover(limit: 50_000m);
Approver board        = new BoardApprover();

teamLead.SetNext(manager).SetNext(director).SetNext(board);

decimal[] amounts = [500m, 3_500m, 15_000m, 75_000m];
foreach (var amount in amounts)
{
    Console.Write($"  Wniosek: {amount:C} → ");
    teamLead.Handle(new PurchaseRequest(amount));
}

// ─── ODMIANA 2: Pipeline (każdy handler przetwarza, nie zatrzymuje) ──────────

Console.WriteLine("\n═══ ODMIANA 2: Pipeline — przetwarzanie zamówienia ═══\n");

var pipeline = new OrderPipeline();
pipeline.AddStep(new StockCheckStep())
        .AddStep(new DiscountStep())
        .AddStep(new TaxCalculationStep())
        .AddStep(new NotificationStep());

var order = new Order("Laptop", quantity: 2, unitPrice: 2499m);
Console.WriteLine($"  Zamówienie wejściowe: {order}");
pipeline.Process(order);
Console.WriteLine($"  Zamówienie po przetworzeniu: {order}");

// ─── ODMIANA 3: Interceptor/Decorator (pre + post) ───────────────────────────

Console.WriteLine("\n═══ ODMIANA 3: Interceptor — logging + timing wokół logiki ═══\n");

ICommandHandler saveHandler = new SaveUserHandler();
ICommandHandler withLogging = new LoggingInterceptor(saveHandler);
ICommandHandler withTiming  = new TimingInterceptor(withLogging);

withTiming.Handle(new SaveUserCommand("jan@firma.pl", "Jan Kowalski"));

// ─── ODMIANA 4: Event Bubbling — zatrzymanie propagacji ──────────────────────

Console.WriteLine("\n═══ ODMIANA 4: Event Bubbling — kliknięcie w GUI ═══\n");

var button   = new ButtonControl("Zapisz");
var form     = new FormControl("Formularz logowania");
var window   = new WindowControl("Okno aplikacji");

button.SetParent(form);
form.SetParent(window);

// Kliknięcie obsługuje button
Console.WriteLine("  Kliknięcie na button (button obsługuje, nie propaguje):");
button.HandleClick(new ClickEvent(x: 100, y: 50, stopPropagation: false));

Console.WriteLine("\n  Kliknięcie na button z Ctrl (obsługuje form):");
button.HandleClick(new ClickEvent(x: 100, y: 50, isCtrlHeld: true, stopPropagation: false));

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── ODMIANA 1: Pure CoR — zatwierdzenia zakupów ────────────────────────────

record PurchaseRequest(decimal Amount);

abstract class Approver
{
    private Approver? _next;
    public Approver SetNext(Approver next) { _next = next; return next; }
    public abstract void Handle(PurchaseRequest req);
    protected void PassToNext(PurchaseRequest req) => _next?.Handle(req);
}

class TeamLeadApprover(decimal limit) : Approver
{
    public override void Handle(PurchaseRequest req)
    {
        if (req.Amount <= limit)
            Console.WriteLine($"TeamLead zatwierdza {req.Amount:C}");
        else
        {
            Console.Write("TeamLead → ");
            PassToNext(req);
        }
    }
}

class ManagerApprover(decimal limit) : Approver
{
    public override void Handle(PurchaseRequest req)
    {
        if (req.Amount <= limit)
            Console.WriteLine($"Manager zatwierdza {req.Amount:C}");
        else
        {
            Console.Write("Manager → ");
            PassToNext(req);
        }
    }
}

class DirectorApprover(decimal limit) : Approver
{
    public override void Handle(PurchaseRequest req)
    {
        if (req.Amount <= limit)
            Console.WriteLine($"Dyrektor zatwierdza {req.Amount:C}");
        else
        {
            Console.Write("Dyrektor → ");
            PassToNext(req);
        }
    }
}

class BoardApprover : Approver
{
    public override void Handle(PurchaseRequest req)
        => Console.WriteLine($"Zarząd zatwierdza {req.Amount:C} (ostatnie ogniwo)");
}

// ─── ODMIANA 2: Pipeline ──────────────────────────────────────────────────────

class Order(string product, int quantity, decimal unitPrice)
{
    public string Product      { get; }          = product;
    public int    Quantity     { get; }          = quantity;
    public decimal UnitPrice   { get; }          = unitPrice;
    public bool   InStock      { get; set; }
    public decimal Discount    { get; set; }
    public decimal Tax         { get; set; }
    public decimal TotalPrice  { get; set; }

    public override string ToString()
        => $"{Product} x{Quantity} @ {UnitPrice:C}, Rabat:{Discount:P}, VAT:{Tax:C}, Razem:{TotalPrice:C}";
}

interface IOrderStep
{
    IOrderStep SetNext(IOrderStep next);
    void Process(Order order);
}

abstract class BaseOrderStep : IOrderStep
{
    private IOrderStep? _next;
    public IOrderStep SetNext(IOrderStep next) { _next = next; return next; }
    public abstract void Process(Order order);
    protected void Next(Order order) => _next?.Process(order);
}

class OrderPipeline
{
    private IOrderStep? _first;
    private IOrderStep? _last;

    public OrderPipeline AddStep(IOrderStep step)
    {
        if (_first == null) { _first = _last = step; }
        else                { _last!.SetNext(step); _last = step; }
        return this;
    }

    public void Process(Order order) => _first?.Process(order);
}

class StockCheckStep : BaseOrderStep
{
    public override void Process(Order order)
    {
        order.InStock = true;
        Console.WriteLine($"    [StockCheck] OK — produkt dostępny");
        Next(order);
    }
}

class DiscountStep : BaseOrderStep
{
    public override void Process(Order order)
    {
        order.Discount = order.Quantity >= 5 ? 0.10m : 0m;
        Console.WriteLine($"    [Discount] Rabat: {order.Discount:P}");
        Next(order);
    }
}

class TaxCalculationStep : BaseOrderStep
{
    public override void Process(Order order)
    {
        var net = order.UnitPrice * order.Quantity * (1 - order.Discount);
        order.Tax = net * 0.23m;
        order.TotalPrice = net + order.Tax;
        Console.WriteLine($"    [Tax] VAT: {order.Tax:C}, Łącznie: {order.TotalPrice:C}");
        Next(order);
    }
}

class NotificationStep : BaseOrderStep
{
    public override void Process(Order order)
    {
        Console.WriteLine($"    [Notification] E-mail wysłany o zamówieniu {order.Product}");
        Next(order);
    }
}

// ─── ODMIANA 3: Interceptor ───────────────────────────────────────────────────

record SaveUserCommand(string Email, string Name);

interface ICommandHandler
{
    void Handle(SaveUserCommand cmd);
}

class SaveUserHandler : ICommandHandler
{
    public void Handle(SaveUserCommand cmd)
        => Console.WriteLine($"    [SaveUser] Zapisano: {cmd.Name} ({cmd.Email})");
}

class LoggingInterceptor(ICommandHandler inner) : ICommandHandler
{
    public void Handle(SaveUserCommand cmd)
    {
        Console.WriteLine($"    [LOG] Przed: SaveUser({cmd.Email})");
        inner.Handle(cmd);
        Console.WriteLine($"    [LOG] Po: SaveUser({cmd.Email}) — OK");
    }
}

class TimingInterceptor(ICommandHandler inner) : ICommandHandler
{
    public void Handle(SaveUserCommand cmd)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        inner.Handle(cmd);
        sw.Stop();
        Console.WriteLine($"    [Timing] Czas wykonania: {sw.ElapsedMilliseconds} ms");
    }
}

// ─── ODMIANA 4: Event Bubbling ────────────────────────────────────────────────

record ClickEvent(int X, int Y, bool StopPropagation, bool IsCtrlHeld = false)
{
    public bool IsCtrlHeld { get; init; } = IsCtrlHeld;
}

abstract class UiControl(string name)
{
    protected UiControl? Parent;
    public void SetParent(UiControl parent) => Parent = parent;
    public abstract void HandleClick(ClickEvent evt);
    protected void BubbleUp(ClickEvent evt) => Parent?.HandleClick(evt);
    public override string ToString() => name;
}

class ButtonControl(string name) : UiControl(name)
{
    public override void HandleClick(ClickEvent evt)
    {
        if (!evt.IsCtrlHeld)
        {
            Console.WriteLine($"    [{this}] Obsługa kliknięcia — stop propagacji");
            // stopPropagation = nie woła BubbleUp
        }
        else
        {
            Console.WriteLine($"    [{this}] Ctrl+klik — przekazuję do rodzica");
            BubbleUp(evt);
        }
    }
}

class FormControl(string name) : UiControl(name)
{
    public override void HandleClick(ClickEvent evt)
    {
        Console.WriteLine($"    [{this}] Obsługa kliknięcia w formularzu");
        // nie propaguje dalej
    }
}

class WindowControl(string name) : UiControl(name)
{
    public override void HandleClick(ClickEvent evt)
        => Console.WriteLine($"    [{this}] Okno obsługuje kliknięcie (ostateczny fallback)");
}
