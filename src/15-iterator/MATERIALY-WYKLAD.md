# Materiały prowadzącego — Wzorzec Iterator

## Cel wykładu

Studenci powinni wyjść z wykładu rozumiejąc:

- **Dlaczego** iterator istnieje (problem enkapsulacji kolekcji)
- **Jak** działa wzorzec w .NET (IEnumerable<T>/IEnumerator<T>)
- **Kiedy** używać wzorca a kiedy wystarczy LINQ

---

## Scenariusz wykładu (90 minut)

### Blok 1 — Motywacja i historia (15 min)

**Pytanie otwierające:** *„Jak udostępnić elementy kolekcji, nie ujawniając że to jest tablica?"*

Pokaż problem:
```csharp
// Złe podejście — ujawniamy implementację
public string[] GetTitles() => _titles;   // Co jeśli zmienimy na List?
public int Count => _count;
public string GetAt(int index) => _titles[index]; // Klient musi znać indeksy
```

Prowadzi to do „kruchości" kodu — zmiana struktury wewnętrznej wymaga zmian u klientów.

**Historia:** Wzorzec pojawił się w STL (C++, 1994) — iteratory jako uogólnienie wskaźników. Gang of Four włączył go do katalogu wzorców w tym samym roku. .NET przyjął go jako fundament (`IEnumerable<T>` od .NET 2.0).

---

### Blok 2 — Struktura GoF (20 min)

Pokaż diagram klas. Omów rolę:
- **Iterator** — interfejs z `MoveNext()`, `Current`, `Reset()`
- **ConcreteIterator** — implementacja dla konkretnej kolekcji
- **Aggregate** — interfejs `CreateIterator()`
- **ConcreteAggregate** — kolekcja zwracająca swój iterator

Zademonstruj na przykładzie `BookCollection` → `BookIterator`.

**Kluczowy punkt:** Iterator to „kursor" — pozwala mieć wiele niezależnych pozycji w tej samej kolekcji jednocześnie.

---

### Blok 3 — .NET i yield return (25 min)

Pokaż ewolucję:

1. **Ręczny iterator** — pełna implementacja `IEnumerator<T>`
2. **Generator** — `yield return` (kompilator generuje maszynę stanów)
3. **LINQ** — leniwe operacje na sekwencjach

```csharp
// .NET sposób — trzy metody
class MyCollection : IEnumerable<int>
{
    // Metoda 1: GetEnumerator()
    // Metoda 2: yield return
    // Metoda 3: LINQ
}
```

Pokaż co kompilator generuje dla `yield return` (uproszczona maszyna stanów).

---

### Blok 4 — Aktywny vs Pasywny (15 min)

| Cecha | Iterator aktywny | Iterator wewnętrzny |
|-------|-----------------|---------------------|
| Kontrola | Klient | Kolekcja |
| API | `MoveNext()`, `Current` | `ForEach(action)` |
| Elastyczność | Wysoka | Niska |
| Prostota | Niska | Wysoka |

Pokaż obydwa w kodzie. Wspomnij o `IObservable<T>` jako reaktywnym wariancie.

---

### Blok 5 — Kiedy używać, alternatywy (15 min)

**Używaj iteratora gdy:**
- Potrzebujesz specjalnego porządku przechodzenia (in-order, BFS, DFS)
- Chcesz wiele równoległych iteracji
- Chcesz ukryć wewnętrzną strukturę kolekcji

**Zamiast iteratora użyj:**
- **LINQ** — gdy operacje są kompozycjami filter/map/reduce
- **Visitor** — gdy chcesz różnych operacji na strukturze, nie tylko przejść
- **Direct indexing** — gdy kolekcja jest prosta i nie ukrywa struktury

---

## Kluczowe pytania do dyskusji

1. Czy `List<T>.GetEnumerator()` zwraca iterator aktywny czy pasywny?
1. Co się stanie jeśli zmodyfikujesz kolekcję podczas iteracji `foreach`?
1. Dlaczego `IEnumerable<T>` nie ma `Count` ani `IndexOf`?
1. Jak iterator w Javie różni się od tego w C#? (`Iterator` vs `IEnumerator`)

---

## Typowe błędy studentów

| Błąd | Poprawne podejście |
|------|-------------------|
| Implementacja `Reset()` w iteratorach yield | `yield return` nie obsługuje `Reset()` — rzuć `NotSupportedException` |
| Modyfikacja kolekcji podczas iteracji | Wymagana `InvalidOperationException` (wersja kolekcji) |
| Materiahzacja całej sekwencji w `GetEnumerator()` | Użyj `yield return` dla leniwości |
| Mieszanie iteratora zewnętrznego z wewnętrznym | Wybierz jeden model dla danej klasy |

---

## Powiązania z innymi wzorcami

| Wzorzec | Powiązanie z Iterator |
|---------|-----------------------|
| **Composite** | Iterator często przechodzi przez struktury złożone (drzewa) |
| **Factory Method** | `CreateIterator()` to Factory Method w Aggregate |
| **Visitor** | Alternatywa gdy potrzebujemy wielu różnych operacji na kolekcji |
| **Command** | `CommandQueue` często używa iteratora do wykonywania poleceń |

---

## Literatura

1. Gamma et al. — *Design Patterns* (1994), s. 257–271
1. Freeman & Robson — *Head First Design Patterns*, rozdz. 9
1. Skeet — *C# in Depth*, rozdz. 6 (yield i iteratory)
1. [Iterators (C# Guide)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators)
