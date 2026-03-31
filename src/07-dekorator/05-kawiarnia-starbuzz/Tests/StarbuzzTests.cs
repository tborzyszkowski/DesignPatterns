using Examples;
using Xunit;

public class StarbuzzTests
{
    [Fact]
    public void Espresso_Cost_Returns7_50()
    {
        Beverage b = new Espresso();

        Assert.Equal(7.50m, b.Cost());
    }

    [Fact]
    public void HouseBlend_Cost_Returns6_00()
    {
        Beverage b = new HouseBlend();

        Assert.Equal(6.00m, b.Cost());
    }

    [Fact]
    public void Mocha_AddsCostToBase()
    {
        Beverage b = new Mocha(new Espresso());

        Assert.Equal(7.50m + 1.20m, b.Cost());
    }

    [Fact]
    public void Soy_AddsCostToBase()
    {
        Beverage b = new Soy(new Espresso());

        Assert.Equal(7.50m + 0.80m, b.Cost());
    }

    [Fact]
    public void Whip_AddsCostToBase()
    {
        Beverage b = new Whip(new Espresso());

        Assert.Equal(7.50m + 0.60m, b.Cost());
    }

    [Fact]
    public void Stacked_Whip_Mocha_Soy_HouseBlend_CorrectCost()
    {
        Beverage b = new Whip(new Mocha(new Soy(new HouseBlend())));

        Assert.Equal(6.00m + 0.80m + 1.20m + 0.60m, b.Cost());
    }

    [Fact]
    public void Stacked_Description_ContainsAllCondiments()
    {
        Beverage b = new Whip(new Mocha(new Soy(new HouseBlend())));

        Assert.Contains("Mocha", b.Description);
        Assert.Contains("Soy", b.Description);
        Assert.Contains("Whip", b.Description);
        Assert.Contains("House Blend", b.Description);
    }

    [Fact]
    public void Espresso_Description_IsEspresso()
    {
        Beverage b = new Espresso();

        Assert.Equal("Espresso", b.Description);
    }
}
