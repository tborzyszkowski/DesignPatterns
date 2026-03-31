# 01. Idea i kontekst

## Cel rozdziału

Zrozumieć, jaki problem pamięciowy rozwiązuje wzorzec Pyłek i dlaczego sama optymalizacja algorytmu nie zawsze wystarcza.

## Szczegółowe wyjaśnienie

Wzorzec Pyłek (Flyweight) stosujemy wtedy, gdy system tworzy bardzo dużo obiektów o podobnej strukturze.
Kluczowa obserwacja jest taka, że część danych zwykle powtarza się między wieloma instancjami.

Zamiast przechowywać wszystko w każdym obiekcie:

1. Wydzielamy dane wspólne jako `intrinsic state`.
1. Przechowujemy je raz i współdzielimy.
1. Dane zależne od kontekstu (`extrinsic state`) podajemy przy wywołaniu metody.

Dlaczego to pomaga:

1. Zmniejsza liczbę dużych, zduplikowanych instancji.
1. Ogranicza zużycie pamięci i presję na GC.
1. Poprawia przewidywalność działania pod dużym obciążeniem.

## Problem

W wielu systemach tworzymy ogromną liczbę obiektów o bardzo podobnej strukturze.
Przykłady:

1. Znaki tekstu w edytorze.
1. Kafelki mapy w grze.
1. Ikony na dashboardzie.

Jeśli każdy obiekt przechowuje cały stan, to:

1. Rośnie zużycie pamięci.
1. Rośnie presja na GC.
1. Spada przewidywalność wydajności.

## Intuicja wzorca Pyłek

1. Oddzielamy część wspólną (intrinsic) od kontekstowej (extrinsic).
1. Część wspólna jest tworzona raz i współdzielona.
1. Część kontekstowa jest przekazywana przez klienta przy wywołaniu.

## Diagramy

### Diagram problemu

![Diagram problemu](diagrams/flyweight_problem_context.png)

Źródło: [diagrams/01-problem-context.puml](diagrams/01-problem-context.puml)

Opis:

1. Każdy obiekt przechowuje te same dane wspólne (np. font i kształt glifu).
1. Takie duplikaty są główną przyczyną wzrostu zużycia pamięci.

### Diagram idei Flyweight

![Diagram idei](diagrams/flyweight_idea.png)

Źródło: [diagrams/02-flyweight-idea.puml](diagrams/02-flyweight-idea.puml)

Opis:

1. `Client` pobiera obiekt z `FlyweightFactory` po kluczu intrinsic.
1. Factory zwraca współdzielony obiekt, jeśli już istnieje.
1. `Client` przekazuje extrinsic state w czasie operacji (np. `Draw`).

## Minimalny scenariusz

Zamiast 1 000 000 obiektów `Glyph` z duplikatami czcionki i kształtu:

1. Tworzymy małe repozytorium unikalnych flyweightów.
1. Klient przekazuje pozycję, rozmiar i kolor jako extrinsic state.

## Przykładowy program

Kod: [Examples/Program.cs](Examples/Program.cs)

Uruchom:

```bash
cd src/11-pylek/01-idea-i-kontekst/Examples
dotnet run
```

Co robi program:

1. Dla tekstu `AABACA` prosi `GlyphFactory` o glif po kluczu `(symbol, font)`.
1. Factory tworzy flyweight tylko dla nowych kluczy i trzyma je w cache.
1. Przy każdym rysowaniu klient przekazuje `x`, `y`, `pointSize`, `color` jako extrinsic state.
1. Na końcu program wypisuje liczbę unikalnych flyweightów i liczbę wywołań `Draw`.

Jak interpretować wynik:

1. `Total draw calls` odpowiada liczbie znaków do narysowania.
1. `Unique flyweights` jest mniejsze, bo `A` i inne powtórzenia są współdzielone.
1. Ta różnica pokazuje istotę Flyweight: mniej obiektów przy tej samej funkcjonalności.

## Co student powinien zapamiętać

1. Flyweight optymalizuje pamięć, nie semantykę domeny.
1. Nie każdy projekt zyska na tym wzorcu.
1. Najpierw analiza modelu i metryki, potem implementacja.
