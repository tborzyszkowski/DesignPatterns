namespace SimpleFactory;

// =====================================================================
// PROSTA FABRYKA (Simple Factory) — przykład z pizzerią
// Inspiracja: Head First Design Patterns (Freeman & Robson), Rozdział 4
// =====================================================================

// ----- Hierarchia produktów ------------------------------------------

public abstract class Pizza
{
    public string Name { get; protected set; } = string.Empty;
    public string Dough { get; protected set; } = string.Empty;
    public string Sauce { get; protected set; } = string.Empty;
    public List<string> Toppings { get; protected set; } = [];

    public virtual void Prepare()
    {
        Console.WriteLine($"\nPrzygotowuję {Name}");
        Console.WriteLine($"  Ciasto: {Dough}");
        Console.WriteLine($"  Sos: {Sauce}");
        Console.WriteLine($"  Dodatki: {string.Join(", ", Toppings)}");
    }

    public virtual void Bake()   => Console.WriteLine($"  Pieczenie {Name} w 200°C przez 25 minut");
    public virtual void Cut()    => Console.WriteLine($"  Krojenie {Name} na 8 kawałków");
    public virtual void Box()    => Console.WriteLine($"  Pakowanie {Name} do pudełka");

    public override string ToString() => Name;
}

public class CheesePizza : Pizza
{
    public CheesePizza()
    {
        Name = "Margherita";
        Dough = "cienkie ciasto";
        Sauce = "sos pomidorowy";
        Toppings = ["mozzarella", "bazylia"];
    }
}

public class PepperoniPizza : Pizza
{
    public PepperoniPizza()
    {
        Name = "Pepperoni";
        Dough = "grube ciasto";
        Sauce = "pikantny sos pomidorowy";
        Toppings = ["pepperoni", "cheddar", "papryka"];
    }
}

public class VeggiePizza : Pizza
{
    public VeggiePizza()
    {
        Name = "Wegetariańska";
        Dough = "ciasto pełnoziarniste";
        Sauce = "sos z bazylią";
        Toppings = ["papryka", "cukinia", "pieczarki", "cebula", "oliwki"];
    }
}

public class ClamPizza : Pizza
{
    public ClamPizza()
    {
        Name = "Clam";
        Dough = "cienkie ciasto";
        Sauce = "sos czosnkowy";
        Toppings = ["małże", "parmezan", "oregano"];
    }
}

// ----- Prosta fabryka ------------------------------------------------

/// <summary>
/// Prosta fabryka — centralizuje logikę tworzenia produktów.
/// NIE jest wzorcem projektowym GoF, ale często używanym idiomem.
/// UWAGA: narusza OCP — każdy nowy typ pizzy wymaga modyfikacji metody CreatePizza.
/// </summary>
public class SimplePizzaFactory
{
    public Pizza? CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese"    => new CheesePizza(),
            "pepperoni" => new PepperoniPizza(),
            "veggie"    => new VeggiePizza(),
            "clam"      => new ClamPizza(),
            _           => null
        };
    }
}

// ----- Klient (Store) ------------------------------------------------

/// <summary>
/// Sklep — klient fabryki. Zna tylko abstrakcję Pizza,
/// nie wie nic o konkretnych klasach.
/// </summary>
public class PizzaStore
{
    private readonly SimplePizzaFactory _factory;

    public PizzaStore(SimplePizzaFactory factory)
    {
        _factory = factory;
    }

    public Pizza? OrderPizza(string type)
    {
        var pizza = _factory.CreatePizza(type);

        if (pizza is null)
        {
            Console.WriteLine($"  [!] Nie mamy pizzy typu '{type}'");
            return null;
        }

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }
}
