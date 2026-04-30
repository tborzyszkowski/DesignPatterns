// =============================================================================
// Wzorzec Iterator — 04. Typy implementacji i jak wybrać właściwy
// Demonstruje 5 typów: Pull, Push, Lazy (yield), LINQ, Kursor dwukierunkowy
// =============================================================================
using System.Collections;

// ─── TYP 1: Pull Iterator (zewnętrzny / aktywny) ──────────────────────────────

Console.WriteLine("═══ TYP 1: Pull Iterator (klient steruje — MoveNext) ═══\n");

var productCatalog = new ProductCatalog();
productCatalog.Add(new Product("Laptop", 2999m));
productCatalog.Add(new Product("Monitor", 899m));
productCatalog.Add(new Product("Klawiatura", 199m));
productCatalog.Add(new Product("Mysz", 89m));

// Klient sam wywołuje MoveNext() — pull model
IEnumerator<Product> pullIter = productCatalog.GetEnumerator();
Console.WriteLine("Iteracja pull (ręczna):");
while (pullIter.MoveNext())
{
    Product p = pullIter.Current;
    Console.WriteLine($"  {p.Name,-15} {p.Price,8:C}");
}
pullIter.Dispose();

// Można zatrzymać w połowie!
Console.WriteLine("\nIteracja zatrzymana po pierwszym elemencie > 500 zł:");
using var earlyStop = productCatalog.GetEnumerator();
while (earlyStop.MoveNext())
{
    if (earlyStop.Current.Price > 500)
    {
        Console.WriteLine($"  Znaleziono: {earlyStop.Current.Name} ({earlyStop.Current.Price:C})");
        break; // ← przerywamy iterację wcześnie
    }
}

// ─── TYP 2: Push Iterator (wewnętrzny / pasywny) ──────────────────────────────

Console.WriteLine("\n═══ TYP 2: Push Iterator (kolekcja steruje — callback) ═══\n");

var pushCatalog = new PushProductCatalog();
pushCatalog.Add(new Product("Laptop", 2999m));
pushCatalog.Add(new Product("Monitor", 899m));
pushCatalog.Add(new Product("Klawiatura", 199m));

Console.WriteLine("ForEach z callbackiem (push model):");
pushCatalog.ForEach(p => Console.WriteLine($"  {p.Name,-15} {p.Price,8:C}"));

Console.WriteLine("\nForEach z filtrowaniem w callbacku:");
pushCatalog.ForEach(p =>
{
    if (p.Price > 500)
        Console.WriteLine($"  [Drogi] {p.Name}");
});

// ─── TYP 3: Lazy Generator (yield return) ─────────────────────────────────────

Console.WriteLine("\n═══ TYP 3: Lazy Generator (yield return) ═══\n");

// 3a. Prosty generator
Console.WriteLine("Generator liczb parzystych do 20:");
foreach (int n in EvenNumbers(1, 20))
    Console.Write(n + " ");
Console.WriteLine();

// 3b. Nieskończony generator
Console.WriteLine("\nPierwsze 8 liczb Fibonacciego (nieskończony generator):");
foreach (int fib in Fibonacci().Take(8))
    Console.Write(fib + " ");
Console.WriteLine();

// 3c. Leniwy odczyt pliku (symulacja)
Console.WriteLine("\nLeniwe czytanie wierszy (symulacja):");
foreach (string line in ReadLines(["wiersz 1", "wiersz 2", "wiersz 3"]).Take(2))
    Console.WriteLine($"  [{line}]");
Console.WriteLine("  (reszta wierszy nie jest odczytana!)");

// ─── TYP 4: LINQ-compatible (IEnumerable<T>) ─────────────────────────────────

Console.WriteLine("\n═══ TYP 4: LINQ-compatible IEnumerable<T> ═══\n");

// Kolekcja implementuje IEnumerable<T> → integracja z LINQ
var linqCatalog = new LinqProductCatalog(
    new Product("Laptop", 2999m),
    new Product("Monitor", 899m),
    new Product("Klawiatura", 199m),
    new Product("Mysz", 89m),
    new Product("Głośniki", 349m)
);

var affordable = linqCatalog
    .Where(p => p.Price < 500)
    .OrderBy(p => p.Price)
    .Select(p => $"{p.Name} ({p.Price:C})");

Console.WriteLine("Tanie produkty (< 500 zł), posortowane:");
foreach (string s in affordable) Console.WriteLine($"  • {s}");

Console.WriteLine($"\nŚrednia cena wszystkich: {linqCatalog.Average(p => p.Price):C}");
Console.WriteLine($"Najdroższy: {linqCatalog.MaxBy(p => p.Price)!.Name}");

// ─── TYP 5: Kursor dwukierunkowy (Bidirectional) ──────────────────────────────

Console.WriteLine("\n═══ TYP 5: Kursor dwukierunkowy ═══\n");

var textEditor = new TextEditor(["Wzorce projektowe", "Gang of Four", "1994 rok", "Klasyka"]);

Console.WriteLine("Nawigacja w przód i w tył:");
textEditor.Cursor.MoveToFirst();
Console.WriteLine($"  First: {textEditor.Cursor.Current}");
textEditor.Cursor.MoveNext();
Console.WriteLine($"  Next:  {textEditor.Cursor.Current}");
textEditor.Cursor.MoveNext();
Console.WriteLine($"  Next:  {textEditor.Cursor.Current}");
textEditor.Cursor.MovePrev();
Console.WriteLine($"  Prev:  {textEditor.Cursor.Current}");
textEditor.Cursor.MoveToLast();
Console.WriteLine($"  Last:  {textEditor.Cursor.Current}");

// ─────────────────────────────────────────────────────────────────────────────
// Implementacje
// ─────────────────────────────────────────────────────────────────────────────

record Product(string Name, decimal Price);

// --- TYP 1: Pull ---

class ProductCatalog : IEnumerable<Product>
{
    private readonly List<Product> _products = [];
    public void Add(Product p) => _products.Add(p);

    public IEnumerator<Product> GetEnumerator() => new ProductIterator(_products);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class ProductIterator(List<Product> products) : IEnumerator<Product>
{
    private int _index = -1;
    public bool MoveNext() { _index++; return _index < products.Count; }
    public Product Current => products[_index];
    object IEnumerator.Current => Current;
    public void Reset() => _index = -1;
    public void Dispose() { }
}

// --- TYP 2: Push ---

class PushProductCatalog
{
    private readonly List<Product> _products = [];
    public void Add(Product p) => _products.Add(p);

    // Iterator wewnętrzny: kolekcja steruje — klient dostarcza akcję
    public void ForEach(Action<Product> action)
    {
        foreach (var p in _products)
            action(p);
    }
}

// --- TYP 3: Generatory ---

static IEnumerable<int> EvenNumbers(int from, int to)
{
    for (int i = from; i <= to; i++)
        if (i % 2 == 0)
            yield return i;
}

static IEnumerable<int> Fibonacci()
{
    int a = 0, b = 1;
    while (true)
    {
        yield return a;
        (a, b) = (b, a + b);
    }
}

static IEnumerable<string> ReadLines(string[] simulatedLines)
{
    foreach (string line in simulatedLines)
    {
        // W prawdziwej implementacji: odczyt z pliku linia po linii
        yield return line;
    }
}

// --- TYP 4: LINQ-compatible ---

class LinqProductCatalog(params Product[] products) : IEnumerable<Product>
{
    private readonly List<Product> _products = [.. products];
    public void Add(Product p) => _products.Add(p);

    // yield return dla leniwej iteracji
    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var p in _products)
            yield return p;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// --- TYP 5: Kursor dwukierunkowy ---

class BidirectionalCursor<T>(List<T> items)
{
    private int _index = 0;

    public T Current => items[_index];
    public bool CanMoveNext => _index < items.Count - 1;
    public bool CanMovePrev => _index > 0;

    public void MoveToFirst() => _index = 0;
    public void MoveToLast() => _index = items.Count - 1;

    public void MoveNext()
    {
        if (CanMoveNext) _index++;
    }

    public void MovePrev()
    {
        if (CanMovePrev) _index--;
    }
}

class TextEditor(string[] lines)
{
    private readonly List<string> _lines = [.. lines];
    public BidirectionalCursor<string> Cursor => new(_lines);
}
