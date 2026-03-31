# 01. Idea i kontekst

## Cel rozdzialu

Zrozumiec, jaki problem pamieciowy rozwiazuje wzorzec Pylek i dlaczego sama optymalizacja algorytmu nie zawsze wystarcza.

## Szczegolowe wyjasnienie

Wzorzec Pylek (Flyweight) stosujemy wtedy, gdy system tworzy bardzo duzo obiektow o podobnej strukturze.
Kluczowa obserwacja jest taka, ze czesc danych zwykle powtarza sie miedzy wieloma instancjami.

Zamiast przechowywac wszystko w kazdym obiekcie:

1. Wydzielamy dane wspolne jako `intrinsic state`.
1. Przechowujemy je raz i wspoldzielimy.
1. Dane zalezne od kontekstu (`extrinsic state`) podajemy przy wywolaniu metody.

Dlaczego to pomaga:

1. Zmniejsza liczbe duzych, zduplikowanych instancji.
1. Ogranicza zuzycie pamieci i presje na GC.
1. Poprawia przewidywalnosc dzialania pod duzym obciazeniem.

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

## Diagramy

### Diagram problemu

Zrodlo: [diagrams/01-problem-context.puml](diagrams/01-problem-context.puml)

Opis:

1. Kazdy obiekt przechowuje te same dane wspolne (np. font i ksztalt glifu).
1. Takie duplikaty sa glowna przyczyna wzrostu zuzycia pamieci.

### Diagram idei Flyweight

Zrodlo: [diagrams/02-flyweight-idea.puml](diagrams/02-flyweight-idea.puml)

Opis:

1. `Client` pobiera obiekt z `FlyweightFactory` po kluczu intrinsic.
1. Factory zwraca wspoldzielony obiekt, jesli juz istnieje.
1. `Client` przekazuje extrinsic state w czasie operacji (np. `Draw`).

## Minimalny scenariusz

Zamiast 1 000 000 obiektow `Glyph` z duplikatami czcionki i ksztaltu:

1. Tworzymy male repozytorium unikalnych flyweightow.
1. Klient przekazuje pozycje, rozmiar i kolor jako extrinsic state.

## Przykladowy program

Kod: [Examples/Program.cs](Examples/Program.cs)

Uruchom:

```bash
cd src/11-pylek/01-idea-i-kontekst/Examples
dotnet run
```

Co robi program:

1. Dla tekstu `AABACA` prosi `GlyphFactory` o glif po kluczu `(symbol, font)`.
1. Factory tworzy flyweight tylko dla nowych kluczy i trzyma je w cache.
1. Przy kazdym rysowaniu klient przekazuje `x`, `y`, `pointSize`, `color` jako extrinsic state.
1. Na koncu program wypisuje liczbe unikalnych flyweightow i liczbe wywolan `Draw`.

Jak interpretowac wynik:

1. `Total draw calls` odpowiada liczbie znakow do narysowania.
1. `Unique flyweights` jest mniejsze, bo `A` i inne powtorzenia sa wspoldzielone.
1. Ta roznica pokazuje istote Flyweight: mniej obiektow przy tej samej funkcjonalnosci.

## Co student powinien zapamietac

1. Flyweight optymalizuje pamiec, nie semantyke domeny.
1. Nie kazdy projekt zyska na tym wzorcu.
1. Najpierw analiza modelu i metryki, potem implementacja.
