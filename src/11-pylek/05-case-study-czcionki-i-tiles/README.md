# 05. Case study: czcionki i tiles

## Cel rozdzialu

Zobaczyc dwa realistyczne scenariusze, gdzie Flyweight daje duzy zwrot: renderowanie znakow i mapy kafelkowe.

## Scenariusz A: znaki tekstu

Problem:

1. Dokument zawiera bardzo duzo znakow.
1. Kazdy znak przechowuje podobne metryki glifu.

Podejscie Flyweight:

1. Jeden flyweight na typ glifu (np. `A`, `B`, `C`).
1. Pozycja i rozmiar to extrinsic state podawany przy renderowaniu.

## Scenariusz B: tiles w grze

Problem:

1. Mapa ma miliony komorek.
1. Typ kafelka (trawa, woda, piasek) czesto sie powtarza.

Podejscie Flyweight:

1. Flyweight trzyma wspolna reprezentacje typu kafelka.
1. Klient przekazuje wspolrzedne i stan runtime jako extrinsic.

## Jak prowadzic demo

1. Uruchom wersje naiwna i policz liczbe instancji.
1. Uruchom wersje flyweight i policz unikalne obiekty.
1. Porownaj pamiec i czas inicjalizacji.

## Diagram interakcji

![Diagram interakcji](diagrams/flyweight_case_sequence.png)

Zrodlo: [diagrams/01-case-sequence.puml](diagrams/01-case-sequence.puml)

## Wnioski

1. Najwiekszy zysk jest przy duzej liczbie podobnych elementow.
1. Kluczowe jest poprawne zaprojektowanie klucza i granicy intrinsic/extrinsic.
