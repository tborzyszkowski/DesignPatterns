# 05. Kiedy nie stosować Adaptera i jakie są alternatywy

## Kiedy Adapter to zły wybór

1. Gdy oba systemy możesz zmienić i prościej ujednolicić kontrakt.
2. Gdy pojawia się wielowarstwowy łańcuch adapterów.
3. Gdy mapowanie zaciera semantykę danych i utrudnia testowanie.

## Alternatywy

- Facade: uproszczenie API bez translacji semantycznej.
- Anti-Corruption Layer: większa warstwa izolacji między bounded contexts.
- Refaktoryzacja kontraktu: najczystsza opcja, jeśli obie strony są pod kontrolą.

## Diagramy

![Decyzja adapter czy nie](diagrams/01-decision-not-use.png)

Źródło: [diagrams/01-decision-not-use.puml](diagrams/01-decision-not-use.puml)

![Alternatywy](diagrams/02-alternatives-map.png)

Źródło: [diagrams/02-alternatives-map.puml](diagrams/02-alternatives-map.puml)

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

Przykład pokazuje trzy ścieżki: adapter, facade i bezpośrednia refaktoryzacja kontraktu.
