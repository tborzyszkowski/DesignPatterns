# Wzorzec Obserwator (Observer)

## Cel modułu

Ten moduł zawiera komplet materiałów dydaktycznych do wykładu o wzorcu Obserwator.
Koncentruje się na modelowaniu relacji jeden-do-wielu między obiektami, gdzie zmiana stanu jednego obiektu powoduje automatyczne powiadamianie i aktualizację wszystkich zależnych obiektów.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Rys historyczny, geneza wzorca, potrżeby które zaspokaja |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować | Sygnały decyzyjne, zalety, wady i procedura decyzyjna |
| [03](03-struktura-gof-i-jak-dziala/README.md) | Jak działa | Rolę GoF, diagramy klas i sekwencji, push vs pull model |
| [04](04-typy-implementacji-i-wybor/README.md) | Typy implementacji | Warianty: klasyczny, zdarzenia C#, IObservable\<T\>, wybór |
| [05](05-duzy-przyklad-i-alternatywy/README.md) | Duży przykład | Stacja pogodowa — pełny przykład z analizą i alternatywami |

## Efekty uczenia

Po przerobieniu modułu student:

1. Rozumie problem ścisłego powiązania (tight coupling) który rozwiązuje Obserwator.
1. Potrafi zaprojektować rolę `Subject` (Observable), `Observer` i zarządzać subskrypcjami.
1. Zna trzy główne warianty implementacji w C#: ręczny interfejs, zdarzenia/delegaty, `IObservable<T>`.
1. Umie wybrać odpowiedni wariant do kontekstu (prostota vs reaktywność vs interoperacyjność).
1. Rozpoznaje kiedy Obserwator jest nadmiarowy i zna alternatywy (Mediator, Message Bus, Polling).

## Jak korzystać z modułu

1. Pracuj sekwencyjnie od 01 do 05.
1. W każdym temacie przeczytaj README, obejrzyj diagramy i uruchom kod C#.
1. Na koniec wykonaj zadania z [ZADANIA.md](ZADANIA.md).

## Uruchamianie przykładów

```bash
cd src/13-obserwator/01-idea-i-kontekst/Examples && dotnet run
cd src/13-obserwator/02-kiedy-stosować-zalety-wady/Examples && dotnet run
cd src/13-obserwator/03-struktura-gof-i-jak-działa/Examples && dotnet run
cd src/13-obserwator/04-typy-implementacji-i-wybor/Examples && dotnet run
cd src/13-obserwator/05-duży-przykład-i-alternatywy/Examples && dotnet run
```

## Uruchamianie testów

```bash
cd src/13-obserwator/05-duży-przykład-i-alternatywy/Tests && dotnet test
```

## Materiały prowadzącego

Szczegółowy scenariusz wykładu: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Zadania

Zadania wraz z rozwiązaniami i omówieniem: [ZADANIA.md](ZADANIA.md)

## Literatura i źródła

1. GoF, Design Patterns (1994), rozdział Observer — s. 293–313.
1. Refactoring.Guru — Observer: https://refactoring.guru/design-patterns/observer
1. Microsoft Learn — Observer Design Pattern: https://learn.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
1. Microsoft Learn — IObservable\<T\>: https://learn.microsoft.com/en-us/dotnet/api/system.iobservable-1
1. ReactiveX / Rx.NET: https://github.com/dotnet/reactive
