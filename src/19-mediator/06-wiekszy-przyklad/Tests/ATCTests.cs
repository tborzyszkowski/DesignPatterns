using Mediator.WiekszyPrzyklad;
using Xunit;

namespace Mediator.WiekszyPrzyklad.Tests;

public class ControlTowerTests
{
    private static ControlTower CreateTower(int runwayCount = 2)
    {
        var runways = Enumerable.Range(1, runwayCount)
            .Select(i => new Runway($"Pas 0{i}"))
            .ToArray();
        return new ControlTower(runways);
    }

    // -------------------------------------------------------------------------
    // Rejestracja
    // -------------------------------------------------------------------------

    [Fact]
    public void Register_SetsMediator_OnAircraft()
    {
        var tower = CreateTower();
        var plane = new TestAircraft("T001");

        tower.Register(plane);

        Assert.True(plane.HasTower);
    }

    // -------------------------------------------------------------------------
    // Prośba o lądowanie — wolny pas
    // -------------------------------------------------------------------------

    [Fact]
    public void RequestLanding_WhenRunwayFree_AssignsClearance()
    {
        var tower = CreateTower(1);
        var plane = new TestAircraft("LOT100");
        tower.Register(plane);

        plane.RequestLanding();

        Assert.Equal(FlightStatus.Landing, plane.Status);
        Assert.NotNull(plane.AssignedRunway);
    }

    [Fact]
    public void RequestLanding_WhenRunwayFree_RunwayBecomesOccupied()
    {
        var tower = CreateTower(1);
        var plane = new TestAircraft("LOT100");
        tower.Register(plane);

        plane.RequestLanding();

        var status = tower.GetRunwayStatus();
        Assert.True(status[0].IsOccupied);
        Assert.Equal("LOT100", status[0].CurrentAircraft);
    }

    // -------------------------------------------------------------------------
    // Kolejka lądowania
    // -------------------------------------------------------------------------

    [Fact]
    public void RequestLanding_WhenNoRunwayFree_AddsToQueue()
    {
        var tower = CreateTower(1);
        var plane1 = new TestAircraft("LOT101");
        var plane2 = new TestAircraft("LOT102");
        tower.Register(plane1);
        tower.Register(plane2);

        plane1.RequestLanding();  // zajmuje jedyny pas
        plane2.RequestLanding();  // powinien trafić do kolejki

        Assert.Equal(FlightStatus.Landing, plane1.Status);
        Assert.Equal(FlightStatus.WaitingForLanding, plane2.Status);
        Assert.True(plane2.ReceivedHoldPosition);
    }

    [Fact]
    public void ReportLanded_ReleasesRunway_AndServicesQueue()
    {
        var tower = CreateTower(1);
        var plane1 = new TestAircraft("LOT101");
        var plane2 = new TestAircraft("LOT102");
        tower.Register(plane1);
        tower.Register(plane2);

        plane1.RequestLanding();
        plane2.RequestLanding();  // w kolejce
        plane1.ReportLanded();    // zwalnia pas

        // plane2 powinien dostać pas
        Assert.Equal(FlightStatus.Landing, plane2.Status);
        Assert.NotNull(plane2.AssignedRunway);
    }

    // -------------------------------------------------------------------------
    // Prośba o start
    // -------------------------------------------------------------------------

    [Fact]
    public void RequestTakeoff_WhenRunwayFree_AssignsClearance()
    {
        var tower = CreateTower(1);
        var plane = new TestAircraft("LOT200");
        plane.ForcedStatus = FlightStatus.OnGround;
        tower.Register(plane);

        plane.RequestTakeoff();

        Assert.Equal(FlightStatus.TakingOff, plane.Status);
        Assert.NotNull(plane.AssignedRunway);
    }

    [Fact]
    public void RequestTakeoff_WhenRunwayOccupied_AddsToQueue()
    {
        var tower = CreateTower(1);
        var lander = new TestAircraft("LOT101");
        var departer = new TestAircraft("LOT201");
        departer.ForcedStatus = FlightStatus.OnGround;

        tower.Register(lander);
        tower.Register(departer);

        lander.RequestLanding();   // zajmuje pas
        departer.RequestTakeoff(); // powinien trafić do kolejki

        Assert.Equal(FlightStatus.WaitingForTakeoff, departer.Status);
        Assert.True(departer.ReceivedHoldPosition);
    }

    // -------------------------------------------------------------------------
    // Stan pasów
    // -------------------------------------------------------------------------

    [Fact]
    public void GetRunwayStatus_ReturnsAllRunways()
    {
        var tower = CreateTower(3);
        var statuses = tower.GetRunwayStatus();
        Assert.Equal(3, statuses.Count);
    }

    [Fact]
    public void GetRunwayStatus_AllFreeInitially()
    {
        var tower = CreateTower(2);
        var statuses = tower.GetRunwayStatus();
        Assert.All(statuses, s => Assert.False(s.IsOccupied));
    }

    // -------------------------------------------------------------------------
    // Priorytety
    // -------------------------------------------------------------------------

    [Fact]
    public void CommercialFlight_WithLargeCapacity_HasPriority()
    {
        var flight = new CommercialFlight("LOT300", 250);
        Assert.True(flight.HasPriority);
    }

    [Fact]
    public void CommercialFlight_WithSmallCapacity_HasNoPriority()
    {
        var flight = new CommercialFlight("LOT300", 100);
        Assert.False(flight.HasPriority);
    }

    // -------------------------------------------------------------------------
    // FlightStatus transitions
    // -------------------------------------------------------------------------

    [Fact]
    public void RequestLanding_ChangesStatus_ToWaitingForLanding_ThenLanding()
    {
        var tower = CreateTower(1);
        var plane = new TestAircraft("LOT400");
        tower.Register(plane);

        // Before request — Airborne
        Assert.Equal(FlightStatus.Airborne, plane.Status);

        plane.RequestLanding();

        // After assignment — Landing
        Assert.Equal(FlightStatus.Landing, plane.Status);
    }

    [Fact]
    public void ReportLanded_SetsStatus_OnGround()
    {
        var tower = CreateTower(1);
        var plane = new TestAircraft("LOT500");
        tower.Register(plane);

        plane.RequestLanding();
        plane.ReportLanded();

        Assert.Equal(FlightStatus.OnGround, plane.Status);
    }

    [Fact]
    public void ReportAirborne_SetsStatus_Airborne_AndClearsRunway()
    {
        var tower = CreateTower(1);
        var plane = new TestAircraft("LOT600");
        plane.ForcedStatus = FlightStatus.OnGround;
        tower.Register(plane);

        plane.RequestTakeoff();
        plane.ReportAirborne();

        Assert.Equal(FlightStatus.Airborne, plane.Status);
        Assert.All(tower.GetRunwayStatus(), s => Assert.False(s.IsOccupied));
    }

    // -------------------------------------------------------------------------
    // Wielu samolotów — dwa pasy
    // -------------------------------------------------------------------------

    [Fact]
    public void TwoAircraft_TwoRunways_BothLandSimultaneously()
    {
        var tower = CreateTower(2);
        var p1 = new TestAircraft("P1");
        var p2 = new TestAircraft("P2");
        tower.Register(p1);
        tower.Register(p2);

        p1.RequestLanding();
        p2.RequestLanding();

        Assert.Equal(FlightStatus.Landing, p1.Status);
        Assert.Equal(FlightStatus.Landing, p2.Status);
        Assert.All(tower.GetRunwayStatus(), s => Assert.True(s.IsOccupied));
    }
}

// =============================================================================
// TEST DOUBLE — TestAircraft
// =============================================================================

class TestAircraft(string callSign) : Aircraft(callSign)
{
    public bool HasTower => Tower is not null;
    public bool ReceivedHoldPosition { get; private set; }
    public FlightStatus ForcedStatus { set => Status = value; }

    protected override void OnLandingClearance(string runway) { }
    protected override void OnTakeoffClearance(string runway) { }
    protected override void OnHoldPosition(string reason) => ReceivedHoldPosition = true;
}
