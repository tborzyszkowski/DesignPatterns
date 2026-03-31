using FactoryMethod.Pizza;
using FactoryMethod.Computers;
using Xunit;

namespace FactoryMethod.Tests;

// =====================================================================
// Testy: PizzaStore — NY i Chicago
// =====================================================================

public class PizzaStoreTests
{
    [Theory]
    [InlineData("cheese", "NY Style Sauce and Cheese Pizza")]
    [InlineData("pepperoni", "NY Style Pepperoni Pizza")]
    [InlineData("veggie", "NY Style Veggie Pizza")]
    public void NYPizzaStore_OrderPizza_ReturnsNYStylePizza(string type, string expectedName)
    {
        PizzaStore store = new NYPizzaStore();
        var pizza = store.OrderPizza(type);

        Assert.NotNull(pizza);
        Assert.Equal(expectedName, pizza.Name);
    }

    [Theory]
    [InlineData("cheese", "Chicago Style Deep Dish Cheese Pizza")]
    [InlineData("pepperoni", "Chicago Style Pepperoni Pizza")]
    public void ChicagoPizzaStore_OrderPizza_ReturnsChicagoStylePizza(string type, string expectedName)
    {
        PizzaStore store = new ChicagoPizzaStore();
        var pizza = store.OrderPizza(type);

        Assert.NotNull(pizza);
        Assert.Equal(expectedName, pizza.Name);
    }

    [Fact]
    public void NYPizzaStore_UnknownType_Throws()
    {
        PizzaStore store = new NYPizzaStore();
        Assert.Throws<ArgumentException>(() => store.OrderPizza("buffalo"));
    }

    [Fact]
    public void ChicagoPizzaStore_UnknownType_Throws()
    {
        PizzaStore store = new ChicagoPizzaStore();
        Assert.Throws<ArgumentException>(() => store.OrderPizza("veggie"));
    }

    [Fact]
    public void NYCheesePizza_HasThinCrustDough()
    {
        var pizza = new NYStyleCheesePizza();
        Assert.Equal("Thin Crust Dough", pizza.Dough);
        Assert.Equal("Marinara Sauce", pizza.Sauce);
    }

    [Fact]
    public void ChicagoCheesePizza_HasExtraThickCrustDough()
    {
        var pizza = new ChicagoStyleCheesePizza();
        Assert.Equal("Extra Thick Crust Dough", pizza.Dough);
        Assert.Equal("Plum Tomato Sauce", pizza.Sauce);
    }

    [Fact]
    public void SameType_DifferentStores_CreateDifferentPizzas()
    {
        PizzaStore ny = new NYPizzaStore();
        PizzaStore chi = new ChicagoPizzaStore();

        var nyPizza = ny.OrderPizza("cheese");
        var chiPizza = chi.OrderPizza("cheese");

        Assert.NotEqual(nyPizza.Name, chiPizza.Name);
        Assert.NotEqual(nyPizza.Dough, chiPizza.Dough);
    }
}

// =====================================================================
// Testy: ComputerFactory — Dell i HP
// =====================================================================

public class ComputerFactoryTests
{
    [Fact]
    public void DellFactory_CreateGamingPC_ReturnsDellGamingPC()
    {
        ComputerFactory factory = new DellComputerFactory();
        var pc = factory.CreateGamingPC();

        Assert.IsType<DellGamingPC>(pc);
        Assert.Equal("Dell", pc.Brand);
        Assert.Equal("RTX 5090", pc.GPU);
    }

    [Fact]
    public void DellFactory_CreateWorkStation_ReturnsDellWorkStation()
    {
        ComputerFactory factory = new DellComputerFactory();
        var ws = factory.CreateWorkStation();

        Assert.IsType<DellWorkStation>(ws);
        Assert.Equal("Dell", ws.Brand);
        Assert.Equal("Xeon W-2400", ws.CPU);
    }

    [Fact]
    public void HpFactory_CreateGamingPC_ReturnsHpGamingPC()
    {
        ComputerFactory factory = new HpComputerFactory();
        var pc = factory.CreateGamingPC();

        Assert.IsType<HpGamingPC>(pc);
        Assert.Equal("HP", pc.Brand);
    }

    [Fact]
    public void HpFactory_CreateWorkStation_ReturnsHpWorkStation()
    {
        ComputerFactory factory = new HpComputerFactory();
        var ws = factory.CreateWorkStation();

        Assert.IsType<HpWorkStation>(ws);
        Assert.Equal("HP", ws.Brand);
    }

    [Fact]
    public void ComputerStore_UsesInjectedFactory()
    {
        // Potwierdza, że ComputerStore operuje na abstrakcji — nie zna konkretnych klas
        ComputerFactory factory = new DellComputerFactory();
        var store = new ComputerStore(factory);

        // Jeśli się skompiluje i nie rzuci wyjątku — OCP działa
        store.ConfigureWorkplace();
    }
}
