# Zadania - Wzorzec Pylek

## Zadanie 1 (podstawowe)

Zaprojektuj prosty `IconFactory`, ktory zwraca wspoldzielone ikony po kluczu (`type`, `color`).

Kryteria:

1. Brak duplikatow flyweight dla tego samego klucza.
1. Kod klienta przekazuje pozycje ikony jako extrinsic state.
1. Pokaz liczbe utworzonych flyweightow.

## Zadanie 2 (srednie)

Rozszerz przyklad o bezpieczenstwo wspolbieznosci (`ConcurrentDictionary`).

Kryteria:

1. Poprawne dzialanie pod obciazeniem wielowatkowym.
1. Brak race condition podczas tworzenia nowego flyweight.
1. Test lub scenariusz, ktory pokazuje stabilny wynik.

## Zadanie 3 (zaawansowane)

Porownaj trzy podejscia:

1. Bez Flyweight.
1. Flyweight z silnym cache.
1. Flyweight z `WeakReference`.

Kryteria:

1. Tabela porownawcza pamieci i czasu.
1. Opis ryzyk i kompromisow kazdego podejscia.
1. Wniosek, ktore podejscie jest najlepsze dla Twojego scenariusza.

## Pytania kontrolne

1. Co jest intrinsic, a co extrinsic w Twoim modelu?
1. Co sie stanie, jesli intrinsic bedzie mutowalny?
1. Czym Flyweight rozni sie od Object Pool?
