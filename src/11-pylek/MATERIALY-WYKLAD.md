# Materialy wykladowe - Pylek (90 minut)

## Cel spotkania

Pokazac, jak ograniczyc zuzycie pamieci przez wspoldzielenie stanu i jak ocenic, czy koszt dodatkowej zlozonosci jest uzasadniony.

## Agenda 90 minut

1. 0-10 min: Problem i motywacja.
1. 10-25 min: Definicja Flyweight i intuicja intrinsic/extrinsic.
1. 25-40 min: Struktura GoF i przeplyw wywolan.
1. 40-60 min: Live coding C# (factory + cache).
1. 60-75 min: Case study (czcionki, tiles) + analiza pamieci.
1. 75-85 min: Kiedy nie stosowac + porownanie z Object Pool.
1. 85-90 min: Podsumowanie i Q&A.

## Narracja prowadzacego

### 1) Problem

1. W systemie wystepuja setki tysiecy/miliony obiektow o podobnej strukturze.
1. Tworzenie pelnych instancji mnozy zuzycie pamieci i presje na GC.
1. Pytanie: co mozemy wspoldzielic bez utraty poprawnosci?

### 2) Kluczowa idea

1. `Intrinsic state` - niezmienny i wspolny.
1. `Extrinsic state` - zalezny od kontekstu i przekazywany przy wywolaniu.
1. Flyweight przechowuje tylko intrinsic.

### 3) Punkt kontrolny dla grupy

Zadaj pytanie: "Ktore pola naszego obiektu sa stale dla wielu rekordow, a ktore zalezne od konkretnej operacji?"

### 4) Live demo

1. Wersja naiwna: tworzenie duzej liczby obiektow.
1. Wersja flyweight: factory + cache.
1. Odczyt metryk: liczba unikalnych obiektow i orientacyjne zuzycie pamieci.

### 5) Decyzja architektoniczna

Stosuj Flyweight, gdy:

1. Liczba obiektow jest bardzo duza.
1. Istnieje wyrazny, wspolny, niemutowalny fragment stanu.
1. Koszt utrzymania factory i cache jest mniejszy niz zysk pamieci.

Nie stosuj, gdy:

1. Obiektow jest malo.
1. Stan jest glownie extrinsic i slabo wspoldzielony.
1. Kod staje sie trudny do utrzymania bez realnego zysku.

## Material do tablicy/slajdow

1. Definicja Flyweight (1 zdanie).
1. Schemat: Client -> Factory -> Flyweight.
1. Roznica Flyweight vs Object Pool.
1. Lista ryzyk: mutowalny intrinsic, niekontrolowany cache, bledna granica stanu.

## FAQ

1. Czy Flyweight to cache? Czesciowo tak, ale cel jest stricte redukcja pamieci przez wspoldzielenie reprezentacji.
1. Czy Flyweight i Object Pool to to samo? Nie. Pool recyklinguje obiekty zywe czasowo, Flyweight wspoldzieli obiekty logicznie rownowazne.
1. Czy moge modyfikowac flyweight? Nie powinienes, bo zlamiesz wspoldzielenie.
