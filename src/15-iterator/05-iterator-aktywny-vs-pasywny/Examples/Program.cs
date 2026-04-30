// =============================================================================
// Wzorzec Iterator — 05. Iterator aktywny vs pasywny
// Demonstruje: pull vs push, wczesne przerwanie, zip, technologie .NET
// =============================================================================
using System.Collections;

// ─── DEMONSTRACJA 1: Iterator aktywny (pull) ──────────────────────────────────

Console.WriteLine("═══ DEMONSTRACJA 1: Iterator Aktywny (Pull / Zewnętrzny) ═══\n");

var numbers = new NumberSequence([10, 20, 30, 40, 50, 60, 70]);

// Klient steruje — wczesne przerwanie po znalezieniu > 45
Console.Write("Szukamy pierwszego > 45: ");
using var pullIter = numbers.GetEnumerator();
while (pullIter.MoveNext())
{
    if (pullIter.Current > 45)
    {
        Console.WriteLine($"Znaleziono: {pullIter.Current}");
        break; // ← wczesne przerwanie niemożliwe w iteratorze pasywnym!
    }
}

// Synchronizacja dwóch iteratorów (zip-like)
Console.WriteLine("\nZip dwóch sekwencji (wymaga iteratora aktywnego):");
var letters = new CharSequence(['A', 'B', 'C', 'D']);
using var numIter = numbers.GetEnumerator();
using var charIter = letters.GetEnumerator();

while (numIter.MoveNext() && charIter.MoveNext())
    Console.Write($"({numIter.Current},{charIter.Current}) ");
Console.WriteLine();

// Przeplatanie dwóch kolekcji
Console.WriteLine("\nPrzeplatanie (ABABAB...):");
var col1 = new NumberSequence([1, 3, 5]);
var col2 = new NumberSequence([2, 4, 6]);
foreach (int n in Interleave(col1, col2))
    Console.Write(n + " ");
Console.WriteLine("\n");

// ─── DEMONSTRACJA 2: Iterator pasywny (push) ──────────────────────────────────

Console.WriteLine("═══ DEMONSTRACJA 2: Iterator Pasywny (Push / Wewnętrzny) ═══\n");

var orderList = new OrderCollection();
orderList.Add(new Order("ORD-001", 150m, "pendding"));
orderList.Add(new Order("ORD-002", 320m, "completed"));
orderList.Add(new Order("ORD-003", 75m, "pending"));
orderList.Add(new Order("ORD-004", 499m, "completed"));

// Prosty push — kolekcja wywołuje akcję dla każdego elementu
Console.WriteLine("Wszystkie zamówienia (ForEach):");
orderList.ForEach(o => Console.WriteLine($"  {o.Id}: {o.Amount:C} [{o.Status}]"));

// Push z predykatem
Console.WriteLine("\nTylko ukończone zamówienia:");
orderList.ForEach(o =>
{
    if (o.Status == "completed")
        Console.WriteLine($"  ✓ {o.Id}: {o.Amount:C}");
});

// Agregacja przez push
decimal total = 0m;
orderList.ForEach(o => total += o.Amount);
Console.WriteLine($"\nSuma wszystkich zamówień: {total:C}");
Console.WriteLine("► Iterator pasywny upraszcza kod ale brak kontroli przepływu\n");

// ─── DEMONSTRACJA 3: Porównanie elastyczności ─────────────────────────────────

Console.WriteLine("═══ DEMONSTRACJA 3: Elastyczność aktywnego vs pasywnego ═══\n");

var longList = new NumberSequence(Enumerable.Range(1, 1_000_000).ToArray());

// Aktywny — przetwarza tylko tyle ile potrzeba
Console.WriteLine("Aktywny — pierwsze 3 liczby podzielne przez 7:");
int found = 0;
using var activeIter = longList.GetEnumerator();
while (activeIter.MoveNext() && found < 3)
{
    if (activeIter.Current % 7 == 0)
    {
        Console.WriteLine($"  {activeIter.Current}");
        found++;
    }
}
Console.WriteLine("  (reszta miliona elementów nie jest przetwarzana)");

// Pasywny — musiałby przetworzyć wszystkie
Console.WriteLine("\nPasywny — musiałby przetworzyć wszystkie elementy:");
found = 0;
longList.ForEachUntil(n =>
{
    if (n % 7 == 0 && found < 3)
    {
        Console.WriteLine($"  {n}");
        found++;
    }
    return found < 3; // false = przerwij (rozszerzenie push o możliwość przerwania)
});
Console.WriteLine();

// ─── DEMONSTRACJA 4: foreach i LINQ jako pull w .NET ─────────────────────────

Console.WriteLine("═══ DEMONSTRACJA 4: foreach i LINQ — pull w .NET ═══\n");

int[] data = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// foreach = pull (klient steruje)
Console.WriteLine("foreach (pull):");
foreach (int n in data)
    Console.Write(n + " ");
Console.WriteLine();

// LINQ jest leniwy (lazy pull) — nie oblicza z góry
Console.WriteLine("\nLINQ lazy pipeline:");
var pipeline = data
    .Where(n => { Console.Write($"[W:{n}]"); return n % 2 == 0; })
    .Select(n => { Console.Write($"[S:{n}]"); return n * n; });

Console.WriteLine("\nBez materializacji — nic nie zostało obliczone!");
Console.Write("Po Take(3): ");
foreach (int n in pipeline.Take(3))
    Console.Write(n + " ");
Console.WriteLine("\n");

// ─── DEMONSTRACJA 5: Reaktywne rozszerzenia (IObservable) — push ──────────────

Console.WriteLine("═══ DEMONSTRACJA 5: Symulacja reaktywna (push-based) ═══\n");

// IObservable<T> to push-based iterator z asynchroniczną naturą
// Tu symulujemy bez rx library
var eventSource = new SimpleObservable<int>();
var observer = new PrintObserver<int>("Rx Observer");

eventSource.Subscribe(observer);
Console.WriteLine("Publikowanie zdarzeń:");
eventSource.Publish(42);
eventSource.Publish(100);
eventSource.Publish(7);
eventSource.Complete();

// ─────────────────────────────────────────────────────────────────────────────
// Implementacje
// ─────────────────────────────────────────────────────────────────────────────

record Order(string Id, decimal Amount, string Status);

// Sekwencje dla iteratora aktywnego
class NumberSequence(int[] data) : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator() => new ArrayEnumerator<int>(data);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Push dla demonstracji
    public void ForEach(Action<int> action)
    {
        foreach (int n in data) action(n);
    }

    // Push z przerwaniem
    public void ForEachUntil(Func<int, bool> action)
    {
        foreach (int n in data)
            if (!action(n)) break;
    }
}

class CharSequence(char[] data) : IEnumerable<char>
{
    public IEnumerator<char> GetEnumerator() => new ArrayEnumerator<char>(data);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class ArrayEnumerator<T>(T[] data) : IEnumerator<T>
{
    private int _index = -1;
    public bool MoveNext() { _index++; return _index < data.Length; }
    public T Current => data[_index];
    object IEnumerator.Current => Current!;
    public void Reset() => _index = -1;
    public void Dispose() { }
}

// Przeplatanie dwóch sekwencji (wymaga aktywnego iteratora)
static IEnumerable<T> Interleave<T>(IEnumerable<T> a, IEnumerable<T> b)
{
    using var ia = a.GetEnumerator();
    using var ib = b.GetEnumerator();
    while (ia.MoveNext() && ib.MoveNext())
    {
        yield return ia.Current;
        yield return ib.Current;
    }
}

// Iterator pasywny (push) — kolekcja zamówień
class OrderCollection
{
    private readonly List<Order> _orders = [];
    public void Add(Order o) => _orders.Add(o);
    public void ForEach(Action<Order> action) { foreach (var o in _orders) action(o); }
}

// Prosta implementacja wzorca Observer (symulacja IObservable<T>)
interface ISimpleObserver<T>
{
    void OnNext(T value);
    void OnCompleted();
}

class SimpleObservable<T>
{
    private readonly List<ISimpleObserver<T>> _observers = [];
    public void Subscribe(ISimpleObserver<T> obs) => _observers.Add(obs);
    public void Publish(T value) { foreach (var o in _observers) o.OnNext(value); }
    public void Complete() { foreach (var o in _observers) o.OnCompleted(); }
}

class PrintObserver<T>(string name) : ISimpleObserver<T>
{
    public void OnNext(T value) => Console.WriteLine($"  [{name}] Otrzymano: {value}");
    public void OnCompleted() => Console.WriteLine($"  [{name}] Sekwencja zakończona");
}
