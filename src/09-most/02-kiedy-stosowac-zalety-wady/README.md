# 02. Kiedy stosować Most - zalety i wady

## Cel tematu

Nauczyć się podejmować decyzję, czy Most ma sens w danym kontekście.

## Sygnały, że warto

1. Masz co najmniej dwie osie zmienności.
2. Obie osie będą rozwijane niezależnie.
3. Chcesz ograniczyć eksplozję klas dziedziczących.

## Kiedy nie

1. Masz jedna oś zmienności (wtedy często wystarczy Strategia).
2. Integrujesz obce API bez zmiany modelu (wtedy Adapter).
3. Problem jest prosty i stabilny (Most byłby overengineering).

## Zalety

1. Niezależne rozszerzanie abstrakcji i implementacji.
2. Lepsza testowalność i podstawialność implementorów.
3. Mniejsze sprzężenie klienta z infrastrukturą.

## Wady

1. Więcej klas i warstw.
2. Ryzyko leakage implementacji.
3. Zły do prostych, jednowymiarowych scenariuszy.

![Decision map](diagrams/bridge_decision_map.png)

Źródło: [diagrams/01-decision-map.puml](diagrams/01-decision-map.puml)

![Bridge vs others](diagrams/bridge_vs_patterns.png)

Źródło: [diagrams/02-compare.puml](diagrams/02-compare.puml)

## Checklista decyzyjna per scenariusz

### Scenariusz A: Integracja z zewnętrznym API (np. nowy dostawca kuriera)

1. Czy model domenowy ma zostać bez zmian? [tak]
2. Czy głównym problemem jest różnica interfejsów? [tak]
3. Czy nie projektujesz nowej, niezależnej osi biznesowej? [tak]

Wniosek: wybierz **Adapter**.

### Scenariusz B: Podmiana sposobu liczenia (np. rabat standardowy/premium)

1. Czy zmienia się głównie algorytm, a nie infrastrukturą? [tak]
2. Czy masz jedna oś decyzji (wariant algorytmu)? [tak]
3. Czy obiekt kontekstowy ma tylko delegować obliczenia? [tak]

Wniosek: wybierz **Strategia**.

### Scenariusz C: Dwie osie rozwoju (np. typ Alertu x kanał dostarczenia)

1. Czy masz co najmniej 2 osie zmienności? [tak]
2. Czy osie będą rozwijane niezależnie (oddzielne release'y/zespoły)? [tak]
3. Czy bez rozdzielenia grozi eksplozja klas typu XViaY? [tak]
4. Czy chcesz móc podmieniać implementor bez zmian po stronie Abstraction? [tak]

Wniosek: wybierz **Most**.

### Szybka reguła 10 sekund

1. Integracja obcego API -> **Adapter**.
2. Podmiana algorytmu w jednej osi -> **Strategia**.
3. Niezależny rozwój dwóch osi -> **Most**.

## Cykl decyzji

![Decision lifecycle](diagrams/bridge_lifecycle_topic02.png)

Źródło: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program porównuje wariant bez Mostu i z Mostem.

## Uruchom

```bash
cd src/09-most/02-kiedy-stosowac-zalety-wady/Examples
dotnet run
```

## Zadania z rozwiązaniami

1. Rozpoznaj osie zmienności dla scenariusza platnosci i raportowania.
Rozwiązanie: platnosc i raport to osobne osie, kandydat na Most.

2. Wskaz antywzorzec leakage w dostarczonym kodzie.
Rozwiązanie: if implementor is X wewnatrz Abstraction.
