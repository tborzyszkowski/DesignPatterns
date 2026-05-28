// =============================================================================
// Wzorzec Mediator — Kontrola Ruchu Lotniczego
// Library: core types and logic
// =============================================================================

namespace Mediator.WiekszyPrzyklad;

// =============================================================================
// MEDIATOR: interfejs
// =============================================================================

public interface IAirTrafficControl
{
    void Register(Aircraft aircraft);
    void RequestLanding(Aircraft aircraft);
    void RequestTakeoff(Aircraft aircraft);
    void ReportLanded(Aircraft aircraft);
    void ReportAirborne(Aircraft aircraft);
    IReadOnlyList<RunwayStatus> GetRunwayStatus();
}

// =============================================================================
// COLLEAGUE: abstrakcja uczestnika
// =============================================================================

public abstract class Aircraft(string callSign)
{
    public string CallSign => callSign;
    public FlightStatus Status { get; protected set; } = FlightStatus.Airborne;
    public string? AssignedRunway { get; private set; }

    protected IAirTrafficControl? Tower;

    public void SetTower(IAirTrafficControl tower) => Tower = tower;

    public virtual void RequestLanding()
    {
        Status = FlightStatus.WaitingForLanding;
        Tower?.RequestLanding(this);
    }

    public virtual void RequestTakeoff()
    {
        Status = FlightStatus.WaitingForTakeoff;
        Tower?.RequestTakeoff(this);
    }

    // Wywołana przez Wieżę — zezwolenie na lądowanie
    public void ReceiveLandingClearance(string runwayName)
    {
        AssignedRunway = runwayName;
        Status = FlightStatus.Landing;
        OnLandingClearance(runwayName);
    }

    // Wywołana przez Wieżę — zezwolenie na start
    public void ReceiveTakeoffClearance(string runwayName)
    {
        AssignedRunway = runwayName;
        Status = FlightStatus.TakingOff;
        OnTakeoffClearance(runwayName);
    }

    // Wywołana przez Wieżę — czekaj
    public void HoldPosition(string reason)
    {
        OnHoldPosition(reason);
    }

    // Pilot zgłasza wylądowanie
    public void ReportLanded()
    {
        Status = FlightStatus.OnGround;
        AssignedRunway = null;
        Tower?.ReportLanded(this);
    }

    // Pilot zgłasza wzniesienie
    public void ReportAirborne()
    {
        Status = FlightStatus.Airborne;
        AssignedRunway = null;
        Tower?.ReportAirborne(this);
    }

    protected abstract void OnLandingClearance(string runway);
    protected abstract void OnTakeoffClearance(string runway);
    protected abstract void OnHoldPosition(string reason);
}

// =============================================================================
// CONCRETE COLLEAGUES
// =============================================================================

public class CommercialFlight(string callSign, int capacity) : Aircraft(callSign)
{
    public int Capacity => capacity;

    // Samoloty komercyjne mają priorytet przy > 200 pasażerów
    public bool HasPriority => capacity > 200;

    protected override void OnLandingClearance(string runway)
        => Console.WriteLine($"  [{CallSign}] ✔ Lądowanie na pasie {runway}" +
                             (HasPriority ? " (priorytet)" : ""));

    protected override void OnTakeoffClearance(string runway)
        => Console.WriteLine($"  [{CallSign}] ✔ Start z pasa {runway}");

    protected override void OnHoldPosition(string reason)
        => Console.WriteLine($"  [{CallSign}] ⏳ Utrzymuję pozycję: {reason}");
}

public class PrivatePlane(string callSign) : Aircraft(callSign)
{
    protected override void OnLandingClearance(string runway)
        => Console.WriteLine($"  [{CallSign}] ✔ Prywatny — lądowanie pas {runway}");

    protected override void OnTakeoffClearance(string runway)
        => Console.WriteLine($"  [{CallSign}] ✔ Prywatny — start z pasa {runway}");

    protected override void OnHoldPosition(string reason)
        => Console.WriteLine($"  [{CallSign}] ⏳ Czekam: {reason}");
}

// =============================================================================
// INFRASTRUKTURA: Pas startowy
// =============================================================================

public class Runway(string name)
{
    public string Name => name;
    public bool IsOccupied { get; private set; }
    public string? CurrentAircraft { get; private set; }

    public void Occupy(string callSign)
    {
        IsOccupied = true;
        CurrentAircraft = callSign;
    }

    public void Clear()
    {
        IsOccupied = false;
        CurrentAircraft = null;
    }
}

// =============================================================================
// CONCRETE MEDIATOR: Wieża kontroli
// =============================================================================

public class ControlTower(params Runway[] runways) : IAirTrafficControl
{
    private readonly List<Runway>   _runways    = [.. runways];
    private readonly List<Aircraft> _registered = [];
    private readonly Queue<Aircraft> _landingQueue  = new();
    private readonly Queue<Aircraft> _takeoffQueue  = new();

    public void Register(Aircraft aircraft)
    {
        _registered.Add(aircraft);
        aircraft.SetTower(this);
        Console.WriteLine($"  [Wieża] Zarejestrowano: {aircraft.CallSign}");
    }

    public void RequestLanding(Aircraft aircraft)
    {
        Console.WriteLine($"  [Wieża] Prośba o lądowanie: {aircraft.CallSign}");

        // Priorytet dla dużych samolotów komercyjnych
        if (aircraft is CommercialFlight { HasPriority: true })
            TryAssignRunway(aircraft, isLanding: true, priority: true);
        else
            TryAssignRunway(aircraft, isLanding: true, priority: false);
    }

    public void RequestTakeoff(Aircraft aircraft)
    {
        Console.WriteLine($"  [Wieża] Prośba o start: {aircraft.CallSign}");
        TryAssignRunway(aircraft, isLanding: false, priority: false);
    }

    public void ReportLanded(Aircraft aircraft)
    {
        Console.WriteLine($"  [Wieża] {aircraft.CallSign} wylądował");
        // Zwolnij pas i obsłuż kolejkę
        var runway = _runways.FirstOrDefault(r => r.CurrentAircraft == aircraft.CallSign);
        runway?.Clear();
        Console.WriteLine($"  [Wieża] Pas {runway?.Name} zwolniony");
        TryProcessQueues();
    }

    public void ReportAirborne(Aircraft aircraft)
    {
        Console.WriteLine($"  [Wieża] {aircraft.CallSign} wznosi się");
        var runway = _runways.FirstOrDefault(r => r.CurrentAircraft == aircraft.CallSign);
        runway?.Clear();
        TryProcessQueues();
    }

    public IReadOnlyList<RunwayStatus> GetRunwayStatus()
        => _runways.Select(r => new RunwayStatus(r.Name, r.IsOccupied, r.CurrentAircraft)).ToList();

    private void TryAssignRunway(Aircraft aircraft, bool isLanding, bool priority)
    {
        Runway? freeRunway;

        if (priority)
        {
            // Priorytet — szukamy pasa z tyłu (bliższy krótszej drogi kołowania)
            freeRunway = _runways.LastOrDefault(r => !r.IsOccupied);
        }
        else
        {
            freeRunway = _runways.FirstOrDefault(r => !r.IsOccupied);
        }

        if (freeRunway is not null)
        {
            freeRunway.Occupy(aircraft.CallSign);
            if (isLanding)
                aircraft.ReceiveLandingClearance(freeRunway.Name);
            else
                aircraft.ReceiveTakeoffClearance(freeRunway.Name);
        }
        else
        {
            if (isLanding)
            {
                _landingQueue.Enqueue(aircraft);
                aircraft.HoldPosition("Brak wolnego pasa — kolejka");
            }
            else
            {
                _takeoffQueue.Enqueue(aircraft);
                aircraft.HoldPosition("Brak wolnego pasa do startu");
            }
        }
    }

    private void TryProcessQueues()
    {
        // Obsługa kolejki lądowania
        while (_landingQueue.TryPeek(out var next) && _runways.Any(r => !r.IsOccupied))
        {
            _landingQueue.Dequeue();
            TryAssignRunway(next, isLanding: true, priority: false);
        }

        // Obsługa kolejki startowania
        while (_takeoffQueue.TryPeek(out var next) && _runways.Any(r => !r.IsOccupied))
        {
            _takeoffQueue.Dequeue();
            TryAssignRunway(next, isLanding: false, priority: false);
        }
    }
}

// =============================================================================
// TYPY POMOCNICZE
// =============================================================================

public enum FlightStatus
{
    Airborne,
    WaitingForLanding,
    Landing,
    OnGround,
    WaitingForTakeoff,
    TakingOff
}

public record RunwayStatus(string RunwayName, bool IsOccupied, string? CurrentAircraft);
