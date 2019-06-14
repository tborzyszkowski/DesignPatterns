# Piotr Kawa - sklep z grami/konsolami
Projekt posiada stworzony przykładowy sklep z grami, w którym możemy zamówić customowe
kompozycje  gra + konsola. Przyjęte zamówienie jest składane do fabryki i przekazywane
klientowi. Fabryki są także w stanie informować sklepy o nowo wydanych grach, tak,
aby te udostępniły je do sprzedaży klientom.

## Użyte wzorce:

### Kreacyjne:
* Budowniczy (pkawa.builder) - zagnieżdżona klasa ConsoleBox w GameStore
* Fabryka abstrakcyjna (pkawa.abstractfactory) - fabryki tworzące gry/konsole
* Singleton (pkawa.abstractfactory.impl.*) - implementacje fabryk, etc.
### Strukturalne:
* Dekorator - przykładowy dekorator stworzony dla 
* Fasada - nałożona na klasę GameStore - pozwala wykonywać złożone operacje jak
inicjalizacja łańcucha zobowiązań, wydawanie przez fabrykę gry, i informowanie o
dostępności sklepu, etc.

### Czynnościowe:
* Obserwator (pkawa.observer) - Klasa ShopData zbierająca informacje o dostępnych grach,
przydatna np przy kolekcjonowaniu zamówienia przez Buildera sklepowego
* Łańcuch zobowiązań (używany w builderze do podawania odpowiedniej implementacji fabryki
bazując na rodzinie konsol, inicjowany w fasadzie)