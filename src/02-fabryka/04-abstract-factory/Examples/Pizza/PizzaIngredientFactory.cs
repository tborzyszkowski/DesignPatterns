namespace AbstractFactory.Pizza;

// =====================================================================
// FABRYKA ABSTRAKCYJNA — składniki pizzy (Head First Design Patterns)
// =====================================================================

// ----- Produkty abstrakcyjne (Abstract Products) ---------------------

public interface IDough  { string Description { get; } }
public interface ISauce  { string Description { get; } }
public interface ICheese { string Description { get; } }
public interface IClams  { string Description { get; } }

// NY — rodzina składników
public class ThinCrustDough   : IDough  { public string Description => "Thin Crust Dough (NY)"; }
public class MarinaraSauce    : ISauce  { public string Description => "Marinara Sauce (NY)"; }
public class ReggianoCheese   : ICheese { public string Description => "Reggiano Cheese (NY)"; }
public class FreshClams       : IClams  { public string Description => "Fresh Clams from Long Island Sound"; }

// Chicago — rodzina składników
public class ThickCrustDough  : IDough  { public string Description => "ThickCrust style extra thick (CHI)"; }
public class PlumTomatoSauce  : ISauce  { public string Description => "Tomato sauce with plum tomatoes (CHI)"; }
public class MozzarellaCheese : ICheese { public string Description => "Shredded Mozzarella (CHI)"; }
public class FrozenClams      : IClams  { public string Description => "Frozen Clams from Chesapeake Bay (CHI)"; }

// ----- Fabryka Abstrakcyjna (AbstractFactory) ------------------------

/// <summary>
/// AbstractFactory — kontrakt całej rodziny produktów.
/// Jedna implementacja = jeden "styl" pizzy.
/// </summary>
public interface IPizzaIngredientFactory
{
    IDough  CreateDough();
    ISauce  CreateSauce();
    ICheese CreateCheese();
    IClams  CreateClams();
}

// ----- Fabryki konkretne (ConcreteFactories) -------------------------

public class NYPizzaIngredientFactory : IPizzaIngredientFactory
{
    public IDough  CreateDough()  => new ThinCrustDough();
    public ISauce  CreateSauce()  => new MarinaraSauce();
    public ICheese CreateCheese() => new ReggianoCheese();
    public IClams  CreateClams()  => new FreshClams();
}

public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
{
    public IDough  CreateDough()  => new ThickCrustDough();
    public ISauce  CreateSauce()  => new PlumTomatoSauce();
    public ICheese CreateCheese() => new MozzarellaCheese();
    public IClams  CreateClams()  => new FrozenClams();
}

// ----- Klient (Product) — Pizza ---------------------------------------

/// <summary>
/// Pizza to klient fabryki — zna TYLKO IPizzaIngredientFactory.
/// Konkretna fabryka jest wstrzykiwana przez konstruktor.
/// </summary>
public abstract class Pizza
{
    public string Name { get; set; } = string.Empty;
    protected IDough?  Dough;
    protected ISauce?  Sauce;
    protected ICheese? Cheese;
    protected IClams?  Clams;

    public abstract void Prepare();

    public virtual void Bake()  => Console.WriteLine("  Bake 25 min at 200°C");
    public virtual void Cut()   => Console.WriteLine("  Cut into diagonal slices");
    public virtual void Box()   => Console.WriteLine($"  Box in {Name} box");

    public override string ToString() => Name;
}

public class CheesePizza : Pizza
{
    private readonly IPizzaIngredientFactory _factory;
    public CheesePizza(IPizzaIngredientFactory factory) => _factory = factory;

    public override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");
        Dough  = _factory.CreateDough();
        Sauce  = _factory.CreateSauce();
        Cheese = _factory.CreateCheese();
        Console.WriteLine($"  Dough : {Dough.Description}");
        Console.WriteLine($"  Sauce : {Sauce.Description}");
        Console.WriteLine($"  Cheese: {Cheese.Description}");
    }
}

public class ClamPizza : Pizza
{
    private readonly IPizzaIngredientFactory _factory;
    public ClamPizza(IPizzaIngredientFactory factory) => _factory = factory;

    public override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");
        Dough  = _factory.CreateDough();
        Sauce  = _factory.CreateSauce();
        Cheese = _factory.CreateCheese();
        Clams  = _factory.CreateClams();
        Console.WriteLine($"  Dough : {Dough.Description}");
        Console.WriteLine($"  Sauce : {Sauce.Description}");
        Console.WriteLine($"  Cheese: {Cheese.Description}");
        Console.WriteLine($"  Clams : {Clams.Description}");
    }
}

// ----- PizzaStore (używa fabryki) ------------------------------------

public abstract class PizzaStore
{
    protected abstract Pizza CreatePizza(string type);

    public Pizza OrderPizza(string type)
    {
        Console.WriteLine($"\n=== {GetType().Name}: Zamówienie '{type}' ===");
        var pizza = CreatePizza(type);
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        Console.WriteLine($"  → Gotowe: {pizza}");
        return pizza;
    }
}

public class NYPizzaStore : PizzaStore
{
    private readonly IPizzaIngredientFactory _factory = new NYPizzaIngredientFactory();

    protected override Pizza CreatePizza(string type)
    {
        Pizza pizza = type.ToLower() switch
        {
            "cheese" => new CheesePizza(_factory),
            "clam"   => new ClamPizza(_factory),
            _ => throw new ArgumentException($"Nieznany typ: {type}")
        };
        pizza.Name = $"New York Style {type} Pizza";
        return pizza;
    }
}

public class ChicagoPizzaStore : PizzaStore
{
    private readonly IPizzaIngredientFactory _factory = new ChicagoPizzaIngredientFactory();

    protected override Pizza CreatePizza(string type)
    {
        Pizza pizza = type.ToLower() switch
        {
            "cheese" => new CheesePizza(_factory),
            "clam"   => new ClamPizza(_factory),
            _ => throw new ArgumentException($"Nieznany typ: {type}")
        };
        pizza.Name = $"Chicago Style {type} Pizza";
        return pizza;
    }
}
