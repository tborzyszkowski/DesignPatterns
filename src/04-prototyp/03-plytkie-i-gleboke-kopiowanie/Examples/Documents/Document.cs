using System.Text.Json;

namespace PlytkieGleboke.Documents;

// ── Zagnieżdżone typy ────────────────────────────────────────────────────────

public sealed class Person
{
    public string Name  { get; set; }
    public string Email { get; set; }

    public Person(string name, string email) => (Name, Email) = (name, email);

    // Konstruktor kopiujący
    public Person(Person source) => (Name, Email) = (source.Name, source.Email);

    public override string ToString() => $"Person({Name}, {Email})";
}

// ── Główna klasa demonstracyjna ──────────────────────────────────────────────

/// <summary>
/// Dokument z zagnieżdżonymi referencjami.
/// Ilustruje problem płytkiego kopiowania i trzy sposoby jego rozwiązania.
/// </summary>
public sealed class Document
{
    public string       Title      { get; set; }
    public Person       Author     { get; set; }   // ← obiekt referencyjny
    public List<string> Tags       { get; set; }   // ← mutable collection
    public List<string> Paragraphs { get; set; }   // ← mutable collection

    public Document(string title, Person author, List<string> tags, List<string> paragraphs)
    {
        Title      = title;
        Author     = author;
        Tags       = tags;
        Paragraphs = paragraphs;
    }

    // ── Strategia 1: Płytka kopia (MemberwiseClone) — błędna dla referencji ─

    /// <summary>
    /// PŁYTKA kopia: wartościowe pola są skopiowane, referencje są współdzielone.
    /// NIEBEZPIECZNE gdy klony mogą modyfikować te same listy/obiekty.
    /// </summary>
    public Document ShallowClone() => (Document)MemberwiseClone();

    // ── Strategia 2: Ręczna głęboka kopia (konstruktor kopiujący) ────────────

    /// <summary>
    /// GŁĘBOKA kopia: każde referencyjne pole jest samodzielnie skopiowane.
    /// Klon jest w pełni niezależny od oryginału.
    /// </summary>
    public Document DeepCloneManual() => new Document(
        Title,
        new Person(Author),          // nowy Person — głęboka kopia
        new List<string>(Tags),      // nowa lista — głęboka kopia
        new List<string>(Paragraphs) // nowa lista — głęboka kopia
    );

    // ── Strategia 3: Głęboka kopia przez serializację JSON ───────────────────

    /// <summary>
    /// GŁĘBOKA kopia przez System.Text.Json.
    /// Wymaga, żeby wszystkie właściwości były publiczne i serializowalne.
    /// Zwraca null jeśli deserializacja się nie powiedzie (obsługiwane wyjątkiem).
    /// </summary>
    public Document DeepCloneJson()
    {
        // ToDto / FromDto — prosta klasa do serializacji
        var json = JsonSerializer.Serialize(new DocumentDto(this));
        var dto  = JsonSerializer.Deserialize<DocumentDto>(json)
                   ?? throw new InvalidOperationException("Deserializacja nieudana");
        return dto.ToDocument();
    }

    public override string ToString() =>
        $"Document {{ Title='{Title}', Author={Author}, Tags=[{string.Join(",", Tags)}], Paragraphs={Paragraphs.Count} }}";
}

// ── DTO dla serializacji JSON ────────────────────────────────────────────────

public sealed class PersonDto
{
    public string Name  { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public PersonDto() { }
    public PersonDto(Person p) { Name = p.Name; Email = p.Email; }
    public Person ToPerson() => new Person(Name, Email);
}

public sealed class DocumentDto
{
    public string       Title      { get; set; } = string.Empty;
    public PersonDto    Author     { get; set; } = new();
    public List<string> Tags       { get; set; } = [];
    public List<string> Paragraphs { get; set; } = [];

    public DocumentDto() { }
    public DocumentDto(Document d)
    {
        Title      = d.Title;
        Author     = new PersonDto(d.Author);
        Tags       = new List<string>(d.Tags);
        Paragraphs = new List<string>(d.Paragraphs);
    }

    public Document ToDocument() => new Document(Title, Author.ToPerson(), Tags, Paragraphs);
}
