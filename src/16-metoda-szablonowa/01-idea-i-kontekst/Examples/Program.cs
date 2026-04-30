// =============================================================================
// Wzorzec Metoda Szablonowa — 01. Idea i kontekst
// Demonstruje: problem duplikacji, ewolucję do wzorca, podstawowa struktura
// =============================================================================

// ─── CZĘŚĆ 1: Problem — kod bez wzorca ───────────────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 1: Problem — duplikacja szkieletu algorytmu ═══\n");

var records = new List<Record>
{
    new("Jan Kowalski", "jan@example.com", 42),
    new("Anna Nowak", "anna@example.com", 35),
    new("Piotr Wiśniewski", "piotr@example.com", 28),
};

Console.WriteLine("--- Eksporter CSV (bez wzorca) ---");
var csvBad = new BadCsvExporter();
csvBad.Export(records);

Console.WriteLine("\n--- Eksporter JSON (bez wzorca) ---");
var jsonBad = new BadJsonExporter();
jsonBad.Export(records);

Console.WriteLine("\n>>> Obserwacja: metody Export() są niemal identyczne!");
Console.WriteLine(">>> Zmiana w logowaniu = 2 edycje. Zmiana kolejności = 2 edycje.\n");

// ─── CZĘŚĆ 2: Rozwiązanie — Template Method ──────────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 2: Rozwiązanie — Metoda Szablonowa ═══\n");

Console.WriteLine("--- Eksporter CSV (z wzorcem) ---");
DataExporter csv = new CsvExporter();
csv.Export(records);

Console.WriteLine("\n--- Eksporter JSON (z wzorcem) ---");
DataExporter json = new JsonExporter();
json.Export(records);

Console.WriteLine("\n--- Eksporter XML (z wzorcem) ---");
DataExporter xml = new XmlExporter();
xml.Export(records);

// ─── CZĘŚĆ 3: Polimorfizm i jednolity interfejs ───────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 3: Polimorfizm — jeden interfejs, różne formaty ═══\n");

DataExporter[] exporters = [new CsvExporter(), new JsonExporter(), new XmlExporter()];

Console.WriteLine("Eksportuję do wszystkich formatów jedną pętlą:");
foreach (DataExporter exporter in exporters)
{
    Console.Write($"  Format: {exporter.GetType().Name,-15} → ");
    exporter.Export(records);
}

// =============================================================================
// WERSJA BEZ WZORCA (dla porównania)
// =============================================================================

record Record(string Name, string Email, int Age);

class BadCsvExporter
{
    public void Export(List<Record> records)
    {
        Console.WriteLine("  [1] Łączę z źródłem danych...");
        Console.WriteLine("  [2] Walidacja danych: OK");
        Console.WriteLine("  [3] Nagłówek: Name,Email,Age");
        foreach (var r in records)
            Console.WriteLine($"  [4] Wiersz: {r.Name},{r.Email},{r.Age}");
        Console.WriteLine("  [5] Zamykam plik CSV");
        Console.WriteLine("  [6] LOG: eksport CSV zakończony");
    }
}

class BadJsonExporter
{
    public void Export(List<Record> records)
    {
        Console.WriteLine("  [1] Łączę z źródłem danych..."); // duplikat!
        Console.WriteLine("  [2] Walidacja danych: OK");       // duplikat!
        Console.WriteLine("  [3] Nagłówek: {");
        foreach (var r in records)
            Console.WriteLine($"  [4]   {{\"name\":\"{r.Name}\",\"email\":\"{r.Email}\",\"age\":{r.Age}}}");
        Console.WriteLine("  [5] }");
        Console.WriteLine("  [6] LOG: eksport JSON zakończony"); // duplikat!
    }
}

// =============================================================================
// WERSJA Z WZORCEM
// =============================================================================

abstract class DataExporter
{
    // Metoda szablonowa — sealed: nikt nie zmieni kolejności kroków!
    public void Export(List<Record> records)
    {
        ConnectToSource();
        ValidateData(records);
        WriteHeader();
        foreach (var record in records)
            WriteRow(record);
        Finalize();
        LogResult(); // wspólna dla wszystkich — nie ma potrzeby duplikować
    }

    // Kroki obowiązkowe — każda podklasa MUSI je zaimplementować
    protected abstract void ConnectToSource();
    protected abstract void ValidateData(List<Record> records);
    protected abstract void WriteHeader();
    protected abstract void WriteRow(Record record);
    protected abstract void Finalize();

    // Krok wspólny — jedna implementacja dla wszystkich!
    protected virtual void LogResult()
        => Console.WriteLine($"  [LOG] Eksport {GetType().Name} zakończony pomyślnie.");
}

class CsvExporter : DataExporter
{
    protected override void ConnectToSource()
        => Console.WriteLine("  [1] CSV: łączę z bazą danych...");

    protected override void ValidateData(List<Record> records)
        => Console.WriteLine($"  [2] CSV: walidacja {records.Count} rekordów: OK");

    protected override void WriteHeader()
        => Console.WriteLine("  [3] CSV: Name,Email,Age");

    protected override void WriteRow(Record r)
        => Console.WriteLine($"  [4] CSV: {r.Name},{r.Email},{r.Age}");

    protected override void Finalize()
        => Console.WriteLine("  [5] CSV: zamykam plik .csv");
}

class JsonExporter : DataExporter
{
    protected override void ConnectToSource()
        => Console.WriteLine("  [1] JSON: łączę z REST API...");

    protected override void ValidateData(List<Record> records)
        => Console.WriteLine($"  [2] JSON: schema validation OK ({records.Count} records)");

    protected override void WriteHeader()
        => Console.WriteLine("  [3] JSON: [");

    protected override void WriteRow(Record r)
        => Console.WriteLine($"  [4] JSON:   {{\"name\":\"{r.Name}\",\"email\":\"{r.Email}\",\"age\":{r.Age}}}");

    protected override void Finalize()
        => Console.WriteLine("  [5] JSON: ]");
}

class XmlExporter : DataExporter
{
    protected override void ConnectToSource()
        => Console.WriteLine("  [1] XML: łączę z plikiem źródłowym...");

    protected override void ValidateData(List<Record> records)
        => Console.WriteLine($"  [2] XML: DTD validation OK ({records.Count} nodes)");

    protected override void WriteHeader()
        => Console.WriteLine("  [3] XML: <?xml version=\"1.0\"?><Records>");

    protected override void WriteRow(Record r)
        => Console.WriteLine($"  [4] XML:   <Record><Name>{r.Name}</Name><Email>{r.Email}</Email><Age>{r.Age}</Age></Record>");

    protected override void Finalize()
        => Console.WriteLine("  [5] XML: </Records>");
}

