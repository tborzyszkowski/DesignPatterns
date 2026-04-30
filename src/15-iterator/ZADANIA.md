# Zadania — Wzorzec Iterator

Poniższe zadania mają na celu utrwalenie wiedzy o wzorcu Iterator.  
Rozwiązania są dołączone — spróbuj jednak rozwiązać zadania samodzielnie przed ich sprawdzeniem.

---

## Zadanie 1 — Iterator zakresu liczb (Range Iterator)

**Poziom:** ★☆☆  
**Temat:** Implementacja `IEnumerable<T>`, generator `yield return`

Zaimplementuj klasę `Range`, która umożliwia iterowanie po liczbach całkowitych w zadanym przedziale `[start, end]` z opcjonalnym krokiem `step`.

```csharp
var range = new Range(1, 10, 2);
foreach (int n in range)
    Console.Write(n + " "); // 1 3 5 7 9
```

**Wymagania:**
- Klasa powinna implementować `IEnumerable<int>`
- Użyj `yield return` (generator)
- Obsłuż krok ujemny (odliczanie w dół)
- Rzuć `ArgumentException` gdy krok jest równy 0

<details>
<summary>Rozwiązanie</summary>

```csharp
using System.Collections;

class Range : IEnumerable<int>
{
    private readonly int _start, _end, _step;

    public Range(int start, int end, int step = 1)
    {
        if (step == 0) throw new ArgumentException("Krok nie może być 0.", nameof(step));
        (_start, _end, _step) = (start, end, step);
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (_step > 0)
            for (int i = _start; i <= _end; i += _step)
                yield return i;
        else
            for (int i = _start; i >= _end; i += _step)
                yield return i;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Test
var up = new Range(1, 10, 2);
Console.Write("W górę:  "); foreach (int n in up) Console.Write(n + " ");
// 1 3 5 7 9

var down = new Range(10, 1, -3);
Console.Write("\nW dół:   "); foreach (int n in down) Console.Write(n + " ");
// 10 7 4 1
```

**Wyjaśnienie:**  
`yield return` tworzy maszynę stanów (state machine) — kompilator automatycznie implementuje `IEnumerator<int>`. Każde wywołanie `MoveNext()` wznawia wykonanie od miejsca ostatniego `yield return`.

</details>

---

## Zadanie 2 — Iterator drzewa binarnego (in-order)

**Poziom:** ★★☆  
**Temat:** Iterator dla struktury drzewiastej, stos do iteracji bez rekurencji

Zaimplementuj drzewo binarne z iteratorem in-order (lewe → węzeł → prawe). Iterator powinien używać **stosu** zamiast rekurencji, żeby można go było wstrzymać w połowie iteracji.

```csharp
var tree = new BinarySearchTree<int>();
tree.Insert(5); tree.Insert(3); tree.Insert(7); tree.Insert(1); tree.Insert(4);

foreach (int val in tree)
    Console.Write(val + " "); // 1 3 4 5 7
```

<details>
<summary>Rozwiązanie</summary>

```csharp
using System.Collections;

class TreeNode<T>(T value)
{
    public T Value { get; } = value;
    public TreeNode<T>? Left { get; set; }
    public TreeNode<T>? Right { get; set; }
}

class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
{
    private TreeNode<T>? _root;

    public void Insert(T value)
    {
        _root = InsertRec(_root, value);
    }

    private TreeNode<T> InsertRec(TreeNode<T>? node, T value)
    {
        if (node is null) return new TreeNode<T>(value);
        if (value.CompareTo(node.Value) < 0)
            node.Left = InsertRec(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = InsertRec(node.Right, value);
        return node;
    }

    public IEnumerator<T> GetEnumerator() => new InOrderIterator<T>(_root);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Iterator iteracyjny (bez rekurencji) — używa stosu
class InOrderIterator<T> : IEnumerator<T>
{
    private readonly Stack<TreeNode<T>> _stack = new();
    private TreeNode<T>? _current;

    public InOrderIterator(TreeNode<T>? root) => PushLeft(root);

    private void PushLeft(TreeNode<T>? node)
    {
        while (node is not null) { _stack.Push(node); node = node.Left; }
    }

    public bool MoveNext()
    {
        if (_stack.Count == 0) return false;
        _current = _stack.Pop();
        PushLeft(_current.Right);
        return true;
    }

    public T Current => _current!.Value;
    object IEnumerator.Current => Current!;
    public void Reset() => throw new NotSupportedException();
    public void Dispose() { }
}
```

**Wyjaśnienie:**  
Iteracyjny in-order traversal przy użyciu stosu jest równoważny rekurencji, ale pozwala wstrzymać iterację w dowolnym miejscu (co jest właśnie cechą iteratora zewnętrznego).

</details>

---

## Zadanie 3 — Iterator filtrujący i transformujący

**Poziom:** ★★☆  
**Temat:** Dekorator iteratora, leniwość obliczeń

Zaimplementuj klasy `FilterIterator<T>` i `MapIterator<T, TResult>`, które owijają dowolny `IEnumerable<T>`.

```csharp
IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

var evenSquares = numbers
    .Filter(x => x % 2 == 0)    // własna implementacja
    .Map(x => x * x);            // własna implementacja

foreach (int n in evenSquares)
    Console.Write(n + " "); // 4 16 36 64 100
```

**Wymagania:**
- Nie używaj LINQ (`Where`, `Select`)
- Implementacje powinny być leniwe (nie obliczają z góry całej kolekcji)
- Użyj metod rozszerzających

<details>
<summary>Rozwiązanie</summary>

```csharp
using System.Collections;

// Metody rozszerzające
static class IteratorExtensions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        => new FilterIterator<T>(source, predicate);

    public static IEnumerable<TResult> Map<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        => new MapIterator<T, TResult>(source, selector);
}

class FilterIterator<T>(IEnumerable<T> source, Func<T, bool> predicate) : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in source)
            if (predicate(item))
                yield return item;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class MapIterator<T, TResult>(IEnumerable<T> source, Func<T, TResult> selector) : IEnumerable<TResult>
{
    public IEnumerator<TResult> GetEnumerator()
    {
        foreach (T item in source)
            yield return selector(item);
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```

**Wyjaśnienie:**  
Leniwe iteratory obliczają elementy **na żądanie** — `FilterIterator` nie przetwarza całej kolekcji od razu, tylko jeden element przy każdym `MoveNext()`. To właśnie robi LINQ.

</details>

---

## Zadanie 4 — Iterator historii przeglądania (Undo/Redo)

**Poziom:** ★★★  
**Temat:** Iterator dwukierunkowy, integracja z aplikacją

Zaimplementuj `BrowsingHistory<T>` — dwukierunkową historię przeglądania z możliwością nawigacji wstecz i do przodu.

```csharp
var history = new BrowsingHistory<string>();
history.Visit("google.com");
history.Visit("github.com");
history.Visit("stackoverflow.com");

Console.WriteLine(history.Current); // stackoverflow.com
history.GoBack();
Console.WriteLine(history.Current); // github.com
history.GoBack();
Console.WriteLine(history.Current); // google.com
history.GoForward();
Console.WriteLine(history.Current); // github.com

// Iteracja: od najnowszego
foreach (string url in history)
    Console.WriteLine(url);
```

<details>
<summary>Rozwiązanie</summary>

```csharp
using System.Collections;

class BrowsingHistory<T> : IEnumerable<T>
{
    private readonly LinkedList<T> _history = new();
    private LinkedListNode<T>? _current;

    public T? Current => _current is null ? default : _current.Value;
    public bool CanGoBack => _current?.Previous is not null;
    public bool CanGoForward => _current?.Next is not null;

    public void Visit(T item)
    {
        // Wycina "przyszłość" przy nowym wejściu
        if (_current is not null)
        {
            var toRemove = _current.Next;
            while (toRemove is not null)
            {
                var next = toRemove.Next;
                _history.Remove(toRemove);
                toRemove = next;
            }
        }
        _history.AddLast(item);
        _current = _history.Last;
    }

    public void GoBack()
    {
        if (CanGoBack) _current = _current!.Previous;
    }

    public void GoForward()
    {
        if (CanGoForward) _current = _current!.Next;
    }

    // Iteracja od najnowszego do najstarszego
    public IEnumerator<T> GetEnumerator()
    {
        var node = _history.Last;
        while (node is not null)
        {
            yield return node.Value;
            node = node.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```

</details>

---

## Zadanie 5 — Pytania teoretyczne

**Poziom:** ★☆☆

Odpowiedz na poniższe pytania:

1. Czym różni się iterator **zewnętrzny** (aktywny) od **wewnętrznego** (pasywnego)?
1. Dlaczego wzorzec Iterator narusza zasadę **jednej odpowiedzialności** (SRP) gdy logika iteracji jest umieszczona w samej kolekcji?
1. Jak `yield return` w C# implementuje wzorzec Iterator? Co generuje kompilator?
1. W jakich sytuacjach LINQ jest **lepszym** wyborem niż własna implementacja iteratora?
1. Jaki problem rozwiązuje `IEnumerable<T>` w porównaniu do bezpośredniego zwracania `List<T>` z metody?

<details>
<summary>Odpowiedzi</summary>

1. **Iterator zewnętrzny (aktywny):** klient kontroluje iterację — sam wywołuje `MoveNext()`, decyduje kiedy i czy kontynuować. **Iterator wewnętrzny (pasywny):** kolekcja kontroluje iterację — klient dostarcza tylko akcję do wykonania (callback), np. `ForEach(action)`. Iterator zewnętrzny jest bardziej elastyczny, wewnętrzny — prostszy w użyciu.

1. Gdy kolekcja sama implementuje iterator, staje się odpowiedzialna zarówno za **przechowywanie danych** jak i za **logikę przechodzenia**. Zgodnie z SRP, te dwie odpowiedzialności powinny być w osobnych klasach (`ConcreteAggregate` i `ConcreteIterator`). Dlatego GoF proponuje osobną klasę iteratora.

1. `yield return` powoduje, że kompilator generuje **klasę maszyny stanów** (state machine) implementującą `IEnumerator<T>`. Metoda z `yield return` staje się fabryką tego enumeratora. Wykonanie zostaje wstrzymane po każdym `yield return` i wznowione przy kolejnym `MoveNext()`.

1. LINQ jest lepszy gdy: piszemy zapytania złożone (filter + sort + group + project), chcemy komponować operacje leniwie, pracujemy z `IQueryable<T>` (bazy danych), nie potrzebujemy zachowania stanu między iteracjami. Własny iterator jest lepszy gdy: potrzebujemy specjalnej semantyki (np. in-order traversal drzewa), mamy złożony stan, chcemy dwukierunkowego przechodzenia.

1. Zwracanie `IEnumerable<T>` zamiast `List<T>` ukrywa szczegół implementacji kolekcji. Klient nie wie czy dane przychodzą z listy, tablicy, bazy danych, pliku, czy są generowane. Można zmienić implementację bez zmiany interfejsu. Dodatkowo `IEnumerable<T>` umożliwia zwracanie leniwych sekwencji (generatorów), które nie muszą materiahzować całej kolekcji w pamięci.

</details>
