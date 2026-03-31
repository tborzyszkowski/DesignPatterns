using StrukturaGoF.Vehicles;
using Xunit;

namespace Examples.Tests;

public class VehicleTests
{
    [Fact]
    public void Vehicle_Indexer_SetsAndGetsValue()
    {
        var vehicle = new Vehicle("Test");

        vehicle["engine"] = "V8";

        Assert.Equal("V8", vehicle["engine"]);
    }

    [Fact]
    public void Vehicle_Indexer_MissingKey_ReturnsBrak()
    {
        var vehicle = new Vehicle("Test");

        Assert.Equal("(brak)", vehicle["missing"]);
    }
}

public class CarBuilderTests
{
    [Fact]
    public void Construct_BuildsCompleteCar()
    {
        var shop = new Shop();
        var builder = new CarBuilder();

        shop.Construct(builder);
        var car = builder.GetVehicle();

        Assert.Contains("Steel Unibody", car["frame"]);
        Assert.Contains("2.0T", car["engine"]);
        Assert.Contains("4 ×", car["wheels"]);
        Assert.Equal("4", car["doors"]);
    }
}

public class ScooterBuilderTests
{
    [Fact]
    public void Construct_BuildsCompleteScooter()
    {
        var shop = new Shop();
        var builder = new ScooterBuilder();

        shop.Construct(builder);
        var scooter = builder.GetVehicle();

        Assert.Contains("Monocoque", scooter["frame"]);
        Assert.Contains("125 cc", scooter["engine"]);
        Assert.Equal("0", scooter["doors"]);
    }
}

public class MotorCycleBuilderTests
{
    [Fact]
    public void Construct_BuildsCompleteMotorCycle()
    {
        var shop = new Shop();
        var builder = new MotorCycleBuilder();

        shop.Construct(builder);
        var moto = builder.GetVehicle();

        Assert.Contains("Trellis", moto["frame"]);
        Assert.Contains("650 cc", moto["engine"]);
        Assert.Equal("0", moto["doors"]);
    }
}

public class ShopTests
{
    [Fact]
    public void Construct_CallsAllBuildSteps()
    {
        var builder = new CarBuilder();
        var shop = new Shop();

        shop.Construct(builder);
        var vehicle = builder.GetVehicle();

        Assert.NotEqual("(brak)", vehicle["frame"]);
        Assert.NotEqual("(brak)", vehicle["engine"]);
        Assert.NotEqual("(brak)", vehicle["wheels"]);
        Assert.NotEqual("(brak)", vehicle["doors"]);
    }

    [Fact]
    public void PartialBuild_WithoutDirector_HasMissingParts()
    {
        var builder = new CarBuilder();

        builder.BuildFrame();
        builder.BuildDoors();
        var vehicle = builder.GetVehicle();

        Assert.NotEqual("(brak)", vehicle["frame"]);
        Assert.NotEqual("(brak)", vehicle["doors"]);
        Assert.Equal("(brak)", vehicle["engine"]);
        Assert.Equal("(brak)", vehicle["wheels"]);
    }
}
