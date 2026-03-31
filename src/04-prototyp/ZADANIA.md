# Zadania dla studentów — Prototyp (Prototype)

## Zadanie 1 (podstawowe)

Temat: Głęboka vs płytka kopia

Treść:
W projekcie [03-plytkie-i-gleboke-kopiowanie/Examples](03-plytkie-i-gleboke-kopiowanie/Examples) dodaj do klasy `Document` pole `List<Person> Reviewers`. Pokaż, że `ShallowClone()` współdzieli tę listę z oryginałem, a `DeepCloneManual()` tworzy niezależną kopię.

Rozwiązanie (skrót):
1. Dodaj `public List<Person> Reviewers { get; set; } = [];`.
2. W `DeepCloneManual()` stwórz nową listę z kopiowanymi `Person`.
3. Zmodyfikuj recenzenta w klonie i wypisz, czy oryginał się zmienił.

Omówienie:
To najczęstszy błąd przy implementacji Prototypu. Każde pole referencyjne wymaga osobnego kopiowania.

---

## Zadanie 2 (średnio zaawansowane)

Temat: Rozszerzenie rejestru kształtów

Treść:
W projekcie [02-struktura-gof/Examples](02-struktura-gof/Examples) dodaj nowy kształt `Ellipse` (z polami `RadiusX`, `RadiusY`) implementujący `IShape`. Zarejestruj go w `ShapeRegistry` i zweryfikuj, że klonowanie i `MoveTo()` działają niezależnie od oryginału.

Rozwiązanie (skrót):
1. Utwórz klasę `Ellipse : Shape` z konstruktorem kopiującym i `Clone()`.
2. Zarejestruj `new Ellipse(0, 0, "purple", 30, 15)` w rejestrze.
3. Sklonuj, przesuń — sprawdź niezależność.

Omówienie:
Rejestr nie wymaga zmian — nowy kształt jest dodawany wyłącznie przez implementację interfejsu. To otwarte na rozszerzenia (OCP).

---

## Zadanie 3 (średnio zaawansowane)

Temat: Klonowanie z pełną hierarchią

Treść:
W projekcie [04-typy-implementacji/Examples](04-typy-implementacji/Examples) dodaj do klasy `Employee` pole `Employee? Manager` (opcjonalna referencja do przełożonego). Zaimplementuj głębokie kopiowanie w konstruktorze kopiującym tak, aby klon miał niezależną kopię managera.

Rozwiązanie (skrót):
1. Dodaj `public Employee? Manager { get; set; }`.
2. W konstruktorze kopiującym: `Manager = source.Manager is not null ? new Employee(source.Manager) : null;`.
3. Zmodyfikuj managera w klonie — oryginał nie powinien się zmienić.

Omówienie:
Rekurencyjne głębokie kopiowanie to typowy wzorzec w Prototype. Wymaga uwagi na cykle (Manager → Employee → Manager...).

---

## Zadanie 4 (zaawansowane)

Temat: Prototype z cache'owaniem

Treść:
W projekcie [01-motywacja/Examples](01-motywacja/Examples) zaimplementuj `ServerConfigCache`, który przechowuje klony `ServerConfig` dla różnych środowisk. Jeśli konfiguracja dla danego środowiska już istnieje w cache, zwróć klon zamiast wywoływać `LoadFromServer()`.

Rozwiązanie (skrót):
1. Utwórz `Dictionary<string, ServerConfig>` jako cache.
2. Metoda `Get(string environment)`: jeśli brak w cache → `LoadFromServer()` + zapisz; jeśli jest → `Clone()`.
3. Zmierz czas dla 5 wywołań tego samego środowiska — tylko pierwsze powinno trwać ~500 ms.

Omówienie:
To połączenie Prototypu z wzorcem cache. W produkcji stosowane np. w pulach konfiguracji per-tenant.

---

## Zadanie 5 (porównawcze)

Temat: Porównanie strategii klonowania

Treść:
Dla klasy `Document` z projektu [03-plytkie-i-gleboke-kopiowanie/Examples](03-plytkie-i-gleboke-kopiowanie/Examples) zmierz czas 10 000 kopii trzema metodami: `ShallowClone()`, `DeepCloneManual()`, `DeepCloneJson()`. Wyciągnij wnioski.

Rozwiązanie (skrót):
1. Użyj `Stopwatch` dla każdej metody.
2. Porównaj czasy i opisz kompromisy (szybkość vs poprawność vs wygoda).
3. Odpowiedz: kiedy JSON jest akceptowalny, a kiedy nie?

Omówienie:
JSON jest najprostszy, ale najwolniejszy i wymaga publicznych właściwości. Konstruktor kopiujący daje pełną kontrolę. `MemberwiseClone()` jest najszybszy, ale niebezpieczny dla referencji.

## Pytania kontrolne

1. Dlaczego kosztowna inicjalizacja obiektu jest główną motywacją do użycia wzorca Prototyp i jak Clone() rozwiązuje ten problem?

1. Jakie role pełnią uczestnicy w klasycznej strukturze GoF (Prototype, ConcretePrototype, Client, Registry) i jak ze sobą współpracują?

1. Czym różni się płytka kopia (MemberwiseClone) od głębokiej kopii (konstruktor kopiujący) i jakie pułapki niesie płytkie kopiowanie pól referencyjnych?

1. Jakie są zalety i wady czterech wariantów implementacji: ICloneable, IPrototype\<T\>, PrototypeBase\<T\> i konstruktor kopiujący?

1. W jakich sytuacjach wzorzec Prototyp jest over-engineeringiem i jakie alternatywy (record with, Factory, Builder) są lepszym wyborem?
