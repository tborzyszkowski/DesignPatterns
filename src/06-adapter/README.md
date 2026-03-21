# Wzorzec Adapter

> Kategoria: Strukturalny (GoF)

## Definicja

Adapter pozwala współpracować klasom o niekompatybilnych interfejsach bez modyfikowania ich kodu źródłowego. W praktyce działa jak "tłumacz" pomiędzy API klienta i API istniejącego komponentu.

## Spis treści

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Motywacja, potrzeby i historia wzorca |
| [02](02-kiedy-stosowac/README.md) | Kiedy stosować | Kryteria, sygnały i metryki decyzji |
| [03](03-struktura-gof/README.md) | Struktura GoF | Diagram klas i sekwencji, cykl życia adaptera |
| [04](04-implementacje-i-warianty/README.md) | Implementacje i warianty | Adapter przez kompozycję i dziedziczenie |
| [05](05-kiedy-nie-i-alternatywy/README.md) | Kiedy nie i alternatywy | Over-engineering, antywzorce i decyzje architektoniczne |
| [06](06-two-way-adapter/README.md) | Two Way Adapter | Jedna klasa udostępnia dwa kierunki adaptacji |
| [07](07-pluggable-adapter/README.md) | Pluggable Adapter | Dynamiczne podpinanie adapterów strategią/rejestrem |

## Jak uruchomić przykłady

```bash
cd src/06-adapter/01-idea-i-kontekst/Examples && dotnet run
cd src/06-adapter/02-kiedy-stosowac/Examples && dotnet run
cd src/06-adapter/03-struktura-gof/Examples && dotnet run
cd src/06-adapter/04-implementacje-i-warianty/Examples && dotnet run
cd src/06-adapter/05-kiedy-nie-i-alternatywy/Examples && dotnet run
cd src/06-adapter/06-two-way-adapter/Examples && dotnet run
cd src/06-adapter/07-pluggable-adapter/Examples && dotnet run
```

## Problemy i ryzyka przy stosowaniu Adaptera

1. Nadmiar adapterów może ukrywać zły kontrakt domenowy zamiast go naprawiać.
2. Łańcuch adapterów utrudnia debugowanie i diagnozę błędów.
3. Brak testów kontraktowych prowadzi do cichych błędów mapowania danych.
4. Adapter bywa wykorzystywany jako "tymczasowy patch" i zostaje na stałe.

## Zadania

Pełna lista zadań i rozwiązań: [ZADANIA.md](ZADANIA.md)

## Literatura

| Źródło | Zakres |
| --- | --- |
| [Refactoring Guru - Adapter](https://refactoring.guru/design-patterns/adapter) | definicja i podstawowy model |
| [SourceMaking - Adapter](https://sourcemaking.com/design_patterns/adapter) | warianty i relacje ze wzorcami |
| GoF, Design Patterns (1994) | formalny opis wzorca |
| [Martin Fowler - Gateway](https://martinfowler.com/articles/refactoring-external-service.html) | praktyczne granice adaptera w integracjach |
