using Examples;
using Xunit;

namespace Examples.Tests;

public class SeabirdTwoWayAdapterTests
{
    [Fact]
    public void Seabird_InitialState_DockedFlightTelemetry()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;

        var telemetry = aircraft.GetFlightTelemetry();

        Assert.Contains("DOCKED", telemetry);
    }

    [Fact]
    public void Seabird_InitialState_DockedSeaTelemetry()
    {
        var seabird = new Seabird();
        ISeacraft seacraft = seabird;

        var telemetry = seacraft.GetSeaTelemetry();

        Assert.Contains("DOCKED", telemetry);
    }

    [Fact]
    public void TakeOff_SetsAirMode_TelemetryShowsAltitude()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;

        aircraft.TakeOff(1500);
        var telemetry = aircraft.GetFlightTelemetry();

        Assert.Contains("AIR", telemetry);
        Assert.Contains("1500", telemetry);
    }

    [Fact]
    public void TakeOff_InvalidAltitude_Throws()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;

        Assert.Throws<InvalidVehicleStateException>(() => aircraft.TakeOff(0));
    }

    [Fact]
    public void Land_AfterTakeOff_ReturnsToDocked()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;

        aircraft.TakeOff(1000);
        aircraft.Land();
        var telemetry = aircraft.GetFlightTelemetry();

        Assert.Contains("DOCKED", telemetry);
    }

    [Fact]
    public void Land_WhenDocked_Throws()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;

        Assert.Throws<InvalidVehicleStateException>(() => aircraft.Land());
    }

    [Fact]
    public void Dive_SetsSubmergedMode_TelemetryShowsDepth()
    {
        var seabird = new Seabird();
        ISeacraft seacraft = seabird;

        seacraft.Dive(80);
        var telemetry = seacraft.GetSeaTelemetry();

        Assert.Contains("SUBMERGED", telemetry);
        Assert.Contains("80", telemetry);
    }

    [Fact]
    public void Dive_InvalidDepth_Throws()
    {
        var seabird = new Seabird();
        ISeacraft seacraft = seabird;

        Assert.Throws<InvalidVehicleStateException>(() => seacraft.Dive(0));
    }

    [Fact]
    public void Dive_WhileInAir_Throws()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;
        ISeacraft seacraft = seabird;

        aircraft.TakeOff(500);

        Assert.Throws<InvalidVehicleStateException>(() => seacraft.Dive(50));
    }

    [Fact]
    public void TakeOff_WhileSubmerged_Throws()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;
        ISeacraft seacraft = seabird;

        seacraft.Dive(100);

        Assert.Throws<InvalidVehicleStateException>(() => aircraft.TakeOff(500));
    }

    [Fact]
    public void Surface_AfterDive_SetsAtSeaMode()
    {
        var seabird = new Seabird();
        ISeacraft seacraft = seabird;

        seacraft.Dive(50);
        seacraft.Surface();
        var telemetry = seacraft.GetSeaTelemetry();

        Assert.Contains("SEA", telemetry);
    }

    [Fact]
    public void Surface_WhenNotSubmerged_Throws()
    {
        var seabird = new Seabird();
        ISeacraft seacraft = seabird;

        Assert.Throws<InvalidVehicleStateException>(() => seacraft.Surface());
    }

    [Fact]
    public void FullCycle_Air_Land_Dive_Surface()
    {
        var seabird = new Seabird();
        IAircraft aircraft = seabird;
        ISeacraft seacraft = seabird;

        aircraft.TakeOff(2000);
        Assert.Contains("AIR", aircraft.GetFlightTelemetry());

        aircraft.Land();
        Assert.Contains("DOCKED", aircraft.GetFlightTelemetry());

        seacraft.Dive(120);
        Assert.Contains("SUBMERGED", seacraft.GetSeaTelemetry());

        seacraft.Surface();
        Assert.Contains("SEA", seacraft.GetSeaTelemetry());
    }
}
