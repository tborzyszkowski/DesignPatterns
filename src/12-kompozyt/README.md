# Wzorzec Kompozyt (Composite)

## Cel modułu

Ten moduł zawiera komplet materiałów dydaktycznych do wykładu o wzorcu Kompozyt.
Koncentruje się na modelowaniu relacji część-całość w strukturach drzewiastych i na jednolitym traktowaniu obiektów prostych oraz złożonych.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Rys historyczny, potrzeby i geneza wzorca |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować | Sygnały decyzyjne, zalety i wady |
| [03](03-struktura-gof-i-jak-dziala/README.md) | Jak działa | Role, diagram klas i sekwencji, przepływ wywołań |
| [04](04-typy-implementacji-i-wybor/README.md) | Typy implementacji | Warianty Composite i schemat wyboru |
| [05](05-duzy-przyklad-system-plikow/README.md) | Duży przykład | Rozbudowany system plików z analizą decyzji |
| [06](06-alternatywy-i-kiedy-nie/README.md) | Alternatywy | Kiedy użyć innego wzorca i dlaczego |

## Efekty uczenia

Po przerobieniu modułu student:

1. Rozumie problem, który rozwiązuje Kompozyt.
1. Potrafi zaprojektować role `Component`, `Leaf` i `Composite`.
1. Umie implementować operacje rekurencyjne i iteracyjne na drzewie.
1. Potrafi dobrać wariant implementacji do potrzeb projektu.
1. Rozpoznaje przypadki, w których warto wybrać inny wzorzec.

## Jak korzystać z modułu

1. Pracuj sekwencyjnie od 01 do 06.
1. W każdym temacie przeczytaj README, obejrzyj diagramy i uruchom kod C#.
1. Na koniec wykonaj zadania z [ZADANIA.md](ZADANIA.md) i porównaj z rozwiązaniami.

## Uruchamianie przykładów

```bash
cd src/12-kompozyt/01-idea-i-kontekst/Examples && dotnet run
cd src/12-kompozyt/02-kiedy-stosowac-zalety-wady/Examples && dotnet run
cd src/12-kompozyt/03-struktura-gof-i-jak-dziala/Examples && dotnet run
cd src/12-kompozyt/04-typy-implementacji-i-wybor/Examples && dotnet run
cd src/12-kompozyt/05-duzy-przyklad-system-plikow/Examples && dotnet run
cd src/12-kompozyt/06-alternatywy-i-kiedy-nie/Examples && dotnet run
```

## Materiały prowadzącego

Szczegółowy scenariusz wykładu: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Zadania

Zadania wraz z rozwiązaniami i omówieniem: [ZADANIA.md](ZADANIA.md)

## Literatura i źródła

1. GoF, Design Patterns, rozdział Composite.
1. Refactoring.Guru: https://refactoring.guru/design-patterns/composite
1. Microsoft Learn, interfejsy kolekcji .NET: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
1. Martin Fowler, Collection Pipeline (kontekst operacji na drzewach): https://martinfowler.com/articles/collection-pipeline/
