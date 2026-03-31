# Materiały wykładowe - Pyłek (90 minut)

## Cel spotkania

Pokazać, jak ograniczyć zużycie pamięci przez współdzielenie stanu i jak ocenić, czy koszt dodatkowej złożoności jest uzasadniony.

## Agenda 90 minut

1. 0-10 min: Problem i motywacja.
1. 10-25 min: Definicja Flyweight i intuicja intrinsic/extrinsic.
1. 25-40 min: Struktura GoF i przepływ wywołań.
1. 40-60 min: Live coding C# (factory + cache).
1. 60-75 min: Case study (czcionki, tiles) + analiza pamięci.
1. 75-85 min: Kiedy nie stosować + porównanie z Object Pool.
1. 85-90 min: Podsumowanie i Q&A.

## Narracja prowadzącego

### 1) Problem

1. W systemie występują setki tysięcy lub miliony obiektów o podobnej strukturze.
1. Tworzenie pełnych instancji mnoży zużycie pamięci i presję na GC.
1. Pytanie: co możemy współdzielić bez utraty poprawności?

### 2) Kluczowa idea

1. `Intrinsic state` - niezmienny i wspólny.
1. `Extrinsic state` - zależny od kontekstu i przekazywany przy wywołaniu.
1. Flyweight przechowuje tylko intrinsic.

### 3) Punkt kontrolny dla grupy

Zadaj pytanie: "Które pola naszego obiektu są stałe dla wielu rekordów, a które zależne od konkretnej operacji?"

### 4) Live demo

1. Wersja naiwna: tworzenie dużej liczby obiektów.
1. Wersja flyweight: factory + cache.
1. Odczyt metryk: liczba unikalnych obiektów i orientacyjne zużycie pamięci.

### 5) Decyzja architektoniczna

Stosuj Flyweight, gdy:

1. Liczba obiektów jest bardzo duża.
1. Istnieje wyraźny, wspólny, niemutowalny fragment stanu.
1. Koszt utrzymania factory i cache jest mniejszy niż zysk pamięci.

Nie stosuj, gdy:

1. Obiektów jest mało.
1. Stan jest głównie extrinsic i słabo współdzielony.
1. Kod staje się trudny do utrzymania bez realnego zysku.

## Materiał do tablicy/slajdów

1. Definicja Flyweight (1 zdanie).
1. Schemat: Client -> Factory -> Flyweight.
1. Różnica Flyweight vs Object Pool.
1. Lista ryzyk: mutowalny intrinsic, niekontrolowany cache, błędna granica stanu.

## FAQ

1. Czy Flyweight to cache? Częściowo tak, ale celem jest przede wszystkim redukcja pamięci przez współdzielenie reprezentacji.
1. Czy Flyweight i Object Pool to to samo? Nie. Pool recyklinguje obiekty żywe czasowo, a Flyweight współdzieli obiekty logicznie równoważne.
1. Czy mogę modyfikować flyweight? Nie powinieneś, bo złamiesz współdzielenie.
