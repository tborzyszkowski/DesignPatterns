namespace TypyImplementacji.ImmutableBuilder;

// ============================================================
// IMMUTABLE BUILDER — C# record + klasyczny Builder z walidacją
// ============================================================

// ----- Produkt jako record (C# 9+) ----------------------------

/// <summary>
/// Person jako record — wartościowa semantyka, niemutowalny.
/// Zapis zwięzły, ale bez walidacji w konstruktorze.
/// </summary>
public sealed record Person(
    Guid   Id,
    string FirstName,
    string LastName,
    int    Age,
    string Email
)
{
    public string FullName => $"{FirstName} {LastName}";

    public override string ToString() =>
        $"Person [{Id.ToString()[..8]}...] {FullName}, age={Age}, email={Email}";
}

// ----- Builder z walidacją i sensownymi domyślnymi ---------------

/// <summary>
/// Builder dla rekordu Person — dodaje walidację i domyślne wartości,
/// których sam record nie może zapewnić.
/// </summary>
public sealed class PersonBuilder
{
    private string _firstName = "Imię";
    private string _lastName  = "Nazwisko";
    private int    _age       = 0;
    private string _email     = string.Empty;

    public PersonBuilder WithFirstName(string v) { _firstName = v; return this; }
    public PersonBuilder WithLastName(string v)  { _lastName  = v; return this; }
    public PersonBuilder WithAge(int v)          { _age       = v; return this; }
    public PersonBuilder WithEmail(string v)     { _email     = v; return this; }

    public Person Build()
    {
        if (string.IsNullOrWhiteSpace(_firstName))
            throw new ArgumentException("FirstName jest wymagany");
        if (_age is < 0 or > 150)
            throw new ArgumentException($"Nieprawidłowy wiek: {_age}");
        if (!string.IsNullOrEmpty(_email) && !_email.Contains('@'))
            throw new ArgumentException($"Nieprawidłowy email: {_email}");

        return new Person(Guid.NewGuid(), _firstName, _lastName, _age, _email);
    }
}

// ----- Demonstracja "with" expression ----------------------------

/// <summary>
/// Pomocnicza klasa demonstrująca operator "with" z C# records.
/// </summary>
public static class RecordWithDemo
{
    public static void Run()
    {
        var original = new Person(Guid.NewGuid(), "Anna", "Kowalska", 30, "anna@firma.pl");
        Console.WriteLine($"Original: {original}");

        // record "with" — kopiuje, zmienia tylko wskazane pola
        var older    = original with { Age = 31 };
        var renamed  = original with { LastName = "Nowak-Kowalska" };

        Console.WriteLine($"Older   : {older}");
        Console.WriteLine($"Renamed : {renamed}");
        Console.WriteLine($"Oryginał niezmieniony: {original}");

        // Value equality (records porównują zawartość, nie referencję)
        var copy = original with { };   // dokładna kopia
        Console.WriteLine($"\nCzy original == copy? {original == copy}");   // True
        Console.WriteLine($"ReferenceEqual? {ReferenceEquals(original, copy)}"); // False
    }
}
