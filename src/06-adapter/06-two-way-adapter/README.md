# 06. Two Way Adapter

## O co chodzi

Two Way Adapter implementuje dwa interfejsy jednocześnie i pozwala używać jednego obiektu w dwóch kierunkach integracji.

## Zastosowanie

- migracje systemów, gdzie stary i nowy interfejs muszą działać równolegle,
- kompatybilność wsteczna API,
- scenariusze, gdzie moduł bywa klientem i serwerem różnych kontraktów.

## Historia

Wariant pojawił się jako rozszerzenie klasycznego Adaptera przy projektach modernizacyjnych legacy, gdy jedna translacja nie wystarczała.

## Diagramy

![Two way class](diagrams/two_way_class.png)

Źródło: [diagrams/01-two-way-class.puml](diagrams/01-two-way-class.puml)

![Two way sequence](diagrams/two_way_sequence.png)

Źródło: [diagrams/02-two-way-sequence.puml](diagrams/02-two-way-sequence.puml)

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

Przykład mapuje obiekt `Seabird` jako `IAircraft` i `ISeacraft`.
