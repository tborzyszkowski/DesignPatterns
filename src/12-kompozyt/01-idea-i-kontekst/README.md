# 01. Idea i kontekst

## Cel rozdziału

Zrozumieć skąd wziął się wzorzec Kompozyt, jakie potrzeby adresuje i dlaczego jest tak często stosowany w strukturach drzewiastych.

## Rys historyczny

1. Przed formalizacją GoF podobne podejścia stosowano w systemach GUI i edytorach dokumentów.
1. W 1994 roku GoF opisało Composite jako wzorzec strukturalny dla relacji część-całość.
1. Współcześnie wzorzec jest podstawą m.in. w DOM, AST, systemach plików i drzewach sceny.

## Szczegółowy opis koncepcji

Kompozyt pozwala traktować obiekty proste (`Leaf`) i złożone (`Composite`) przez wspólny interfejs (`Component`).
Dzięki temu klient nie musi wiedzieć, czy operuje na pojedynczym elemencie, czy na całym poddrzewie.

Potrzeby, które zaspokaja wzorzec:

1. Jednolity interfejs dla różnych poziomów hierarchii.
1. Rekurencyjne operacje na strukturze bez rozgałęzionego kodu klienta.
1. Łatwe dokładanie nowych gałęzi drzewa bez przebudowy logiki wywołań.

## Diagramy

### Problem i motywacja

![Problem i motywacja](diagrams/composite_problem_context.png)

Źródło: [diagrams/01-problem-context.puml](diagrams/01-problem-context.puml)

### Cykl życia wywołania

![Cykl życia wywołania](diagrams/composite_lifecycle.png)

Źródło: [diagrams/02-lifecycle-sequence.puml](diagrams/02-lifecycle-sequence.puml)

## Przykładowy program C#

Kod: [Examples/Program.cs](Examples/Program.cs)

```csharp
INode root = DemoTree.Build();
root.Print();
```

Jak działa:

1. `Build()` tworzy drzewo katalogów i plików.
1. `Print()` wywołane na korzeniu przechodzi przez całe poddrzewo.
1. Klient używa tylko interfejsu `INode`, bez wiedzy o szczegółach klas.

Uruchom:

```bash
cd src/12-kompozyt/01-idea-i-kontekst/Examples
dotnet run
```

## Literatura

1. GoF, Design Patterns, Composite.
1. Refactoring.Guru: https://refactoring.guru/design-patterns/composite
