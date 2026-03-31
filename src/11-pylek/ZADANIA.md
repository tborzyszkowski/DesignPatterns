# Zadania - Wzorzec Pyłek

## Zadanie 1 (podstawowe)

Zaprojektuj prostą klasę `IconFactory`, która zwraca współdzielone ikony po kluczu (`type`, `color`).

Kryteria:

1. Brak duplikatów flyweight dla tego samego klucza.
1. Kod klienta przekazuje pozycję ikony jako extrinsic state.
1. Pokaż liczbę utworzonych flyweightów.

## Zadanie 2 (średnie)

Rozszerz przykład o bezpieczeństwo współbieżności (`ConcurrentDictionary`).

Kryteria:

1. Poprawne działanie pod obciążeniem wielowątkowym.
1. Brak race condition podczas tworzenia nowego flyweight.
1. Test lub scenariusz, który pokazuje stabilny wynik.

## Zadanie 3 (zaawansowane)

Porównaj trzy podejścia:

1. Bez Flyweight.
1. Flyweight z silnym cache.
1. Flyweight z `WeakReference`.

Kryteria:

1. Tabela porównawcza pamięci i czasu.
1. Opis ryzyk i kompromisów każdego podejścia.
1. Wniosek, które podejście jest najlepsze dla Twojego scenariusza.

## Pytania kontrolne

1. Co jest intrinsic, a co extrinsic w Twoim modelu?
1. Co się stanie, jeśli intrinsic będzie mutowalny?
1. Czym Flyweight różni się od Object Pool?
