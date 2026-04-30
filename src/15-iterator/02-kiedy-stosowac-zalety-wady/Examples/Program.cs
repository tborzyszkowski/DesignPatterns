// =============================================================================
// Wzorzec Iterator — 02. Kiedy stosować, zalety i wady
// Demonstruje: różne odmiany iteratora, kiedy jest korzystny, kiedy nie
// =============================================================================
using System.Collections;

// ─── SCENARIUSZ 1: Kiedy iterator jest korzystny — ukrywanie struktury ────────

Console.WriteLine("═══ SCENARIUSZ 1: Ukrywanie struktury wewnętrznej ═══\n");

// Kolekcja może zmienić implementację — klient nie musi tego wiedzieć
IEnumerable<string> fruits = new FruitBasket(["jabłko", "banan", "gruszka", "śliwka"]);
Console.WriteLine("Owoce (przez foreach — IEnumerable<string>):");
foreach (string fruit in fruits)
    Console.WriteLine($"  • {fruit}");

Console.WriteLine("\n► Zmień FruitBasket z tablicy na HashSet — foreach działa tak samo!\n");

// ─── SCENARIUSZ 2: Wiele niezależnych iteratorów ──────────────────────────────

Console.WriteLine("═══ SCENARIUSZ 2: Wiele równoległych iteratorów ═══\n");

var numbers = new NumberList([10, 20, 30, 40, 50]);

// Dwa niezależne kursory — niemożliwe bez wzorca
using var iter1 = numbers.GetEnumerator();
using var iter2 = numbers.GetEnumerator();

iter1.MoveNext(); iter1.MoveNext();  // iter1 → 20
iter2.MoveNext();                     // iter2 → 10

Console.WriteLine($"Iter1 wskazuje na: {iter1.Current}");
Console.WriteLine($"Iter2 wskazuje na: {iter2.Current}");
Console.WriteLine("► Iteratory są niezależnymi kursorami!\n");

// ─── SCENARIUSZ 3: Odmiany iteratora ─────────────────────────────────────────

Console.WriteLine("═══ SCENARIUSZ 3: Odmiany wzorca Iterator ═══\n");

int[] data = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3];

// 3a. Iterator do przodu (domyślny)
Console.Write("Forward:  ");
foreach (int n in data) Console.Write(n + " ");
Console.WriteLine();

// 3b. Iterator wsteczny
Console.Write("Reverse:  ");
foreach (int n in data.AsReverse()) Console.Write(n + " ");
Console.WriteLine();

// 3c. Iterator filtrujący (własna implementacja, nie LINQ)
Console.Write("Filter>4: ");
foreach (int n in data.WhereCustom(x => x > 4)) Console.Write(n + " ");
Console.WriteLine();

// 3d. Nieskończony generator Fibonacciego
Console.Write("Fibonacci: ");
foreach (int fib in Fibonacci().Take(10)) Console.Write(fib + " ");
Console.WriteLine("\n");

// ─── SCENARIUSZ 4: Kiedy iterator jest ZBĘDNY (LINQ jest lepszy) ──────────────

Console.WriteLine("═══ SCENARIUSZ 4: Kiedy LINQ jest lepszym wyborem ═══\n");

var employees = new List<Employee>
{
    new("Anna", "IT", 8000m),
    new("Bartek", "HR", 5000m),
    new("Celina", "IT", 9000m),
    new("Damian", "HR", 6000m),
    new("Ewa", "IT", 7500m),
};

// Z LINQ — czytelniejsze niż własny iterator filtrujący
Console.WriteLine("Pracownicy IT zarabiający >7500 (LINQ):");
var itHighEarners = employees
    .Where(e => e.Department == "IT" && e.Salary > 7500)
    .OrderByDescending(e => e.Salary);

foreach (var emp in itHighEarners)
    Console.WriteLine($"  {emp.Name}: {emp.Salary:C0}");

Console.WriteLine("\n► LINQ jest lepszy niż własny iterator gdy: filter + sort + group + project\n");

// ─── SCENARIUSZ 5: Zalety — leniwe generowanie ────────────────────────────────

Console.WriteLine("═══ SCENARIUSZ 5: Leniwa sekwencja — korzyść iteratora ═══\n");

// Bez iteratora: wszystkie liczby pierwsze do 1000 w pamięci
// Z iteratorem: generujemy tylko tyle ile potrzeba

Console.Write("Pierwsze 8 liczb pierwszych (generator lazy): ");
foreach (int prime in PrimeGenerator().Take(8))
    Console.Write(prime + " ");
Console.WriteLine("\n");

// ─── SCENARIUSZ 6: Wada — modyfikacja podczas iteracji ───────────────────────

Console.WriteLine("═══ SCENARIUSZ 6: Wada — modyfikacja kolekcji podczas iteracji ═══\n");

var list = new List<int> { 1, 2, 3, 4, 5 };
Console.WriteLine("Próba modyfikacji listy podczas iteracji:");
try
{
    foreach (int item in list)
    {
        Console.Write(item + " ");
        if (item == 3) list.Add(99); // ← InvalidOperationException!
    }
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"\n  ✗ {ex.Message}");
    Console.WriteLine("  ► Trzeba iterować po kopii lub użyć indeksowania");
}

// ─────────────────────────────────────────────────────────────────────────────
// Implementacje
// ─────────────────────────────────────────────────────────────────────────────

class FruitBasket(string[] fruits) : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator() => ((IEnumerable<string>)fruits).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class NumberList(int[] numbers) : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator() => new NumberListEnumerator(numbers);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class NumberListEnumerator(int[] numbers) : IEnumerator<int>
{
    private int _index = -1;
    public bool MoveNext() { _index++; return _index < numbers.Length; }
    public int Current => numbers[_index];
    object IEnumerator.Current => Current;
    public void Reset() => _index = -1;
    public void Dispose() { }
}

static class IteratorExtensions
{
    // Własny iterator wsteczny (bez LINQ.Reverse)
    public static IEnumerable<T> AsReverse<T>(this T[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
            yield return array[i];
    }

    // Własny filtr (bez LINQ.Where)
    public static IEnumerable<T> WhereCustom<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
            if (predicate(item))
                yield return item;
    }
}

// Nieskończony generator Fibonacciego
static IEnumerable<int> Fibonacci()
{
    int a = 0, b = 1;
    while (true)
    {
        yield return a;
        (a, b) = (b, a + b);
    }
}

// Generator liczb pierwszych (Sieve of Eratosthenes — leniwy)
static IEnumerable<int> PrimeGenerator()
{
    yield return 2;
    var primes = new List<int> { 2 };
    for (int candidate = 3; ; candidate += 2)
    {
        bool isPrime = true;
        foreach (int p in primes)
        {
            if (p * p > candidate) break;
            if (candidate % p == 0) { isPrime = false; break; }
        }
        if (isPrime) { primes.Add(candidate); yield return candidate; }
    }
}

record Employee(string Name, string Department, decimal Salary);
