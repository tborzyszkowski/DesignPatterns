# Wzorzec Prototyp (Prototype)

> **Typ:** Kreacyjny (Creational)  
> **Wg:** Gamma, Helm, Johnson, Vlissides — *Design Patterns* (GoF, 1994)

---

## Definicja

> Wzorzec Prototyp określa rodzaje obiektów do stworzenia za pomocą prototypowego
> egzemplarza i tworzy nowe obiekty przez **kopiowanie** tego prototypu.

Zamiast instancjonować obiekty wywołaniem `new ConcreteClass(...)`, klient
wywołuje `prototype.Clone()` na istniejącym obiekcie, otrzymując gotową,
niezależną kopię.

---

## Spis treści

| # | Temat | Opis |
|---|-------|------|
| [01](01-motywacja/README.md) | Motywacja | Dlaczego potrzebujemy Prototypu? Kosztowna inicjalizacja. |
| [02](02-struktura-gof/README.md) | Struktura GoF | Klasyczny diagram klas, rola klienta, rejestru i prototypu. |
| [03](03-plytkie-i-gleboke-kopiowanie/README.md) | Płytka i głęboka kopia | `MemberwiseClone()` vs konstruktor kopiujący vs JSON. |
| [04](04-typy-implementacji/README.md) | Typy implementacji | `ICloneable`, `IPrototype<T>`, konstruktor kopiujący, `record`. |
| [05](05-kiedy-stosowac/README.md) | Kiedy stosować | Gra — registry wrogów; kiedy NIE stosować; alternatywy. |

---

## Szybki przegląd

### Problem, który rozwiązuje

- Tworzenie obiektu jest drogie (sieć, baza danych, złożone obliczenia)
  i chcemy produkować wiele podobnych instancji tanio.
- Typ obiektu do skopiowania jest znany dopiero w runtime (polimorfizm).
- Chcemy unikać rozbudowanej hierarchii klas factory dla każdej kombinacji.

### Rozwiązanie — jedno zdanie

Utrzymuj jeden (lub kilka) „szablonowy" obiekt i zamiast `new` wywołaj `Clone()`.

### Kluczowa reguła implementacji

**Używaj konstruktora kopiującego** — jest czytelny, daje pełną kontrolę
nad głębią kopii i jest zalecany przez nowoczesne standardy C#:

```csharp
public class Shape
{
    public string Color { get; set; } = "";

    // Konstruktor kopiujący
    protected Shape(Shape source) { Color = source.Color; }

    public virtual Shape Clone() => new Shape(this);
}

public class Circle : Shape
{
    public int Radius { get; set; }

    private Circle(Circle source) : base(source) { Radius = source.Radius; }

    public override Shape Clone() => new Circle(this);
}
```

### Prototype Registry

Opcjonalny element: rejestr szablonów identyfikowanych kluczem:

```csharp
var registry = new ShapeRegistry();
registry.Register("small-circle", new Circle { Radius = 5, Color = "red" });

// Klonuje szablon — klient nie zna konkretnego typu
Shape shape = registry.Clone("small-circle");
```

---

## Struktura GoF

```
«interface»
IPrototype
────────────
+ Clone() : IPrototype
       △
       │
   ┌─────────────┐
   │ConcreteProto│
   │─────────────│
   │ - field1    │
   │ + Clone()   │──► new ConcreteProto(this)
   └─────────────┘

        Client ──uses──► IPrototype
```

---

## Porównanie z innymi wzorcami kreacyjnymi

| Wzorzec | Punkt wyjścia | Jak tworzy | Kiedy |
|---------|--------------|------------|-------|
| **Factory Method** | klasa potomna | `new ConcreteProduct()` | typ znany w compile-time |
| **Abstract Factory** | rodzina produktów | fabryki per rodzina | spójne zestawy obiektów |
| **Builder** | od zera, krok po kroku | `director.Construct()` | złożone obiekty z wariantami |
| **Prototype** | istniejący obiekt | `prototype.Clone()` | kopiowanie drogich/złożonych obiektów |
| **Singleton** | brak tworzenia | referencja do istniejącego | dokładnie jedna instancja |

---

## Rys historyczny

| Rok | Wydarzenie |
|-----|-----------|
| 1994 | GoF — Prototype jako jeden z 5 wzorców kreacyjnych |
| 1995 | `ICloneable` w pierwotnym projekcie .NET (wersja beta) |
| 2002 | .NET 1.0 — `ICloneable` wbudowany w BCL |
| 2004 | .NET 2.0 — Microsoft odradza `ICloneable` w guidelines (FxCop CA2101) |
| 2005 | JavaScript — `Object.create()` jako prototype-based inheritance |
| 2020 | C# 9 — `record` z `with`-expression jako nowoczesny wariant Prototypu dla VO |
| 2021 | .NET 5/6 — `BinaryFormatter` oznaczony jako `[Obsolete]`, zalecany `System.Text.Json` |

---

## Jak uruchomić przykłady

```bash
# Sekcja 01 — Motywacja
cd src/04-prototyp/01-motywacja/Examples && dotnet run

# Sekcja 02 — Struktura GoF
cd src/04-prototyp/02-struktura-gof/Examples && dotnet run

# Sekcja 03 — Płytka i głęboka kopia
cd src/04-prototyp/03-plytkie-i-gleboke-kopiowanie/Examples && dotnet run

# Sekcja 04 — Typy implementacji
cd src/04-prototyp/04-typy-implementacji/Examples && dotnet run

# Sekcja 05 — Kiedy stosować
cd src/04-prototyp/05-kiedy-stosowac/Examples && dotnet run
```

---

## Powiązane wzorce w tym repo

- [01 — Singleton](../01-singleton/README.md)
- [02 — Fabryka](../02-fabryka/README.md) — alternatywa dla prostych przypadków
- [03 — Budowniczy](../03-budowniczy/README.md) — gdy obiekt tworzony jest krok po kroku
