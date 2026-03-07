// =============================================================
//  Warianty implementacji wzorca Prototyp — Program.cs
// =============================================================
using TypyImplementacji;
using System.Runtime.CompilerServices;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ─────────────────────────────────────────────────────────────
//  WARIANT 1: ICloneable — pułapka płytkiej kopii
// ─────────────────────────────────────────────────────────────
Console.WriteLine("══════════════════════════════════════════════════");
Console.WriteLine(" WARIANT 1: ICloneable (historyczny, niezalecany) ");
Console.WriteLine("══════════════════════════════════════════════════");

var original1 = new VehicleCardLegacy
{
    Brand    = "Toyota",
    Model    = "Corolla",
    Year     = 2020,
    Features = ["ABS", "ESP", "Parking sensors"]
};

var clone1 = (VehicleCardLegacy)original1.Clone();   // <── rzutowanie wymagane

Console.WriteLine($"  oryginał: {original1}");
Console.WriteLine($"  klon:     {clone1}");
Console.WriteLine($"  Adresy list identyczne: {ReferenceEquals(original1.Features, clone1.Features)}");

// Modyfikujemy klona — zmiana dotyczy też oryginału!
clone1.Features.Add("Heated seats");
Console.WriteLine($"\n  Po dodaniu opcji do klona:");
Console.WriteLine($"  oryginał.Features: [{string.Join(", ", original1.Features)}]  ← ZMIENIONY!");
Console.WriteLine($"  klon.Features:     [{string.Join(", ", clone1.Features)}]");

// ─────────────────────────────────────────────────────────────
//  WARIANT 2: Własny IPrototype<T> — bezpieczeństwo typów
// ─────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("══════════════════════════════════════════════════");
Console.WriteLine(" WARIANT 2: IPrototype<T> — generyczny interfejs  ");
Console.WriteLine("══════════════════════════════════════════════════");

var original2 = new VehicleCard
{
    Brand    = "Toyota",
    Model    = "Corolla",
    Year     = 2020,
    Features = ["ABS", "ESP", "Parking sensors"]
};

VehicleCard clone2 = original2.Clone();   // <── bez rzutowania, typ zwracany VehicleCard

Console.WriteLine($"  oryginał: {original2}");
Console.WriteLine($"  klon:     {clone2}");
Console.WriteLine($"  Adresy list identyczne: {ReferenceEquals(original2.Features, clone2.Features)}");

clone2.Features.Add("Heated seats");
Console.WriteLine($"\n  Po dodaniu opcji do klona:");
Console.WriteLine($"  oryginał.Features: [{string.Join(", ", original2.Features)}]  ← NIE zmieniony");
Console.WriteLine($"  klon.Features:     [{string.Join(", ", clone2.Features)}]");

// ─────────────────────────────────────────────────────────────
//  WARIANT 3: PrototypeBase<T> — abstrakcyjna klasa bazowa
// ─────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("══════════════════════════════════════════════════");
Console.WriteLine(" WARIANT 3: PrototypeBase<T> — klasa bazowa       ");
Console.WriteLine("══════════════════════════════════════════════════");

var masterConfig = ServerConfig.LoadFromServer("prod");
Console.WriteLine($"  masterConfig:    {masterConfig}");

var testConfig   = masterConfig.Clone();   // nie blokuje 100 ms!
Console.WriteLine($"  klon (bez sieci): {testConfig}");
Console.WriteLine($"  Adresy Hosts identyczne: {ReferenceEquals(masterConfig.AllowedHosts, testConfig.AllowedHosts)}");

// ─────────────────────────────────────────────────────────────
//  WARIANT 4: Konstruktor kopiujący (zalecany)
// ─────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("══════════════════════════════════════════════════");
Console.WriteLine(" WARIANT 4: Konstruktor kopiujący (zalecany)       ");
Console.WriteLine("══════════════════════════════════════════════════");

var templateEmployee = new Employee
{
    Name    = "Jan Kowalski",
    Role    = "Developer",
    Address = new() { Street = "ul. Kwiatowa 5", City = "Warszawa" },
    Skills  = ["C#", "SQL", "Docker"]
};

// Klonowanie przez konstruktor kopiujący
var hiredEmployee = new Employee(templateEmployee) { Name = "Anna Nowak" };
// alternatywnie: var hiredEmployee = templateEmployee.Clone() z nadpisaniem Name

Console.WriteLine($"  szablon: {templateEmployee}");
Console.WriteLine($"  klon:    {hiredEmployee}");
Console.WriteLine($"  Adresy identyczne: {ReferenceEquals(templateEmployee.Address, hiredEmployee.Address)}");

hiredEmployee.Skills.Add("React");
hiredEmployee.Address.City = "Kraków";
Console.WriteLine($"\n  Po modyfikacji klona:");
Console.WriteLine($"  szablon: {templateEmployee}  ← NIE zmieniony");
Console.WriteLine($"  klon:    {hiredEmployee}");

// ─────────────────────────────────────────────────────────────
//  WARIANT 5: Record + with-expression (C# 9+)
// ─────────────────────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("══════════════════════════════════════════════════");
Console.WriteLine(" WARIANT 5: record + with-expression (C# 9+)       ");
Console.WriteLine("══════════════════════════════════════════════════");

var defaultConn = new ConnectionOptions("localhost", 5432, UseSsl: false);

// with tworzy nową instancję z wybranymi polami nadpisanymi
var prodConn = defaultConn with { Host = "db.prod.example.com", Port = 5433, UseSsl = true };
var testConn = defaultConn with { Host = "db.test.example.com" };

Console.WriteLine($"  default: {defaultConn}");
Console.WriteLine($"  prod:    {prodConn}");
Console.WriteLine($"  test:    {testConn}");

// Records mają value equality — equals nie porównuje referencji
Console.WriteLine($"\n  ReferenceEquals(default, default): {ReferenceEquals(defaultConn, defaultConn)}");
Console.WriteLine($"  ReferenceEquals(default, testConn): {ReferenceEquals(defaultConn, testConn)}");
Console.WriteLine($"  default == testConn: {defaultConn == testConn}");  // false — inne pole Host
var testConn2 = defaultConn with { Host = "db.test.example.com" };
Console.WriteLine($"  testConn == testConn2: {testConn == testConn2}");   // true — wartości identyczne

Console.WriteLine("\n  Gotowe.");
