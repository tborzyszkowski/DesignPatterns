using ProblemKonstrukcji;

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║   PROBLEM: Dlaczego potrzebujemy wzorca Budowniczy?  ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");

// =====================================================================
// PROBLEM 1: Teleskopowy konstruktor
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PROBLEM 1: Teleskopowy konstruktor                  │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

// Co oznacza true, false, true? Trzeba sprawdzić definicję klasy!
var p1 = new PizzaTelescoping("large", true, false, true);
// p1.Bacon = true; 
Console.WriteLine($"Teleskopowy: {p1}");
Console.WriteLine("  ← Czy widzisz od razu, że mamy ser i bekon, ale nie pepperoni?");

// =====================================================================
// PROBLEM 2: Object Initializer — mutowalność
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PROBLEM 2: Object Initializer — ale obiekt mutowalny│");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

var p2 = new PizzaMutable { Size = "small", Cheese = true };
Console.WriteLine($"Object init: {p2}");
// Niestety można zmodyfikować po stworzeniu:
p2.Bacon = true;  // ← obiekt nie jest bezpieczny
Console.WriteLine($"  Po modyfikacji: {p2}");
Console.WriteLine("  ← Obiekt mutowalny — można zmienić po zwrocie z metody!");

// =====================================================================
// ROZWIĄZANIE: Builder
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  ROZWIĄZANIE: Builder                                │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");

var p3 = new Pizza.Builder("large")
    .WithCheese()
    .WithBacon()
    .Build();

Console.WriteLine($"Builder: {p3}");
Console.WriteLine("  ← Czytelny kod: widać co dodajemy. Obiekt niemutowalny.");

// Walidacja działa:
try { new Pizza.Builder(""); }
catch (ArgumentException ex) { Console.WriteLine($"\n  Walidacja: {ex.Message}"); }

// =====================================================================
// FACTORY vs BUILDER — różne role
// =====================================================================
Console.WriteLine("\n┌──────────────────────────────────────────────────────┐");
Console.WriteLine("│  PODSUMOWANIE: Factory vs Builder                    │");
Console.WriteLine("└──────────────────────────────────────────────────────┘");
Console.WriteLine("Factory Method  → odpowiada: KTÓRY obiekt stworzyć?");
Console.WriteLine("                  (NYStyleCheesePizza vs ChicagoStyleCheesePizza)");
Console.WriteLine("Builder         → odpowiada: JAK zbudować złożony obiekt?");
Console.WriteLine("                  (konfiguracja krok po kroku, opcjonalne parametry)");
Console.WriteLine();
Console.WriteLine("Mogą współpracować: Factory wybiera Builder, Builder buduje Product.");
