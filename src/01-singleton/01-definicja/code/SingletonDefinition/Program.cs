using SingletonDefinition;

Console.WriteLine("=== WZORZEC SINGLETON — DEFINICJA I IMPLEMENTACJE ===\n");

// ──────────────────────────────────────────────────────────────────────────────
// 1. ClassicSingleton — klasyczny leniwy (NIE thread-safe)
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── 1. ClassicSingleton (lazy, nie thread-safe) ──");
var classic1 = ClassicSingleton.GetInstance();
var classic2 = ClassicSingleton.GetInstance();
Console.WriteLine(classic1.Greet());
Console.WriteLine($"classic1 == classic2: {ReferenceEquals(classic1, classic2)}");
Console.WriteLine();

// ──────────────────────────────────────────────────────────────────────────────
// 2. EagerSingleton — inicjalizacja zachłanna
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── 2. EagerSingleton (eager, thread-safe) ──");
var eager1 = EagerSingleton.Instance;
var eager2 = EagerSingleton.Instance;
Console.WriteLine(eager1.Greet());
Console.WriteLine($"eager1 == eager2: {ReferenceEquals(eager1, eager2)}");
Console.WriteLine();

// ──────────────────────────────────────────────────────────────────────────────
// 3. LazySingleton — Lazy<T> (zalecany w .NET)
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── 3. LazySingleton (Lazy<T>, thread-safe) ──");
Console.WriteLine($"Przed pierwszym dostępem: IsCreated = {LazySingleton.IsCreated}");
var lazy1 = LazySingleton.Instance;
var lazy2 = LazySingleton.Instance;
Console.WriteLine(lazy1.Greet());
Console.WriteLine(lazy1.GetStatus());
Console.WriteLine($"lazy1 == lazy2: {ReferenceEquals(lazy1, lazy2)}");
Console.WriteLine();

// ──────────────────────────────────────────────────────────────────────────────
// 4. StaticHolderSingleton — Static Holder pattern
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── 4. StaticHolderSingleton (Static Holder, thread-safe) ──");
var holder1 = StaticHolderSingleton.Instance;
var holder2 = StaticHolderSingleton.Instance;
Console.WriteLine(holder1.Greet());
Console.WriteLine($"holder1 == holder2: {ReferenceEquals(holder1, holder2)}");
Console.WriteLine();

// ──────────────────────────────────────────────────────────────────────────────
// 5. ChocolateBoiler — przykład praktyczny
// ──────────────────────────────────────────────────────────────────────────────
Console.WriteLine("── 5. ChocolateBoiler — przykład praktyczny ──");
var boiler1 = ChocolateBoiler.GetInstance();
var boiler2 = ChocolateBoiler.GetInstance();

Console.WriteLine($"boiler1 == boiler2: {ReferenceEquals(boiler1, boiler2)}");
Console.WriteLine($"Stan: {boiler1}");

boiler1.Fill();
boiler1.Boil();
boiler1.Drain();

// boiler2 odzwierciedla ten sam stan — to ten sam obiekt!
Console.WriteLine($"\nStan przez boiler2 (ten sam obiekt): {boiler2}");

Console.WriteLine("\n=== KONIEC DEMONSTRACJI ===");
