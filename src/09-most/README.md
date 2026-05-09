# Wzorzec Most (Bridge)

## Cel modułu

Ten moduł zawiera materiały dydaktyczne do wykładu o wzorcu Most w języku C#.
Każdy temat ma osobny katalog z:

1. szczegółowym README.md,
2. uruchamialnym kodem .NET (Examples),
3. diagramami PlantUML (diagrams/*.puml + *.png),
4. zadaniami i rozwiązaniami.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Motywacja 2D zmienności i rys historyczny |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować | Sygnały, zalety, wady i antywzorce |
| [03](03-struktura-gof/README.md) | Struktura GoF | Role wzorca, diagram klas i sekwencji |
| [04](04-implementacje-i-warianty/README.md) | Implementacje i warianty | Statyczny, dynamiczny, factory+bridge |
| [05](05-wiekszy-przyklad-i-alternatywy/README.md) | Większy przykład | Scenariusz end-to-end i alternatywy |
| [06](06-most-w-bibliotekach-standardowych/README.md) | Most w bibliotekach | Przykłady z platformy i ich analiza |

## Jak uruchamiać przykłady

```bash
cd src/09-most/01-idea-i-kontekst/Examples && dotnet run
cd src/09-most/02-kiedy-stosowac-zalety-wady/Examples && dotnet run
cd src/09-most/03-struktura-gof/Examples && dotnet run
cd src/09-most/04-implementacje-i-warianty/Examples && dotnet run
cd src/09-most/05-wiekszy-przyklad-i-alternatywy/Examples && dotnet run
cd src/09-most/06-most-w-bibliotekach-standardowych/Examples && dotnet run
```

## Jak uruchamiać testy jednostkowe

```bash
dotnet test src/09-most/01-idea-i-kontekst/Tests/Examples.Tests.csproj
dotnet test src/09-most/02-kiedy-stosowac-zalety-wady/Tests/Examples.Tests.csproj
dotnet test src/09-most/03-struktura-gof/Tests/Examples.Tests.csproj
dotnet test src/09-most/04-implementacje-i-warianty/Tests/Examples.Tests.csproj
dotnet test src/09-most/05-wiekszy-przyklad-i-alternatywy/Tests/Examples.Tests.csproj
dotnet test src/09-most/06-most-w-bibliotekach-standardowych/Tests/Examples.Tests.csproj
```

## Problemy i ryzyka przy stosowaniu Most

1. Mylenie Mostu z Adaptorem i Strategią.
2. Przedwczesne projektowanie dwóch osi zmienności.
3. Przeciek implementacji do warstwy Abstraction.
4. Hard-coded implementor zamiast DI lub fabryki.

## Literatura

1. GoF, Design Patterns, rozdział Bridge.
2. Refactoring.Guru (Bridge): https://refactoring.guru/design-patterns/bridge
3. Martin Fowler, Isolating domain from infrastructure: https://martinfowler.com/
4. Microsoft Docs, ILogger: https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger

## Zadania

Zbiorczy zestaw zadań i rozwiązań: [ZADANIA.md](ZADANIA.md)
