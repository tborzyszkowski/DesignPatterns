using TypyImplementacji.StepBuilder;
using TypyImplementacji.ImmutableBuilder;

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║     TYPY IMPLEMENTACJI BUILDERA                      ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");

// =====================================================================
// TYP 1: Step Builder — SqlQueryBuilder
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  TYP 1: Step Builder — SQL Query                     │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

// Kompilator WYMUSZA kolejność: From → Select → [Where] → [OrderBy/Limit] → Build
var q1 = SqlQueryBuilder.Query()
    .From("employees")
    .SelectAll()
    .Where("department = 'IT'")
    .OrderBy("salary", descending: true)
    .Limit(10)
    .Build();

Console.WriteLine($"  SQL: {q1.ToSql()}");

var q2 = SqlQueryBuilder.Query()
    .From("orders")
    .Select("id", "customer_id", "total")
    .Where("total > 1000")
    .Build();

Console.WriteLine($"  SQL: {q2.ToSql()}");

var q3 = SqlQueryBuilder.Query()
    .From("products")
    .SelectAll()
    .Build();   // bez WHERE — bezpośrednio z IWhereStep

Console.WriteLine($"  SQL: {q3.ToSql()}");

Console.WriteLine("\n  WNIOSEK: Nie możemy napisać SqlQueryBuilder.Query().Build()");
Console.WriteLine("  — kompilator nie pozwoli, bo IFromStep nie ma metody Build()!");

// =====================================================================
// TYP 2: Immutable Builder (Builder + C# record)
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  TYP 2: Immutable Builder (record)                   │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

var person = new PersonBuilder()
    .WithFirstName("Katarzyna")
    .WithLastName("Wiśniewska")
    .WithAge(28)
    .WithEmail("kasia@firma.pl")
    .Build();

Console.WriteLine($"  {person}");

// Walidacja
try { new PersonBuilder().WithAge(-5).Build(); }
catch (ArgumentException ex) { Console.WriteLine($"  Błąd: {ex.Message}"); }

try { new PersonBuilder().WithEmail("nieprawidlowy").Build(); }
catch (ArgumentException ex) { Console.WriteLine($"  Błąd: {ex.Message}"); }

// =====================================================================
// TYP 3: C# record "with" expression — modyfikacja niemutowalnych
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  TYP 3: record + with-expression                     │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

RecordWithDemo.Run();
