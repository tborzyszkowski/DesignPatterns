using FluentBuilder.Employees;
using FluentBuilder.Emails;

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║      FLUENT BUILDER — Method Chaining               ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");

// =====================================================================
// PRZYKŁAD 1: Employee Builder
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 1: EmployeeBuilder                         │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

var anna = new Employee.Builder()
    .WithFirstName("Anna")
    .WithLastName("Kowalska")
    .WithBirthDate(1992, 5, 14)
    .WithDepartment("Engineering")
    .WithSalary(12_500m)
    .Build();

Console.WriteLine(anna);

var marek = new Employee.Builder()
    .WithFirstName("Marek")
    .WithLastName("Nowak")
    .WithBirthDate(1985, 11, 3)
    .WithDepartment("Management")
    .WithSalary(18_000m)
    .Build();

Console.WriteLine(marek);

// Konwersja niejawna (implicit operator)
Console.WriteLine("\n--- Konwersja niejawna (implicit operator) ---");
Employee piotr = new Employee.Builder()
    .WithFirstName("Piotr")
    .WithLastName("Wiśniewski")
    .WithBirthDate(2000, 3, 20)
    .WithDepartment("IT Support");
// ↑ Brak .Build() — implicit operator Employee konwertuje automatycznie
Console.WriteLine(piotr);

// =====================================================================
// PRZYKŁAD 2: Email Builder
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 2: EmailBuilder                            │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

var email = new Email.Builder()
    .From("hr@firma.pl")
    .To("anna.kowalska@firma.pl")
    .To("marek.nowak@firma.pl")
    .Cc("ceo@firma.pl")
    .WithSubject("Nowe zasady pracy zdalnej")
    .WithBody("<h1>Nowe zasady</h1><p>Od 1 marca obowiązują nowe zasady pracy zdalnej...</p>")
    .AsHtml()
    .WithAttachment("polityka_zdalna_2026.pdf")
    .Build();

Console.WriteLine(email);

// =====================================================================
// PRZYKŁAD 3: Walidacja
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PRZYKŁAD 3: Walidacja w Build()                     │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

try
{
    var invalid = new Email.Builder()
        .From("sender@test.pl")
        // brak .To() — Builder zwaliduje
        .WithSubject("Test")
        .Build();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"  Błąd walidacji: {ex.Message}");
}

try
{
    new Employee.Builder().WithBirthDate(2099, 1, 1).Build();
}
catch (ArgumentException ex)
{
    Console.WriteLine($"  Błąd walidacji: {ex.Message}");
}

Console.WriteLine("\nWNIOSEK: Build() to naturalne miejsce na walidację całego obiektu.");
