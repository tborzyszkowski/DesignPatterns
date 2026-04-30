// =============================================================================
// Wzorzec Iterator — 03. Struktura GoF i jak działa
// Demonstruje: klasyczny szkielet GoF, wersję .NET, cykl życia iteratora
// =============================================================================
using System.Collections;

// ─── SEKCJA 1: Czysty szkielet GoF ────────────────────────────────────────────

Console.WriteLine("═══ SEKCJA 1: Czysty szkielet GoF ═══\n");

var shelf = new BookShelf();
shelf.Append(new BookGoF("Design Patterns", "GoF"));
shelf.Append(new BookGoF("Head First Design Patterns", "Freeman"));
shelf.Append(new BookGoF("Refactoring", "Fowler"));
shelf.Append(new BookGoF("Clean Code", "Martin"));

// CreateIterator() — rola Aggregate
IBookIterator iter = shelf.CreateIterator();

Console.WriteLine("Iteracja GoF (First / Next / IsDone):");
for (BookGoF? book = iter.First(); !iter.IsDone(); book = iter.Next())
    Console.WriteLine($"  • {book!.Title} — {book.Author}");

// ─── SEKCJA 2: Nowoczesny styl (MoveNext / Current) ──────────────────────────

Console.WriteLine("\n═══ SEKCJA 2: Nowoczesny styl MoveNext/Current ═══\n");

IBookIterator iter2 = shelf.CreateIterator();
Console.WriteLine("Iteracja nowoczesna (MoveNext / Current):");
while (iter2.MoveNext())
    Console.WriteLine($"  • {iter2.Current!.Title}");

// ─── SEKCJA 3: Cykl życia — demo stanów ──────────────────────────────────────

Console.WriteLine("\n═══ SEKCJA 3: Cykl życia iteratora ═══\n");

var lifecycle = new SmallCollection([1, 2, 3]);
using var lifIter = lifecycle.GetEnumerator();

Console.WriteLine("Stany iteratora:");
Console.WriteLine($"  Przed pierwszym MoveNext() — Current: ---");
lifIter.MoveNext();
Console.WriteLine($"  Po 1. MoveNext() — Current: {lifIter.Current} (stan: Aktywny)");
lifIter.MoveNext();
Console.WriteLine($"  Po 2. MoveNext() — Current: {lifIter.Current} (stan: Aktywny)");
lifIter.MoveNext();
Console.WriteLine($"  Po 3. MoveNext() — Current: {lifIter.Current} (stan: Aktywny)");
bool hasMore = lifIter.MoveNext();
Console.WriteLine($"  Po 4. MoveNext() — zwraca: {hasMore} (stan: Zakończony)");

// ─── SEKCJA 4: Konsekwencje — zmiana kolekcji podczas iteracji ────────────────

Console.WriteLine("\n═══ SEKCJA 4: Konsekwencja — modyfikacja podczas iteracji ═══\n");

var mutableList = new List<string> { "A", "B", "C" };
Console.WriteLine("Bezpieczna iteracja — po kopii:");
foreach (string s in mutableList.ToList())  // ToList() = kopia
{
    Console.Write($"  {s}");
    mutableList.Add("X"); // bezpieczne — iterujemy po kopii
}
Console.WriteLine($"\n  Lista po iteracji ma {mutableList.Count} elementów\n");

// ─── SEKCJA 5: Wersja .NET — BookShelf jako IEnumerable<T> ───────────────────

Console.WriteLine("═══ SEKCJA 5: BookShelf jako IEnumerable<T> (.NET style) ═══\n");

var modernShelf = new ModernBookShelf();
modernShelf.Add(new BookGoF("Domain-Driven Design", "Evans"));
modernShelf.Add(new BookGoF("Patterns of Enterprise Application Architecture", "Fowler"));
modernShelf.Add(new BookGoF("The Pragmatic Programmer", "Hunt & Thomas"));

Console.WriteLine("Iteracja przez foreach (IEnumerable<T>):");
foreach (BookGoF book in modernShelf)
    Console.WriteLine($"  • {book.Title}");

Console.WriteLine("\nIteracja przez LINQ:");
var titles = modernShelf.Select(b => b.Title).Where(t => t.Contains("Patterns"));
foreach (string title in titles)
    Console.WriteLine($"  [LINQ] {title}");

// ─────────────────────────────────────────────────────────────────────────────
// Implementacje
// ─────────────────────────────────────────────────────────────────────────────

// === Rola: Iterator (interfejs) ===

interface IBookIterator
{
    BookGoF? First();
    BookGoF? Next();
    bool IsDone();
    BookGoF? CurrentItem();

    // Nowoczesna wersja
    bool MoveNext();
    BookGoF? Current { get; }
}

// === Rola: Aggregate (interfejs) ===

interface IBookAggregate
{
    IBookIterator CreateIterator();
}

// === Dane ===

record BookGoF(string Title, string Author);

// === Rola: ConcreteAggregate ===

class BookShelf : IBookAggregate
{
    private readonly List<BookGoF> _books = [];

    public void Append(BookGoF book) => _books.Add(book);
    internal int Count => _books.Count;
    internal BookGoF GetBookAt(int index) => _books[index];

    public IBookIterator CreateIterator() => new BookShelfIterator(this);
}

// === Rola: ConcreteIterator ===

class BookShelfIterator(BookShelf shelf) : IBookIterator
{
    private int _index = -1;  // -1 = przed pierwszym elementem

    // GoF API
    public BookGoF? First()
    {
        _index = 0;
        return IsDone() ? null : shelf.GetBookAt(_index);
    }

    public BookGoF? Next()
    {
        _index++;
        return IsDone() ? null : shelf.GetBookAt(_index);
    }

    public bool IsDone() => _index >= shelf.Count;

    public BookGoF? CurrentItem() => IsDone() ? null : shelf.GetBookAt(_index);

    // Nowoczesna wersja — MoveNext/Current
    public bool MoveNext()
    {
        _index++;
        return _index < shelf.Count;
    }

    public BookGoF? Current => (_index >= 0 && _index < shelf.Count)
        ? shelf.GetBookAt(_index)
        : null;
}

// === Cykl życia — prosta kolekcja z IEnumerable<T> ===

class SmallCollection(int[] data) : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator() => new SmallEnumerator(data);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class SmallEnumerator(int[] data) : IEnumerator<int>
{
    private int _index = -1;
    public bool MoveNext() { _index++; return _index < data.Length; }
    public int Current => data[_index];
    object IEnumerator.Current => Current;
    public void Reset() => _index = -1;
    public void Dispose() { }
}

// === Wersja .NET — IEnumerable<T> z yield return ===

class ModernBookShelf : IEnumerable<BookGoF>
{
    private readonly List<BookGoF> _books = [];
    public void Add(BookGoF book) => _books.Add(book);

    public IEnumerator<BookGoF> GetEnumerator()
    {
        foreach (var book in _books)
            yield return book;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
