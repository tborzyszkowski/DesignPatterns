# 02. Intrinsic vs Extrinsic

## Cel rozdzialu

Nauczyc sie poprawnie dzielic stan obiektu i unikac najczestszych bledow projektowych.

## Definicje

1. `Intrinsic state` - stan wspolny, niemutowalny, wspoldzielony.
1. `Extrinsic state` - stan zalezy od kontekstu uzycia, podawany przez klienta.

## Jak dzielic stan - procedura

1. Wypisz wszystkie pola obiektu.
1. Oznacz, ktore pola sa identyczne dla wielu instancji.
1. Sprawdz, czy pola wspolne moga byc niemutowalne.
1. Pola kontekstowe usun z flyweight i przekazuj w metodzie operacyjnej.

## Przyklad: znak tekstowy

1. Intrinsic: symbol glifu, metryki czcionki, font family.
1. Extrinsic: pozycja `(x, y)`, kolor, rozmiar, warstwa.

## Typowe bledy

1. Wrzucenie mutowalnego stanu do intrinsic.
1. Zbyt duzy klucz w factory (nadmierna liczba flyweightow).
1. Brak jednoznacznej odpowiedzialnosci klienta za extrinsic state.

## Diagram pamieci

Zrodlo: [diagrams/01-memory-layout.puml](diagrams/01-memory-layout.puml)

## Checklista przed implementacja

1. Czy liczba obiektow jest wystarczajaco duza?
1. Czy intrinsic ma wysoki wspolczynnik powtarzalnosci?
1. Czy zespol rozumie konsekwencje dodatkowej warstwy factory?
