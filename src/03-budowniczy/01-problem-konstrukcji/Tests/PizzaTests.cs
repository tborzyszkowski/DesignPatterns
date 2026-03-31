using ProblemKonstrukcji;
using Xunit;

namespace Examples.Tests;

public class PizzaTelescopingTests
{
    [Fact]
    public void Constructor_MinimalParameters_SetsDefaults()
    {
        var pizza = new PizzaTelescoping("small");

        Assert.Equal("small", pizza.Size);
        Assert.False(pizza.Cheese);
        Assert.False(pizza.Pepperoni);
        Assert.False(pizza.Bacon);
    }

    [Fact]
    public void Constructor_AllParameters_SetsAll()
    {
        var pizza = new PizzaTelescoping("large", true, true, true, true, true);

        Assert.True(pizza.Cheese);
        Assert.True(pizza.Pepperoni);
        Assert.True(pizza.Bacon);
        Assert.True(pizza.Mushrooms);
        Assert.True(pizza.Onions);
    }
}

public class PizzaMutableTests
{
    [Fact]
    public void Properties_CanBeModifiedAfterCreation()
    {
        var pizza = new PizzaMutable { Size = "small", Cheese = true };

        pizza.Bacon = true;

        Assert.True(pizza.Bacon);
    }
}

public class PizzaBuilderTests
{
    [Fact]
    public void Build_MinimalPizza_HasSizeOnly()
    {
        var pizza = new Pizza.Builder("medium").Build();

        Assert.Equal("medium", pizza.Size);
        Assert.False(pizza.Cheese);
        Assert.False(pizza.Pepperoni);
    }

    [Fact]
    public void Build_WithToppings_SetsAllFlags()
    {
        var pizza = new Pizza.Builder("large")
            .WithCheese()
            .WithBacon()
            .WithMushrooms()
            .Build();

        Assert.True(pizza.Cheese);
        Assert.True(pizza.Bacon);
        Assert.True(pizza.Mushrooms);
        Assert.False(pizza.Pepperoni);
        Assert.False(pizza.Onions);
    }

    [Fact]
    public void Build_AllToppings()
    {
        var pizza = new Pizza.Builder("large")
            .WithCheese()
            .WithPepperoni()
            .WithBacon()
            .WithMushrooms()
            .WithOnions()
            .Build();

        Assert.True(pizza.Cheese);
        Assert.True(pizza.Pepperoni);
        Assert.True(pizza.Bacon);
        Assert.True(pizza.Mushrooms);
        Assert.True(pizza.Onions);
    }

    [Fact]
    public void Builder_EmptySize_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Pizza.Builder(""));
    }

    [Fact]
    public void Builder_WhitespaceSize_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Pizza.Builder("   "));
    }

    [Fact]
    public void ToString_IncludesToppings()
    {
        var pizza = new Pizza.Builder("small").WithCheese().WithOnions().Build();

        var result = pizza.ToString();

        Assert.Contains("small", result);
        Assert.Contains("+cheese", result);
        Assert.Contains("+onions", result);
        Assert.DoesNotContain("+bacon", result);
    }
}
