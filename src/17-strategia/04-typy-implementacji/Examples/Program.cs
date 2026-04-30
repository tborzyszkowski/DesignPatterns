// =============================================================================
// Wzorzec Strategia — 04. Typy implementacji
// Demonstruje: 4 warianty implementacji w C# z porównaniem
// =============================================================================

// ─── TYP 1: Interfejs — standardowy GoF ──────────────────────────────────────

Console.WriteLine("═══ TYP 1: Interfejs (domyślny wybór) ═══\n");

int[] data = [5, 2, 8, 1, 9, 3, 7];

ISortStrategy<int>[] interfaceStrategies = [
    new BubbleSortStrategy<int>(),
    new QuickSortStrategy<int>(),
    new InsertionSortStrategy<int>(),
];

foreach (var strategy in interfaceStrategies)
{
    var sorted = strategy.Sort(data);
    Console.WriteLine($"  {strategy.GetType().Name,25}: [{string.Join(", ", sorted)}]");
}

// ─── TYP 2: Klasa abstrakcyjna z logiką wspólną ──────────────────────────────

Console.WriteLine("\n═══ TYP 2: Klasa abstrakcyjna (z logiką bazową) ═══\n");

decimal netAmount = 1000m;
AbstractShippingStrategy[] shippingStrategies = [
    new StandardShipping(),
    new ExpressShipping(),
    new FreeShipping(),
];

foreach (var s in shippingStrategies)
{
    var cost = s.Calculate(netAmount);
    Console.WriteLine($"  {s.GetType().Name,18}: koszt={cost:C}, info={s.Description}");
}

// ─── TYP 3: Func<> jako strategia ────────────────────────────────────────────

Console.WriteLine("\n═══ TYP 3: Func<> / delegat (strategie inline) ═══\n");

// Strategie jako lambdy — zero klas!
Func<int[], int[]>[] lambdaStrategies = [
    arr => arr.OrderBy(x => x).ToArray(),
    arr => arr.OrderByDescending(x => x).ToArray(),
    arr => arr.OrderBy(_ => Guid.NewGuid()).ToArray(), // losowo
];

string[] lambdaNames = ["Rosnąco", "Malejąco", "Losowo  "];

for (int i = 0; i < lambdaStrategies.Length; i++)
{
    var result = lambdaStrategies[i](data);
    Console.WriteLine($"  {lambdaNames[i]}: [{string.Join(", ", result)}]");
}

// Func<> jako parametr kontekstu
var funcSorter = new FuncSorter<int>(arr => arr.OrderBy(x => x).ToArray());
Console.WriteLine($"\n  FuncSorter: [{string.Join(", ", funcSorter.Sort(data))}]");
funcSorter.SetStrategy(arr => arr.OrderByDescending(x => x).ToArray());
Console.WriteLine($"  FuncSorter: [{string.Join(", ", funcSorter.Sort(data))}]");

// ─── TYP 4: Enum + Słownik-fabryka ───────────────────────────────────────────

Console.WriteLine("\n═══ TYP 4: Enum + Słownik (wybór z konfiguracji) ═══\n");

var reportService = new ReportService();
string reportData = "Sprzedaż: 1.2M PLN";

foreach (ReportFormat fmt in Enum.GetValues<ReportFormat>())
{
    var output = reportService.Export(reportData, fmt);
    Console.WriteLine($"  {fmt}: {output}");
}

// Symulacja wyboru z pliku konfiguracyjnego
string formatFromConfig = "Xml"; // np. z appsettings.json
if (Enum.TryParse<ReportFormat>(formatFromConfig, out var configFmt))
{
    Console.WriteLine($"\n  Config format ({formatFromConfig}): {reportService.Export(reportData, configFmt)}");
}

// ─── PORÓWNANIE typów ─────────────────────────────────────────────────────────

Console.WriteLine("\n═══ Porównanie wszystkich typów ═══\n");

Console.WriteLine("""
  Typ 1 (Interfejs)        → Użyj domyślnie. DI-friendly, testowalny.
  Typ 2 (Klasa abstrakt.)  → Gdy strategie mają wspólny kod.
  Typ 3 (Func<>)           → Dla prostych algorytmów 1-5 linii.
  Typ 4 (Enum + Słownik)   → Gdy wybór pochodzi z konfiguracji/bazy.
""");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── TYP 1: Interfejs ─────────────────────────────────────────────────────────

interface ISortStrategy<T> where T : IComparable<T>
{
    IList<T> Sort(IEnumerable<T> data);
}

class BubbleSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IEnumerable<T> input)
    {
        var arr = input.ToArray();
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        return arr;
    }
}

class QuickSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IEnumerable<T> input) => QuickSort(input.ToList());

    private static List<T> QuickSort(List<T> list)
    {
        if (list.Count <= 1) return list;
        var pivot = list[list.Count / 2];
        var left = list.Where(x => x.CompareTo(pivot) < 0).ToList();
        var middle = list.Where(x => x.CompareTo(pivot) == 0).ToList();
        var right = list.Where(x => x.CompareTo(pivot) > 0).ToList();
        return [.. QuickSort(left), .. middle, .. QuickSort(right)];
    }
}

class InsertionSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IEnumerable<T> input)
    {
        var arr = input.ToArray();
        for (int i = 1; i < arr.Length; i++)
        {
            var key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j].CompareTo(key) > 0)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
        return arr;
    }
}

// ─── TYP 2: Klasa abstrakcyjna ────────────────────────────────────────────────

abstract class AbstractShippingStrategy
{
    // Wspólna logika: logowanie, ograniczenia wagowe, itp.
    public string Description { get; private set; } = "";

    public decimal Calculate(decimal orderValue)
    {
        var cost = ComputeCost(orderValue);
        Description = $"bazowa={GetBaseRate():C}, zmiana={cost - GetBaseRate():C}";
        return cost;
    }

    protected abstract decimal ComputeCost(decimal orderValue);
    protected abstract decimal GetBaseRate();
}

class StandardShipping : AbstractShippingStrategy
{
    protected override decimal GetBaseRate() => 15m;
    protected override decimal ComputeCost(decimal orderValue) => GetBaseRate();
}

class ExpressShipping : AbstractShippingStrategy
{
    protected override decimal GetBaseRate() => 30m;
    protected override decimal ComputeCost(decimal orderValue) => GetBaseRate() * 1.5m;
}

class FreeShipping : AbstractShippingStrategy
{
    protected override decimal GetBaseRate() => 0m;
    protected override decimal ComputeCost(decimal orderValue)
        => orderValue >= 200m ? 0m : 15m; // gratis przy zamówieniu ≥ 200 PLN
}

// ─── TYP 3: Func<> ────────────────────────────────────────────────────────────

class FuncSorter<T>(Func<T[], T[]> strategy)
{
    private Func<T[], T[]> _strategy = strategy;
    public void SetStrategy(Func<T[], T[]> s) => _strategy = s;
    public T[] Sort(T[] data) => _strategy(data);
}

// ─── TYP 4: Enum + Słownik ────────────────────────────────────────────────────

enum ReportFormat { Json, Csv, Xml, Markdown }

class ReportService
{
    private readonly Dictionary<ReportFormat, Func<string, string>> _strategies = new()
    {
        [ReportFormat.Json] = data => $"{{\"data\":\"{data}\"}}",
        [ReportFormat.Csv] = data => $"data\n{data}",
        [ReportFormat.Xml] = data => $"<data>{data}</data>",
        [ReportFormat.Markdown] = data => $"**{data}**",
    };

    public string Export(string data, ReportFormat format)
        => _strategies.TryGetValue(format, out var fn)
            ? fn(data)
            : throw new ArgumentOutOfRangeException(nameof(format));

    // Nowa strategia bez modyfikacji klasy — tylko słownik
    public void RegisterStrategy(ReportFormat format, Func<string, string> exporter)
        => _strategies[format] = exporter;
}
