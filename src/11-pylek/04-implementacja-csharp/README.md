# 04. Implementacja C#

## Cel rozdzialu

Pokazac praktyczna implementacje FlyweightFactory w C# z naciskiem na poprawny klucz, niemutowalnosc i wspolbieznosc.

## Szkielet architektury

1. `IFlyweight` - kontrakt operacji z extrinsic state.
1. `ConcreteFlyweight` - immutable intrinsic state.
1. `FlyweightKey` - klucz identyfikujacy wspolny stan.
1. `FlyweightFactory` - cache oparty o `ConcurrentDictionary`.

## Zalecenia implementacyjne

1. Trzymaj intrinsic jako `readonly`.
1. Uzywaj jawnego typu klucza zamiast surowych stringow.
1. Zadbaj o deterministyczne `Equals` i `GetHashCode` klucza.
1. Rejestruj metryki: liczba miss/hit oraz liczba unikalnych flyweightow.

## Pseudokod factory

```csharp
public sealed class FlyweightFactory
{
    private readonly ConcurrentDictionary<FlyweightKey, IFlyweight> _cache = new();

    public IFlyweight Get(FlyweightKey key)
    {
        return _cache.GetOrAdd(key, k => new ConcreteFlyweight(k));
    }
}
```

## Najczestsze bledy C#

1. Mutowanie intrinsic po utworzeniu flyweight.
1. Niespojny klucz (`ToLower`/`Trim` wykonywane raz, a raz nie).
1. Wstrzykiwanie zaleznosci zaleznych od requestu do flyweight.

## Co mierzyc w demie

1. `UniqueFlyweights`.
1. `Requests` i `HitRatio`.
1. Przyblizona roznica pamieci miedzy wersja naiwna i flyweight.
