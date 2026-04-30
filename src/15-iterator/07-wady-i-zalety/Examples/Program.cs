// =============================================================================
// Wzorzec Iterator — 07. Wady i zalety w różnych sytuacjach
// Demonstruje: SRP, OCP, alokacje, modyfikacja podczas iteracji, alternatywy
// =============================================================================
using System.Collections;
using System.Diagnostics;

// ─── ZALETA 1: SRP — oddzielenie odpowiedzialności ───────────────────────────

Console.WriteLine("═══ ZALETA 1: Single Responsibility Principle ═══\n");

var zoo = new AnimalZoo();
zoo.AddAnimal(new Animal("Lew", "Lwy afrykańskie", true));
zoo.AddAnimal(new Animal("Tygrys", "Wielkie koty azji", false));
zoo.AddAnimal(new Animal("Słoń", "Słonie afrykańskie", true));
zoo.AddAnimal(new Animal("Żyrafa", "Parzystokopytne", false));

// Zoo zajmuje się przechowywaniem — nie musi wiedzieć jak iterować
Console.WriteLine("Iteracja forward (domyślna):");
foreach (Animal a in zoo) Console.WriteLine($"  {a.Name}");

// Iterator reverse — nowa odpowiedzialność, bez zmiany Zoo!
Console.WriteLine("\nIteracja reverse (nowy iterator, brak zmian w Zoo):");
foreach (Animal a in zoo.GetReverseIterator()) Console.WriteLine($"  {a.Name}");

// Iterator filtrujący — też bez zmian w Zoo!
Console.WriteLine("\nTylko zagrożone gatunki (nowy iterator, brak zmian w Zoo):");
foreach (Animal a in zoo.GetEndangeredIterator()) Console.WriteLine($"  ⚠ {a.Name}");

// ─── ZALETA 2: OCP — nowe iteratory bez zmian kolekcji ───────────────────────

Console.WriteLine("\n═══ ZALETA 2: Open/Closed Principle ═══\n");
Console.WriteLine("Zoo jest ZAMKNIĘTE na modyfikacje — każdy nowy iterator to osobna klasa.");
Console.WriteLine("Nowy typ iteracji (np. alfabetyczny) = nowa klasa, bez edycji Zoo.\n");

// Iterator alfabetyczny — dodany bez modyfikacji Zoo
Console.WriteLine("Iteracja alfabetyczna:");
foreach (Animal a in zoo.GetAlphabeticalIterator()) Console.WriteLine($"  {a.Name}");

// ─── ZALETA 3: Wiele niezależnych iteratorów ──────────────────────────────────

Console.WriteLine("\n═══ ZALETA 3: Wiele niezależnych kursorów ═══\n");

using var iter1 = zoo.GetEnumerator();
using var iter2 = zoo.GetEnumerator();
using var iter3 = zoo.GetEnumerator();

iter1.MoveNext(); // Lew
iter2.MoveNext(); iter2.MoveNext(); // Tygrys

Console.WriteLine("Trzy niezależne kursory w tej samej kolekcji:");
Console.WriteLine($"  Kursor 1: {iter1.Current.Name}");
Console.WriteLine($"  Kursor 2: {iter2.Current.Name}");
Console.WriteLine($"  Kursor 3: jeszcze nie rozpoczął");

// ─── WADA 1: Overkill dla prostych kolekcji ──────────────────────────────────

Console.WriteLine("\n═══ WADA 1: Iterator może być nadmiarowy ═══\n");

// Dla prostej List<T> — własny iterator to nadmiar
var simpleList = new List<string> { "A", "B", "C" };

Console.WriteLine("Dla prostej listy — foreach wystarczy:");
foreach (string s in simpleList) Console.Write(s + " ");
Console.WriteLine("\n(Nie potrzeba własnego iteratora — List<T> już go ma)");

// ─── WADA 2: Problem z modyfikacją ────────────────────────────────────────────

Console.WriteLine("\n═══ WADA 2: Modyfikacja podczas iteracji ═══\n");

var modList = new List<Animal>(zoo);

Console.WriteLine("NIEBEZPIECZNE — modyfikacja podczas foreach:");
try
{
    foreach (Animal a in modList)
    {
        if (a.Name == "Lew") modList.Remove(a);
    }
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"  ✗ {ex.Message}");
}

Console.WriteLine("\nBEZPIECZNE — iteracja po kopii:");
foreach (Animal a in modList.ToList()) // ToList() = kopia
{
    if (a.Name == "Tygrys") modList.Remove(a); // bezpieczne
}
Console.WriteLine($"  Lista po usunięciu Tygrysa: {modList.Count} elementów");

Console.WriteLine("\nBEZPIECZNE — iteracja wstecz (przy usuwaniu):");
var tempList = new List<Animal>(zoo);
for (int i = tempList.Count - 1; i >= 0; i--)
{
    if (!tempList[i].Endangered)
        tempList.RemoveAt(i); // bezpieczne — usuwamy od tyłu
}
Console.WriteLine($"  Pozostały tylko zagrożone: {string.Join(", ", tempList.Select(a => a.Name))}");

// ─── WADA 3: Reset() i yield return ──────────────────────────────────────────

Console.WriteLine("\n═══ WADA 3: Reset() i yield return ═══\n");

static IEnumerable<int> Generator()
{
    yield return 1;
    yield return 2;
    yield return 3;
}

using var gen = Generator().GetEnumerator();
gen.MoveNext(); Console.WriteLine($"Pierwszy element: {gen.Current}");

try
{
    gen.Reset(); // Generatory nie obsługują Reset()!
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"  ✗ Reset() nieobsługiwane: {ex.Message}");
    Console.WriteLine("  ► Stwórz nowy enumerator przez ponowne GetEnumerator()");
}

// ─── WADA 4: Alokacje ─────────────────────────────────────────────────────────

Console.WriteLine("\n═══ WADA 4: Alokacje (uwaga w hot paths) ═══\n");

// Każde GetEnumerator() alokuje obiekt (dla klas)
// Wyjątek: struct enumerators (np. List<T>.Enumerator)

var intList = new List<int>(Enumerable.Range(1, 1000));

var sw = Stopwatch.StartNew();
long sum1 = 0;
for (int i = 0; i < 100_000; i++)
{
    foreach (int n in intList) sum1 += n; // struct enumerator — bezalokacyjny!
}
sw.Stop();
Console.WriteLine($"foreach List<int> (struct): {sw.ElapsedMilliseconds}ms, suma={sum1}");

sw.Restart();
long sum2 = 0;
IEnumerable<int> enumerable = intList;
for (int i = 0; i < 100_000; i++)
{
    foreach (int n in enumerable) sum2 += n; // boxing — alokuje!
}
sw.Stop();
Console.WriteLine($"foreach IEnumerable<int> (boxing): {sw.ElapsedMilliseconds}ms, suma={sum2}");

Console.WriteLine("\n► W hot paths preferuj konkretny typ (List<T>) zamiast IEnumerable<T>");

// ─────────────────────────────────────────────────────────────────────────────
// Implementacje
// ─────────────────────────────────────────────────────────────────────────────

record Animal(string Name, string Species, bool Endangered);

class AnimalZoo : IEnumerable<Animal>
{
    private readonly List<Animal> _animals = [];
    public void AddAnimal(Animal a) => _animals.Add(a);

    // Forward iterator (domyślny)
    public IEnumerator<Animal> GetEnumerator() => _animals.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Nowe iteratory — OCP: bez zmian w Zoo!
    public IEnumerable<Animal> GetReverseIterator()
    {
        for (int i = _animals.Count - 1; i >= 0; i--)
            yield return _animals[i];
    }

    public IEnumerable<Animal> GetEndangeredIterator()
    {
        foreach (var a in _animals)
            if (a.Endangered) yield return a;
    }

    public IEnumerable<Animal> GetAlphabeticalIterator()
    {
        return _animals.OrderBy(a => a.Name);
    }
}
