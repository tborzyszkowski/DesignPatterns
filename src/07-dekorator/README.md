# Wzorzec Dekorator (Decorator)

## Cel modułu

Ten moduł zawiera materiały wykładowe i ćwiczeniowe do wzorca Dekorator w C#.
Materiały są podzielone na tematy, każdy z własnym kodem, diagramami PlantUML i zadaniami z rozwiązaniami.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Geneza, potrzeby i rys historyczny wzorca |
| [02](02-kiedy-stosowac/README.md) | Kiedy stosować | Kryteria, zalety/wady, pomiar narzutu |
| [03](03-struktura-gof/README.md) | Struktura GoF | Role, diagram klas i sekwencji, przepływ |
| [04](04-implementacje-i-typy/README.md) | Implementacje i typy | Klasyczny, funkcyjny i pipeline/DI |
| [05](05-kawiarnia-starbuzz/README.md) | Starbuzz Coffee | Większy przykład z komentarzem i alternatywami |
| [06](06-dekoratory-bcl-stream/README.md) | Dekoratory w BCL | `Stream`, `BufferedStream`, `GZipStream` |

## Jak uruchamiać przykłady

```bash
cd src/07-dekorator/01-idea-i-kontekst/Examples && dotnet run
cd src/07-dekorator/02-kiedy-stosowac/Examples && dotnet run
cd src/07-dekorator/03-struktura-gof/Examples && dotnet run
cd src/07-dekorator/04-implementacje-i-typy/Examples && dotnet run
cd src/07-dekorator/05-kawiarnia-starbuzz/Examples && dotnet run
cd src/07-dekorator/06-dekoratory-bcl-stream/Examples && dotnet run
```

## Literatura

- GoF, Design Patterns (Decorator)
- Refactoring.Guru: https://refactoring.guru/design-patterns/decorator
- Microsoft Docs Stream: https://learn.microsoft.com/dotnet/api/system.io.stream
- Head First Design Patterns (Starbuzz Coffee)

## Zadania

Zbiorczy zestaw zadań i rozwiązań: [ZADANIA.md](ZADANIA.md)
