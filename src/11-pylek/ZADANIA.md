# Zadania - Wzorzec Pyłek

## Zadanie 1 (podstawowe) — ikony UI

Zaprojektuj klasę `IconFactory`, która zwraca współdzielone ikony-flyweighty po kluczu `(type, theme)`.

Wymagania:

1. Brak duplikatów flyweight dla tego samego klucza `(type, theme)`.
1. Klient przekazuje `x`, `y`, `label` jako extrinsic state przy wywołaniu `Render`.
1. Program wypisuje: liczbę unikalnych flyweightów i liczbę wywołań `Render`.
1. Pokaż przynajmniej 3 typy ikon i 2 motywy (jasny/ciemny).

Weryfikacja: liczba flyweightów musi być mniejsza niż liczba wywołań `Render`.

## Zadanie 2 (podstawowe) — kafelki mapy

Zbuduj system kafelków dla mapy gry 10×10 (100 komórek). Typy terenu: Trawa, Woda, Piasek, Skała.

Wymagania:

1. Flyweight przechowuje: `terrainType`, `movementCost`, `texturePath` (intrinsic).
1. Klient przekazuje `(int x, int y, bool hasFog)` jako extrinsic.
1. Wypełnij mapę losowo i wypisz liczbę unikalnych flyweightów vs całkowitą liczbę komórek.

Pytanie kontrolne: ile flyweightów powinien mieć w cache `TileFactory` dla 4 typów terenu?

## Zadanie 3 (średnie) — edytor tekstu

Zaimplementuj fragment renderowania tekstu. Wejście: ciąg znaków `"Hello, World! Hello?"`.

Wymagania:

1. `GlyphFlyweight` przechowuje: `char Symbol`, `string FontFamily`, `int BaselineOffset` (intrinsic).
1. Klient przekazuje `(int x, int y, int fontSize, string color)` przy wywołaniu `Draw`.
1. `GlyphFactory` opiera się na `ConcurrentDictionary` (bezpieczna wielowątkowość).
1. Wypisz: unique flyweights, total draw calls, procent zaoszczędzonych obiektów.
1. Policz szacunkowy zysk pamięciowy: zakładaj 80 B na pełny obiekt vs 20 B na extrinsic slot.

## Zadanie 4 (średnie) — bezpieczeństwo współbieżności

Rozszerz `GlyphFactory` z Zadania 3 o pomiar poprawności wielowątkowej.

Wymagania:

1. Uruchom 10 wątków równolegle, każdy renderuje ten sam tekst 1000 razy.
1. Po zakończeniu: `UniqueCount` musi wynosić tyle samo co liczba unikalnych znaków wejściowych (brak duplikatów w cache).
1. Zmierz i wypisz czas całkowity oraz `HitRatio` (trafi/przegraneCreate).
1. Porównaj `ConcurrentDictionary.GetOrAdd` z manualnym lock — co jest szybsze?

## Zadanie 5 (zaawansowane) — system cząstek

Zaprojektuj Flyweight dla systemu cząstek efektów specjalnych (gra, symulacja).

Typy cząstek: `fire`, `smoke`, `snow`, `spark`, `rain` (5 flyweightów).
Każda cząstka ma: `color`, `texture`, `blendMode` (intrinsic) + `x`, `y`, `velocity`, `opacity` (extrinsic).

Wymagania:

1. Wygeneruj 100 000 cząstek (losowy rozkład typów) z egzemplarzy Flyweight.
1. Porównaj zużycie pamięci naiwnego podejścia (100 000 pełnych obiektów) vs Flyweight.
1. Użyj `struct` dla extrinsic context (`ParticleContext`) aby uniknąć allocacji na stercie.
1. Wypisz tabelę: typ | ilość wystąpień | udział %.

## Zadanie 6 (zaawansowane) — procedura decyzyjna

Dla każdego z poniższych scenariuszy zastosuj procedurę decyzyjną z rozdziału 06 i udokumentuj swój wybór.

Scenariusz A:
System wyświetla 50 000 produktów w e-sklepie. Każdy produkt ma unikalny `Id`, `Name`, `Price`, `Stock`.

Scenariusz B:
Renderujesz grafikę SVG z 200 000 elipsy. 90% elips ma identyczne `strokeWidth`, `strokeColor`, `fillColor`. Różnią się tylko `cx`, `cy`, `rx`, `ry`.

Scenariusz C:
Twoja aplikacja łączy się z bazą danych. Chcesz ograniczyć liczbę jednocześnie otwartych połączeń do 10.

Scenariusz D:
Cache'ujesz wyniki przeliczania kursów walut, które wygasają po 60 sekundach.

Scenariusz E:
Logowanie do aplikacji. Obiekt `Session` zawiera dane użytkownika, uprawnienia, timestamp. Każda sesja jest unikalna.

Dla każdego scenariusza podaj:

1. Jaki wzorzec/podejście wybrałeś (Flyweight / Object Pool / Cache / Prosty model)?
1. Które pytania z checklisty były rozstrzygające?
1. Jeśli Flyweight: wskaż, co jest intrinsic, a co extrinsic.

Klucz odpowiedzi: A=Prosty model (brak intrinsic), B=Flyweight (intrinsic: stroke+fill; extrinsic: cx,cy,rx,ry), C=Object Pool, D=Cache (TTL), E=Prosty model.

## Pytania kontrolne

1. Co jest intrinsic, a co extrinsic w Twoim modelu z Zadania 3?
1. Co się stanie, jeśli dwa wątki jednocześnie wywołają `GetOrAdd` z tym samym kluczem i `GetOrAdd` nie jest atomiczne?
1. Czym Flyweight różni się od Object Pool? Podaj przykład każdego z nich.
1. Czym Flyweight różni się od prostego cache? Kiedy cache wystarczy?
1. Jakie są konsekwencje umieszczenia mutowalnego stanu w intrinsic?
1. Dlaczego klucz Flyweight powinien być `record struct` zamiast klasy?
1. Jak `WeakReference` zmienia zachowanie cache Flyweight? Kiedy to jest użyteczne?
1. Kiedy Flyweight NIE da żadnego zysku mimo dużej liczby obiektów?
