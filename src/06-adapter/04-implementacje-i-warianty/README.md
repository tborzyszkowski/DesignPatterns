# 04. Implementacje i warianty Adaptera

## Typy implementacji

1. Adapter przez kompozycję (Object Adapter):

- preferowany w C#,
- adapter zawiera instancję adaptee.

1. Adapter przez dziedziczenie (Class Adapter):

- wymaga dziedziczenia po adaptee,
- mniejsza elastyczność, bo silniejsze sprzężenie.

## Diagramy

![Object vs Class Adapter](diagrams/object_vs_class_adapter.png)

Źródło: [diagrams/01-object-vs-class.puml](diagrams/01-object-vs-class.puml)

![Rys historyczny](diagrams/adapter_history.png)

Źródło: [diagrams/02-history.puml](diagrams/02-history.puml)

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

Przykład porównuje oba podejścia i wypisuje wynik mapowania.
