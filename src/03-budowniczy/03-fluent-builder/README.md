# Fluent Builder — Interfejs Płynny i Method Chaining

## Idea

**Fluent Builder** to ewolucja klasycznego Buildera GoF: zamiast zwracać `void`,
każda metoda konfiguracyjna zwraca `this`. Pozwala to na **łańcuchowanie wywołań**
w stylu przypominającym naturalny język.

> *"A fluent interface is normally implemented by using method chaining to relay
> the instruction context of a subsequent call."*
> — Martin Fowler, [FluentInterface](https://www.martinfowler.com/bliki/FluentInterface.html)

### Czym jest Fluent Interface (wewnętrzne DSL)?

Martin Fowler opisał Fluent Interface jako **wewnętrzne DSL** (*Domain-Specific Language*)
wbudowane w język główny. Kod jest poprawnym C#, ale czyta się jak zdanie dziedzinowe:

```csharp
// "Zbuduj mi email od hr@firma.pl do anna@firma.pl z tematem X w formacie HTML"
new Email.Builder()
    .From("hr@firma.pl")
    .To("anna@firma.pl")
    .WithSubject("Nowe zasady pracy zdalnej")
    .AsHtml()
    .Build();
```

Różnica w stosunku do klasycznej metody proceduralnej:

```csharp
// Klasycznie — obiekt konfiguruje się przez wielokrotne wywołania
var builder = new EmailBuilder();
builder.SetFrom("hr@firma.pl");
builder.AddTo("anna@firma.pl");
builder.SetSubject("...");
var email = builder.Build();    // Builder i Product to oddzielne klasy
```

Fluent Builder eliminuje zmienną pośrednią (`builder`) i sprawia, że konfiguracja
staje się jednym wyrażeniem, które można przypisać lub przekazać od razu.

---

## Struktura

![Fluent Builder — klasy](diagrams/fluent_builder_class.png)

Kluczowa różnica wobec GoF: Builder **nie ma Dyrektora**. Klient sam komponuje
wywołania. Kolejność jest dowolna (chyba że użyjemy Step Buildera — patrz sekcja 04).

---

## Diagram sekwencji

![Fluent Builder — sekwencja](diagrams/fluent_builder_sequence.png)

---

## Dlaczego Builder zagnieżdżamy wewnątrz klasy produktu?

W implementacji z *EmployeeBuilder* Builder jest klasą `Employee.Builder` —
**zagnieżdżoną** (`nested class`) wewnątrz `Employee`:

```csharp
public sealed class Employee
{
    // pola prywatne — dostępne tylko dla Builder (bo jest zagnieżdżony w tej samej klasie)
    private readonly int    _id;
    private readonly string _firstName;

    private Employee(Builder b)   // konstruktor prywatny!
    {
        _id        = b._nextId++;
        _firstName = b.FirstName;
    }

    public sealed class Builder
    {
        internal static int _nextId = 1;
        public string FirstName { get; private set; } = "Imię";
        // ...
    }
}
```

Zalety tego podejścia:
- Konstruktor `Employee` jest **prywatny** — jedyna droga stworzenia obiektu to `Builder`.
  Nie ma ryzyka, że ktoś "przypadkowo" wywoła `new Employee(...)` z zewnątrz.
- Builder ma dostęp do prywatnych pól produktu (zagnieżdżone klasy w C# dzielą zakres).
- API klasy pozostaje czyste — użytkownicy widzą tylko publiczne `Employee.Builder`, nie konstruktor.

Alternatywa: Builder jako **oddzielna klasa** (`EmployeeBuilder`, nie zagnieżdżony):
```csharp
// Oddzielna klasa — konstruktor produktu musi być internal lub mieć fabrykę
public class EmployeeBuilder
{
    public Employee Build() => new Employee(FirstName, LastName, ...);
}
```
To zrywa enkapsulację — `Employee` musi mieć dostępny konstruktor. Z tego powodu
**zagnieżdżony Builder jest preferowany** gdy zależy nam na tym, żeby Builder był
jedynym prawowitym źródłem obiektów.

---

## Implementacja: EmployeeBuilder

```csharp
public class Builder
{
    // Wartości domyślne — Builder działa nawet bez żadnego wywołania With*
    public string  FirstName  { get; private set; } = "Imię";
    public string  Department { get; private set; } = "Niezdefiniowany";
    public decimal Salary     { get; private set; } = 5000m;
    // ...

    // Każda metoda konfiguracyjna:
    //   1. mutuje własne pole
    //   2. zwraca this (nie nowy obiekt!) → umożliwia chaining
    public Builder WithFirstName(string firstName)
    {
        FirstName = firstName;
        return this;    // ← kluczowe
    }

    public Builder WithSalary(decimal salary)
    {
        // Walidacja może być już tutaj, jeśli błąd jest lokalny dla danego pola
        if (salary < 0) throw new ArgumentException("Pensja nie może być ujemna");
        Salary = salary;
        return this;
    }

    // Build() to "materialization point" — jedyne miejsce tworzenia Employee
    public Employee Build() => new Employee(this);

    // Alternatywnie: implicit operator (patrz niżej)
}
```

### Mechanizm `return this` — jak naprawdę działa chaining?

```csharp
// Ten kod:
Employee e = new Employee.Builder()
    .WithFirstName("Anna")    // returns Builder
    .WithLastName("Kowalska") // returns Builder
    .WithSalary(12_500m)      // returns Builder
    .Build();                 // returns Employee

// Jest identyczny z:
var b = new Employee.Builder();
b = b.WithFirstName("Anna");     // b wciąż wskazuje na ten sam obiekt
b = b.WithLastName("Kowalska");  // nadpisujemy zmienną, ale obiekt jest ten sam
b = b.WithSalary(12_500m);
Employee e = b.Build();
```

Builder mutuje **swoje własne pola** i zwraca referencję do siebie.
Nie ma tu magii — chaining to syntaktyczny cukier nad sekwencją mutacji.

### Użycie

```csharp
var employee = new Employee.Builder()
    .WithFirstName("Anna")
    .WithLastName("Kowalska")
    .WithBirthDate(1992, 5, 14)
    .WithDepartment("Engineering")
    .WithSalary(12_500m)
    .Build();
```

---

## Konwersja niejawna (Implicit Operator)

Trick z `implicit operator` pozwala pominąć jawne wywołanie `Build()`:

```csharp
public static implicit operator Employee(Builder builder) => builder.Build();

// Użycie:
Employee e = new Employee.Builder()
    .WithFirstName("Piotr")
    .WithLastName("Wiśniewski");
// ↑ brak Build() — konwersja następuje automatycznie przy przypisaniu
```

### Kiedy `implicit operator` jest wartościowy?

| Scenariusz | Czy warto? |
|-----------|-----------|
| Zwięzłe API (np. biblioteka) | ✅ — skraca wywołania |
| Test Data Builder | ✅ — testy są krótkie i czytelne |
| Kod produkcyjny ogólnego zastosowania | ⚠️ — zaskakuje czytelnika |
| Dziedziczenie builderów | ❌ — `implicit operator` nie dziedziczy się |

> **Pułapka:** `implicit operator` jest statyczny i nie dziedziczy się.
> Jeśli rozszerzasz Builder przez dziedziczenie, `implicit operator` w klasie
> bazowej będzie konwertował na typ bazowy, nie pochodny.

### Dziedziczenie Builderów — problem "utraty typu"

```csharp
// Problem: WithX() w klasie bazowej zwraca BaseBuilder, nie ChildBuilder
public class PersonBuilder
{
    public PersonBuilder WithName(string n) { _name = n; return this; }
}

public class EmployeeBuilder : PersonBuilder
{
    public EmployeeBuilder WithDepartment(string d) { _dept = d; return this; }
}

// ❌ Nie skompiluje się — WithName zwraca PersonBuilder, a nie EmployeeBuilder
new EmployeeBuilder()
    .WithName("Anna")        // zwraca PersonBuilder
    .WithDepartment("IT");   // błąd: PersonBuilder nie ma WithDepartment
```

**Rozwiązanie — Recursive Generics (CRTP):**

```csharp
public abstract class PersonBuilder<TBuilder> where TBuilder : PersonBuilder<TBuilder>
{
    protected string _name = string.Empty;

    public TBuilder WithName(string n) { _name = n; return (TBuilder)this; }
}

public sealed class EmployeeBuilder : PersonBuilder<EmployeeBuilder>
{
    private string _department = string.Empty;

    public EmployeeBuilder WithDepartment(string d) { _department = d; return this; }

    public Employee Build() => new Employee(_name, _department);
}

// ✅ Działa — WithName zwraca EmployeeBuilder
new EmployeeBuilder()
    .WithName("Anna")
    .WithDepartment("IT")
    .Build();
```

> Uwaga: ten wzorzec (Recursive Generics / CRTP — *Curiously Recurring Template Pattern*)
> jest poprawny, ale zaawansowany. Stosuj go tylko gdy faktycznie potrzebujesz
> dziedziczenia builderów.

---

## Przykład: EmailBuilder

```csharp
var email = new Email.Builder()
    .From("hr@firma.pl")
    .To("anna@firma.pl")
    .To("marek@firma.pl")       // To() można wywołać wiele razy — Builder akumuluje listę
    .Cc("ceo@firma.pl")
    .WithSubject("Nowe zasady pracy zdalnej")
    .WithBody("<h1>Nowe zasady</h1><p>...</p>")
    .AsHtml()
    .WithAttachment("polityka_zdalna_2026.pdf")
    .Build();
```

Zwróć uwagę: `.To()` można wywołać wielokrotnie — Builder akumuluje listę adresatów.
Konstruktor z parametrem `string[] to` wymusiłby przekazanie wszystkich adresatów naraz.

### Wewnętrzna implementacja akumulacji list

```csharp
public sealed class Email
{
    // ...
    public sealed class Builder
    {
        private readonly List<string> _toAddresses  = [];    // akumulacja
        private readonly List<string> _ccAddresses  = [];
        private readonly List<string> _attachments  = [];
        private string _senderAddress = string.Empty;

        // Każde wywołanie To() dodaje jeden adres do listy
        public Builder To(string address)
        {
            _toAddresses.Add(address);
            return this;
        }

        public Builder Cc(string address)
        {
            _ccAddresses.Add(address);
            return this;
        }

        public Builder WithAttachment(string path)
        {
            _attachments.Add(path);
            return this;
        }
    }
}
```

Ta technika (*accumulator pattern*) jest niemożliwa do odtworzenia z użyciem
konstruktora — tam `string[]` to jeden argument, nie seria wywołań.

---

## Walidacja w `Build()`

```csharp
public Email Build()
{
    if (string.IsNullOrWhiteSpace(SenderAddress))
        throw new InvalidOperationException("Pole From jest wymagane");
    if (ToAddresses.Count == 0)
        throw new InvalidOperationException("Wymagany co najmniej jeden adresat To");
    return new Email(this);
}
```

`Build()` to **jedyne miejsce**, gdzie walidujemy kompletność obiektu.
Pozwala to na wywołania w dowolnej kolejności, ale gwarantuje spójność wyniku.

### Trzy strategie walidacji w Builderze

| Strategia | Kiedy walidujemy | Zalety | Wady |
|-----------|-----------------|--------|------|
| **Lokalna (w metodzie With*)** | Przy każdym ustawieniu pola | Szybki feedback | Nie waliduje zależności między polami |
| **Leniwa (w `Build()`)** | Przy materializacji | Waliduje kombinacje pól | Błąd pojawia się późno |
| **Mieszana** | Prosta walidacja w With*, złożona w Build() | Balans | Logika rozproszona |

Przykład walidacji zależności między polami (tylko w `Build()`):

```csharp
public Email Build()
{
    // Walidacja lokalna (można przenieść do WithSubject)
    if (string.IsNullOrWhiteSpace(_subject))
        throw new InvalidOperationException("Temat jest wymagany");

    // Walidacja kombinacji pól — niemożliwa do zrobienia wcześniej
    if (_isHtml && _body?.Contains('<') == false)
        throw new InvalidOperationException(
            "Treść oznaczona jako HTML nie zawiera tagów HTML");

    return new Email(this);
}
```

---

## Fluent Builder vs GoF Builder

| Cecha | GoF Builder | Fluent Builder |
|---|---|---|
| Dyrektor | Wymagany | Opcjonalny / zbędny |
| Kolejność kroków | Narzucona przez Director | Dowolna (lub narzucona przez Step Builder) |
| Czytelność wywołania | Proceduralna | "Jak zdanie w języku naturalnym" |
| Walidacja | W Director lub Builder | Centralna w `Build()` |
| Powszechność użycia | Frameworki | Codzienne API, testy (test data builders) |
| Wielokrotne powtórzenia kroku | Nie (Director wywołuje każdy krok raz) | Tak (akumulacja list) |
| Dziedziczenie buildera | Klasyczne | Wymaga CRTP dla poprawnych typów zwrotnych |

---

## Fluent Builder a bezpieczeństwo wątków

Builder jest z założenia **niebezpieczny wątkowo** — ale to jest właściwe zachowanie:

```csharp
// ŹLE — współdzielenie buildera między wątkami
var sharedBuilder = new Email.Builder().From("hr@firma.pl");

// Wątek A                         // Wątek B
sharedBuilder.To("anna@firma.pl"); // sharedBuilder.To("marek@firma.pl");
var emailA = sharedBuilder.Build();// var emailB = sharedBuilder.Build();
// emailA może zawierać adres "marek@firma.pl" — race condition!

// DOBRZE — każdy wątek tworzy własny builder
var emailA = new Email.Builder().From("hr@firma.pl").To("anna@firma.pl").Build();
var emailB = new Email.Builder().From("hr@firma.pl").To("marek@firma.pl").Build();
```

Builder to **jednorazowy obiekt konfiguracyjny** — twórz nowy dla każdego produktu.
Klasa produktu (`Email`, `Employee`) powinna być niemutowalna — wtedy risk concurrency się kończy w `Build()`.

---

## Fluent Builder w testach jednostkowych

Fluent Builder jest wyjątkowo przydatny jako **Test Data Builder** (*Object Mother* to pokrewny wzorzec):

```csharp
// Tworzenie danych testowych bez pisania wielu konstruktorów testowych
var employee = new Employee.Builder()
    .WithDepartment("IT")
    .WithSalary(10_000m)
    .Build();   // reszta pól = sensowne domyślne

// Klasa testowa z fabryką buildera — "domyślny pracownik IT"
public static class EmployeeFixtures
{
    public static Employee.Builder DefaultEmployee() =>
        new Employee.Builder()
            .WithFirstName("Test")
            .WithLastName("User")
            .WithDepartment("Engineering")
            .WithSalary(10_000m);
}

// W testach — modyfikujemy tylko to, co jest istotne dla testu
[Fact]
public void Employee_WithNegativeSalary_ThrowsException()
{
    Assert.Throws<ArgumentException>(() =>
        EmployeeFixtures.DefaultEmployee()
            .WithSalary(-1)   // zmiana tylko istotnego pola
            .Build());
}
```

Podejście to ma kilka zalet:
- Testy nie są kruche — zmiana sygnatury `Employee` wymaga aktualizacji tylko w builderze
- Wartości domyślne w Builder dają sensowne "tło" dla danych testowych
- Każdy test precyzyjnie opisuje co sprawdza, nie jak zbudować obiekt

---

## Uruchomienie

```bash
cd src/03-budowniczy/03-fluent-builder/Examples
dotnet run
```

---

## Literatura

- Fowler M. — *FluentInterface*, <https://www.martinfowler.com/bliki/FluentInterface.html>
- Freeman S. et al. — *Growing Object-Oriented Software, Guided by Tests*, Addison-Wesley 2009 (Test Data Builders, rozdz. 22)
- Bloch J. — *Effective Java*, 3rd ed., Addison-Wesley 2018, Item 2
- Shvets A. — *Builder*, <https://refactoring.guru/design-patterns/builder>
