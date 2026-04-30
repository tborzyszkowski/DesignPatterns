// ============================================================
// Temat 02: Kiedy stosować wzorzec Obserwator
// ============================================================
// Demonstruje:
//   1. Poprawne użycie: giełda akcji z dynamicznymi inwestorami
//   2. Potencjalny wyciek pamięci przy event bez wypisania
//   3. Przypadek gdzie Obserwator jest zbędny
// ============================================================

Console.WriteLine("=== PRZYKŁAD 1: Giełda akcji (dobry przypadek dla Obserwatora) ===");
Console.WriteLine();

var appleShare = new Share("AAPL", 150.00m);

var jan = new Investor("Jan", minBuy: 140m, maxSell: 200m);
var anna = new Investor("Anna", minBuy: 145m, maxSell: 190m);
var auditLog = new AuditLog();

appleShare.Subscribe(jan);
appleShare.Subscribe(anna);
appleShare.Subscribe(auditLog);

appleShare.Price = 148.50m;   // Anna: cena za niska żeby sprzedać, Jan: kupuje
Console.WriteLine();
appleShare.Price = 195.00m;   // Anna: sprzedaje, Jan: nie sprzedaje jeszcze
Console.WriteLine();

appleShare.Unsubscribe(jan);  // Jan wychodzi z rynku

appleShare.Price = 205.00m;   // Jan NIE dostaje powiadomienia

Console.WriteLine();
Console.WriteLine($"[AuditLog] Zalogowano {auditLog.EventCount} zdarzeń");

Console.WriteLine();
Console.WriteLine("=== PRZYKŁAD 2: Wyciek pamięci przy event C# (demonstracja ryzyka) ===");
Console.WriteLine();

// EventSource trzyma referencję do obserwatorów przez event
var source = new EventSource();

// Tworzymy 3 obserwatorów i rejestrujemy — ale nie wypisujemy!
for (int i = 1; i <= 3; i++)
{
    var obs = new LeakyObserver($"Obs-{i}");
    source.DataChanged += obs.OnDataChanged;   // Rejestracja
    // BRAK: source.DataChanged -= obs.OnDataChanged;
    // W GC: source żyje → trzyma obserwatorów przy życiu!
}

source.TriggerChange("Hello");
Console.WriteLine("  [Uwaga] Wszystkie 3 obserwatory wciąż żyją bo source ma referencję przez event!");
Console.WriteLine("  [Fix] Zawsze wypisuj: source.DataChanged -= handler lub używaj IDisposable.");

// ============================================================
// DOMAIN: Giełda akcji
// ============================================================

internal interface IShareObserver
{
    void OnPriceChanged(string symbol, decimal oldPrice, decimal newPrice);
}

internal sealed class Share(string symbol, decimal initialPrice)
{
    private readonly List<IShareObserver> _observers = new();
    private decimal _price = initialPrice;

    public string Symbol => symbol;

    public decimal Price
    {
        get => _price;
        set
        {
            decimal old = _price;
            _price = value;
            Console.WriteLine($"  [{Symbol}] Cena: {old:C} → {value:C}");
            NotifyAll(old, value);
        }
    }

    public void Subscribe(IShareObserver obs) => _observers.Add(obs);
    public void Unsubscribe(IShareObserver obs) => _observers.Remove(obs);

    private void NotifyAll(decimal oldPrice, decimal newPrice)
    {
        foreach (IShareObserver obs in _observers)
            obs.OnPriceChanged(Symbol, oldPrice, newPrice);
    }
}

internal sealed class Investor(string name, decimal minBuy, decimal maxSell) : IShareObserver
{
    public void OnPriceChanged(string symbol, decimal oldPrice, decimal newPrice)
    {
        if (newPrice <= minBuy)
            Console.WriteLine($"    [{name}] KUP {symbol} @ {newPrice:C} (poniżej progu {minBuy:C})");
        else if (newPrice >= maxSell)
            Console.WriteLine($"    [{name}] SPRZEDAJ {symbol} @ {newPrice:C} (powyżej progu {maxSell:C})");
        else
            Console.WriteLine($"    [{name}] Obserwuję {symbol} @ {newPrice:C}");
    }
}

internal sealed class AuditLog : IShareObserver
{
    public int EventCount { get; private set; }

    public void OnPriceChanged(string symbol, decimal oldPrice, decimal newPrice)
    {
        EventCount++;
        Console.WriteLine($"    [AUDIT #{EventCount}] {symbol}: {oldPrice:C} → {newPrice:C}");
    }
}

// ============================================================
// Demonstracja wycieku pamięci z event C#
// ============================================================

internal sealed class EventSource
{
    public event EventHandler<string>? DataChanged;

    public void TriggerChange(string data)
        => DataChanged?.Invoke(this, data);
}

internal sealed class LeakyObserver(string name)
{
    public void OnDataChanged(object? sender, string data)
        => Console.WriteLine($"  [{name}] Otrzymałem: {data}");
}
