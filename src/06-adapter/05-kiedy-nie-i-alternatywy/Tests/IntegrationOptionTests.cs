using Examples;
using Xunit;

namespace Examples.Tests;

public class IntegrationOptionTests
{
    [Fact]
    public void IntegrationOption_RecordStoresAllFields()
    {
        var option = new IntegrationOption("Test", 10, 2.0, 1.5, "note");

        Assert.Equal("Test", option.Name);
        Assert.Equal(10, option.InitialCostPoints);
        Assert.Equal(2.0, option.MonthlyMaintenancePoints);
        Assert.Equal(1.5, option.SemanticRiskFactor);
        Assert.Equal("note", option.Notes);
    }

    [Fact]
    public void EstimateTotalCost_ZeroMonths_ReturnsInitialTimesRisk()
    {
        var option = new IntegrationOption("A", 10, 2.0, 1.0, "");

        var cost = Program.EstimateTotalCost(option, 0);

        Assert.Equal(10.0, cost);
    }

    [Fact]
    public void EstimateTotalCost_TwelveMonths_CalculatesCorrectly()
    {
        var option = new IntegrationOption("Adapter", 8, 2.5, 1.30, "");

        var cost = Program.EstimateTotalCost(option, 12);

        var expected = (8 + 2.5 * 12) * 1.30;
        Assert.Equal(expected, cost, precision: 5);
    }

    [Fact]
    public void EstimateTotalCost_NoRisk_EqualsBaselineCost()
    {
        var option = new IntegrationOption("Refactor", 14, 0.9, 1.0, "");

        var cost = Program.EstimateTotalCost(option, 6);

        var expected = 14 + 0.9 * 6;
        Assert.Equal(expected, cost, precision: 5);
    }

    [Fact]
    public void Refactor_CheapestLongTerm()
    {
        var adapter = new IntegrationOption("Adapter", 8, 2.5, 1.30, "");
        var facade = new IntegrationOption("Facade", 6, 2.0, 1.10, "");
        var refactor = new IntegrationOption("Refactor", 14, 0.9, 1.00, "");

        var costAdapter = Program.EstimateTotalCost(adapter, 12);
        var costFacade = Program.EstimateTotalCost(facade, 12);
        var costRefactor = Program.EstimateTotalCost(refactor, 12);

        Assert.True(costRefactor < costFacade);
        Assert.True(costRefactor < costAdapter);
    }
}
