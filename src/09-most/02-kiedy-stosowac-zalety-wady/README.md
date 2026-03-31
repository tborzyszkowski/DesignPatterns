# 02. Kiedy stosowac Most - zalety i wady

## Cel tematu

Nauczyc sie podejmowac decyzje, czy Most ma sens w danym kontekscie.

## Sygnaly, ze warto

1. Masz co najmniej dwie osie zmiennosci.
2. Obie osie beda rozwijane niezaleznie.
3. Chcesz ograniczyc eksplozje klas dziedziczacych.

## Kiedy nie

1. Masz jedna os zmiennosci (wtedy czesto wystarczy Strategia).
2. Integrujesz obce API bez zmiany modelu (wtedy Adapter).
3. Problem jest prosty i stabilny (Most bylby overengineering).

## Zalety

1. Niezalezne rozszerzanie abstrakcji i implementacji.
2. Lepsza testowalnosc i podstawialnosc implementorow.
3. Mniejsze sprzezenie klienta z infrastruktura.

## Wady

1. Wiecej klas i warstw.
2. Ryzyko leakage implementacji.
3. Zly do prostych, jednowymiarowych scenariuszy.

![Decision map](diagrams/bridge_decision_map.png)

Zrodlo: [diagrams/01-decision-map.puml](diagrams/01-decision-map.puml)

![Bridge vs others](diagrams/bridge_vs_patterns.png)

Zrodlo: [diagrams/02-compare.puml](diagrams/02-compare.puml)

## Cykl decyzji

![Decision lifecycle](diagrams/bridge_lifecycle_topic02.png)

Zrodlo: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program porownuje wariant bez Mostu i z Mostem.

## Uruchom

```bash
cd src/09-most/02-kiedy-stosowac-zalety-wady/Examples
dotnet run
```

## Zadania z rozwiazaniami

1. Rozpoznaj osie zmiennosci dla scenariusza platnosci i raportowania.
Rozwiazanie: platnosc i raport to osobne osie, kandydat na Most.

2. Wskaz antywzorzec leakage w dostarczonym kodzie.
Rozwiazanie: if implementor is X wewnatrz Abstraction.
