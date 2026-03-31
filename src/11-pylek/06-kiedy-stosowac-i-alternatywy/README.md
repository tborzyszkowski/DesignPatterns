# 06. Kiedy stosowac i alternatywy

## Cel rozdzialu

Podjac swiadoma decyzje, czy Flyweight jest najlepszym wyborem dla danego problemu.

## Kiedy stosowac Flyweight

1. Bardzo duza liczba obiektow.
1. Wysoki stopien wspolnego, niemutowalnego stanu.
1. Wyrazne oddzielenie kontekstu klienta od reprezentacji wspolnej.

## Kiedy nie stosowac

1. Mala skala obiektow.
1. Niski poziom wspoldzielenia stanu.
1. Brak presji pamieciowej i brak problemow GC.

## Porownanie z alternatywami

1. `Object Pool`: recykling obiektow tymczasowych, nie wspoldzielenie reprezentacji.
1. Zwykly cache wynikow: przechowuje rezultaty, niekoniecznie obiekty modelu.
1. Immutable value objects: upraszczaja model, ale nie usuwaja duplikatow same z siebie.

## Mini drzewo decyzyjne

1. Czy masz bardzo duzo podobnych obiektow? Jesli nie, odpusc Flyweight.
1. Czy potrafisz wydzielic niemutowalny intrinsic? Jesli nie, odpusc Flyweight.
1. Czy pomiar pokazuje problem pamieci? Jesli tak, wdrazaj stopniowo.

## Ryzyka i zabezpieczenia

1. Ryzyko: niekontrolowany rozrost cache -> limit lub `WeakReference`.
1. Ryzyko: zly klucz -> testy kontraktowe dla klucza.
1. Ryzyko: nadmiarowa zlozonosc -> utrzymuj prosty interfejs klienta.

## Diagram porownawczy

Zrodlo: [diagrams/01-flyweight-vs-pool.puml](diagrams/01-flyweight-vs-pool.puml)
