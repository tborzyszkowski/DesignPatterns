using StrukturaGoF.Shapes;
using Xunit;

namespace Examples.Tests;

public class ShapeCloneTests
{
    [Fact]
    public void Circle_Clone_CopiesAllProperties()
    {
        var original = new Circle(10, 20, "red", 50);

        var clone = (Circle)original.Clone();

        Assert.Equal(10, clone.X);
        Assert.Equal(20, clone.Y);
        Assert.Equal("red", clone.Color);
        Assert.Equal(50, clone.Radius);
    }

    [Fact]
    public void Circle_Clone_IsIndependent()
    {
        var original = new Circle(10, 20, "red", 50);

        var clone = original.Clone();
        clone.MoveTo(100, 200);

        Assert.Equal(10, original.X);
        Assert.Equal(20, original.Y);
    }

    [Fact]
    public void Rectangle_Clone_CopiesAllProperties()
    {
        var original = new Rectangle(5, 15, "blue", 80, 40);

        var clone = (Rectangle)original.Clone();

        Assert.Equal(5, clone.X);
        Assert.Equal(15, clone.Y);
        Assert.Equal("blue", clone.Color);
        Assert.Equal(80, clone.Width);
        Assert.Equal(40, clone.Height);
    }

    [Fact]
    public void Polygon_Clone_DeepCopiesPoints()
    {
        var original = new Polygon(0, 0, "green", [(0, 0), (50, 0), (25, 43)]);

        var clone = (Polygon)original.Clone();

        Assert.False(ReferenceEquals(original.Points, clone.Points));
        Assert.Equal(original.Points, clone.Points);
    }

    [Fact]
    public void Polygon_Clone_IsIndependent()
    {
        var original = new Polygon(0, 0, "green", [(0, 0), (50, 0), (25, 43)]);

        var clone = original.Clone();
        clone.MoveTo(999, 999);

        Assert.Equal(0, original.X);
        Assert.Equal(0, original.Y);
    }
}

public class ShapeRegistryTests
{
    [Fact]
    public void Clone_ReturnsNewInstance()
    {
        var registry = new ShapeRegistry();
        var original = new Circle(0, 0, "red", 25);
        registry.Register("circle", original);

        var clone = registry.Clone("circle");

        Assert.False(ReferenceEquals(original, clone));
    }

    [Fact]
    public void Clone_CopiesValues()
    {
        var registry = new ShapeRegistry();
        registry.Register("rect", new Rectangle(1, 2, "gray", 80, 40));

        var clone = (Rectangle)registry.Clone("rect");

        Assert.Equal(1, clone.X);
        Assert.Equal(2, clone.Y);
        Assert.Equal(80, clone.Width);
        Assert.Equal(40, clone.Height);
    }

    [Fact]
    public void Clone_IsIndependentFromPrototype()
    {
        var registry = new ShapeRegistry();
        registry.Register("circle", new Circle(0, 0, "red", 25));

        var clone = registry.Clone("circle");
        clone.MoveTo(100, 200);

        var prototype = (Circle)registry.GetPrototype("circle");
        Assert.Equal(0, prototype.X);
        Assert.Equal(0, prototype.Y);
    }

    [Fact]
    public void Keys_ReturnsRegisteredKeys()
    {
        var registry = new ShapeRegistry();
        registry.Register("a", new Circle(0, 0, "red", 10));
        registry.Register("b", new Rectangle(0, 0, "blue", 20, 10));

        var keys = registry.Keys;

        Assert.Contains("a", keys);
        Assert.Contains("b", keys);
        Assert.Equal(2, keys.Count);
    }
}
