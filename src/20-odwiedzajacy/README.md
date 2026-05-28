# Wzorzec Odwiedzający (Visitor)

> **Wzorzec behawioralny** — pozwala definiować nowe operacje na elementach struktury obiektów bez modyfikowania klas tych elementów. Operacja jest „odwiedzającym", który przechodzi przez strukturę i wykonuje działania na każdym elemencie.

## Tematy

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Problem, historia, mechanizm podwójnego przekazania |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować, zalety i wady | Sygnały wskazujące, odmiany wzorca, drzewo decyzyjne |
| [03](03-struktura-gof/README.md) | Struktura GoF | Diagram klas, sekwencji, double dispatch |
| [04](04-typy-implementacji/README.md) | Typy implementacji | Klasyczny GoF, delegaty, pattern matching, generyczny |
| [05](05-wady-zalety-alternatywy/README.md) | Wady, zalety, alternatywy | Porównanie z innymi wzorcami i technikami C# |
| [06](06-wiekszy-przyklad/README.md) | Większy przykład | Drzewo wyrażeń AST: ewaluacja, drukowanie, optymalizacja |

## Efekty kształcenia

Po ukończeniu tego modułu student:

1. Rozumie, jaki problem rozwiązuje wzorzec Odwiedzający i kiedy jest właściwym wyborem
2. Potrafi wyjaśnić mechanizm podwójnego przekazania (double dispatch)
3. Umie zaprojektować hierarchię elementów z metodą `Accept` i odpowiednie interfejsy odwiedzającego
4. Rozróżnia cztery style implementacji: klasyczny GoF, delegatowy, pattern matching, generyczny
5. Zna wady wzorca (zamknięta hierarchia elementów) i wie, kiedy wybrać alternatywę
6. Potrafi zaprojektować i przetestować własny odwiedzający z testami xUnit

## Szybki start

```bash
# Temat 01 — idea
cd src/20-odwiedzajacy/01-idea-i-kontekst/Examples && dotnet run

# Temat 02 — kiedy stosować
cd src/20-odwiedzajacy/02-kiedy-stosowac-zalety-wady/Examples && dotnet run

# Temat 03 — struktura GoF
cd src/20-odwiedzajacy/03-struktura-gof/Examples && dotnet run

# Temat 04 — typy implementacji
cd src/20-odwiedzajacy/04-typy-implementacji/Examples && dotnet run

# Temat 05 — alternatywy
cd src/20-odwiedzajacy/05-wady-zalety-alternatywy/Examples && dotnet run

# Temat 06 — większy przykład + testy
cd src/20-odwiedzajacy/06-wiekszy-przyklad/Examples && dotnet run
cd src/20-odwiedzajacy/06-wiekszy-przyklad/Tests && dotnet test
```

## Literatura

- E. Gamma, R. Helm, R. Johnson, J. Vlissides, *Design Patterns: Elements of Reusable Object-Oriented Software*, Addison-Wesley, 1994, s. 331–344
- [Visitor — refactoring.guru (PL)](https://refactoring.guru/pl/design-patterns/visitor)
- [Visitor — sourcemaking.com](https://sourcemaking.com/design_patterns/visitor)
- [Wzorzec Odwiedzający — Wikipedia PL](https://pl.wikipedia.org/wiki/Odwiedzaj%C4%85cy_(wzorzec_projektowy))
- [Double Dispatch in C# — Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression)
