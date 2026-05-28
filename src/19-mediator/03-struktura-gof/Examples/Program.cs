// =============================================================================
// Wzorzec Mediator — 03. Struktura GoF
// Pokazuje wszystkie role GoF na przykładzie panelu sterowania lotniskiem
// =============================================================================

Console.WriteLine("═══ Struktura GoF — Panel sterowania lotniskiem ═══\n");

// Tworzenie uczestników (GoF: ConcreteColleagues)
var runway1  = new Runway("Pas 01");
var runway2  = new Runway("Pas 02");
var plane1   = new Aircraft("LOT101");
var plane2   = new Aircraft("RYR202");
var plane3   = new Aircraft("WZZ303");
var weather  = new WeatherStation();

// Tworzenie i konfiguracja mediatora (GoF: ConcreteMediator)
IAirTrafficMediator tower = new ControlTower();
tower.Register(runway1);
tower.Register(runway2);
tower.Register(plane1);
tower.Register(plane2);
tower.Register(plane3);
tower.Register(weather);

Console.WriteLine("── Symulacja ──\n");

// Samoloty komunikują się przez wieżę — nie znają pasów ani innych samolotów
plane1.RequestLanding();
plane2.RequestLanding();   // drugi samolot — wieża przydzieli wolny pas
plane3.RequestTakeoff();

Console.WriteLine("\nZmiana warunków pogodowych:");
weather.ReportWindSpeed(45); // silny wiatr — wieża reaguje

// =============================================================================
// GoF: Mediator (interfejs)
// =============================================================================

interface IAirTrafficMediator
{
    void Register(AirportComponent component);
    void Notify(AirportComponent sender, string @event, object? data = null);
}

// =============================================================================
// GoF: Colleague (klasa bazowa uczestnika)
// =============================================================================

abstract class AirportComponent(string name)
{
    public string Name => name;
    protected IAirTrafficMediator? Tower { get; private set; }

    // Uczestnik rejestruje się u mediatora
    public void SetMediator(IAirTrafficMediator mediator) => Tower = mediator;

    protected void NotifyTower(string @event, object? data = null)
        => Tower?.Notify(this, @event, data);
}

// =============================================================================
// GoF: ConcreteColleague — Samolot
// =============================================================================

class Aircraft(string callsign) : AirportComponent(callsign)
{
    public bool IsLanded   { get; private set; }
    public bool OnRunway   { get; private set; }
    private string? _assignedRunway;

    public void RequestLanding()
    {
        Console.WriteLine($"  [{Name}] Proszę o zezwolenie na lądowanie");
        NotifyTower("land_request");
    }

    public void RequestTakeoff()
    {
        Console.WriteLine($"  [{Name}] Proszę o zezwolenie na start");
        NotifyTower("takeoff_request");
    }

    // Reakcja na decyzję wieży — wywołana przez Mediatora
    public void ClearToLand(string runwayName)
    {
        _assignedRunway = runwayName;
        IsLanded = true;
        Console.WriteLine($"  [{Name}] ✔ Lądowanie na pasie {runwayName}");
    }

    public void HoldPosition()
        => Console.WriteLine($"  [{Name}] ⏳ Czekam na przydzielenie pasa");

    public void ClearForTakeoff(string runwayName)
        => Console.WriteLine($"  [{Name}] ✔ Start z pasa {runwayName}");

    public void GroundStop()
        => Console.WriteLine($"  [{Name}] ⛔ Zatrzymanie — warunki pogodowe");
}

// =============================================================================
// GoF: ConcreteColleague — Pas startowy
// =============================================================================

class Runway(string name) : AirportComponent(name)
{
    public bool IsOccupied { get; private set; }

    public void Occupy()
    {
        IsOccupied = true;
        Console.WriteLine($"  [Pas {Name}] zajęty");
        NotifyTower("runway_occupied");
    }

    public void Clear()
    {
        IsOccupied = false;
        Console.WriteLine($"  [Pas {Name}] wolny");
        NotifyTower("runway_clear");
    }
}

// =============================================================================
// GoF: ConcreteColleague — Stacja meteorologiczna
// =============================================================================

class WeatherStation : AirportComponent("MeteoStation")
{
    public int WindSpeedKmh { get; private set; }

    public void ReportWindSpeed(int kmh)
    {
        WindSpeedKmh = kmh;
        Console.WriteLine($"  [Meteo] Prędkość wiatru: {kmh} km/h");
        NotifyTower("wind_update", kmh);
    }
}

// =============================================================================
// GoF: ConcreteMediator — Wieża kontroli lotów
// =============================================================================

class ControlTower : IAirTrafficMediator
{
    private readonly List<Runway>  _runways  = [];
    private readonly List<Aircraft> _aircraft = [];
    private readonly Queue<Aircraft> _waitingForLanding  = new();
    private readonly Queue<Aircraft> _waitingForTakeoff  = new();
    private WeatherStation? _weather;

    public void Register(AirportComponent component)
    {
        component.SetMediator(this);
        switch (component)
        {
            case Runway r:   _runways.Add(r); break;
            case Aircraft a: _aircraft.Add(a); break;
            case WeatherStation w: _weather = w; break;
        }
    }

    // GoF: Notify — centralny punkt koordynacji
    public void Notify(AirportComponent sender, string @event, object? data = null)
    {
        Console.WriteLine($"  [Wieża] Zdarzenie: {sender.Name} → '{@event}'");

        switch (@event)
        {
            case "land_request":
                HandleLandRequest((Aircraft)sender);
                break;

            case "takeoff_request":
                HandleTakeoffRequest((Aircraft)sender);
                break;

            case "runway_clear":
                // Pas zwolniony — obsłuż kolejkę oczekujących
                if (_waitingForLanding.TryDequeue(out var waiting))
                    HandleLandRequest(waiting);
                break;

            case "wind_update" when data is int windSpeed && windSpeed > 40:
                // Silny wiatr — zatrzymaj wszystkie samoloty na ziemi
                Console.WriteLine($"  [Wieża] ⚠ Wiatr {windSpeed} km/h — zatrzymanie operacji");
                foreach (var plane in _aircraft.Where(a => !a.IsLanded))
                    plane.GroundStop();
                break;
        }
    }

    private void HandleLandRequest(Aircraft plane)
    {
        var freeRunway = _runways.FirstOrDefault(r => !r.IsOccupied);
        if (freeRunway != null)
        {
            freeRunway.Occupy();
            plane.ClearToLand(freeRunway.Name);
        }
        else
        {
            _waitingForLanding.Enqueue(plane);
            plane.HoldPosition();
        }
    }

    private void HandleTakeoffRequest(Aircraft plane)
    {
        var freeRunway = _runways.FirstOrDefault(r => !r.IsOccupied);
        if (freeRunway != null)
        {
            freeRunway.Occupy();
            plane.ClearForTakeoff(freeRunway.Name);
        }
        else
        {
            _waitingForTakeoff.Enqueue(plane);
            Console.WriteLine($"  [Wieża] {plane.Name} czeka na wolny pas do startu");
        }
    }
}
