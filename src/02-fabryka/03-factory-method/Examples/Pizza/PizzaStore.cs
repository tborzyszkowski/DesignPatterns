namespace FactoryMethod.Pizza;

// =====================================================================
// FACTORY METHOD — pizzeria (Head First Design Patterns, Rozdział 4)
// =====================================================================

// ----- Produkt (Product) ---------------------------------------------

public abstract class Pizza
{
    public string Name { get; protected set; } = string.Empty;
    public string Dough { get; protected set; } = string.Empty;
    public string Sauce { get; protected set; } = string.Empty;
    public List<string> Toppings { get; protected set; } = [];

    public abstract void Prepare();
    public virtual  void Bake()  => Console.WriteLine($"  Pieczenie 25 minut w 200°C");
    public virtual  void Cut()   => Console.WriteLine($"  Krojenie po przekątnej");
    public virtual  void Box()   => Console.WriteLine($"  Pakowanie do pudełka {Name}");

    public override string ToString() => Name;
}

// NY — cienkie ciasto, lekkie dodatki
public class NYStyleCheesePizza : Pizza
{
    public NYStyleCheesePizza()
    {
        Name  = "NY Style Sauce and Cheese Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings = ["Grated Reggiano"];
    }
    public override void Prepare() => Console.WriteLine($"Preparing {Name}...");
}

public class NYStylePepperoniPizza : Pizza
{
    public NYStylePepperoniPizza()
    {
        Name  = "NY Style Pepperoni Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings = ["Sliced Pepperoni", "Parmesan"];
    }
    public override void Prepare() => Console.WriteLine($"Preparing {Name}...");
}

public class NYStyleVeggiePizza : Pizza
{
    public NYStyleVeggiePizza()
    {
        Name  = "NY Style Veggie Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings = ["Roasted Peppers", "Onions", "Mushrooms"];
    }
    public override void Prepare() => Console.WriteLine($"Preparing {Name}...");
}

// Chicago — grube ciasto, duszona pizza (deep dish)
public class ChicagoStyleCheesePizza : Pizza
{
    public ChicagoStyleCheesePizza()
    {
        Name  = "Chicago Style Deep Dish Cheese Pizza";
        Dough = "Extra Thick Crust Dough";
        Sauce = "Plum Tomato Sauce";
        Toppings = ["Shredded Mozzarella"];
    }
    public override void Prepare() => Console.WriteLine($"Preparing {Name}...");
    public override void Bake()   => Console.WriteLine("  Baking for 35 minutes at 180°C");
    public override void Cut()    => Console.WriteLine("  Cutting the pizza into square slices");
}

public class ChicagoStylePepperoniPizza : Pizza
{
    public ChicagoStylePepperoniPizza()
    {
        Name  = "Chicago Style Pepperoni Pizza";
        Dough = "Extra Thick Crust Dough";
        Sauce = "Plum Tomato Sauce";
        Toppings = ["Thick Pepperoni", "Shredded Mozzarella"];
    }
    public override void Prepare() => Console.WriteLine($"Preparing {Name}...");
    public override void Bake()   => Console.WriteLine("  Baking for 35 minutes at 180°C");
}

// ----- Creator (AbstractCreator) -------------------------------------

/// <summary>
/// Twórca (Creator) — definiuje metody wytwórcze CreatePizza().
/// Metoda OrderPizza() to "metoda szablonowa" (Template Method):
/// wie, JAK przetworzyć pizzę, ale NIE wie, KTÓRĄ konkretną pizzę stworzyć.
/// </summary>
public abstract class PizzaStore
{
    /// <summary>
    /// Metoda wytwórcza (Factory Method) — hook, który definiują podklasy.
    /// </summary>
    protected abstract Pizza CreatePizza(string type);

    /// <summary>
    /// Metoda szablonowa — algorytm jest tutaj, tworzenie w podklasach.
    /// </summary>
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

// ----- ConcreteCreators ----------------------------------------------

/// <summary>
/// Konkretny Twórca — decyduje, jakie NYStyle pizza tworzyć.
/// Rozszerzamy system przez DODANIE nowej podklasy PizzaStore.
/// </summary>
public class NYPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese"    => new NYStyleCheesePizza(),
            "pepperoni" => new NYStylePepperoniPizza(),
            "veggie"    => new NYStyleVeggiePizza(),
            _ => throw new ArgumentException($"NY Store nie zna pizzy '{type}'")
        };
    }
}

/// <summary>
/// Konkretny Twórca dla Chicago. Logika PizzaStore nie ulega zmianie.
/// </summary>
public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese"    => new ChicagoStyleCheesePizza(),
            "pepperoni" => new ChicagoStylePepperoniPizza(),
            _ => throw new ArgumentException($"Chicago Store nie zna pizzy '{type}'")
        };
    }
}
