using System.Reflection;
using System.Text.Json;
using Problems;
using Xunit;

namespace Problems.Tests;

// =====================================================================
// Testy: Problem dziedziczenia
// =====================================================================

public class InheritanceProblemTests
{
    [Fact]
    public void ProblematicLogger_GetInstance_AlwaysReturnsBaseType()
    {
        var instance = ProblematicLogger.GetInstance();
        // Nawet jeśli chcemy FileLogger — zawsze dostajemy bazowy typ
        Assert.IsType<ProblematicLogger>(instance);
    }

    [Fact]
    public void RegistryLogger_Console_ReturnsSameInstance()
    {
        var l1 = BaseLogger.GetInstance("console");
        var l2 = BaseLogger.GetInstance("console");
        Assert.Same(l1, l2);
    }

    [Fact]
    public void RegistryLogger_File_ReturnsSameInstance()
    {
        var l1 = BaseLogger.GetInstance("file");
        var l2 = BaseLogger.GetInstance("file");
        Assert.Same(l1, l2);
    }

    [Fact]
    public void RegistryLogger_DifferentTypes_ReturnDifferentInstances()
    {
        var console = BaseLogger.GetInstance("console");
        var file = BaseLogger.GetInstance("file");
        Assert.NotSame(console, file);
    }

    [Fact]
    public void RegistryLogger_UnknownType_Throws()
    {
        Assert.Throws<ArgumentException>(() => BaseLogger.GetInstance("database"));
    }

    [Fact]
    public void IndependentFileLogger_IsSingleton()
    {
        var l1 = IndependentFileLogger.Instance;
        var l2 = IndependentFileLogger.Instance;
        Assert.Same(l1, l2);
    }

    [Fact]
    public void IndependentDatabaseLogger_IsSingleton()
    {
        var l1 = IndependentDatabaseLogger.Instance;
        var l2 = IndependentDatabaseLogger.Instance;
        Assert.Same(l1, l2);
    }

    [Fact]
    public void IndependentLoggers_AreDifferentInstances()
    {
        IndependentLogger file = IndependentFileLogger.Instance;
        IndependentLogger db = IndependentDatabaseLogger.Instance;
        Assert.NotSame(file, db);
    }
}

// =====================================================================
// Testy: Problem serializacji
// =====================================================================

public class SerializationProblemTests
{
    [Fact]
    public void UnprotectedConfig_Deserialize_CreatesNewInstance()
    {
        var original = UnprotectedConfig.Instance;
        var json = JsonSerializer.Serialize(original);
        var deserialized = JsonSerializer.Deserialize<UnprotectedConfig>(json);

        // PROBLEM: deserializacja tworzy nowy obiekt
        Assert.NotSame(original, deserialized);
    }

    [Fact]
    public void ProtectedConfig_Deserialize_ReturnsSameInstance()
    {
        var original = ProtectedConfig.Instance;
        original.Environment = "Production";
        original.MaxConnections = 10;

        var json = JsonSerializer.Serialize(original);
        var deserialized = JsonSerializer.Deserialize<ProtectedConfig>(json);

        // ROZWIĄZANIE: konwerter zwraca istniejącą instancję singletona
        Assert.Same(original, deserialized);
    }

    [Fact]
    public void ProtectedConfig_Serialize_ContainsProperties()
    {
        var json = JsonSerializer.Serialize(ProtectedConfig.Instance);
        Assert.Contains("Environment", json);
        Assert.Contains("MaxConnections", json);
    }
}

// =====================================================================
// Testy: Problem refleksji
// =====================================================================

public class ReflectionProblemTests
{
    [Fact]
    public void VulnerableSingleton_Reflection_CreatesSecondInstance()
    {
        var original = VulnerableSingleton.Instance;

        // Refleksja pozwala wywołać prywatny konstruktor
        var ctor = typeof(VulnerableSingleton)
            .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);

        Assert.NotNull(ctor);
        var second = (VulnerableSingleton)ctor!.Invoke(null);

        // PROBLEM: mamy dwie instancje
        Assert.NotSame(original, second);
    }

    [Fact]
    public void HardenedSingleton_Reflection_ThrowsOnSecondInstance()
    {
        var original = HardenedSingleton.Instance;

        var ctor = typeof(HardenedSingleton)
            .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);

        Assert.NotNull(ctor);

        // ROZWIĄZANIE: guard w konstruktorze rzuca wyjątek
        var ex = Assert.Throws<TargetInvocationException>(
            () => ctor!.Invoke(null));
        Assert.IsType<InvalidOperationException>(ex.InnerException);
    }

    [Fact]
    public void HardenedSingleton_Instance_ReturnsSameObject()
    {
        var h1 = HardenedSingleton.Instance;
        var h2 = HardenedSingleton.Instance;
        Assert.Same(h1, h2);
    }
}
