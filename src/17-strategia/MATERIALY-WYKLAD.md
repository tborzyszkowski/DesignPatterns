# Materiały do wykładu — Wzorzec Strategia

## Plan wykładu (90 minut)

| Blok | Czas | Temat | Powiązany temat |
|------|------|-------|-----------------|
| 1 | 15 min | Motywacja i historia — dlaczego Strategia | 01 |
| 2 | 15 min | Struktura GoF, diagramy, role | 03 |
| 3 | 20 min | Typy implementacji i przegląd przykładów | 04 |
| 4 | 15 min | Strategia w .NET (IComparer, LINQ, HTTP) | 04 |
| 5 | 10 min | Wady, pułapki, kiedy NIE używać | 05 |
| 6 | 15 min | Duży przykład + alternatywy + Q&A | 06 |

---

## Blok 1 — Motywacja i historia (15 min)

### Kluczowe pytanie otwierające

> *Ile razy pisałeś `if (type == "credit") { ... } else if (type == "paypal") { ... } else if ...`?*

### Kontekst historyczny

- GoF (1994): wzorzec Strategia jako jeden z 23 wzorców. Formalnie: "Define a family of algorithms, encapsulate each one, and make them interchangeable."
- **Head First Design Patterns** zaczyna się właśnie od tego wzorca — kaczki z wymiennymi zachowaniami. Motto: *"Identify the aspects of your application that vary and separate them from what stays the same."*
- **Open/Closed Principle** (Bertrand Meyer, 1988): klasy otwarte na rozszerzenie, zamknięte na modyfikację. Strategia to wzorcowa realizacja OCP.

### Problem, który rozwiązuje

Diagram do omówienia: `01-idea-i-kontekst/diagrams/strategy_problem.png`

```
Wyobraź sobie klasę Navigator z metodą BuildRoute():
  if (transport == "car") { /* oblicz autostradą */ }
  else if (transport == "bike") { /* oblicz ścieżkami */ }
  else if (transport == "walking") { /* oblicz pieszo */ }
  else if (transport == "publicTransit") { /* oblicz komunikacją */ }
```
Problem: każda nowa opcja transportu = modyfikacja klasy + ryzyko regresji.

### Pytania do dyskusji

- Co się dzieje z taką klasą przy 10 typach transportu?
- Jak przetestujesz jeden algorytm bez uruchamiania pozostałych?
- Jak pozwolisz użytkownikowi dodać własny algorytm bez zmiany kodu bazowego?

---

## Blok 2 — Struktura GoF (15 min)

### Role wzorca

| Rola | Odpowiednik C# | Opis |
|------|---------------|------|
| `Context` | Klasa z polem `IStrategy` | Utrzymuje referencję do strategii, deleguje do niej |
| `Strategy` | `interface IStrategy` | Wspólny kontrakt dla wszystkich wariantów algorytmu |
| `ConcreteStrategy` | Klasa implementująca `IStrategy` | Konkretna realizacja algorytmu |

Diagram do omówienia: `03-struktura-i-dzialanie/diagrams/strategy_class_diagram.png`

### Kluczowe obserwacje

1. **Context nie wie** jaką strategię posiada — wie tylko, że to `IStrategy`.
2. Strategia może być **podmieniana w trakcie działania** programu (runtime injection).
3. Strategia jest **wstrzykiwana** przez konstruktor lub setter — to klasyczny **Dependency Injection**.

---

## Blok 3 — Typy implementacji (20 min)

### Cztery warianty

Diagram: `04-typy-implementacji/diagrams/strategy_types.png`

1. **Typ 1: Interfejs (klasyczny GoF)** — `interface IStrategy { Execute(); }`
2. **Typ 2: Klasa abstrakcyjna** — gdy strategie dzielą wspólny stan lub metody pomocnicze
3. **Typ 3: Delegaty/Func<>** — zamiast klas; lambda jako strategia
4. **Typ 4: Enum + Factory** — strategia wybierana przez wartość enum

### Przykład — Typ 3 (delegaty) jako nowoczesny C#

```csharp
var sorter = new Sorter(strategy: (data) => data.OrderBy(x => x).ToList());
sorter.Sort(myList);
```

---

## Blok 4 — Strategia w .NET (15 min)

### Przykłady z BCL (Base Class Library)

| Klasa/Interfejs | Rola strategii | Przykład użycia |
|----------------|---------------|-----------------|
| `IComparer<T>` | Algorytm porównywania | `list.Sort(new AgeComparer())` |
| `IEqualityComparer<T>` | Algorytm równości | `new HashSet<T>(new CaseInsensitiveComparer())` |
| `StringComparer` | Gotowe strategie porównania | `StringComparer.OrdinalIgnoreCase` |
| `IFormattable` | Algorytm formatowania | `date.ToString("d", culture)` |
| LINQ `OrderBy` | Strategia przez lambda | `.OrderBy(x => x.Price)` |
| ASP.NET Core DI | Rejestracja strategii | `services.AddScoped<IPaymentStrategy, PayPalStrategy>()` |

---

## Blok 5 — Wady i kiedy NIE używać (10 min)

### Sygnały ostrzegawcze

- Tworzysz interfejs z jedną metodą tylko po to, by mieć 2 implementacje
- Algorytmy są proste (1-2 linie) — lambda wystarcza
- Klient **musi wiedzieć** o wszystkich strategiach, żeby wybrać właściwą
- Komunikacja między strategiami jest skomplikowana — może lepiej Dekorator lub Łańcuch

### Porównanie ze wzorcem Metoda Szablonowa

| Cecha | Strategia | Metoda Szablonowa |
|-------|-----------|------------------|
| Mechanizm | Kompozycja (interfejs) | Dziedziczenie (klasa bazowa) |
| Zmiana algorytmu w runtime | ✅ | ❌ |
| Wspólny kod między wariantami | Trudny | ✅ (w klasie bazowej) |
| Testowalność | ✅ (mock interfejsu) | ⚠️ (wymaga podklasy) |
| Liczba klas | Więcej | Mniej |

---

## Blok 6 — Duży przykład (15 min)

Diagram: `06-duzy-przyklad-i-alternatywy/diagrams/strategy_order_system.png`

System zamówień e-commerce z wymiennymi strategiami:
- Obliczanie rabatów (`IDiscountStrategy`)
- Wybór przewoźnika (`IShippingStrategy`)
- Sposób płatności (`IPaymentStrategy`)

Każda strategia wstrzykiwana przez DI/konstruktor.

### Kluczowe pytania na zakończenie

- Kiedy wybrać Strategię zamiast Metody Szablonowej?
- Czy delegat (`Func<>`) to strategia? (Tak — ale bez nazwy i dokumentacji interfejsu)
- Jak zarejestrować i wybierać strategie przez ASP.NET Core DI?

---

## Powiązania z innymi wzorcami

| Wzorzec | Relacja |
|---------|---------|
| **Metoda Szablonowa** | Konkurent: dziedziczenie vs kompozycja |
| **Dekorator** | Uzupełnienie: dekoratory modyfikują, strategie zastępują |
| **Fabryka/Fabryka abstrakcyjna** | Często tworzy strategie |
| **Polecenie (Command)** | Podobna struktura; Command enkapsuluje żądanie, Strategia — algorytm |
| **Stan (State)** | Podobna struktura; State zmienia zachowanie gdy zmienia się stan wewnętrzny |
| **Budowniczy** | Może używać strategii do budowania |
