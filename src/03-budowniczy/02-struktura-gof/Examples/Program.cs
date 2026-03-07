using StrukturaGoF.Vehicles;

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║     WZORZEC BUDOWNICZY — Struktura GoF (Klasyczna)   ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");

// =====================================================================
// Dyrektor i Budowniczowie
// =====================================================================
var shop = new Shop();

Console.WriteLine("\n=== Scooter ===");
var scooterBuilder = new ScooterBuilder();
shop.Construct(scooterBuilder);
scooterBuilder.GetVehicle().Show();

Console.WriteLine("\n=== Car ===");
var carBuilder = new CarBuilder();
shop.Construct(carBuilder);
carBuilder.GetVehicle().Show();

Console.WriteLine("\n=== MotorCycle ===");
var motoBuilder = new MotorCycleBuilder();
shop.Construct(motoBuilder);
motoBuilder.GetVehicle().Show();

// =====================================================================
// Demonstracja separacji Director <-> Builder
// =====================================================================
Console.WriteLine("\n\n--- Dyrektor i Builder są niezależne ---");
Console.WriteLine("Mogę zbudować pojazd BEZ Dyrektora (wywołując kroki ręcznie):");

var car2 = new CarBuilder();
car2.BuildFrame();   // pominę Engine i Wheels celowo
car2.BuildDoors();
Console.WriteLine("\nNiekompletny samochód (bez silnika i kół):");
car2.GetVehicle().Show();

Console.WriteLine("\nWNIOSEK:");
Console.WriteLine("  Director = algorytm składania.");
Console.WriteLine("  Builder  = sposób budowania każdego kroku.");
Console.WriteLine("  Są niezależne — można wymieniać oba osobno.");
