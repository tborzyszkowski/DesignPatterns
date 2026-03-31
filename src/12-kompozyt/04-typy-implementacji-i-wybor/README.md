# 04. Typy implementacji i wybór wariantu

## Cel rozdziału

Poznać najczęściej spotykane warianty implementacji Kompozytu i świadomie dobrać właściwy do problemu.

## Typy implementacji

1. Transparent Composite:
Interfejs `Component` zawiera `Add/Remove`, a liście zwracają wyjątek.
2. Safe Composite:
Metody zarządzania dziećmi są tylko w `Composite`, co poprawia bezpieczeństwo API.
3. Composite + Iterator:
Do przejścia po drzewie używany jest iterator (np. BFS/DFS) zamiast czystej rekurencji.

## Jak wybrać właściwy wariant

1. Chcesz maksymalnej prostoty klienta? Rozważ transparent.
1. Chcesz bezpieczniejszego API i mniej błędów? Rozważ safe.
1. Masz bardzo głębokie drzewa lub potrzebę wielu strategii przejścia? Dodaj iterator.

## Diagram porównawczy

![Porównanie wariantów](diagrams/composite_variants.png)

Źródło: [diagrams/01-variants.puml](diagrams/01-variants.puml)

## Schemat implementacji

![Schemat implementacji](diagrams/composite_implementation_scheme.png)

Źródło: [diagrams/02-implementation-scheme.puml](diagrams/02-implementation-scheme.puml)

## Przykład C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program porównuje wariant transparent i safe na tym samym problemie.

```bash
cd src/12-kompozyt/04-typy-implementacji-i-wybor/Examples
dotnet run
```

## Źródła

1. Refactoring.Guru Composite: https://refactoring.guru/design-patterns/composite
1. Microsoft Learn IEnumerable<T>: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
