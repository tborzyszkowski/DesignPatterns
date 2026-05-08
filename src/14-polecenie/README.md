# Wzorzec Polecenie (Command)

## Cel modułu

Ten moduł zawiera komplet materiałów dydaktycznych do wykładu o wzorcu Polecenie.
Koncentruje się na enkapsulacji żądań jako obiektów, co umożliwia kolejkowanie, rejestrowanie operacji, cofanie zmian (undo/redo) oraz budowanie makropoleceń.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Rys historyczny, geneza wzorca, problem który rozwiązuje |
| [02](02-kiedy-stosować-zalety-wady/README.md) | Kiedy stosować | Sygnały decyzyjne, zalety, wady, odmiany wzorca |
| [03](03-struktura-gof-i-jak-działa/README.md) | Jak działa | Rolę GoF, diagramy klas i sekwencji, struktura wzorca |
| [04](04-typy-implementacji-i-wybor/README.md) | Typy implementacji | Warianty: prosty, undo/redo, makro, asynchroniczny, delegat |
| [05](05-duży-przykład-i-alternatywy/README.md) | Duży przykład | Inteligentny dom — pełny przykład z testami i alternatywami |

## Efekty uczenia

Po przerobieniu modułu student:

1. Rozumie problem ścisłego powiązania nadawcy żądania z jego odbiorcą.
1. Potrafi zaprojektować rolę `Command`, `ConcreteCommand`, `Invoker`, `Receiver` i `Client`.
1. Zna warianty wzorca Polecenie w C#: prosty, undo/redo, makropolecenia, asynchroniczny i oparty na delegatach.
1. Umie wybrać odpowiedni wariant do kontekstu (prostota vs. pełne undo vs. reaktywność).
1. Rozpoznaje kiedy wzorzec Polecenie jest nadmiarowy i zna alternatywy (Strategia, Łańcuch Zobowiązań).

## Jak korzystać z modułu

1. Pracuj sekwencyjnie od 01 do 05.
1. W każdym temacie przeczytaj README, obejrzyj diagramy i uruchom kod C#.
1. Na koniec wykonaj zadania z [ZADANIA.md](ZADANIA.md).

## Uruchamianie przykładów

```bash
cd src/14-polecenie/01-idea-i-kontekst/Examples && dotnet run
cd src/14-polecenie/02-kiedy-stosować-zalety-wady/Examples && dotnet run
cd src/14-polecenie/03-struktura-gof-i-jak-działa/Examples && dotnet run
cd src/14-polecenie/04-typy-implementacji-i-wybor/Examples && dotnet run
cd src/14-polecenie/05-duży-przykład-i-alternatywy/Examples && dotnet run
```

## Uruchamianie testów

```bash
cd src/14-polecenie/05-duży-przykład-i-alternatywy/Tests && dotnet test
```

## Materiały prowadzącego

Szczegółowy scenariusz wykładu: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Zadania

Zadania wraz z rozwiązaniami i omówieniem: [ZADANIA.md](ZADANIA.md)

## Literatura i źródła

1. Gamma E., Helm R., Johnson R., Vlissides J. — *Design Patterns: Elements of Reusable Object-Oriented Software* (1994), rozdział Command — s. 233–242.
1. Freeman E., Freeman E. — *Head First Design Patterns* (2021), rozdział 6: The Command Pattern — s. 191–254.
1. Martin R.C. — *Agile Software Development, Principles, Patterns, and Practices* (2002), rozdział 21.
1. [Refactoring Guru — Command](https://refactoring.guru/design-patterns/command) — ilustracje i przykłady wielojęzykowe.
1. [Microsoft Docs — Command pattern in C#](https://docs.microsoft.com/en-us/dotnet/standard/design-patterns/) — przykłady .NET.
1. [SourceMaking — Command](https://sourcemaking.com/design_patterns/command) — teoria i przykłady.
