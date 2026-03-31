# Materiały wykładowe — Prototyp (Prototype)

## Plan wykładu (90 min)

| Czas | Temat | Forma |
| --- | --- | --- |
| 0-10 | Motywacja — kosztowna inicjalizacja i potrzeba klonowania | slajd + dyskusja |
| 10-25 | Struktura GoF — diagram klas, interfejs Prototype, Registry | slajd + live coding |
| 25-45 | Płytka vs głęboka kopia — MemberwiseClone, konstruktor kopiujący, JSON | slajd + live demo |
| 45-65 | Typy implementacji — ICloneable, IPrototype\<T\>, PrototypeBase\<T\>, copy ctor, record | slajd + live coding |
| 65-80 | Kiedy stosować, kiedy nie — gra z registry wrogów, kontrprzykłady | slajd + demo |
| 80-90 | Podsumowanie, pytania kontrolne | Q&A |

## Slajdy

### Slajd 1 — Motywacja (01-motywacja)

1. Problem: tworzenie obiektu wymaga kosztownej operacji (sieć, baza, parsowanie) — np. `ServerConfig.LoadFromServer()` trwa ~500 ms.
1. Bez Prototypu: 3 identyczne konfiguracje = 3 × 500 ms = 1500 ms.
1. Z Prototypem: ładujemy raz, klonujemy wielokrotnie — 1 × 500 ms + klonowanie ~0 ms.
1. `Clone()` tworzy głęboką kopię — klon jest niezależny (nowa lista `AllowedIps`).
1. `CloneWith()` — wariant klonowania z nadpisaniem wybranych pól.

### Slajd 2 — Struktura GoF (02-struktura-gof)

1. Interfejs `IShape` deklaruje `Clone()`, `Draw()`, `MoveTo()` — klient nie zna konkretnych typów.
1. Abstrakcyjna klasa `Shape` z konstruktorem kopiującym (`protected Shape(Shape source)`) — podklasy wywołują `base(source)`.
1. Konkretne kształty: `Circle`, `Rectangle`, `Polygon` — każdy ma prywatny copy ctor i `override Clone()`.
1. `Polygon` głęboko kopiuje `List<(int,int)> Points` — krotki są value type, więc `new List<>()` wystarczy.
1. `ShapeRegistry` — rejestr prototypów: `Register(key, prototype)`, `Clone(key)` zwraca klon, nie oryginał.

### Slajd 3 — Płytka i głęboka kopia (03-plytkie-i-gleboke-kopiowanie)

1. `MemberwiseClone()` kopiuje bit-po-bicie: typy wartościowe OK, stringi OK (immutable), referencje WSPÓŁDZIELONE.
1. Pułapka: `shallow.Author.Name = "X"` zmienia też oryginał — ta sama instancja `Person`.
1. Konstruktor kopiujący: `new Person(Author)` + `new List<string>(Tags)` — pełna niezależność.
1. Serializacja JSON (`System.Text.Json`): uniwersalna głęboka kopia, ale wymaga publicznych właściwości i jest wolniejsza.
1. DTO (`DocumentDto`, `PersonDto`) jako warstwa pośrednia do serializacji — oddziela model od mechanizmu kopiowania.

### Slajd 4 — Typy implementacji (04-typy-implementacji)

1. **ICloneable** (niezalecany): zwraca `object` → wymaga rzutowania, nie precyzuje głębokości kopii.
1. **IPrototype\<T\>** (generyczny): `Clone()` zwraca `T` — bezpieczeństwo typów bez rzutowania.
1. **PrototypeBase\<T\>** (klasa bazowa): wymusza `abstract Clone()` w podklasach, miejsce na wspólną logikę.
1. **Konstruktor kopiujący** (zalecany): `new Employee(source)` — czytelny, pełna kontrola nad głębią, brak wymagań na interfejs.
1. **Record + with** (C# 9+): niemutowalne obiekty-wartości — `with { Port = 443 }` tworzy płytką kopię z nadpisanymi polami.

### Slajd 5 — Kiedy stosować, kiedy nie (05-kiedy-stosowac)

1. **TAK**: Registry wrogów w grze — szablony ładowane raz, spawn = tani klon z ustawioną pozycją.
1. **TAK**: Konfiguracje per-tenant, szablony dokumentów, prototypy UI — obiekty podobne, drogie w tworzeniu.
1. **NIE**: Proste obiekty-wartości (`Point`, `ReportRow`) — `record with` wystarczy.
1. **NIE**: Obiekty zawsze unikalne (`Order` z nowym ID i datą) — klonowanie byłoby błędem domenowym.
1. **NIE**: Proste DTO jednorazowe — Prototype Registry to overkill.

## FAQ

### 1. Czym Prototyp różni się od Fabryki?

Fabryka tworzy nowe obiekty od zera (przez `new`), Prototyp kopiuje istniejący obiekt. Prototyp jest lepszy gdy inicjalizacja jest kosztowna lub typ jest znany dopiero w runtime.

### 2. Czy ICloneable jest bezpieczny w użyciu?

Nie jest zalecany. Interfejs nie precyzuje, czy kopia jest płytka czy głęboka, a `Clone()` zwraca `object`. Preferuj własny `IPrototype<T>` lub konstruktor kopiujący.

### 3. Kiedy MemberwiseClone() jest wystarczający?

Tylko gdy obiekt zawiera wyłącznie typy wartościowe i stringi (immutable). Dla pól referencyjnych (listy, obiekty zagnieżdżone) — zawsze głęboka kopia.

### 4. Jak uniknąć błędów przy głębokim kopiowaniu?

Używaj konstruktora kopiującego i kopiuj każde pole referencyjne osobno. Testuj niezależność klonu — modyfikacja klonu nie powinna wpływać na oryginał.

### 5. Czy record w C# zastępuje wzorzec Prototyp?

Częściowo — dla niemutowalnych obiektów-wartości `with` jest wystarczający. Ale dla obiektów z mutowalnym stanem, polimorficznym klonowaniem lub kosztowną inicjalizacją Prototyp pozostaje właściwym wzorcem.

## Literatura

| Źródło | Zakres |
| --- | --- |
| GoF, Design Patterns (1994), rozdz. Prototype | oryginalna definicja i struktura |
| [Refactoring.Guru: Prototype](https://refactoring.guru/design-patterns/prototype) | wizualizacja, przykłady w wielu językach |
| [Microsoft Docs: MemberwiseClone](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone) | semantyka płytkiej kopii w .NET |
| [Microsoft Docs: Records](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/record) | record i with-expression jako alternatywa |
