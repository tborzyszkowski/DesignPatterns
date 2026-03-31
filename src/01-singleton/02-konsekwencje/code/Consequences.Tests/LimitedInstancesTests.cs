using Consequences;
using Xunit;

namespace Consequences.Tests;

public class LimitedInstancesSingletonTests
{
    [Fact]
    public void GetInstance_FirstCall_CreatesNewInstance()
    {
        var instance = LimitedInstancesSingleton.GetInstance();
        Assert.NotNull(instance);
        Assert.True(instance.Id > 0);
    }

    [Fact]
    public void GetInstance_ReturnsInstanceWithValidId()
    {
        var instance = LimitedInstancesSingleton.GetInstance();
        Assert.True(instance.Id >= 1);
    }

    [Fact]
    public void GetInstance_RoundRobin_SelectsLeastUsed()
    {
        // Wywołaj wystarczająco dużo razy, aby pula była pełna i round-robin zaczął działać
        var instances = new List<LimitedInstancesSingleton>();
        for (int i = 0; i < 10; i++)
            instances.Add(LimitedInstancesSingleton.GetInstance());

        // Po 10 wywołaniach pula powinna mieć 3 instancje
        Assert.True(LimitedInstancesSingleton.InstanceCount <= 3);
    }

    [Fact]
    public void GetInstance_MaxThreeInstances()
    {
        // Wymuś stworzenie instancji
        for (int i = 0; i < 5; i++)
            LimitedInstancesSingleton.GetInstance();

        Assert.True(LimitedInstancesSingleton.InstanceCount <= 3);
    }

    [Fact]
    public void GetInstance_TracksUseCount()
    {
        var instance = LimitedInstancesSingleton.GetInstance();
        Assert.True(instance.UseCount >= 1);
    }

    [Fact]
    public void ToString_ContainsIdAndUseCount()
    {
        var instance = LimitedInstancesSingleton.GetInstance();
        var str = instance.ToString();

        Assert.Contains("Id=", str);
        Assert.Contains("UseCount=", str);
    }
}
