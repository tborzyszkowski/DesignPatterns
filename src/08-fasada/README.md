# Wzorzec Fasada (Facade)

## Cel modułu

Ten moduł zawiera komplet materiałów dydaktycznych do wykładu o wzorcu Fasada w języku C#.
Każdy temat ma osobny katalog z:

1. szczegółowym `README.md`,
2. uruchamialnym kodem .NET (`Examples`),
3. diagramami PlantUML (`diagrams/*.puml` + `*.png`),
4. zadaniami dla studentów wraz z rozwiązaniami i wyjaśnieniami.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Potrzeby, rys historyczny, ujednolicanie API, ACL, bezpieczeństwo |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować | Heurystyki, zalety, wady, antyprzykłady |
| [03](03-struktura-i-dzialanie/README.md) | Struktura i działanie | Role, diagram klas i sekwencji, przepływ wywołań |
| [04](04-typy-implementacji/README.md) | Typy implementacji | Różne style implementacji i schemat wyboru |
| [05](05-wiekszy-przyklad-i-alternatywy/README.md) | Większy przykład | End-to-end scenariusz, alternatywy i kryteria decyzji |
| [06](06-fasady-w-bibliotekach-standardowych/README.md) | Fasady w bibliotekach | Przykłady z BCL/ASP.NET i ich interpretacja |

## Jak uruchamiać przykłady

```bash
cd src/08-fasada/01-idea-i-kontekst/Examples && dotnet run
cd src/08-fasada/02-kiedy-stosowac-zalety-wady/Examples && dotnet run
cd src/08-fasada/03-struktura-i-dzialanie/Examples && dotnet run
cd src/08-fasada/04-typy-implementacji/Examples && dotnet run
cd src/08-fasada/05-wiekszy-przyklad-i-alternatywy/Examples && dotnet run
cd src/08-fasada/06-fasady-w-bibliotekach-standardowych/Examples && dotnet run
```

## Literatura i źródła

1. GoF, *Design Patterns*, rozdział Facade.
2. Refactoring.Guru (Facade): https://refactoring.guru/design-patterns/facade
3. Martin Fowler, *Anti-Corruption Layer*: https://martinfowler.com/bliki/AntiCorruptionLayer.html
4. Microsoft Docs, `HttpClient`: https://learn.microsoft.com/dotnet/api/system.net.http.httpclient
5. Microsoft Docs, `ILogger`: https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger

## Zadania przekrojowe

Zbiorczy zestaw zadań (z rozwiązaniami): [ZADANIA.md](ZADANIA.md)
