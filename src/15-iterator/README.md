# Wzorzec Iterator (Iterator)

## Cel modułu

Ten moduł zawiera komplet materiałów dydaktycznych do wykładu o wzorcu **Iterator**.  
Iterator umożliwia sekwencyjny dostęp do elementów kolekcji **bez ujawniania jej wewnętrznej struktury**. Jest fundamentem całego modelu kolekcji w .NET (`IEnumerable<T>`, `foreach`, LINQ).

## Spis tematów

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Rys historyczny, problem enkapsulacji kolekcji, koncepcja wzorca |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować | Sygnały decyzyjne, zalety, wady, odmiany wzorca |
| [03](03-struktura-i-dzialanie/README.md) | Struktura i działanie | Role GoF, diagramy klas i sekwencji, konsekwencje stosowania |
| [04](04-typy-implementacji/README.md) | Typy implementacji | Pull, push, lazy (yield), LINQ, kursor — jak wybrać |
| [05](05-iterator-aktywny-vs-pasywny/README.md) | Aktywny vs pasywny | Porównanie modeli, technologie, `IObservable` |
| [06](06-iterator-wewnetrzny/README.md) | Iterator wewnętrzny | Koncepcja, implementacja, wady i zalety |
| [07](07-wady-i-zalety/README.md) | Wady i zalety | Analiza stosowania w różnych sytuacjach |
| [08](08-duzy-przyklad-i-alternatywy/README.md) | Duży przykład | Katalog biblioteki — pełny przykład z testami i alternatywami |

## Efekty uczenia

Po przerobieniu modułu student:

1. Rozumie problem ścisłego powiązania klienta ze strukturą kolekcji.
1. Potrafi zaprojektować role `Iterator`, `ConcreteIterator`, `Aggregate`, `ConcreteAggregate`.
1. Zna różnicę między iteratorem aktywnym (zewnętrznym) a pasywnym (wewnętrznym).
1. Potrafi implementować `IEnumerable<T>` / `IEnumerator<T>` oraz generator `yield return`.
1. Rozumie związek wzorca Iterator z LINQ, `foreach` i `IObservable<T>`.
1. Wie kiedy użyć wzorca, a kiedy sięgnąć po alternatywy (LINQ, Visitor, Composite).

## Jak korzystać z modułu

1. Pracuj sekwencyjnie od 01 do 08.
1. W każdym temacie przeczytaj README, obejrzyj diagramy i uruchom kod C#.
1. Na koniec wykonaj zadania z [ZADANIA.md](ZADANIA.md).

## Uruchamianie przykładów

```bash
cd src/15-iterator/01-idea-i-kontekst/Examples && dotnet run
cd src/15-iterator/02-kiedy-stosowac-zalety-wady/Examples && dotnet run
cd src/15-iterator/03-struktura-i-dzialanie/Examples && dotnet run
cd src/15-iterator/04-typy-implementacji/Examples && dotnet run
cd src/15-iterator/05-iterator-aktywny-vs-pasywny/Examples && dotnet run
cd src/15-iterator/06-iterator-wewnetrzny/Examples && dotnet run
cd src/15-iterator/07-wady-i-zalety/Examples && dotnet run
cd src/15-iterator/08-duzy-przyklad-i-alternatywy/Examples && dotnet run
```

## Uruchamianie testów

```bash
cd src/15-iterator/08-duzy-przyklad-i-alternatywy/Tests && dotnet test
```

## Materiały prowadzącego

Szczegółowy scenariusz wykładu: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Zadania

Zadania wraz z rozwiązaniami i omówieniem: [ZADANIA.md](ZADANIA.md)

## Literatura i źródła

1. Gamma E., Helm R., Johnson R., Vlissides J. — *Design Patterns: Elements of Reusable Object-Oriented Software* (1994), rozdział Iterator — s. 257–271.
1. Freeman E., Robson E. — *Head First Design Patterns* (2004/2020), rozdz. 9 — *The Iterator and Composite Patterns*.
1. Microsoft Docs — [Iterators (C#)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators)
1. Microsoft Docs — [IEnumerable\<T\>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)
1. Skeet J. — *C# in Depth*, 4th ed. (2019), rozdz. 6 — *Implementing iterators the easy way with yield*.
