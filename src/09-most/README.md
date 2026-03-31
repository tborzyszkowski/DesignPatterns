# Wzorzec Most (Bridge)

## Cel modulu

Ten modul zawiera materialy dydaktyczne do wykladu o wzorcu Most w jezyku C#.
Kazdy temat ma osobny katalog z:

1. szczegolowym README.md,
2. uruchamialnym kodem .NET (Examples),
3. diagramami PlantUML (diagrams/*.puml + *.png),
4. zadaniami i rozwiazaniami.

## Spis tematow

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Motywacja 2D zmiennosci i rys historyczny |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosowac | Sygnaly, zalety, wady i antywzorce |
| [03](03-struktura-gof/README.md) | Struktura GoF | Role wzorca, diagram klas i sekwencji |
| [04](04-implementacje-i-warianty/README.md) | Implementacje i warianty | Statyczny, dynamiczny, factory+bridge |
| [05](05-wiekszy-przyklad-i-alternatywy/README.md) | Wiekszy przyklad | Scenariusz end-to-end i alternatywy |
| [06](06-most-w-bibliotekach-standardowych/README.md) | Most w bibliotekach | Przyklady z platformy i ich analiza |

## Jak uruchamiac przyklady

```bash
cd src/09-most/01-idea-i-kontekst/Examples && dotnet run
cd src/09-most/02-kiedy-stosowac-zalety-wady/Examples && dotnet run
cd src/09-most/03-struktura-gof/Examples && dotnet run
cd src/09-most/04-implementacje-i-warianty/Examples && dotnet run
cd src/09-most/05-wiekszy-przyklad-i-alternatywy/Examples && dotnet run
cd src/09-most/06-most-w-bibliotekach-standardowych/Examples && dotnet run
```

## Jak uruchamiac testy jednostkowe

```bash
dotnet test src/09-most/01-idea-i-kontekst/Tests/Examples.Tests.csproj
dotnet test src/09-most/02-kiedy-stosowac-zalety-wady/Tests/Examples.Tests.csproj
dotnet test src/09-most/03-struktura-gof/Tests/Examples.Tests.csproj
dotnet test src/09-most/04-implementacje-i-warianty/Tests/Examples.Tests.csproj
dotnet test src/09-most/05-wiekszy-przyklad-i-alternatywy/Tests/Examples.Tests.csproj
dotnet test src/09-most/06-most-w-bibliotekach-standardowych/Tests/Examples.Tests.csproj
```

## Problemy i ryzyka przy stosowaniu Most

1. Mylenie Mostu z Adaptorem i Strategia.
2. Przedwczesne projektowanie dwoch osi zmiennosci.
3. Przeciek implementacji do warstwy Abstraction.
4. Hard-coded implementor zamiast DI lub fabryki.

## Literatura

1. GoF, Design Patterns, rozdzial Bridge.
2. Refactoring.Guru (Bridge): https://refactoring.guru/design-patterns/bridge
3. Martin Fowler, Isolating domain from infrastructure: https://martinfowler.com/
4. Microsoft Docs, ILogger: https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger

## Zadania

Zbiorczy zestaw zadan i rozwiazan: [ZADANIA.md](ZADANIA.md)
