# Wzorzec Strategia (Strategy)

## Cel modułu

Ten moduł zawiera komplet materiałów dydaktycznych do wykładu o wzorcu **Strategia** (Strategy).  
Wzorzec definiuje **rodzinę algorytmów**, hermetyzuje każdy z nich i sprawia, że są one wymienne. Pozwala algorytmowi zmieniać się niezależnie od klientów, którzy go używają. Jest jednym z fundamentów zasady **Open/Closed** i wzorcem powszechnie stosowanym w bibliotekach .NET.

## Spis tematów

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Rys historyczny, problem warunkowej logiki, koncepcja wzorca |
| [02](02-kiedy-stosować-zalety-wady/README.md) | Kiedy stosować | Sygnały decyzyjne, zalety, wady, odmiany wzorca |
| [03](03-struktura-i-działanie/README.md) | Struktura i działanie | Rolę GoF, diagramy klas i sekwencji, konsekwencje stosowania |
| [04](04-typy-implementacji/README.md) | Typy implementacji | Interfejs, klasa abstrakcyjna, delegaty, hybrydy i schemat wyboru |
| [05](05-wady-i-zalety/README.md) | Wady i zalety | Analiza — OCP, SRP, testowalność, pułapki i alternatywy |
| [06](06-duży-przykład-i-alternatywy/README.md) | Duży przykład | System zamówień e-commerce — pełny przykład z testami i alternatywami |

## Efekty uczenia

Po przerobieniu modułu student:

1. Rozumie problem eksplozji warunków `if/switch` przy wyborze algorytmu.
1. Potrafi zaprojektować rolę `Context`, `IStrategy` i `ConcreteStrategy`.
1. Zna różnicę między strategią a metodą szablonową i wie kiedy wybrać każdą.
1. Rozumie zastosowanie wzorca w bibliotece .NET (`IComparer<T>`, LINQ, `IEqualityComparer<T>`).
1. Potrafi zaimplementować strategię jako interfejs, klasę abstrakcyjną oraz delegat (`Func<>`).
1. Oceni kiedy wzorzec Strategia nadmiernie komplikuje rozwiązanie.

## Jak korzystać z modułu

1. Pracuj sekwencyjnie od 01 do 06.
1. W każdym temacie przeczytaj README, obejrzyj diagramy i uruchom kod C#.
1. Na koniec wykonaj zadania z [ZADANIA.md](ZADANIA.md).

## Uruchamianie przykładów

```bash
cd src/17-strategia/01-idea-i-kontekst/Examples && dotnet run
cd src/17-strategia/02-kiedy-stosować-zalety-wady/Examples && dotnet run
cd src/17-strategia/03-struktura-i-działanie/Examples && dotnet run
cd src/17-strategia/04-typy-implementacji/Examples && dotnet run
cd src/17-strategia/05-wady-i-zalety/Examples && dotnet run
cd src/17-strategia/06-duży-przykład-i-alternatywy/Examples && dotnet run
```

## Uruchamianie testów

```bash
cd src/17-strategia/06-duży-przykład-i-alternatywy/Tests && dotnet test --nologo
```

## Literatura i źródła

1. **GoF** — Gamma, Helm, Johnson, Vlissides: *Design Patterns: Elements of Reusable Object-Oriented Software*, Addison-Wesley 1994, s. 315–323 — oryginalne omówienie wzorca Strategia.
1. **Freeman & Freeman** — *Head First Design Patterns*, O'Reilly 2004, rozdz. 1 — tu właśnie zaczyna się cała książka od wzorca Strategia (kaczki z zachowaniami).
1. **Martin** — Robert C. Martin: *Agile Software Development*, rozdz. 12 (Open-Closed Principle) — Strategia jako wzorcowa implementacja OCP.
1. **RefactoringGuru** — https://refactoring.guru/design-patterns/strategy — szczegółowy opis z przykładami C# i Java.
1. **SourceMaking** — https://sourcemaking.com/design_patterns/strategy — alternatywny opis z przykładami.
1. **Microsoft .NET Docs** — https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 — `IComparer<T>` jako wbudowany wzorzec Strategia.
