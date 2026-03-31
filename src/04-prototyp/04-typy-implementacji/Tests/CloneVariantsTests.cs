using TypyImplementacji;
using Xunit;

namespace Examples.Tests;

public class VehicleCardLegacyTests
{
    [Fact]
    public void Clone_ReturnsShallowCopy()
    {
        var original = new VehicleCardLegacy
        {
            Brand = "Toyota", Model = "Corolla", Year = 2020,
            Features = ["ABS", "ESP"]
        };

        var clone = (VehicleCardLegacy)original.Clone();

        Assert.Equal("Toyota", clone.Brand);
        Assert.Equal("Corolla", clone.Model);
        Assert.Equal(2020, clone.Year);
    }

    [Fact]
    public void Clone_SharesFeaturesReference()
    {
        var original = new VehicleCardLegacy { Features = ["ABS"] };

        var clone = (VehicleCardLegacy)original.Clone();

        Assert.True(ReferenceEquals(original.Features, clone.Features));
    }
}

public class VehicleCardTests
{
    [Fact]
    public void Clone_ReturnsDeepCopy()
    {
        var original = new VehicleCard
        {
            Brand = "Toyota", Model = "Corolla", Year = 2020,
            Features = ["ABS", "ESP"]
        };

        var clone = original.Clone();

        Assert.Equal("Toyota", clone.Brand);
        Assert.Equal(2020, clone.Year);
        Assert.False(ReferenceEquals(original.Features, clone.Features));
        Assert.Equal(original.Features, clone.Features);
    }

    [Fact]
    public void Clone_FeaturesAreIndependent()
    {
        var original = new VehicleCard { Features = ["ABS"] };

        var clone = original.Clone();
        clone.Features.Add("Heated seats");

        Assert.Single(original.Features);
    }
}

public class ServerConfigTests
{
    [Fact]
    public void Clone_CopiesAllProperties()
    {
        var config = new ServerConfig
        {
            Environment = "staging",
            Port = 8080,
            AllowedHosts = ["localhost", "10.0.0.1"]
        };

        var clone = config.Clone();

        Assert.Equal("staging", clone.Environment);
        Assert.Equal(8080, clone.Port);
        Assert.Equal(config.AllowedHosts, clone.AllowedHosts);
    }

    [Fact]
    public void Clone_DeepCopiesAllowedHosts()
    {
        var config = new ServerConfig
        {
            AllowedHosts = ["localhost"]
        };

        var clone = config.Clone();

        Assert.False(ReferenceEquals(config.AllowedHosts, clone.AllowedHosts));
    }
}

public class EmployeeTests
{
    [Fact]
    public void CopyConstructor_CopiesAllProperties()
    {
        var original = new Employee
        {
            Name = "Jan", Role = "Developer",
            Address = new Address { Street = "ul. Kwiatowa 5", City = "Warszawa" },
            Skills = ["C#", "SQL"]
        };

        var clone = new Employee(original);

        Assert.Equal("Jan", clone.Name);
        Assert.Equal("Developer", clone.Role);
        Assert.Equal("ul. Kwiatowa 5", clone.Address.Street);
        Assert.Equal(original.Skills, clone.Skills);
    }

    [Fact]
    public void CopyConstructor_AddressIsIndependent()
    {
        var original = new Employee
        {
            Address = new Address { Street = "ul. Kwiatowa 5", City = "Warszawa" }
        };

        var clone = new Employee(original);
        clone.Address.Street = "ul. Nowa 1";

        Assert.Equal("ul. Kwiatowa 5", original.Address.Street);
    }

    [Fact]
    public void CopyConstructor_SkillsAreIndependent()
    {
        var original = new Employee { Skills = ["C#", "SQL"] };

        var clone = new Employee(original);
        clone.Skills.Add("Docker");

        Assert.Equal(2, original.Skills.Count);
    }

    [Fact]
    public void Clone_ReturnsIndependentCopy()
    {
        var original = new Employee
        {
            Name = "Jan",
            Address = new Address { City = "Kraków" }
        };

        var clone = original.Clone();
        clone.Name = "Anna";
        clone.Address.City = "Gdańsk";

        Assert.Equal("Jan", original.Name);
        Assert.Equal("Kraków", original.Address.City);
    }
}
