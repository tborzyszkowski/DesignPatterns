# Projekt  na zaliczenie

## Strukturalne

* dekorator - logowanie
* adapter - sterownanie silnikiem
* proxy

## Behawioralne
* obserwator - sledzenie zmian polozenia
* mediator - reczne/automatyczne sterowanie obrotem kamery

## Kreatywne
* singleton - dostep do kamery


Program wyszukuje twarzy i oczu na obrazie z kamery. Podejmuje probe okreslenia czy osoba sie usmiecha, czy tez nie.
Jesli twarz nie jest na srodku ekranu, program sterujac dwoma serwomechanizmami przesuwa odpowiednio kamere.
Silniczki podlaczone sa do portow GPIO Raspberry Pi. Aby moc przedstawic dzialalajcy program - zamiast wysylac sygnaly
 na porty GPIO program wysyla informacje o zamiarze wykonania operacji na konsole.

