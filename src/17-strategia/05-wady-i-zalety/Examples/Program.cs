// =============================================================================
// Wzorzec Strategia — 05. Wady i zalety
// Demonstruje: OCP/SRP, over-engineering, testability, alternatywy
// =============================================================================

// ─── CZĘŚĆ 1: Zaleta — OCP (Open/Closed Principle) ───────────────────────────

Console.WriteLine("═══ CZĘŚĆ 1: OCP — nowa strategia BEZ modyfikacji Context ═══\n");

var calc = new PriceCalculator(new RegularPriceStrategy());
Console.WriteLine($"  Regularna:   {calc.Calculate(1000m):C}");

calc.SetStrategy(new MemberPriceStrategy(10));
Console.WriteLine($"  Członek -10%:{calc.Calculate(1000m):C}");

// Nowa strategia — dodana BEZ modyfikacji PriceCalculator!
calc.SetStrategy(new FlashSaleStrategy(50));
Console.WriteLine($"  Flash -50%:  {calc.Calculate(1000m):C}");

// ─── CZĘŚĆ 2: Zaleta — SRP (Single Responsibility) ───────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 2: SRP — rozdzielenie odpowiedzialności ═══\n");

// Context odpowiada za: przepływ, walidację, logowanie
// Strategia odpowiada za: algorytm sortowania
var sorter = new LoggingSorter<int>(new MergeSortStrategy<int>());
var result = sorter.Sort([5, 1, 3, 2, 4, 8, 6]);
Console.WriteLine($"  Wynik: [{string.Join(", ", result)}]");
Console.WriteLine($"  Logi: {string.Join(" | ", sorter.Log)}");

// ─── CZĘŚĆ 3: Zaleta — Testowalność ──────────────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 3: Testowalność — strategia niezależna od Context ═══\n");

// Strategia testowalna BEZ Context:
var bubbleSort = new BubbleSortAlgo<int>();
var testData = new[] { 3, 1, 4, 1, 5, 9 };
var sorted = bubbleSort.Sort(testData);
Console.WriteLine($"  BubbleSort test: [{string.Join(", ", sorted)}] — OK: {sorted.SequenceEqual([1, 1, 3, 4, 5, 9])}");

// Mockowanie strategii przez lambdę:
var mockSorter = new LoggingSorter<int>(new LambdaSortStrategy<int>(data => data.Reverse().ToArray()));
var mockResult = mockSorter.Sort([1, 2, 3]);
Console.WriteLine($"  Mock strategia: [{string.Join(", ", mockResult)}]");

// ─── CZĘŚĆ 4: Wada — Over-engineering ────────────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 4: Over-engineering — kiedy NIE używać Strategii ═══\n");

// ZŁY przykład: 2 warianty, nigdy się nie zmienią, proste
var withPattern = new GreeterWithStrategy(new FormalGreetingStrategy());
Console.WriteLine($"  [Wzorzec] {withPattern.Greet("Jan")}");

// DOBRY przykład: prosta metoda wystarczy!
Console.WriteLine($"  [Proste]  {Greeter.Greet("Jan", formal: true)}");
Console.WriteLine($"  [Proste]  {Greeter.Greet("Jan", formal: false)}");

Console.WriteLine("""

  Wzorzec Strategia jest over-engineeringiem gdy:
  ✗ Masz tylko 2 warianty
  ✗ Warianty nigdy nie będą dodawane
  ✗ Klient i tak musi znać oba warianty
  ✗ Algorytm nie zmienia się w runtime
""");

// ─── CZĘŚĆ 5: Wada — Klient musi znać strategie ──────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 5: Klient musi znać strategie (Factory łagodzi problem) ═══\n");

// Problem: klient musi wiedzieć jak tworzyć strategie
// Rozwiązanie: fabryka ukrywa to
var factory = new SortStrategyFactory<int>();
var strategy1 = factory.Create("merge");
var strategy2 = factory.Create("bubble");

var ctx1 = new SortContext<int>(strategy1);
var ctx2 = new SortContext<int>(strategy2);

Console.WriteLine($"  Merge:  [{string.Join(", ", ctx1.Sort([3, 1, 2]))}]");
Console.WriteLine($"  Bubble: [{string.Join(", ", ctx2.Sort([3, 1, 2]))}]");

// ─── CZĘŚĆ 6: Alternatywa — Metoda Szablonowa ────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 6: Alternatywa — Metoda Szablonowa ═══\n");

// Metoda Szablonowa gdy kroki algorytmu są wspólne
DataProcessor[] processors = [
    new CsvDataProcessor(),
    new JsonDataProcessor(),
];

foreach (var p in processors)
{
    var output = p.Process("surowe-dane");
    Console.WriteLine($"  {p.GetType().Name}: {output}");
}

Console.WriteLine("""

  Strategia vs Metoda Szablonowa:
  Strategia:        podmiana CAŁEGO algorytmu, kompozycja
  Metoda Szablonowa: podmiana KROKÓW algorytmu, dziedziczenie
""");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── OCP Demo ─────────────────────────────────────────────────────────────────

interface IPricingStrategy
{
    decimal Apply(decimal basePrice);
}

class RegularPriceStrategy : IPricingStrategy
{
    public decimal Apply(decimal basePrice) => basePrice;
}

class MemberPriceStrategy(decimal discountPercent) : IPricingStrategy
{
    public decimal Apply(decimal basePrice) => basePrice * (1 - discountPercent / 100);
}

// Nowa strategia — BEZ modyfikacji PriceCalculator!
class FlashSaleStrategy(decimal discountPercent) : IPricingStrategy
{
    public decimal Apply(decimal basePrice) => basePrice * (1 - discountPercent / 100);
}

class PriceCalculator(IPricingStrategy strategy)
{
    private IPricingStrategy _strategy = strategy;
    public void SetStrategy(IPricingStrategy s) => _strategy = s;
    public decimal Calculate(decimal price) => _strategy.Apply(price);
}

// ─── SRP + Testowalność Demo ──────────────────────────────────────────────────

interface ISortAlgorithm<T> where T : IComparable<T>
{
    T[] Sort(T[] data);
}

class MergeSortStrategy<T> : ISortAlgorithm<T> where T : IComparable<T>
{
    public T[] Sort(T[] data)
    {
        if (data.Length <= 1) return data;
        int mid = data.Length / 2;
        var left = Sort(data[..mid]);
        var right = Sort(data[mid..]);
        return Merge(left, right);
    }

    private static T[] Merge(T[] left, T[] right)
    {
        var result = new T[left.Length + right.Length];
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
            result[k++] = left[i].CompareTo(right[j]) <= 0 ? left[i++] : right[j++];
        while (i < left.Length) result[k++] = left[i++];
        while (j < right.Length) result[k++] = right[j++];
        return result;
    }
}

class BubbleSortAlgo<T> : ISortAlgorithm<T> where T : IComparable<T>
{
    public T[] Sort(T[] input)
    {
        var arr = input.ToArray();
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        return arr;
    }
}

class LambdaSortStrategy<T>(Func<T[], T[]> fn) : ISortAlgorithm<T> where T : IComparable<T>
{
    public T[] Sort(T[] data) => fn(data);
}

class LoggingSorter<T>(ISortAlgorithm<T> strategy) where T : IComparable<T>
{
    public List<string> Log { get; } = [];

    public T[] Sort(T[] data)
    {
        Log.Add($"Start: [{string.Join(",", data)}]");
        var result = strategy.Sort(data);
        Log.Add($"Done:  [{string.Join(",", result)}]");
        return result;
    }
}

// ─── Over-engineering Demo ────────────────────────────────────────────────────

interface IGreetingStrategy { string Greet(string name); }
class FormalGreetingStrategy : IGreetingStrategy
{
    public string Greet(string name) => $"Dzień dobry, {name}.";
}

class GreeterWithStrategy(IGreetingStrategy strategy)
{
    public string Greet(string name) => strategy.Greet(name);
}

// Prosta alternatywa
static class Greeter
{
    public static string Greet(string name, bool formal)
        => formal ? $"Dzień dobry, {name}." : $"Hej, {name}!";
}

// ─── Factory Demo ─────────────────────────────────────────────────────────────

class SortStrategyFactory<T> where T : IComparable<T>
{
    public ISortAlgorithm<T> Create(string name) => name switch
    {
        "bubble" => new BubbleSortAlgo<T>(),
        "merge" => new MergeSortStrategy<T>(),
        _ => throw new ArgumentException($"Nieznana strategia: {name}"),
    };
}

class SortContext<T>(ISortAlgorithm<T> strategy) where T : IComparable<T>
{
    public T[] Sort(T[] data) => strategy.Sort(data);
}

// ─── Metoda Szablonowa (alternatywa) ─────────────────────────────────────────

abstract class DataProcessor
{
    // Metoda Szablonowa — szkielet
    public string Process(string rawData)
    {
        var validated = Validate(rawData);
        var transformed = Transform(validated);
        return Format(transformed);
    }

    private static string Validate(string data) => data.Trim();
    protected abstract string Transform(string data);
    protected abstract string Format(string data);
}

class CsvDataProcessor : DataProcessor
{
    protected override string Transform(string data) => data.Replace("-", ",");
    protected override string Format(string data) => $"CSV: {data}";
}

class JsonDataProcessor : DataProcessor
{
    protected override string Transform(string data) => data.Replace("-", ":");
    protected override string Format(string data) => $"{{\"data\":\"{data}\"}}";
}
