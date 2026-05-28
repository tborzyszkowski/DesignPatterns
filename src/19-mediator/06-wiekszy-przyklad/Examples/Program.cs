// =============================================================================
// Wzorzec Mediator — 06. Większy przykład
// Demo: Lotnisko Warszawa-Chopin
// =============================================================================

using Mediator.WiekszyPrzyklad;

Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║  LOTNISKO WARSZAWA-CHOPIN — SYMULACJA ║");
Console.WriteLine("╚══════════════════════════════════════╝\n");

// Inicjalizacja: 2 pasy startowe
var tower = new ControlTower(
    new Runway("27L"),
    new Runway("27R"));

// Rejestracja lotów (różne typy uczestników)
var lot101 = new CommercialFlight("LOT101", capacity: 260);  // ma priorytet
var ryr202 = new PrivatePlane("RYR202");
var wzz303 = new CommercialFlight("WZZ303", capacity: 150);
var fra404 = new CommercialFlight("FRA404", capacity: 310);  // ma priorytet

Console.WriteLine("═══ Rejestracja lotów ═══");
tower.Register(lot101);
tower.Register(ryr202);
tower.Register(wzz303);
tower.Register(fra404);

Console.WriteLine("\n═══ Scenariusz 1: Jednoczesne prośby o lądowanie ═══\n");

// 4 samoloty chcą lądować — tylko 2 pasy
lot101.RequestLanding();
ryr202.RequestLanding();
wzz303.RequestLanding();  // trafi do kolejki
fra404.RequestLanding();  // trafi do kolejki (priorytet!)

Console.WriteLine("\n═══ Status pasów: ═══");
foreach (var s in tower.GetRunwayStatus())
    Console.WriteLine($"  Pas {s.RunwayName}: {(s.IsOccupied ? $"ZAJĘTY [{s.CurrentAircraft}]" : "WOLNY")}");

Console.WriteLine("\n═══ Scenariusz 2: LOT101 ląduje → pas wolnieje ═══\n");
lot101.ReportLanded();  // wieża automatycznie obsługuje kolejkę

Console.WriteLine("\n═══ Scenariusz 3: RYR202 ląduje → kolejny ═══\n");
ryr202.ReportLanded();

Console.WriteLine("\n═══ Status końcowy pasów: ═══");
foreach (var s in tower.GetRunwayStatus())
    Console.WriteLine($"  Pas {s.RunwayName}: {(s.IsOccupied ? $"ZAJĘTY [{s.CurrentAircraft}]" : "WOLNY")}");

Console.WriteLine("\n═══ Scenariusz 4: Start (takeoff) ═══\n");
var sp123 = new PrivatePlane("SP-ABC");
tower.Register(sp123);
sp123.RequestLanding();   // najpierw musi wylądować

Console.WriteLine();
// Gdy przyleci, prosi o start
wzz303.ReportLanded();
fra404.ReportLanded();

var newFlight = new CommercialFlight("LOT505", capacity: 180);
tower.Register(newFlight);
newFlight.RequestTakeoff();
