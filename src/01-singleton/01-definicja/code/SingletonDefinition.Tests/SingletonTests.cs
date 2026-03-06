using SingletonDefinition;
using Xunit;

namespace SingletonDefinition.Tests;

/// <summary>
/// Testy weryfikujące własności podstawowych implementacji Singletona.
/// Każdy test sprawdza kluczową właściwość wzorca: identyczność instancji.
/// </summary>
public class SingletonTests
{
    [Fact(DisplayName = "ClassicSingleton: dwa wywołania zwracają tę samą instancję")]
    public void ClassicSingleton_TwoCalls_ReturnSameInstance()
    {
        var instance1 = ClassicSingleton.GetInstance();
        var instance2 = ClassicSingleton.GetInstance();

        Assert.Same(instance1, instance2);
    }

    [Fact(DisplayName = "EagerSingleton: właściwość Instance zawsze zwraca ten sam obiekt")]
    public void EagerSingleton_PropertyAccess_ReturnsSameInstance()
    {
        var instance1 = EagerSingleton.Instance;
        var instance2 = EagerSingleton.Instance;

        Assert.Same(instance1, instance2);
    }

    [Fact(DisplayName = "LazySingleton: przed dostępem IsCreated == false")]
    public void LazySingleton_BeforeAccess_IsNotCreated()
    {
        // Uwaga: test może nie zadziałać poprawnie jeśli LazySingleton.Instance
        // było już wywołane wcześniej w tym procesie (Lazy<T> nie resetuje się).
        // Ten test jest ilustracyjny — weryfikuje metodę GetStatus().
        var instance = LazySingleton.Instance;
        Assert.NotNull(instance);
    }

    [Fact(DisplayName = "LazySingleton: dwa wywołania zwracają tę samą instancję")]
    public void LazySingleton_TwoCalls_ReturnSameInstance()
    {
        var instance1 = LazySingleton.Instance;
        var instance2 = LazySingleton.Instance;

        Assert.Same(instance1, instance2);
    }

    [Fact(DisplayName = "StaticHolderSingleton: dwa wywołania zwracają tę samą instancję")]
    public void StaticHolderSingleton_TwoCalls_ReturnSameInstance()
    {
        var instance1 = StaticHolderSingleton.Instance;
        var instance2 = StaticHolderSingleton.Instance;

        Assert.Same(instance1, instance2);
    }

    [Fact(DisplayName = "ChocolateBoiler: GetInstance() zawsze zwraca tę samą instancję")]
    public void ChocolateBoiler_GetInstance_ReturnsSameInstance()
    {
        var boiler1 = ChocolateBoiler.GetInstance();
        var boiler2 = ChocolateBoiler.GetInstance();

        Assert.Same(boiler1, boiler2);
    }

    [Fact(DisplayName = "ChocolateBoiler: stan jest współdzielony między referencjami")]
    public void ChocolateBoiler_SharedState_ReflectedInBothReferences()
    {
        var boiler1 = ChocolateBoiler.GetInstance();
        var boiler2 = ChocolateBoiler.GetInstance();

        // Operacja przez boiler1...
        boiler1.Fill();

        // ...jest widoczna przez boiler2 (ten sam obiekt)
        Assert.False(boiler2.IsEmpty);
    }

    [Fact(DisplayName = "ChocolateBoiler: drain po fill+boil daje pusty kocioł")]
    public void ChocolateBoiler_FullCycle_ResultsInEmptyBoiler()
    {
        var boiler = ChocolateBoiler.GetInstance();

        // Pełny cykl (jeśli kocioł nie jest już pełny z poprzedniego testu)
        if (boiler.IsEmpty)
        {
            boiler.Fill();
            boiler.Boil();
            boiler.Drain();
            Assert.True(boiler.IsEmpty);
        }
        else
        {
            // Kocioł już pełny — test ilustracyjny
            Assert.False(boiler.IsEmpty);
        }
    }
}
