// =============================================================================
// Wzorzec Iterator — 08. Duży przykład: Katalog Biblioteki + alternatywy
// =============================================================================
// Model domeny:
//   Book — rekord z Title, Author, Genre, Year, Available, ISBN
//   Library — kolekcja z wieloma sposobami iterowania
//   Różne strategie: własny iterator, LINQ, yield, cursor, Visitor-like
// =============================================================================
using System.Collections;

// ─── INICJALIZACJA BIBLIOTEKI ─────────────────────────────────────────────────

var library = new Library();
library.Add(new Book("Władca Pierścieni", "J.R.R. Tolkien", "Fantastyka", 1954, Available: true, "978-83-8032-000-1"));
library.Add(new Book("Dune", "Frank Herbert", "SF", 1965, Available: false, "978-83-8032-001-8"));
library.Add(new Book("Wiedźmin: Ostatnie Życzenie", "Andrzej Sapkowski", "Fantastyka", 1993, Available: true, "978-83-7780-200-1"));
library.Add(new Book("1984", "George Orwell", "Dystopia", 1949, Available: true, "978-83-0001-000-0"));
library.Add(new Book("Nowy Wspaniały Świat", "Aldous Huxley", "Dystopia", 1932, Available: false, "978-83-0002-000-7"));
library.Add(new Book("Solaris", "Stanisław Lem", "SF", 1961, Available: true, "978-83-0003-000-4"));
library.Add(new Book("Hobbit", "J.R.R. Tolkien", "Fantastyka", 1937, Available: true, "978-83-8032-100-8"));
library.Add(new Book("Fundacja", "Isaac Asimov", "SF", 1951, Available: false, "978-83-0004-000-1"));
library.Add(new Book("Zbrodnia i kara", "Fiodor Dostojewski", "Klasyka", 1866, Available: true, "978-83-0005-000-8"));
library.Add(new Book("Anna Karenina", "Lew Tołstoj", "Klasyka", 1878, Available: true, "978-83-0006-000-5"));

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║        KATALOG BIBLIOTEKI — WZORZEC ITERATOR         ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝\n");

// ─── SCENARIUSZ 1: Przeglądanie pełnego katalogu ──────────────────────────────

Console.WriteLine("═══ SCENARIUSZ 1: Pełny katalog ═══\n");
PrintBooks(library, "Wszystkie książki:");

// ─── SCENARIUSZ 2: Filtrowanie według gatunku ─────────────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 2: Filtrowanie według gatunku ═══\n");

foreach (string genre in new[] { "Fantastyka", "SF", "Dystopia", "Klasyka" })
{
    var books = library.GetByGenre(genre);
    Console.WriteLine($"Gatunek: {genre}");
    foreach (var b in books)
        Console.WriteLine($"  [{(b.Available ? "✓" : "✗")}] {b.Title} ({b.Year})");
}

// ─── SCENARIUSZ 3: Filtr dostępności ─────────────────────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 3: Dostępne i niedostępne ═══\n");

PrintBooks(library.GetAvailable(), "Dostępne do wypożyczenia:");
PrintBooks(library.GetUnavailable(), "Aktualnie wypożyczone:");

// ─── SCENARIUSZ 4: Wyszukiwanie ───────────────────────────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 4: Wyszukiwanie ═══\n");

string query = "tolk";
Console.WriteLine($"Wyniki dla: \"{query}\"");
foreach (var b in library.Search(query))
    Console.WriteLine($"  [{b.ISBN}] {b.Title} — {b.Author}");

// ─── SCENARIUSZ 5: Sortowanie ─────────────────────────────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 5: Różne porządki iteracji ═══\n");

PrintBooks(library.GetAlphabetical(), "Alfabetycznie (tytuł):");
PrintBooks(library.GetByYearRange(1950, 1970), "Rocznik 1950–1970:");
PrintBooks(library.GetByAuthor("Tolkien"), "Autor: Tolkien");

// ─── SCENARIUSZ 6: Złożony iterator (kompozyt) ───────────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 6: Złożony iterator — kilka kolekcji ═══\n");

var library2 = new Library();
library2.Add(new Book("Diuna: Mesjasz", "Frank Herbert", "SF", 1969, Available: true, "978-83-9000-001-0"));
library2.Add(new Book("Dzieci Diuny", "Frank Herbert", "SF", 1976, Available: false, "978-83-9000-002-7"));

var combined = new CompositeLibrary(library, library2);
Console.WriteLine("Obie biblioteki przez CompositeLibrary:");
foreach (var b in combined)
    Console.WriteLine($"  {b.Title} ({b.Year}) — {b.Author}");

// ─── SCENARIUSZ 7: LINQ jako alternatywa ─────────────────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 7: LINQ vs własny iterator ═══\n");

Console.WriteLine("LINQ (deklaratywny, czytelny):");
var linqResult = library
    .Where(b => b.Genre == "SF" && b.Available)
    .OrderBy(b => b.Year)
    .Select(b => new { b.Title, b.Year, b.Author });

foreach (var r in linqResult)
    Console.WriteLine($"  {r.Year}: {r.Title} ({r.Author})");

Console.WriteLine("\nWłasny iterator (imperatywny, kontrolowany):");
foreach (var b in library.GetByGenre("SF"))
{
    if (b.Available)
        Console.WriteLine($"  {b.Year}: {b.Title} ({b.Author})");
}

// ─── SCENARIUSZ 8: Generator (yield) — leniwy eksport ────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 8: Leniwy eksport CSV (yield) ═══\n");

Console.WriteLine("Eksport 3 pierwszych książek (generator):");
foreach (string csvLine in library.ExportToCsv().Take(3))
    Console.WriteLine($"  {csvLine}");

// ─── SCENARIUSZ 9: Async enumerable (symulacja) ───────────────────────────────

Console.WriteLine("\n═══ SCENARIUSZ 9: Asynchroniczne pobieranie danych ═══\n");

var onlineLib = new OnlineLibrary();
Console.Write("Async stream: ");
await foreach (Book b in onlineLib.FetchBooksAsync())
    Console.Write($"[{b.Title[..4]}] ");
Console.WriteLine();

// ─── PODSUMOWANIE ALTERNATYW ─────────────────────────────────────────────────

Console.WriteLine("\n═══ PODSUMOWANIE ALTERNATYW ═══\n");
Console.WriteLine("┌──────────────────────┬────────────────────────────────────────────┐");
Console.WriteLine("│ Podejście            │ Kiedy użyć                                 │");
Console.WriteLine("├──────────────────────┼────────────────────────────────────────────┤");
Console.WriteLine("│ IEnumerable + yield  │ Własna kolekcja, leniwa ewaluacja          │");
Console.WriteLine("│ LINQ                 │ Filtr+sort+projekcja na istniejącej kol.   │");
Console.WriteLine("│ Własny IEnumerator   │ Złożone przechodzenie, wiele kursorów      │");
Console.WriteLine("│ Composite iterator   │ Wiele kolekcji jako jedna                  │");
Console.WriteLine("│ IAsyncEnumerable     │ Dane z sieci/bazy, asynchroniczne          │");
Console.WriteLine("└──────────────────────┴────────────────────────────────────────────┘");

// ─────────────────────────────────────────────────────────────────────────────
// Helpers
// ─────────────────────────────────────────────────────────────────────────────

static void PrintBooks(IEnumerable<Book> books, string header)
{
    Console.WriteLine(header);
    bool any = false;
    foreach (var b in books)
    {
        Console.WriteLine($"  [{(b.Available ? "✓" : "✗")}] {b.Title} — {b.Author} ({b.Year})");
        any = true;
    }
    if (!any) Console.WriteLine("  (brak)");
}

// =============================================================================
// Klasy domenowe
// =============================================================================

record Book(string Title, string Author, string Genre, int Year, bool Available, string ISBN);

// =============================================================================
// Library — kolekcja z wieloma iteratorami
// =============================================================================

class Library : IEnumerable<Book>
{
    private readonly List<Book> _books = [];

    public void Add(Book book) => _books.Add(book);
    public int Count => _books.Count;

    // Domyślna iteracja — wszystkie książki
    public IEnumerator<Book> GetEnumerator() => _books.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // ─── Iteratory filtrujące (yield) ─────────────────────────────────────
    public IEnumerable<Book> GetByGenre(string genre)
    {
        foreach (var b in _books)
            if (b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                yield return b;
    }

    public IEnumerable<Book> GetByAuthor(string authorFragment)
    {
        foreach (var b in _books)
            if (b.Author.Contains(authorFragment, StringComparison.OrdinalIgnoreCase))
                yield return b;
    }

    public IEnumerable<Book> GetAvailable()
    {
        foreach (var b in _books)
            if (b.Available) yield return b;
    }

    public IEnumerable<Book> GetUnavailable()
    {
        foreach (var b in _books)
            if (!b.Available) yield return b;
    }

    public IEnumerable<Book> GetByYearRange(int from, int to)
    {
        foreach (var b in _books)
            if (b.Year >= from && b.Year <= to) yield return b;
    }

    // ─── Iteratory sortujące ───────────────────────────────────────────────
    public IEnumerable<Book> GetAlphabetical() =>
        _books.OrderBy(b => b.Title);

    public IEnumerable<Book> GetReverse() =>
        _books.AsEnumerable().Reverse();

    // ─── Wyszukiwanie ─────────────────────────────────────────────────────
    public IEnumerable<Book> Search(string query)
    {
        foreach (var b in _books)
            if (b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.ISBN.Contains(query))
                yield return b;
    }

    // ─── Eksport — generator CSV ───────────────────────────────────────────
    public IEnumerable<string> ExportToCsv()
    {
        yield return "ISBN,Tytuł,Autor,Gatunek,Rok,Dostępna";
        foreach (var b in _books)
            yield return $"{b.ISBN},{b.Title},{b.Author},{b.Genre},{b.Year},{b.Available}";
    }
}

// =============================================================================
// CompositeLibrary — złożony iterator wielu bibliotek
// =============================================================================

class CompositeLibrary(params Library[] libraries) : IEnumerable<Book>
{
    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var lib in libraries)
            foreach (var book in lib)
                yield return book;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// =============================================================================
// OnlineLibrary — IAsyncEnumerable symulacja
// =============================================================================

class OnlineLibrary
{
    private static readonly Book[] _remote =
    [
        new("Remote Book 1", "Author A", "SF", 2020, true, "000-1"),
        new("Remote Book 2", "Author B", "Fantastyka", 2021, false, "000-2"),
        new("Remote Book 3", "Author C", "Klasyka", 2022, true, "000-3"),
    ];

    public async IAsyncEnumerable<Book> FetchBooksAsync()
    {
        foreach (var book in _remote)
        {
            await Task.Delay(10); // symulacja opóźnienia sieciowego
            yield return book;
        }
    }
}
