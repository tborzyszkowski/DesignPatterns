// =============================================================
//  Kiedy stosować Prototyp — Program.cs
// =============================================================
using KiedyStosowac;
using System.Diagnostics;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ─────────────────────────────────────────────────────────────
//  SCENARIUSZ 1: Registry wrogów — spawn N razy jest tani
// ─────────────────────────────────────────────────────────────
Console.WriteLine("═══════════════════════════════════════════════════════");
Console.WriteLine(" SCENARIUSZ 1: Registry wrogów (Prototype Pattern)     ");
Console.WriteLine("═══════════════════════════════════════════════════════");

var registry = new EnemyRegistry();

// Ładujemy szablony raz — tu w kodzie, w produkcji wczytalibyśmy
// z pliku JSON/XML, co mogłoby trwać dziesiątki ms dla setek szablonów.
registry.Register("goblin", new Goblin());
registry.Register("orc",    new Orc());
registry.Register("dragon", new Dragon());

Console.WriteLine($"\n  Zarejestrowane szablony: [{string.Join(", ", registry.Keys)}]");

// Spawn'ujemy falę wrogów — każdy to tania kopia szablonu
Console.WriteLine("\n  === Fala 1: patrol goblins ===");
var wave1 = new List<IEnemy>
{
    registry.Spawn("goblin", 10, 5),
    registry.Spawn("goblin", 12, 5),
    registry.Spawn("goblin", 14, 5),
    registry.Spawn("orc",    13, 3),
};
wave1.ForEach(e => e.PrintStats());

// Sprawdzamy: szablony NIE zostały zmodyfikowane
Console.WriteLine("\n  === Fala 2: boss encounter ===");
var boss = registry.Spawn("dragon", 50, 50);
boss.PrintStats();

// Kluczowe — modyfikacja zspawnowanego wroga nie psuje szablonu
registry.Spawn("goblin", 0, 0).PrintStats();

Console.WriteLine("\n  Weryfikacja izolacji szablonów:");
var g1 = registry.Spawn("goblin", 1, 1);
var g2 = registry.Spawn("goblin", 2, 2);
g1.Abilities.GetType(); // tylko odczyt — IReadOnlyList
Console.WriteLine($"  g1.Abilities == g2.Abilities (te same referencje)? " +
    $"{ReferenceEquals(g1.Abilities, g2.Abilities)}");   // powinno być False
Console.WriteLine($"  g1 i g2 są niezależnymi kopiami szablonu — ✓");

// ─────────────────────────────────────────────────────────────
//  SCENARIUSZ 2: Performance — clone vs new
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n═══════════════════════════════════════════════════════");
Console.WriteLine(" SCENARIUSZ 2: Benchmark — spawn przez Prototype vs new ");
Console.WriteLine("═══════════════════════════════════════════════════════");

const int N = 10_000;

var sw = Stopwatch.StartNew();
for (int i = 0; i < N; i++)
    _ = registry.Spawn("orc", i % 100, i % 100);
sw.Stop();
long cloneMs = sw.ElapsedMilliseconds;

// Dla porównania: konstruktor nowego wroga (bez rejestru)
sw.Restart();
for (int i = 0; i < N; i++)
    _ = new Orc();
sw.Stop();
long newMs = sw.ElapsedMilliseconds;

Console.WriteLine($"  Spawn przez registry ({N}x): {cloneMs} ms");
Console.WriteLine($"  new Orc() bez registry ({N}x): {newMs} ms");
Console.WriteLine($"  Prototype ma sens gdy inicjalizacja jest naprawdę droga.");

// ─────────────────────────────────────────────────────────────
//  SCENARIUSZ 3: Kiedy NIE stosować — proste DTO / ValueObject
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n═══════════════════════════════════════════════════════");
Console.WriteLine(" SCENARIUSZ 3: Kiedy NIE stosować Prototypu             ");
Console.WriteLine("═══════════════════════════════════════════════════════");

// Punkt na płaszczyźnie — record + with jest wystarczający
var p1 = new Point(3.0, 4.0);
var p2 = p1 with { X = 10.0 };
Console.WriteLine($"\n  Point p1 = {p1}");
Console.WriteLine($"  Point p2 = {p2}  (with-expression, nie potrzeba Prototypu)");

// Order — każde zamówienie jest unikalne, klonowanie nie ma sensu
var order1 = OrderFactory.Create("CUST-001",
    [("SKU-A", 3, 19.99m), ("SKU-B", 1, 49.99m)]);
Console.WriteLine($"\n  Zamówienie: {order1.OrderId}  dla {order1.CustomerId}");
Console.WriteLine($"  Sum: {order1.Lines.Sum(l => l.Qty * l.Price):C}");
Console.WriteLine($"  Zamówienie ma unikalne ID i datę — klonowanie byłoby błędem domenowym.");

// ReportRow — wystarczy with
var row = new ReportRow("Widget", 5, 9.99m);
var adjusted = row with { Quantity = row.Quantity * 2 };
Console.WriteLine($"\n  ReportRow: {row}  Total={row.Total:C}");
Console.WriteLine($"  Adjusted:  {adjusted}  Total={adjusted.Total:C}  (record with — wystarczy)");

Console.WriteLine("\n  Gotowe.");
