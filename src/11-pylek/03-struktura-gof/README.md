# 03. Struktura GoF Flyweight

## Szczegolowy opis

Wzorzec Pylek definiuje mechanizm wspoldzielenia obiektow, aby zmniejszyc liczbe instancji i zuzycie pamieci.

## Role we wzorcu

1. `Flyweight` - interfejs operacji przyjmujacy extrinsic state.
1. `ConcreteFlyweight` - przechowuje intrinsic state.
1. `FlyweightFactory` - zwraca istniejacy flyweight lub tworzy nowy.
1. `Client` - przechowuje/extrahuje extrinsic state i wywoluje operacje.

Jak dziala wspolpraca rol:

1. `Client` prosi `FlyweightFactory` o obiekt po kluczu intrinsic.
1. Factory sprawdza cache i zwraca istniejacy flyweight lub tworzy nowy.
1. `Client` wywoluje operacje na flyweight, przekazujac extrinsic state.
1. `ConcreteFlyweight` laczy intrinsic z extrinsic tylko na czas operacji.

## Diagramy

### Diagram klas

Zrodlo: [diagrams/01-class.puml](diagrams/01-class.puml)

### Diagram sekwencji

Zrodlo: [diagrams/02-sequence.puml](diagrams/02-sequence.puml)

## Praktyczne konsekwencje

1. Mniej instancji i mniejsze zuzycie pamieci.
1. Wyzsza zlozonosc modelu przez rozdzielenie stanu.
1. Koniecznosc dbania o niemutowalnosc intrinsic.
