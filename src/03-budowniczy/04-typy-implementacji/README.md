# Warianty Implementacji Buildera

## Przegląd wariantów

Wzorzec Builder można zaimplementować na kilka sposobów, zależnie od potrzeb:

| Wariant | Kolejność kroków | Kiedy stosować |
|---|---|---|
| **GoF (Director + Builder)** | Narzucona przez Director | Złożone procedury budowania, wielokrotne użycie algorytmu |
| **Fluent Builder** | Dowolna | Konfiguracja z wieloma opcjonalnymi parametrami |
| **Step Builder** | Wymuszana przez **kompilator** | Gdy błędna kolejność to błąd biznesowy |
| **Immutable Builder + record** | Dowolna | Niemutowalne obiekty wartościowe (VO) |

---

## Typ 1: Step Builder

### Motywacja

Zwykły Fluent Builder pozwala na dowolną kolejność wywołań — ale co jeśli kolejność
ma znaczenie biznesowe? Np. zapytanie SQL musi mieć `FROM` przed `SELECT`:

```csharp
// Problematyczne z Fluent Builderem — brak gwarancji kolejności
SqlQueryBuilder.Query()
    .Select("*")     // SELECT bez FROM — błąd w SQL, ale kompilator nie zauważy
    .Build();
```

Step Builder rozwiązuje ten problem przez **system typów**: każdy krok zwraca
inny interfejs, który udostępnia wyłącznie legalne **następne** operacje.

### Jak działa wymuszanie kolejności?

```
Query() → IFromStep
             ↓ From("employees")
          ISelectStep
             ↓ SelectAll() lub Select(...)
          IWhereStep
             ↓ Where(...) lub od razu Build()
          IBuildStep
             ↓ OrderBy(), Limit(), Build()
          SqlQuery
```

Klient **nie może** pominąć `From()`, bo `IFromStep` udostępnia *tylko* metodę `From()`.
Próba wywołania `Build()` na `IFromStep` to błąd kompilacji — metoda tam nie istnieje.

Kluczowy pomysł: **każdy krok zwraca inny interfejs**, który udostępnia
wyłącznie legalne kolejne operacje. Kompilator staje się strażnikiem kolejności.

![Step Builder — klasy](diagrams/step_builder.png)

### Implementacja — interfejsy kroków

```csharp
// Każdy interfejs = jeden "stan" w procesie budowania
// Metody dostępne w danym stanie = legal moves

public interface IFromStep
{
    ISelectStep From(string table);   // jedyna dostępna akcja w tym stanie
}

public interface ISelectStep
{
    IWhereStep Select(params string[] cols);
    IWhereStep SelectAll();
}

public interface IWhereStep
{
    IBuildStep Where(string condition);
    SqlQuery   Build();               // WHERE jest opcjonalne — można pominąć
}

public interface IBuildStep
{
    IBuildStep OrderBy(string column);
    IBuildStep Limit(int n);
    SqlQuery   Build();
}
```

### Jedna klasa implementuje wszystkie interfejsy

```csharp
public sealed class SqlQueryBuilder : IFromStep, ISelectStep, IWhereStep, IBuildStep
{
    private string   _table   = string.Empty;
    private string[] _columns = [];
    private string   _where   = string.Empty;
    private string   _orderBy = string.Empty;
    private int      _limit;

    private SqlQueryBuilder() { }   // prywatny konstruktor — wejście tylko przez Query()

    // Statyczny punkt wejścia — zwraca IFromStep (tylko From() dostępne)
    public static IFromStep Query() => new SqlQueryBuilder();

    // Explicit interface implementation — bo IBuildStep i IWhereStep
    // mają obie metodę Build() o tym samym podpisie
    ISelectStep IFromStep.From(string table)  { _table   = table; return this; }
    IWhereStep  ISelectStep.SelectAll()       { _columns = [];    return this; }
    IBuildStep  IWhereStep.Where(string cond) { _where   = cond;  return this; }
    IBuildStep  IBuildStep.OrderBy(string c)  { _orderBy = c;     return this; }
    IBuildStep  IBuildStep.Limit(int n)       { _limit   = n;     return this; }

    // Build() istnieje w obu IWhereStep i IBuildStep — explicit implementation
    SqlQuery IWhereStep.Build()  => BuildQuery();
    SqlQuery IBuildStep.Build()  => BuildQuery();

    private SqlQuery BuildQuery() =>
        new SqlQuery(_table, _columns, _where, _orderBy, _limit);
}
```

### Użycie — kompilator pilnuje kolejności

```csharp
// ✅ Poprawna kolejność
var q = SqlQueryBuilder.Query()    // zwraca IFromStep
    .From("employees")             // IFromStep  → ISelectStep
    .SelectAll()                   // ISelectStep → IWhereStep
    .Where("age > 30")             // IWhereStep  → IBuildStep
    .OrderBy("name")               // IBuildStep  → IBuildStep
    .Build();                      // IBuildStep  → SqlQuery

// ✅ WHERE jest opcjonalne — przejście z IWhereStep od razu do Build()
var all = SqlQueryBuilder.Query()
    .From("products")
    .Select("id", "name", "price")
    .Build();                      // dostępne bezpośrednio z IWhereStep

// ❌ Błąd kompilacji — Build() nie istnieje w IFromStep!
SqlQueryBuilder.Query().Build();

// ❌ Błąd kompilacji — From() nie istnieje w ISelectStep!
SqlQueryBuilder.Query().From("t").From("t2");
```

### Dlaczego `explicit interface implementation` dla `Build()`?

Gdy `IWhereStep` i `IBuildStep` mają obie metodę `Build()` zwracającą `SqlQuery`,
C# wymaga jawnego wskazania interfejsu przy implementacji. Bez słowa `explicit`
C# nie wie, która `Build()` jest dla którego interfejsu:

```csharp
// Bez explicit — błąd: wieloznaczność
public SqlQuery Build() => BuildQuery();   // dla którego interfejsu?

// Z explicit — jednoznaczne
SqlQuery IWhereStep.Build()  => BuildQuery();   // Build() z IWhereStep
SqlQuery IBuildStep.Build()  => BuildQuery();   // Build() z IBuildStep
```

---

## Typ 2: Immutable Builder + C# record

### Czym jest niemutowalny obiekt wartościowy?

**Value Object (VO)** to obiekt, którego tożsamość wynika z wartości jego pól,
a nie z referencji. Dwa obiekty wartościowe z identycznymi polami są *równe*.
Są **niezmienne** — raz stworzony VO nie można zmienić (można stworzyć nowy).

Klasyczne przykłady: `DateTime`, `Money`, `Color`, adres pocztowy, współrzędne GPS.

`record` w C# 9+ implementuje VO automatycznie: konstruktor pozycyjny,
`==` oparty o content, `ToString()`, dekonstrukcja. Builder dodaje walidację.

Gdy produkt jest prostym **obiektem wartościowym** (Value Object), `record`
zapewnia niemutowalność i `==` oparty o content. Builder dodaje walidację.

![Immutable Builder — klasy](diagrams/immutable_builder.png)

### Record — definicja (C# 9+)

```csharp
// Kompilator generuje: konstruktor, ==, GetHashCode, ToString, Deconstruct
public sealed record Person(
    Guid   Id,
    string FirstName,
    string LastName,
    int    Age,
    string Email
)
{
    // Opcjonalnie: computed property
    public string FullName => $"{FirstName} {LastName}";
}

// Użycie bez Buildera — wszystkie pola wymagane, walidacja niemożliwa
var p = new Person(
    Guid.NewGuid(),
    "Anna", "Kowalska",
    30,
    "anna@firma.pl"
);
```

Problemem jest brak walidacji — `new Person(Guid.NewGuid(), "", "", -5, "nie-email")`
skompiluje się i wykona. Builder rozwiązuje ten problem.

### Builder z walidacją

```csharp
public sealed class PersonBuilder
{
    // Wartości domyślne — Builder nie wymaga ustawiania wszystkich pól
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
        // Walidacja kombinacji pól — niemożliwa bez buildera
        if (_age is < 0 or > 150)
            throw new ArgumentException($"Nieprawidłowy wiek: {_age}");
        if (!_email.Contains('@'))
            throw new ArgumentException($"Nieprawidłowy email: {_email}");

        // Guid.NewGuid() — Builder generuje ID, nie klient
        return new Person(Guid.NewGuid(), _firstName, _lastName, _age, _email);
    }
}
```

### `with`-expression — "modyfikacja" niemutowalnych recordów

`with` tworzy **kopię** rekordu z wybranymi zmienionymi polami. Oryginał jest nienaruszony.

```csharp
var p1 = new PersonBuilder()
    .WithFirstName("Anna").WithLastName("Kowalska")
    .WithAge(30).WithEmail("anna@firma.pl")
    .Build();

// with-expression — klonuj z nowym Age
var p2 = p1 with { Age = 31 };          // nowy obiekt, reszta pól z p1
var p3 = p1 with { LastName = "Nowak" }; // kolejna kopia

Console.WriteLine(p1 == p2);                    // False — różny wiek
Console.WriteLine(p1 == p1 with { });           // True  — identyczne pola, value equality
Console.WriteLine(ReferenceEquals(p1, p2));     // False — to różne obiekty w pamięci
```

### Kiedy Builder + `with` vs sam Builder?

```
Potrzebuję zbudować Person od zera z walidacją?
  → PersonBuilder.Build()

Mam już Person i chcę zmienić jedno pole (np. urodziny)?
  → with-expression: person with { Age = 31 }
   (nie waliduje — ostrożnie gdy zmiana może naruszyć niezmienniki)

Potrzebuję zmienić pole I zwalidować wynik?
  → Nowy Builder, przekaż stare wartości ręcznie lub
  → Dodaj metodę CopyWith() do PersonBuilder przyjmującą Person jako punkt startowy
```

Przykład `CopyWith()`:

```csharp
public static PersonBuilder CopyFrom(Person source) =>
    new PersonBuilder()
        .WithFirstName(source.FirstName)
        .WithLastName(source.LastName)
        .WithAge(source.Age)
        .WithEmail(source.Email);

// Użycie
var updated = PersonBuilder.CopyFrom(existingPerson)
    .WithEmail("nowy@adres.pl")
    .Build();   // ← walidacja ponownie uruchomiona
```

---

## Kiedy który wariant?

```
Mam wiele opcjonalnych pól?
  → TAK: Fluent Builder (lub Immutable Builder jeśli obiekt jest VO)

Kolejność kroków ma znaczenie biznesowe?
  → TAK: Step Builder (kompilator wymusza kolejność)

Chcę wielokrotnie uruchamiać ten sam algorytm dla różnych konfiguracji?
  → TAK: GoF Builder z Director

Buduję niemutowalny Value Object z prostą strukturą?
  → Rozważ: record + Builder z walidacją (lub nawet sam record jeśli nie potrzebujesz walidacji)
```

### Porównanie szczegółowe

| Cecha | GoF + Director | Fluent | Step | Immutable (record) |
|-------|---------------|--------|------|-------------------|
| Kolejność kroków | Director narzuca | Dowolna | Wymusza kompilator | Dowolna |
| Dziedziczenie | Klasyczne | CRTP dla typów zwrotnych | Bardzo trudne | Dziedziczenie recordów możliwe |
| Walidacja | W Director / Builder | `Build()` | `Build()` | `Build()` |
| Niemutowalność produktu | Opcjonalna | Opcjonalna | Opcjonalna | Zbudowana w `record` |
| Czytelność użycia | Proceduralna | Fluent DSL | Fluent + IntelliSense | Fluent |
| Złożoność implementacji | Średnia | Niska | Wysoka (wiele interfejsów) | Niska |
| Wielokrotne użycie | Przez Director | Przez metody fabryczne | Przez statyczny punkt wejścia | CopyFrom() |

---

## Uruchomienie

```bash
cd src/03-budowniczy/04-typy-implementacji/Examples
dotnet run
```

---

## Literatura

- Bloch J. — *Effective Java*, 3rd ed., Item 2: "*Consider a builder when faced with many constructor parameters*"
- Fowler M. — *FluentInterface*, <https://www.martinfowler.com/bliki/FluentInterface.html>
- Microsoft — *Records in C#*, <https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record>
- Shvets A. — *Builder*, <https://refactoring.guru/design-patterns/builder>
