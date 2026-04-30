// =============================================================================
// Wzorzec Iterator — 01. Idea i kontekst
// Problem: jak udostępnić elementy kolekcji bez ujawniania jej struktury?
// Rozwiązanie: wzorzec Iterator — oddziela logikę przechodzenia od kolekcji
// =============================================================================
using System.Collections;

// ─── SEKCJA 1: Problem bez wzorca Iterator ────────────────────────────────────

Console.WriteLine("═══ SEKCJA 1: Problem — klient zależy od wewnętrznej struktury ═══\n");

var naive = new NaiveBookshelf();
naive.Add("Wzorce projektowe (GoF)");
naive.Add("Clean Code");
naive.Add("Refactoring");

// Klient musi znać szczegóły implementacji (tablica, licznik)
Console.WriteLine("Wydruk przez bezpośredni dostęp do tablicy:");
string[] books = naive.GetBooks();
for (int i = 0; i < naive.Count; i++)
    Console.WriteLine($"  [{i}] {books[i]}");

Console.WriteLine("\n► Problem: jeśli zmienimy tablicę na LinkedList, klient musi być przepisany!\n");

// ─── SEKCJA 2: Rozwiązanie — wzorzec Iterator ─────────────────────────────────

Console.WriteLine("═══ SEKCJA 2: Rozwiązanie — iterator oddziela przechodzenie ═══\n");

var collection = new BookCollection();
collection.Add(new Book("Wzorce projektowe", "Gang of Four", 1994));
collection.Add(new Book("Clean Code", "Robert C. Martin", 2008));
collection.Add(new Book("Refactoring", "Martin Fowler", 1999));
collection.Add(new Book("C# in Depth", "Jon Skeet", 2019));

// Klient używa iteratora — nie wie jak kolekcja jest zaimplementowana
IIterator<Book> iterator = collection.CreateIterator();

Console.WriteLine("Wydruk przez iterator:");
while (iterator.MoveNext())
{
    Book book = iterator.Current;
    Console.WriteLine($"  • {book.Title} — {book.Author} ({book.Year})");
}

Console.WriteLine("\n► Jeśli zmienimy BookCollection z listy na słownik, klient nie wymaga zmian!\n");

// ─── SEKCJA 3: Wiele niezależnych iteratorów ──────────────────────────────────

Console.WriteLine("═══ SEKCJA 3: Wiele niezależnych iteratorów dla tej samej kolekcji ═══\n");

IIterator<Book> iter1 = collection.CreateIterator();
IIterator<Book> iter2 = collection.CreateIterator();

// Przesuń iter1 o 2 pozycje
iter1.MoveNext(); iter1.MoveNext();
// iter2 jest na początku
iter2.MoveNext();

Console.WriteLine($"Iterator 1 wskazuje na: {iter1.Current.Title}");
Console.WriteLine($"Iterator 2 wskazuje na: {iter2.Current.Title}");
Console.WriteLine("► Iteratory są niezależnymi kursorami w kolekcji!\n");

// ─── SEKCJA 4: Styl .NET — IEnumerable<T> i foreach ──────────────────────────

Console.WriteLine("═══ SEKCJA 4: Styl .NET — IEnumerable<T> i foreach ═══\n");

var netCollection = new DotNetBookCollection();
netCollection.Add(new Book("Domain-Driven Design", "Eric Evans", 2003));
netCollection.Add(new Book("The Pragmatic Programmer", "Hunt & Thomas", 1999));
netCollection.Add(new Book("Head First Design Patterns", "Freeman & Robson", 2020));

// foreach używa IEnumerable<T> pod spodem (wzorzec Iterator!)
Console.WriteLine("Wydruk przez foreach (IEnumerable<T>):");
foreach (Book book in netCollection)
    Console.WriteLine($"  • {book.Title} ({book.Year})");

// ─── SEKCJA 5: Drzewo z iteratorem DFS ────────────────────────────────────────

Console.WriteLine("\n═══ SEKCJA 5: Iterator dla struktury drzewiastej (DFS) ═══\n");

//     Wzorce
//    /       \
// GoF       Clean
//          /     \
//       SOLID  DRY

var root = new TreeNode<string>("Wzorce");
var gof = new TreeNode<string>("GoF");
var clean = new TreeNode<string>("Clean Code");
var solid = new TreeNode<string>("SOLID");
var dry = new TreeNode<string>("DRY");

root.Add(gof);
root.Add(clean);
clean.Add(solid);
clean.Add(dry);

var tree = new TreeCollection<string>(root);
Console.WriteLine("DFS (in-depth, preorder) przez drzewo:");
foreach (string node in tree)
    Console.Write(node + "  ");
Console.WriteLine("\n");

// ─────────────────────────────────────────────────────────────────────────────
// Implementacje
// ─────────────────────────────────────────────────────────────────────────────

// === Problem bez wzorca ===

class NaiveBookshelf
{
    private string[] _books = new string[100];
    private int _count;

    public void Add(string title) => _books[_count++] = title;
    public string[] GetBooks() => _books;   // ujawnia wewnętrzną tablicę!
    public int Count => _count;             // klient musi znać indeks
}

// === Rozwiązanie: Wzorzec Iterator ===

record Book(string Title, string Author, int Year);

// Interfejsy wzorca (minimalna wersja)
interface IIterator<T>
{
    bool MoveNext();
    T Current { get; }
    void Reset();
}

interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// Kolekcja jako Aggregate
class BookCollection : IAggregate<Book>
{
    private readonly List<Book> _books = [];

    public void Add(Book book) => _books.Add(book);
    internal int Count => _books.Count;
    internal Book GetAt(int index) => _books[index];

    public IIterator<Book> CreateIterator() => new BookIterator(this);
}

// Iterator jako ConcreteIterator
class BookIterator(BookCollection collection) : IIterator<Book>
{
    private int _index = -1;

    public bool MoveNext()
    {
        _index++;
        return _index < collection.Count;
    }

    public Book Current => collection.GetAt(_index);

    public void Reset() => _index = -1;
}

// === Styl .NET: IEnumerable<T> ===

class DotNetBookCollection : IEnumerable<Book>
{
    private readonly List<Book> _books = [];
    public void Add(Book book) => _books.Add(book);

    // IEnumerable<T> to "Aggregate" ze świata .NET
    public IEnumerator<Book> GetEnumerator() => _books.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// === Iterator dla drzewa (DFS preorder) ===

class TreeNode<T>(T value)
{
    public T Value { get; } = value;
    private readonly List<TreeNode<T>> _children = [];
    public IReadOnlyList<TreeNode<T>> Children => _children;
    public void Add(TreeNode<T> child) => _children.Add(child);
}

class TreeCollection<T>(TreeNode<T> root) : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator() => new DfsIterator<T>(root);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Iterator DFS (Depth-First Search) preorder
class DfsIterator<T>(TreeNode<T> root) : IEnumerator<T>
{
    private readonly Stack<TreeNode<T>> _stack = new([root]);
    private T _current = default!;

    public bool MoveNext()
    {
        if (_stack.Count == 0) return false;
        var node = _stack.Pop();
        _current = node.Value;
        // Dodaj dzieci od prawej (aby lewa była na szczycie stosu)
        for (int i = node.Children.Count - 1; i >= 0; i--)
            _stack.Push(node.Children[i]);
        return true;
    }

    public T Current => _current;
    object IEnumerator.Current => Current!;
    public void Reset() => throw new NotSupportedException();
    public void Dispose() { }
}
