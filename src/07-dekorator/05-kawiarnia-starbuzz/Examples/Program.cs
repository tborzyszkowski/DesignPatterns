namespace Examples;

public abstract class Beverage
{
    public virtual string Description => "Unknown beverage";
    public abstract decimal Cost();
}

public sealed class Espresso : Beverage
{
    public override string Description => "Espresso";
    public override decimal Cost() => 7.50m;
}

public sealed class HouseBlend : Beverage
{
    public override string Description => "House Blend";
    public override decimal Cost() => 6.00m;
}

public abstract class CondimentDecorator(Beverage beverage) : Beverage
{
    protected Beverage Beverage { get; } = beverage;
}

public sealed class Mocha(Beverage beverage) : CondimentDecorator(beverage)
{
    public override string Description => $"{Beverage.Description}, Mocha";
    public override decimal Cost() => Beverage.Cost() + 1.20m;
}

public sealed class Soy(Beverage beverage) : CondimentDecorator(beverage)
{
    public override string Description => $"{Beverage.Description}, Soy";
    public override decimal Cost() => Beverage.Cost() + 0.80m;
}

public sealed class Whip(Beverage beverage) : CondimentDecorator(beverage)
{
    public override string Description => $"{Beverage.Description}, Whip";
    public override decimal Cost() => Beverage.Cost() + 0.60m;
}

public static class Program
{
    public static void Main()
    {
        Beverage order1 = new Espresso();
        Console.WriteLine($"{order1.Description} = {order1.Cost():0.00} PLN");

        Beverage order2 = new Whip(new Mocha(new Soy(new HouseBlend())));
        Console.WriteLine($"{order2.Description} = {order2.Cost():0.00} PLN");
    }
}
