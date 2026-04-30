// =============================================================================
// Testy jednostkowe — Wzorzec Iterator (Katalog Biblioteki)
// Projekt SAMODZIELNY — nie referencjonuje projektu Examples
// =============================================================================
using System.Collections;
using Xunit;

namespace Iterator.Library.Tests;

// =============================================================================
// Model domenowy (kopia — projekt samodzielny)
// =============================================================================

record Book(string Title, string Author, string Genre, int Year, bool Available, string ISBN);

class Library : IEnumerable<Book>
{
    private readonly List<Book> _books = [];
    public void Add(Book book) => _books.Add(book);
    public int Count => _books.Count;
    public IEnumerator<Book> GetEnumerator() => _books.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<Book> GetByGenre(string genre)
    {
        foreach (var b in _books)
            if (b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                yield return b;
    }

    public IEnumerable<Book> GetByAuthor(string fragment)
    {
        foreach (var b in _books)
            if (b.Author.Contains(fragment, StringComparison.OrdinalIgnoreCase))
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

    public IEnumerable<Book> GetAlphabetical() => _books.OrderBy(b => b.Title);

    public IEnumerable<Book> Search(string query)
    {
        foreach (var b in _books)
            if (b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.ISBN.Contains(query))
                yield return b;
    }

    public IEnumerable<string> ExportToCsv()
    {
        yield return "ISBN,Tytuł,Autor,Gatunek,Rok,Dostępna";
        foreach (var b in _books)
            yield return $"{b.ISBN},{b.Title},{b.Author},{b.Genre},{b.Year},{b.Available}";
    }
}

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
// Testy
// =============================================================================

public class LibraryIteratorTests
{
    private static Library CreateSampleLibrary()
    {
        var lib = new Library();
        lib.Add(new Book("Władca Pierścieni", "Tolkien", "Fantastyka", 1954, true, "ISBN-001"));
        lib.Add(new Book("Dune", "Herbert", "SF", 1965, false, "ISBN-002"));
        lib.Add(new Book("1984", "Orwell", "Dystopia", 1949, true, "ISBN-003"));
        lib.Add(new Book("Solaris", "Lem", "SF", 1961, true, "ISBN-004"));
        lib.Add(new Book("Hobbit", "Tolkien", "Fantastyka", 1937, false, "ISBN-005"));
        return lib;
    }

    // ─── Podstawowa iteracja ───────────────────────────────────────────────

    [Fact]
    public void DefaultIterator_ReturnsAllBooks()
    {
        var lib = CreateSampleLibrary();
        var books = lib.ToList();
        Assert.Equal(5, books.Count);
    }

    [Fact]
    public void DefaultIterator_EmptyLibrary_ReturnsEmpty()
    {
        var lib = new Library();
        Assert.Empty(lib);
    }

    // ─── Filtrowanie po gatunku ────────────────────────────────────────────

    [Fact]
    public void GetByGenre_ReturnsOnlyMatchingGenre()
    {
        var lib = CreateSampleLibrary();
        var sf = lib.GetByGenre("SF").ToList();
        Assert.Equal(2, sf.Count);
        Assert.All(sf, b => Assert.Equal("SF", b.Genre));
    }

    [Fact]
    public void GetByGenre_CaseInsensitive()
    {
        var lib = CreateSampleLibrary();
        var sf = lib.GetByGenre("sf").ToList();
        Assert.Equal(2, sf.Count);
    }

    [Fact]
    public void GetByGenre_NonExistentGenre_ReturnsEmpty()
    {
        var lib = CreateSampleLibrary();
        Assert.Empty(lib.GetByGenre("Horror"));
    }

    // ─── Filtrowanie po autorze ────────────────────────────────────────────

    [Fact]
    public void GetByAuthor_ReturnsMatchingBooks()
    {
        var lib = CreateSampleLibrary();
        var tolkien = lib.GetByAuthor("tolkien").ToList();
        Assert.Equal(2, tolkien.Count);
    }

    [Fact]
    public void GetByAuthor_PartialMatch()
    {
        var lib = CreateSampleLibrary();
        var books = lib.GetByAuthor("lem").ToList();
        Assert.Single(books);
        Assert.Equal("Solaris", books[0].Title);
    }

    // ─── Dostępność ────────────────────────────────────────────────────────

    [Fact]
    public void GetAvailable_ReturnsOnlyAvailable()
    {
        var lib = CreateSampleLibrary();
        var available = lib.GetAvailable().ToList();
        Assert.Equal(3, available.Count);
        Assert.All(available, b => Assert.True(b.Available));
    }

    [Fact]
    public void GetUnavailable_ReturnsOnlyUnavailable()
    {
        var lib = CreateSampleLibrary();
        var unavailable = lib.GetUnavailable().ToList();
        Assert.Equal(2, unavailable.Count);
        Assert.All(unavailable, b => Assert.False(b.Available));
    }

    [Fact]
    public void Available_And_Unavailable_CoverAllBooks()
    {
        var lib = CreateSampleLibrary();
        int available = lib.GetAvailable().Count();
        int unavailable = lib.GetUnavailable().Count();
        Assert.Equal(lib.Count, available + unavailable);
    }

    // ─── Zakres lat ────────────────────────────────────────────────────────

    [Fact]
    public void GetByYearRange_InclusiveBounds()
    {
        var lib = CreateSampleLibrary();
        var books = lib.GetByYearRange(1949, 1961).ToList();
        // 1984(1949), 1WP(1954), Solaris(1961) = 3
        Assert.Equal(3, books.Count);
    }

    [Fact]
    public void GetByYearRange_NoResults_WhenOutOfRange()
    {
        var lib = CreateSampleLibrary();
        Assert.Empty(lib.GetByYearRange(2000, 2020));
    }

    // ─── Sortowanie ────────────────────────────────────────────────────────

    [Fact]
    public void GetAlphabetical_IsSortedByTitle()
    {
        var lib = CreateSampleLibrary();
        var sorted = lib.GetAlphabetical().Select(b => b.Title).ToList();
        var expected = sorted.OrderBy(t => t).ToList();
        Assert.Equal(expected, sorted);
    }

    // ─── Wyszukiwanie ─────────────────────────────────────────────────────

    [Fact]
    public void Search_FindsByTitleFragment()
    {
        var lib = CreateSampleLibrary();
        var results = lib.Search("hobbit").ToList();
        Assert.Single(results);
        Assert.Equal("Hobbit", results[0].Title);
    }

    [Fact]
    public void Search_FindsByAuthor()
    {
        var lib = CreateSampleLibrary();
        var results = lib.Search("Lem").ToList();
        Assert.Single(results);
    }

    [Fact]
    public void Search_FindsByISBN()
    {
        var lib = CreateSampleLibrary();
        var results = lib.Search("ISBN-003").ToList();
        Assert.Single(results);
        Assert.Equal("1984", results[0].Title);
    }

    [Fact]
    public void Search_Empty_ReturnsEmpty()
    {
        var lib = CreateSampleLibrary();
        Assert.Empty(lib.Search("XYZ-nieistniejące-12345"));
    }

    // ─── CSV Export ────────────────────────────────────────────────────────

    [Fact]
    public void ExportToCsv_FirstLineIsHeader()
    {
        var lib = CreateSampleLibrary();
        var lines = lib.ExportToCsv().ToList();
        Assert.StartsWith("ISBN", lines[0]);
        Assert.Contains("Tytuł", lines[0]);
    }

    [Fact]
    public void ExportToCsv_HasHeaderPlusOneLinePerBook()
    {
        var lib = CreateSampleLibrary();
        var lines = lib.ExportToCsv().ToList();
        Assert.Equal(lib.Count + 1, lines.Count); // nagłówek + książki
    }

    [Fact]
    public void ExportToCsv_IsLazy()
    {
        // Tylko Take(1) — iterator musi być leniwy
        var lib = CreateSampleLibrary();
        var header = lib.ExportToCsv().Take(1).Single();
        Assert.StartsWith("ISBN", header);
    }

    // ─── Composite iterator ────────────────────────────────────────────────

    [Fact]
    public void CompositeLibrary_IteratesAllLibraries()
    {
        var lib1 = new Library();
        lib1.Add(new Book("Book A", "Author", "Genre", 2020, true, "A-001"));
        lib1.Add(new Book("Book B", "Author", "Genre", 2021, true, "A-002"));

        var lib2 = new Library();
        lib2.Add(new Book("Book C", "Author", "Genre", 2022, true, "B-001"));

        var composite = new CompositeLibrary(lib1, lib2);
        Assert.Equal(3, composite.Count());
    }

    [Fact]
    public void CompositeLibrary_PreservesOrder()
    {
        var lib1 = new Library();
        lib1.Add(new Book("First", "A", "G", 2020, true, "1"));

        var lib2 = new Library();
        lib2.Add(new Book("Second", "B", "G", 2021, true, "2"));

        var composite = new CompositeLibrary(lib1, lib2).ToList();
        Assert.Equal("First", composite[0].Title);
        Assert.Equal("Second", composite[1].Title);
    }

    [Fact]
    public void CompositeLibrary_EmptyLibraries_ReturnsEmpty()
    {
        var composite = new CompositeLibrary(new Library(), new Library());
        Assert.Empty(composite);
    }

    // ─── Niezależne iteratory ──────────────────────────────────────────────

    [Fact]
    public void TwoIterators_AreIndependent()
    {
        var lib = CreateSampleLibrary();

        using var iter1 = lib.GetEnumerator();
        using var iter2 = lib.GetEnumerator();

        iter1.MoveNext();
        iter1.MoveNext(); // iter1 na pozycji 2

        iter2.MoveNext(); // iter2 na pozycji 1

        Assert.NotEqual(iter1.Current.Title, iter2.Current.Title);
    }

    // ─── Zgodność z LINQ ──────────────────────────────────────────────────

    [Fact]
    public void GetByGenre_MatchesLinqEquivalent()
    {
        var lib = CreateSampleLibrary();

        var byIterator = lib.GetByGenre("SF").Select(b => b.Title).OrderBy(t => t).ToList();
        var byLinq = lib.Where(b => b.Genre == "SF").Select(b => b.Title).OrderBy(t => t).ToList();

        Assert.Equal(byLinq, byIterator);
    }

    [Fact]
    public void GetAvailable_MatchesLinqEquivalent()
    {
        var lib = CreateSampleLibrary();

        var byIterator = lib.GetAvailable().Select(b => b.ISBN).OrderBy(x => x).ToList();
        var byLinq = lib.Where(b => b.Available).Select(b => b.ISBN).OrderBy(x => x).ToList();

        Assert.Equal(byLinq, byIterator);
    }
}
