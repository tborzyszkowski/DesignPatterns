using OpenClosed.WithoutOcp;
using OpenClosed.WithOcp;
using Xunit;

namespace OpenClosed.Tests;

// =====================================================================
// Testy: BEZ OCP — OrderProcessor z enum ShippingType
// =====================================================================

public class WithoutOcpTests
{
    private readonly WithoutOcp.OrderProcessor _processor = new();

    [Theory]
    [InlineData(ShippingType.Standard, 10.00)]
    [InlineData(ShippingType.Express, 25.00)]
    [InlineData(ShippingType.Overnight, 50.00)]
    [InlineData(ShippingType.FreeShipping, 0.00)]
    public void CalculateShipping_FixedRate_ReturnsExpected(ShippingType type, decimal expected)
    {
        var order = new WithoutOcp.Order("C1", 100m, "Warszawa");
        Assert.Equal(expected, _processor.CalculateShipping(order, type));
    }

    [Fact]
    public void CalculateShipping_International_HighValue_Returns50()
    {
        var order = new WithoutOcp.Order("C1", 200m, "Berlin");
        Assert.Equal(50.00m, _processor.CalculateShipping(order, ShippingType.International));
    }

    [Fact]
    public void CalculateShipping_International_LowValue_Returns80()
    {
        var order = new WithoutOcp.Order("C1", 199m, "Berlin");
        Assert.Equal(80.00m, _processor.CalculateShipping(order, ShippingType.International));
    }
}

// =====================================================================
// Testy: Z OCP — OrderProcessor z IShippingCalculator
// =====================================================================

public class WithOcpTests
{
    [Fact]
    public void CalculateShipping_UsesRegisteredCalculator()
    {
        var calculators = new IShippingCalculator[] { new StandardShipping() };
        var processor = new WithOcp.OrderProcessor(calculators);
        var order = new WithOcp.Order("C1", 100m, "Warszawa");

        Assert.Equal(10.00m, processor.CalculateShipping(order, "Standard"));
    }

    [Fact]
    public void CalculateShipping_UnknownType_Throws()
    {
        var processor = new WithOcp.OrderProcessor([]);
        var order = new WithOcp.Order("C1", 100m, "Warszawa");

        Assert.Throws<InvalidOperationException>(
            () => processor.CalculateShipping(order, "Unknown"));
    }

    [Fact]
    public void StandardShipping_Returns10()
    {
        var calc = new StandardShipping();
        Assert.Equal("Standard", calc.ShippingType);
        Assert.Equal(10.00m, calc.Calculate(new WithOcp.Order("C1", 0m, "")));
    }

    [Fact]
    public void ExpressShipping_Returns25()
    {
        var calc = new ExpressShipping();
        Assert.Equal("Express", calc.ShippingType);
        Assert.Equal(25.00m, calc.Calculate(new WithOcp.Order("C1", 0m, "")));
    }

    [Fact]
    public void OvernightShipping_Returns50()
    {
        var calc = new OvernightShipping();
        Assert.Equal("Overnight", calc.ShippingType);
        Assert.Equal(50.00m, calc.Calculate(new WithOcp.Order("C1", 0m, "")));
    }

    [Fact]
    public void FreeShipping_Returns0()
    {
        var calc = new FreeShipping();
        Assert.Equal("Free", calc.ShippingType);
        Assert.Equal(0.00m, calc.Calculate(new WithOcp.Order("C1", 0m, "")));
    }

    [Fact]
    public void InternationalShipping_HighValue_Returns50()
    {
        var calc = new InternationalShipping();
        Assert.Equal(50.00m, calc.Calculate(new WithOcp.Order("C1", 200m, "Berlin")));
    }

    [Fact]
    public void InternationalShipping_LowValue_Returns80()
    {
        var calc = new InternationalShipping();
        Assert.Equal(80.00m, calc.Calculate(new WithOcp.Order("C1", 199m, "Berlin")));
    }

    [Fact]
    public void SameDayShipping_ReturnsBaseAndPercent()
    {
        var calc = new SameDayShipping();
        Assert.Equal("SameDay", calc.ShippingType);
        // 99 + 250 * 0.01 = 101.50
        Assert.Equal(101.50m, calc.Calculate(new WithOcp.Order("C1", 250m, "")));
    }

    [Fact]
    public void OrderProcessor_CanBeExtended_WithNewCalculator()
    {
        // Demonstruje OCP: dodajemy nowy typ bez modyfikacji istniejącego kodu
        var calculators = new IShippingCalculator[]
        {
            new StandardShipping(),
            new CustomTestShipping()
        };
        var processor = new WithOcp.OrderProcessor(calculators);
        var order = new WithOcp.Order("C1", 100m, "Gdańsk");

        Assert.Equal(10.00m, processor.CalculateShipping(order, "Standard"));
        Assert.Equal(42.00m, processor.CalculateShipping(order, "CustomTest"));
    }

    private class CustomTestShipping : IShippingCalculator
    {
        public string ShippingType => "CustomTest";
        public decimal Calculate(WithOcp.Order order) => 42.00m;
    }
}
