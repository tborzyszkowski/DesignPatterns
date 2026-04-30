// =============================================================================
// Wzorzec Iterator — 06. Iterator Wewnętrzny
// Demonstruje: ForEach, Map, Fold na drzewie, porównanie z zewnętrznym
// =============================================================================

// ─── DEMO 1: Iterator wewnętrzny na liście ────────────────────────────────────

Console.WriteLine("═══ DEMO 1: Iterator wewnętrzny na liście (ForEach) ═══\n");

var tasks = new TaskList();
tasks.Add(new WorkTask("Napisać testy", Priority.High, false));
tasks.Add(new WorkTask("Napisać dokumentację", Priority.Medium, true));
tasks.Add(new WorkTask("Refactoring", Priority.Low, false));
tasks.Add(new WorkTask("Code review", Priority.High, true));

// Iterator wewnętrzny: kolekcja wywołuje akcję
Console.WriteLine("Wszystkie zadania:");
tasks.ForEach(t => Console.WriteLine($"  [{(t.Done ? "✓" : " ")}] {t.Name} ({t.Priority})"));

Console.WriteLine("\nTylko niezakończone:");
tasks.ForEach(t =>
{
    if (!t.Done)
        Console.WriteLine($"  ⚡ {t.Name}");
});

// Map — transformacja kolekcji (iterator wewnętrzny z wynikiem)
Console.WriteLine("\nNazwy jako wielkie litery (Map):");
TaskList<string> names = tasks.Map(t => t.Name.ToUpper());
names.ForEach(name => Console.WriteLine($"  {name}"));

// Fold (Reduce) — agregacja
int highCount = tasks.Fold(0, (acc, t) => t.Priority == Priority.High ? acc + 1 : acc);
Console.WriteLine($"\nZadania o wysokim priorytecie: {highCount}");

// ─── DEMO 2: Iterator wewnętrzny na drzewie ───────────────────────────────────

Console.WriteLine("\n═══ DEMO 2: Iterator wewnętrzny na drzewie (rekurencja) ═══\n");

//          Kategorie
//         /         \
//     Nauka        Hobby
//    /     \       /   \
// Fizyka  Chem  Fotograf. Malarstwo
//   |
// Optyka

var root = new TreeNode<string>("Kategorie");
var nauka = new TreeNode<string>("Nauka");
var hobby = new TreeNode<string>("Hobby");
var fizyka = new TreeNode<string>("Fizyka");
var chemia = new TreeNode<string>("Chemia");
var foto = new TreeNode<string>("Fotografia");
var malarstwo = new TreeNode<string>("Malarstwo");
var optyka = new TreeNode<string>("Optyka");

root.AddChild(nauka); root.AddChild(hobby);
nauka.AddChild(fizyka); nauka.AddChild(chemia);
hobby.AddChild(foto); hobby.AddChild(malarstwo);
fizyka.AddChild(optyka);

// Iterator wewnętrzny — DFS przez rekurencję
Console.WriteLine("DFS preorder (iterator wewnętrzny — ForEach):");
int depth = 0;
root.ForEach(value =>
{
    // Wewnętrzny iterator nie dostarcza głębokości — problem!
    Console.WriteLine($"  {value}");
});

// Map — transformacja wartości w drzewie
Console.WriteLine("\nDrzewo po Map (ToUpper):");
TreeNode<string> upperTree = root.Map(s => s.ToUpper());
upperTree.ForEach(v => Console.WriteLine($"  {v}"));

// Fold — zlicz wszystkie węzły
int nodeCount = root.Fold(0, (acc, _) => acc + 1);
Console.WriteLine($"\nLiczba węzłów: {nodeCount}");

// Collect — zbierz wszystkie wartości
List<string> allValues = root.Collect();
Console.WriteLine($"Wszystkie wartości: [{string.Join(", ", allValues)}]");

// ─── DEMO 3: Porównanie z iteratorem zewnętrznym ──────────────────────────────

Console.WriteLine("\n═══ DEMO 3: Wewnętrzny vs Zewnętrzny — ograniczenia ═══\n");

// Zewnętrzny — daje dostęp do głębokości / ścieżki
Console.WriteLine("Zewnętrzny iterator — z głębokością:");
foreach ((string value, int d) in root.DfsWithDepth())
    Console.WriteLine($"  {"  ".PadLeft(d * 2)}{value} (głębokość={d})");

Console.WriteLine("\n► Iterator wewnętrzny nie może łatwo dostarczyć stanu (głębokości, ścieżki).");
Console.WriteLine("► Iterator zewnętrzny daje pełną kontrolę ale wymaga więcej kodu.\n");

// ─── DEMO 4: Funkcyjny styl — composability ──────────────────────────────────

Console.WriteLine("═══ DEMO 4: Funkcyjny styl z iteratorem wewnętrznym ═══\n");

var numbers = new FunctionalList<int>([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

// Łańcuchowanie operacji (jak LINQ, ale bez IEnumerable)
int sumOfSquaresOfEvens = numbers
    .Filter(n => n % 2 == 0)   // [2, 4, 6, 8, 10]
    .Map(n => n * n)             // [4, 16, 36, 64, 100]
    .Fold(0, (acc, n) => acc + n); // 220

Console.WriteLine($"Suma kwadratów liczb parzystych: {sumOfSquaresOfEvens}");

// Porównaj z LINQ
int linq = Enumerable.Range(1, 10)
    .Where(n => n % 2 == 0)
    .Select(n => n * n)
    .Sum();
Console.WriteLine($"Wynik LINQ (kontrolny):          {linq}");

// ─────────────────────────────────────────────────────────────────────────────
// Implementacje
// ─────────────────────────────────────────────────────────────────────────────

enum Priority { Low, Medium, High }
record WorkTask(string Name, Priority Priority, bool Done);

// Iterator wewnętrzny na liście
class TaskList
{
    private readonly List<WorkTask> _tasks = [];
    public void Add(WorkTask t) => _tasks.Add(t);

    public void ForEach(Action<WorkTask> action)
    {
        foreach (var t in _tasks) action(t);
    }

    public TaskList<TResult> Map<TResult>(Func<WorkTask, TResult> transform)
    {
        var result = new TaskList<TResult>();
        foreach (var t in _tasks) result.Add(transform(t));
        return result;
    }

    public TResult Fold<TResult>(TResult seed, Func<TResult, WorkTask, TResult> combine)
    {
        TResult acc = seed;
        foreach (var t in _tasks) acc = combine(acc, t);
        return acc;
    }
}

class TaskList<T>
{
    private readonly List<T> _items = [];
    public void Add(T item) => _items.Add(item);
    public void ForEach(Action<T> action) { foreach (var i in _items) action(i); }
}

// Drzewo z iteratorem wewnętrznym
class TreeNode<T>(T value)
{
    public T Value { get; } = value;
    private readonly List<TreeNode<T>> _children = [];
    public IReadOnlyList<TreeNode<T>> Children => _children;

    public void AddChild(TreeNode<T> child) => _children.Add(child);

    // Iterator wewnętrzny — DFS preorder
    public void ForEach(Action<T> action)
    {
        action(Value);
        foreach (var child in _children)
            child.ForEach(action); // rekurencja
    }

    // Map — tworzy nowe drzewo z przetransformowanymi wartościami
    public TreeNode<TResult> Map<TResult>(Func<T, TResult> transform)
    {
        var newNode = new TreeNode<TResult>(transform(Value));
        foreach (var child in _children)
            newNode.AddChild(child.Map(transform));
        return newNode;
    }

    // Fold (reduce) — agregacja
    public TResult Fold<TResult>(TResult seed, Func<TResult, T, TResult> combine)
    {
        TResult acc = combine(seed, Value);
        foreach (var child in _children)
            acc = child.Fold(acc, combine);
        return acc;
    }

    // Collect — zebierz wszystkie wartości
    public List<T> Collect()
    {
        var result = new List<T>();
        ForEach(v => result.Add(v));
        return result;
    }

    // Iterator zewnętrzny z głębokością — pokazuje ograniczenie wewnętrznego
    public IEnumerable<(T Value, int Depth)> DfsWithDepth(int depth = 0)
    {
        yield return (Value, depth);
        foreach (var child in _children)
            foreach (var item in child.DfsWithDepth(depth + 1))
                yield return item;
    }
}

// Funkcyjna lista z wewnętrznymi iteratorami
class FunctionalList<T>(IEnumerable<T> items)
{
    private readonly List<T> _items = [.. items];

    public FunctionalList<T> Filter(Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var item in _items)
            if (predicate(item)) result.Add(item);
        return new FunctionalList<T>(result);
    }

    public FunctionalList<TResult> Map<TResult>(Func<T, TResult> transform)
    {
        var result = new List<TResult>();
        foreach (var item in _items) result.Add(transform(item));
        return new FunctionalList<TResult>(result);
    }

    public TResult Fold<TResult>(TResult seed, Func<TResult, T, TResult> combine)
    {
        TResult acc = seed;
        foreach (var item in _items) acc = combine(acc, item);
        return acc;
    }
}
