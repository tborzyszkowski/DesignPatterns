# Materiały wykładowe: Kompozyt (90 minut)

## Cel spotkania

Pokazać, jak projektować hierarchie część-całość, aby klient mógł traktować obiekty pojedyncze i złożone w ten sam sposób.

## Agenda

1. 0-10 min: Problem i motywacja.
1. 10-20 min: Rys historyczny i definicja GoF.
1. 20-35 min: Struktura wzorca i przepływ wywołań.
1. 35-50 min: Kiedy stosować, zalety i wady.
1. 50-70 min: Typy implementacji i schemat wyboru.
1. 70-85 min: Duży przykład (system plików).
1. 85-90 min: Alternatywy i podsumowanie.

## Rys historyczny (do omówienia)

1. Lata 80/90: wzrost znaczenia GUI i struktur dokumentów (drzewa widgetów, dokumenty zagnieżdżone).
1. 1994: GoF formalizuje Composite jako wzorzec strukturalny.
1. Współcześnie: AST w kompilatorach, DOM, menu, systemy plików, sceny 2D/3D.

## Kluczowe pytania do studentów

1. Czy Twoje obiekty naturalnie tworzą drzewo?
1. Czy klient powinien traktować liść i gałąź jednakowo?
1. Czy operacje mają być wykonywane na całym poddrzewie?

## Przebieg live demo

1. Zbuduj interfejs `IFileSystemNode`.
1. Dodaj `FileNode` jako `Leaf`.
1. Dodaj `DirectoryNode` jako `Composite`.
1. Uruchom `GetSize()` i `PrintTree()` na zagnieżdżonej strukturze.
1. Pokaż jak łatwo dodać kolejną gałąź bez zmian w kliencie.

## Punkty ryzyka do podkreślenia

1. Nadmiar metod typu `Add/Remove` w liściach (przeciążenie API).
1. Ryzyko cykli w drzewie, jeśli brak walidacji rodzic-dziecko.
1. Problemy wydajnościowe przy bardzo głębokich drzewach i rekurencji.

## Podsumowanie dla prowadzącego

1. Kompozyt upraszcza kod klienta.
1. Koszt to większa odpowiedzialność projektanta za spójność drzewa.
1. Często dobrze działa razem z Visitor lub Iterator.

## Materiał do tablicy/slajdów

1. Definicja Kompozytu (1 zdanie).
1. Schemat: Client → Component ← Leaf, Composite (dzieci).
1. Różnica Transparent vs Safe Composite.
1. Lista ryzyk: cykle w drzewie, metody zarządzania dziećmi w liściach, głęboka rekurencja.

## FAQ

1. Czy Kompozyt to to samo co drzewo danych? Nie. Drzewo to struktura danych; Kompozyt to wzorzec nadający tej strukturze jednolite API przez wspólny interfejs `Component`.
1. Czy liść może mieć dzieci w Safe Composite? Nie — metoda `Add` jest tylko w `Composite`, więc próba dodania dziecka do liścia nie skompiluje się lub da błąd w czasie wykonania.
1. Kiedy zamiast rekurencji użyć iteratora? Gdy drzewo jest bardzo głębokie (ryzyko `StackOverflowException`) lub gdy potrzebujesz różnych strategii przejścia (BFS, DFS, priorytetowe).
1. Czy Kompozyt i Dekorator to to samo? Nie. Dekorator rozszerza zachowanie jednego obiektu; Kompozyt grupuje wiele obiektów w hierarchię i traktuje je jednakowo.
1. Czy mogę użyć Kompozytu z LINQ? Tak. Jeśli `Composite` implementuje `IEnumerable<Component>`, możesz korzystać z LINQ do filtrowania i projekcji węzłów.
