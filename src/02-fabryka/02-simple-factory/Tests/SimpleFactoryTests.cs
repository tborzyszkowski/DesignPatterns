using SimpleFactory;
using SimpleFactory.Notifications;
using Xunit;

namespace SimpleFactory.Tests;

// =====================================================================
// Testy: SimplePizzaFactory
// =====================================================================

public class PizzaFactoryTests
{
    private readonly SimplePizzaFactory _factory = new();

    [Theory]
    [InlineData("cheese", "Margherita")]
    [InlineData("pepperoni", "Pepperoni")]
    [InlineData("veggie", "Wegetariańska")]
    [InlineData("clam", "Clam")]
    public void CreatePizza_KnownType_ReturnsCorrectPizza(string type, string expectedName)
    {
        var pizza = _factory.CreatePizza(type);

        Assert.NotNull(pizza);
        Assert.Equal(expectedName, pizza!.Name);
    }

    [Fact]
    public void CreatePizza_UnknownType_ReturnsNull()
    {
        Assert.Null(_factory.CreatePizza("hawaii"));
    }

    [Fact]
    public void CheesePizza_HasCorrectIngredients()
    {
        var pizza = new CheesePizza();
        Assert.Equal("cienkie ciasto", pizza.Dough);
        Assert.Equal("sos pomidorowy", pizza.Sauce);
        Assert.Contains("mozzarella", pizza.Toppings);
    }

    [Fact]
    public void PepperoniPizza_HasCorrectIngredients()
    {
        var pizza = new PepperoniPizza();
        Assert.Equal("grube ciasto", pizza.Dough);
        Assert.Contains("pepperoni", pizza.Toppings);
    }

    [Fact]
    public void VeggiePizza_HasMultipleToppings()
    {
        var pizza = new VeggiePizza();
        Assert.True(pizza.Toppings.Count >= 4);
    }
}

// =====================================================================
// Testy: PizzaStore
// =====================================================================

public class PizzaStoreTests
{
    [Fact]
    public void OrderPizza_KnownType_ReturnsPizza()
    {
        var store = new PizzaStore(new SimplePizzaFactory());
        var pizza = store.OrderPizza("cheese");

        Assert.NotNull(pizza);
        Assert.Equal("Margherita", pizza!.Name);
    }

    [Fact]
    public void OrderPizza_UnknownType_ReturnsNull()
    {
        var store = new PizzaStore(new SimplePizzaFactory());
        Assert.Null(store.OrderPizza("buffalo"));
    }
}

// =====================================================================
// Testy: NotificationFactory
// =====================================================================

public class NotificationFactoryTests
{
    private readonly NotificationFactory _factory = new();

    [Theory]
    [InlineData("email", "Email")]
    [InlineData("sms", "SMS")]
    [InlineData("push", "Push")]
    [InlineData("slack", "Slack")]
    public void Create_KnownChannel_ReturnsCorrectType(string channel, string expectedChannel)
    {
        var notification = _factory.Create(channel);

        Assert.NotNull(notification);
        Assert.Equal(expectedChannel, notification.Channel);
    }

    [Fact]
    public void Create_UnknownChannel_Throws()
    {
        Assert.Throws<ArgumentException>(() => _factory.Create("fax"));
    }

    [Fact]
    public void Create_IsCaseInsensitive()
    {
        var notification = _factory.Create("EMAIL");
        Assert.Equal("Email", notification.Channel);
    }

    [Fact]
    public void EmailNotification_ImplementsINotification()
    {
        INotification notification = new EmailNotification();
        Assert.IsAssignableFrom<INotification>(notification);
    }
}
