# 03. Struktura GoF wzorca Most

## Cel tematu

Poznać formalną strukturę GoF i przepływ wywołań.

## Role

1. Abstraction - interfejs domenowy dla klienta.
2. RefinedAbstraction - rozszerzone operacje domenowe.
3. Implementor - kontrakt techniczny.
4. ConcreteImplementor - konkretne wykonanie.

## Diagram klas

![Bridge class](diagrams/bridge_class.png)

Źródło: [diagrams/01-class.puml](diagrams/01-class.puml)

## Diagram sekwencji

![Bridge sequence](diagrams/bridge_sequence.png)

Źródło: [diagrams/02-sequence.puml](diagrams/02-sequence.puml)

## Cykl życia obiektów

![Bridge lifecycle](diagrams/bridge_lifecycle_topic03.png)

Źródło: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program pokazuje klasyczną strukturę GoF na prostym API raportowym.

## Uruchom

```bash
cd src/09-most/03-struktura-gof/Examples
dotnet run
```

## Zadania z rozwiązaniami

1. Dodaj RefinedAbstraction PremiumReport.
Rozwiązanie: nowa klasa po stronie abstrakcji, bez zmian implementorów.

2. Dodaj CsvReportImplementor.
Rozwiązanie: nowa klasa implementora, bez zmian Abstraction.
