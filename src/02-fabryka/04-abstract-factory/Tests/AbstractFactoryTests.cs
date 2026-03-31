using AbstractFactory.Pizza;
using AbstractFactory.Computers;
using Xunit;

namespace AbstractFactory.Tests;

// =====================================================================
// Testy: Pizza Ingredient Factories
// =====================================================================

public class PizzaIngredientFactoryTests
{
    [Fact]
    public void NYFactory_CreateDough_ReturnsThinCrust()
    {
        IPizzaIngredientFactory factory = new NYPizzaIngredientFactory();
        var dough = factory.CreateDough();

        Assert.IsType<ThinCrustDough>(dough);
        Assert.Contains("NY", dough.Description);
    }

    [Fact]
    public void NYFactory_CreateSauce_ReturnsMarinara()
    {
        IPizzaIngredientFactory factory = new NYPizzaIngredientFactory();
        var sauce = factory.CreateSauce();

        Assert.IsType<MarinaraSauce>(sauce);
    }

    [Fact]
    public void NYFactory_CreateCheese_ReturnsReggiano()
    {
        IPizzaIngredientFactory factory = new NYPizzaIngredientFactory();
        var cheese = factory.CreateCheese();

        Assert.IsType<ReggianoCheese>(cheese);
    }

    [Fact]
    public void NYFactory_CreateClams_ReturnsFresh()
    {
        IPizzaIngredientFactory factory = new NYPizzaIngredientFactory();
        var clams = factory.CreateClams();

        Assert.IsType<FreshClams>(clams);
        Assert.Contains("Fresh", clams.Description);
    }

    [Fact]
    public void ChicagoFactory_CreateDough_ReturnsThickCrust()
    {
        IPizzaIngredientFactory factory = new ChicagoPizzaIngredientFactory();
        var dough = factory.CreateDough();

        Assert.IsType<ThickCrustDough>(dough);
        Assert.Contains("CHI", dough.Description);
    }

    [Fact]
    public void ChicagoFactory_CreateSauce_ReturnsPlumTomato()
    {
        IPizzaIngredientFactory factory = new ChicagoPizzaIngredientFactory();
        Assert.IsType<PlumTomatoSauce>(factory.CreateSauce());
    }

    [Fact]
    public void ChicagoFactory_CreateCheese_ReturnsMozzarella()
    {
        IPizzaIngredientFactory factory = new ChicagoPizzaIngredientFactory();
        Assert.IsType<MozzarellaCheese>(factory.CreateCheese());
    }

    [Fact]
    public void ChicagoFactory_CreateClams_ReturnsFrozen()
    {
        IPizzaIngredientFactory factory = new ChicagoPizzaIngredientFactory();
        var clams = factory.CreateClams();

        Assert.IsType<FrozenClams>(clams);
        Assert.Contains("Frozen", clams.Description);
    }

    [Fact]
    public void NYvsChicago_DifferentIngredientFamilies()
    {
        IPizzaIngredientFactory ny = new NYPizzaIngredientFactory();
        IPizzaIngredientFactory chi = new ChicagoPizzaIngredientFactory();

        Assert.NotEqual(ny.CreateDough().GetType(), chi.CreateDough().GetType());
        Assert.NotEqual(ny.CreateSauce().GetType(), chi.CreateSauce().GetType());
        Assert.NotEqual(ny.CreateCheese().GetType(), chi.CreateCheese().GetType());
        Assert.NotEqual(ny.CreateClams().GetType(), chi.CreateClams().GetType());
    }
}

// =====================================================================
// Testy: PizzaStore z Abstract Factory
// =====================================================================

public class PizzaStoreTests
{
    [Fact]
    public void NYPizzaStore_OrderCheese_ReturnsNYStylePizza()
    {
        PizzaStore store = new NYPizzaStore();
        var pizza = store.OrderPizza("cheese");

        Assert.NotNull(pizza);
        Assert.Contains("New York", pizza.Name);
    }

    [Fact]
    public void ChicagoPizzaStore_OrderCheese_ReturnsChicagoStylePizza()
    {
        PizzaStore store = new ChicagoPizzaStore();
        var pizza = store.OrderPizza("cheese");

        Assert.NotNull(pizza);
        Assert.Contains("Chicago", pizza.Name);
    }

    [Fact]
    public void NYPizzaStore_OrderClam_ReturnsNYClamPizza()
    {
        PizzaStore store = new NYPizzaStore();
        var pizza = store.OrderPizza("clam");

        Assert.IsType<ClamPizza>(pizza);
        Assert.Contains("New York", pizza.Name);
    }

    [Fact]
    public void ChicagoPizzaStore_UnknownType_Throws()
    {
        PizzaStore store = new ChicagoPizzaStore();
        Assert.Throws<ArgumentException>(() => store.OrderPizza("veggie"));
    }
}

// =====================================================================
// Testy: Computer Abstract Factory
// =====================================================================

public class ComputerFactoryTests
{
    [Fact]
    public void DellFactory_CreatesConsistentFamily()
    {
        IComputerFactory factory = new DellComputerFactory();

        Assert.Equal("Dell", factory.CreateGamingPC().Brand);
        Assert.Equal("Dell", factory.CreateWorkStation().Brand);
        Assert.Equal("Dell", factory.CreateLaptop().Brand);
    }

    [Fact]
    public void HpFactory_CreatesConsistentFamily()
    {
        IComputerFactory factory = new HpComputerFactory();

        Assert.Equal("HP", factory.CreateGamingPC().Brand);
        Assert.Equal("HP", factory.CreateWorkStation().Brand);
        Assert.Equal("HP", factory.CreateLaptop().Brand);
    }

    [Fact]
    public void DellGamingPC_HasRTX5090()
    {
        IComputerFactory factory = new DellComputerFactory();
        Assert.Equal("RTX 5090", factory.CreateGamingPC().GPU);
    }

    [Fact]
    public void HpWorkStation_HasThreadripper()
    {
        IComputerFactory factory = new HpComputerFactory();
        Assert.Contains("Threadripper", factory.CreateWorkStation().CPU);
    }

    [Fact]
    public void DellLaptop_HasOLEDScreen()
    {
        IComputerFactory factory = new DellComputerFactory();
        Assert.Contains("OLED", factory.CreateLaptop().Screen);
    }

    [Fact]
    public void Office_UsesInjectedFactory()
    {
        IComputerFactory factory = new HpComputerFactory();
        var office = new Office(factory);

        // Jeśli się skompiluje i nie rzuci wyjątku — klient operuje na abstrakcji
        office.SetupAllEquipment();
        office.SetupDeveloperWorkplace();
        office.SetupGameRoom();
    }
}
