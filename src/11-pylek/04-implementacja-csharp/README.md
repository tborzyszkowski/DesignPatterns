# 04. Implementacja C#

## Cel rozdziału

Pokazać praktyczną implementację FlyweightFactory w C# z naciskiem na poprawny klucz, niemutowalność i współbieżność.

## Szkielet architektury

1. `IFlyweight` - kontrakt operacji z extrinsic state.
1. `ConcreteFlyweight` - immutable intrinsic state.
1. `FlyweightKey` - klucz identyfikujący wspólny stan.
1. `FlyweightFactory` - cache oparty o `ConcurrentDictionary`.

## Zalecenia implementacyjne

1. Trzymaj intrinsic jako `readonly`.
1. Używaj jawnego typu klucza zamiast surowych stringów.
1. Zadbaj o deterministyczne `Equals` i `GetHashCode` klucza.
1. Rejestruj metryki: liczba miss/hit oraz liczba unikalnych flyweightów.

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

## Najczęstsze błędy C#

1. Mutowanie intrinsic po utworzeniu flyweight.
1. Niespójny klucz (`ToLower`/`Trim` wykonywane raz, a raz nie).
1. Wstrzykiwanie zależności zależnych od requestu do flyweight.

## Przykładowy program C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program implementuje `TokenFactory` opartą o `ConcurrentDictionary` z silnie typowanym kluczem (`record struct`).
Wyświetla metryki: liczba unikalnych flyweightów, trafień i pudłów, hit ratio.

```bash
cd src/11-pyłek/04-implementacja-csharp/Examples
dotnet run
```

## Co mierzyć w demie

1. `UniqueFlyweights`.
1. `Requests` i `HitRatio`.
1. Przybliżona różnica pamięci między wersją naiwną i flyweight.
