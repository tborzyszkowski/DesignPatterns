# 04. Typy implementacji i wybór wariantu

## Cel rozdziału

Poznać najczęściej spotykane warianty implementacji Kompozytu i świadomie dobrać właściwy do problemu.

## Typy implementacji

### 1. Transparent Composite

**Idea:** Interfejs bazowy (`Component`) zawiera metody zarządzania dziećmi (`Add`, `Remove`, `GetChild`). Liść i kompozyt są traktowane **identycznie** przez kod klienta — nie trzeba sprawdzać typu.

**Jak działa w kodzie:**

```csharp
internal abstract class TransparentComponent(string name)
{
    protected string Name { get; } = name;
    public abstract void Operation(int level = 0);

    // Metoda w bazowej klasie — dostępna dla WSZYSTKICH, w tym dla liścia
    public virtual void Add(TransparentComponent child)
        => throw new NotSupportedException("Leaf cannot Add");
}

internal sealed class TransparentLeaf(string name) : TransparentComponent(name)
{
    // Nie nadpisuje Add — wyjątek przyjdzie z klasy bazowej
    public override void Operation(int level = 0)
        => Console.WriteLine($"{new string(' ', level * 2)}- {Name}");
}

internal sealed class TransparentComposite(string name) : TransparentComponent(name)
{
    private readonly List<TransparentComponent> _children = new();

    // Nadpisuje Add — faktyczna implementacja
    public override void Add(TransparentComponent child) => _children.Add(child);

    public override void Operation(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {Name}");
        foreach (var child in _children)
            child.Operation(level + 1);
    }
}
```

**Użycie — klient nie sprawdza typów:**

```csharp
TransparentComponent root = new TransparentComposite("root");
root.Add(new TransparentLeaf("item-1"));   // OK
root.Operation();

// Próba Add na liściu ujawnia się w runtime, nie w kompilacji:
TransparentComponent leaf = new TransparentLeaf("orphan");
leaf.Add(new TransparentLeaf("child"));    // NotSupportedException!
```

**Zalety:**
- Klient operuje tylko na typie `TransparentComponent` — brak rzutowań i `is`/`as`.
- Łatwa podmiana liścia na kompozyt bez zmiany kodu klienta.

**Wady:**
- Błąd wywołania `Add` na liściu wykryty dopiero w **runtime**.
- Narusza zasadę Liskov (liść nie może spełnić kontraktu `Add`).

**Kiedy stosować:** UI frameworki, systemy plików — gdy klient musi traktować wszystkie węzły jednakowo i błędy są akceptowalne w runtime.

---

### 2. Safe Composite

**Idea:** Metody zarządzania dziećmi (`Add`, `Remove`) są **tylko w klasie Composite**, a nie w interfejsie bazowym. Liść i kompozyt implementują ten sam interfejs operacyjny, ale ich hierarchia zarządzania jest oddzielna.

**Jak działa w kodzie:**

```csharp
internal interface ISafeComponent
{
    void Operation(int level = 0);
    // Brak Add/Remove — interfejs zawiera TYLKO operacje biznesowe
}

internal sealed class SafeLeaf(string name) : ISafeComponent
{
    // Brak Add — kompilator nie pozwoli jej wywołać na liściu
    public void Operation(int level = 0)
        => Console.WriteLine($"{new string(' ', level * 2)}- {name}");
}

internal sealed class SafeComposite(string name) : ISafeComponent
{
    private readonly List<ISafeComponent> _children = new();

    // Add tylko tutaj — widoczne wyłącznie gdy masz referencję do SafeComposite
    public void Add(ISafeComponent child) => _children.Add(child);

    public void Operation(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {name}");
        foreach (var child in _children)
            child.Operation(level + 1);
    }
}
```

**Użycie — błąd wykryty przez kompilator:**

```csharp
var root = new SafeComposite("root");   // typ SafeComposite, nie interfejs
root.Add(new SafeLeaf("item-1"));       // OK — Add jest na SafeComposite

ISafeComponent component = root;
// component.Add(...);                  // Błąd kompilacji — ISafeComponent nie ma Add!
```

**Zalety:**
- Błąd wywołania `Add` na złym typie = **błąd kompilacji**, nie runtime.
- Czyste API: interfejs operacyjny nie jest zaśmiecony metodami strukturalnymi.
- Zgodny z zasadą Liskov.

**Wady:**
- Kod budujący drzewo musi znać konkretny typ `SafeComposite` (nie może operować na interfejsie).
- Wymaga rzutowania lub trzymania referencji do `SafeComposite` jeśli drzewo budowane dynamicznie.

**Kiedy stosować:** Biblioteki, publiczne API — gdy bezpieczeństwo typów jest ważniejsze od jednolitości klienta.

---

### 3. Composite + Iterator (BFS/DFS)

**Idea:** Węzeł drzewa udostępnia kolekcję dzieci (`Children`), a **przejście po drzewie jest wydzielone do osobnego iteratora**. Iterator może implementować BFS (wszerz), DFS (w głąb) lub inne strategie bez zmiany węzła.

**Jak działa w kodzie:**

```csharp
internal sealed class IterNode(string name)
{
    private readonly List<IterNode> _children = new();
    public string Name { get; } = name;

    // Węzeł udostępnia dzieci — ale NIE definiuje jak je przejść
    public IEnumerable<IterNode> Children => _children;

    public void Add(IterNode child) => _children.Add(child);
}

// Iterator BFS — przejście wszerz (poziom po poziomie)
internal static class BfsIterator
{
    public static IEnumerable<IterNode> Traverse(IterNode root)
    {
        var queue = new Queue<IterNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            IterNode node = queue.Dequeue();
            yield return node;                          // zwróć aktualny węzeł
            foreach (IterNode child in node.Children)
                queue.Enqueue(child);                   // dodaj dzieci do kolejki
        }
    }
}
```

**Użycie — strategia przejścia wymieniana bez zmiany węzła:**

```csharp
var root = new IterNode("root");
var branch = new IterNode("branch-A");
branch.Add(new IterNode("leaf-A1"));
branch.Add(new IterNode("leaf-A2"));
root.Add(branch);
root.Add(new IterNode("leaf-B"));

// BFS — kolejność: root → branch-A → leaf-B → leaf-A1 → leaf-A2
foreach (IterNode node in BfsIterator.Traverse(root))
    Console.WriteLine($"  {node.Name}");

// Dodanie DFS nie wymaga zmiany IterNode — wystarczy nowa klasa iteratora
```

**Dlaczego BFS zamiast czystej rekurencji:**

| Aspekt | Czysta rekurencja | BFS/DFS iterator |
|---|---|---|
| Głębokie drzewa | `StackOverflowException` | Bezpieczne (własna kolejka/stos) |
| Strategia przejścia | Na stałe wbudowana w `Operation` | Wymieniana przez wybór iteratora |
| Wielokrotne przejście | Zawsze od nowa | Można `yield return` i przerywać |
| Czytelność węzła | Logika przejścia w węźle | Węzeł tylko przechowuje dzieci |

**Zalety:**
- Brak ryzyka przepełnienia stosu przy głębokich drzewach.
- Wiele strategii przejścia bez zmian w klasie węzła.
- Kompatybilność z LINQ (`Where`, `Select`, `First` na wynikach iteratora).

**Wady:**
- Więcej klas — oddzielny iterator dla każdej strategii.
- Węzeł musi ujawniać `Children` (nie zawsze pożądane).

**Kiedy stosować:** Duże lub głębokie drzewa (AST, grafy zależności, DOM), potrzeba wielu strategii przejścia, integracja z LINQ.

---

## Porównanie wariantów

| Kryterium | Transparent | Safe | + Iterator |
|---|---|---|---|
| Jednolitość API dla klienta | ✓ pełna | ✗ wymaga cast | ✓ pełna |
| Bezpieczeństwo typów | ✗ runtime | ✓ kompilacja | ✓ kompilacja |
| Zgodność z LSP | ✗ | ✓ | ✓ |
| Wiele strategii przejścia | ✗ | ✗ | ✓ |
| Głębokie drzewa (bez SO) | ✗ rekurencja | ✗ rekurencja | ✓ |
| Złożoność implementacji | niska | niska | średnia |

## Jak wybrać właściwy wariant

| Sytuacja | Wybór |
|---|---|
| Klient zawsze traktuje liść i kompozyt tak samo | **Transparent** |
| Publiczne API, błędy wykryte przez kompilator | **Safe** |
| Głębokie drzewa lub potrzeba BFS/DFS/wielokrotnych przejść | **+ Iterator** |
| Integracja z LINQ na drzewie | **+ Iterator** |

## Diagram porównawczy

![Porównanie wariantów](diagrams/composite_variants.png)

Źródło: [diagrams/01-variants.puml](diagrams/01-variants.puml)

## Schemat implementacji

![Schemat implementacji](diagrams/composite_implementation_scheme.png)

Źródło: [diagrams/02-implementation-scheme.puml](diagrams/02-implementation-scheme.puml)

## Przykład C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program porównuje wszystkie trzy warianty na tym samym zestawie węzłów:

1. Transparent Composite — `Add/Remove` w bazowej klasie `TransparentComponent`, liść rzuca `NotSupportedException`.
1. Safe Composite — `Add` tylko w `SafeComposite`, liść `SafeLeaf` nie wie nic o dzieciach.
1. Composite + Iterator (BFS) — `IterNode` udostępnia `Children`, a statyczna klasa `BfsIterator` przechodzi drzewo kolejką zamiast czystą rekurencją.

```bash
cd src/12-kompozyt/04-typy-implementacji-i-wybor/Examples
dotnet run
```

## Źródła

1. Refactoring.Guru Composite: https://refactoring.guru/design-patterns/composite
1. Microsoft Learn IEnumerable<T>: https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1
