# 01. Idea i kontekst

## Cel rozdzialu

Zrozumiec, jaki problem pamieciowy rozwiazuje wzorzec Pylek i dlaczego sama optymalizacja algorytmu nie zawsze wystarcza.

## Problem

W wielu systemach tworzymy ogromna liczbe obiektow o bardzo podobnej strukturze.
Przyklady:

1. Znaki tekstu w edytorze.
1. Kafelki mapy w grze.
1. Ikony na dashboardzie.

Jesli kazdy obiekt przechowuje caly stan, to:

1. Rosnie zuzycie pamieci.
1. Rosnie presja na GC.
1. Spada przewidywalnosc wydajnosci.

## Intuicja wzorca Pylek

1. Oddzielamy czesc wspolna (intrinsic) od kontekstowej (extrinsic).
1. Czesc wspolna jest tworzona raz i wspoldzielona.
1. Czesc kontekstowa jest przekazywana przez klienta przy wywolaniu.

## Minimalny scenariusz

Zamiast 1 000 000 obiektow `Glyph` z duplikatami czcionki i ksztaltu:

1. Tworzymy male repozytorium unikalnych flyweightow.
1. Klient przekazuje pozycje, rozmiar i kolor jako extrinsic state.

## Co student powinien zapamietac

1. Flyweight optymalizuje pamiec, nie semantyke domeny.
1. Nie kazdy projekt zyska na tym wzorcu.
1. Najpierw analiza modelu i metryki, potem implementacja.
