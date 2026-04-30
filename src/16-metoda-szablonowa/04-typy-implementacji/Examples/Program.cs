// =============================================================================
// Wzorzec Metoda Szablonowa — 04. Typy implementacji
// Demonstruje: 4 typy + schemat wyboru + porównanie z interfejsem domyślnym
// =============================================================================

// ─── TYP 1: Czysto abstrakcyjny ───────────────────────────────────────────────

Console.WriteLine("═══ TYP 1: Czysto abstrakcyjny (wszystkie kroki obowiązkowe) ═══\n");

int[] data = [5, 3, 8, 1, 9, 2, 7, 4, 6];

AbstractSorter bubble = new BubbleSorter();
bubble.Sort([.. data]);

AbstractSorter insertion = new InsertionSorter();
insertion.Sort([.. data]);

// ─── TYP 2: Z haczykami ───────────────────────────────────────────────────────

Console.WriteLine("\n═══ TYP 2: Z haczykami (hooks — opcjonalne rozszerzenia) ═══\n");

CaffeineRecipe[] drinks = [new Coffee(), new Tea(), new HerbalTea()];
foreach (var drink in drinks)
{
    Console.WriteLine($"\n▸ {drink.GetType().Name}:");
    drink.Prepare();
}

// ─── TYP 3: Z implementacjami domyślnymi ────────────────────────────────────

Console.WriteLine("\n═══ TYP 3: Z domyślnymi implementacjami (podklasa przesłania co chce) ═══\n");

HttpRequestHandler[] handlers =
[
    new PublicApiHandler(),
    new AdminApiHandler(),
    new AuditedApiHandler(),
];

var fakeRequest = new HttpRequest("/api/data", "GET", "user123");
foreach (var handler in handlers)
{
    Console.WriteLine($"\n▸ {handler.GetType().Name}:");
    handler.Handle(fakeRequest);
}

// ─── TYP 4: Delegaty — bez dziedziczenia ─────────────────────────────────────

Console.WriteLine("\n═══ TYP 4: Delegaty / Func<> — bez hierarchii klas ═══\n");

var etlPipeline = new DataPipeline(
    extract:   () => { Console.WriteLine("  Extract: czytam z bazy"); return "raw_data"; },
    transform: data => { Console.WriteLine($"  Transform: przetwarzam '{data}'"); return data.ToUpperInvariant(); },
    load:      data => Console.WriteLine($"  Load: zapisuję '{data}' do hurtowni")
);
etlPipeline.Run();

Console.WriteLine();

var apiPipeline = new DataPipeline(
    extract:   () => { Console.WriteLine("  Extract: pobieram z REST API"); return "{\"id\":1}"; },
    transform: data => { Console.WriteLine($"  Transform: parsowanie JSON"); return "Record(id=1)"; },
    load:      data => Console.WriteLine($"  Load: cache Redis ← {data}")
);
apiPipeline.Run();

// ─── PORÓWNANIE: abstract vs interface default methods (C# 8+) ───────────────

Console.WriteLine("\n═══ PORÓWNANIE: abstract class vs interface (C# 8+ default methods) ═══\n");

IDocumentProcessor[] docProcessors =
[
    new PdfProcessor(),
    new WordProcessor(),
];

foreach (var proc in docProcessors)
{
    Console.WriteLine($"\n▸ {proc.GetType().Name} (przez interfejs):");
    proc.ProcessDocument("sample.doc");
}

// ─── SCHEMAT WYBORU ───────────────────────────────────────────────────────────

Console.WriteLine("\n═══ SCHEMAT WYBORU — kiedy który typ? ═══\n");
Console.WriteLine("Typ 1 — czysto abstract:       Wszystkie kroki unikalne (sorter, parser formatów)");
Console.WriteLine("Typ 2 — z haczykami:           Opcjonalne rozszerzenia (napoje, zamówienia VIP)");
Console.WriteLine("Typ 3 — domyślne implementacje: Większość kroków ma sensowne defaults (HTTP handlers)");
Console.WriteLine("Typ 4 — delegaty:              Unikasz hierarchii, testowalność, IoC container");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── Typ 1: Czysto abstrakcyjny ──────────────────────────────────────────────

abstract class AbstractSorter
{
    // Metoda szablonowa
    public void Sort(int[] data)
    {
        Console.WriteLine($"  [{GetType().Name}] Sortuję {data.Length} elementów...");
        var sw = System.Diagnostics.Stopwatch.StartNew();
        DoSort(data);
        sw.Stop();
        Verify(data);
        Console.WriteLine($"  [{GetType().Name}] Gotowe! ({sw.ElapsedTicks} ticks)");
        Console.WriteLine($"  Wynik: [{string.Join(", ", data)}]");
    }

    protected abstract void DoSort(int[] data);

    // Verify jest wspólne — ale każdy sorter może je zaimplementować inaczej
    protected virtual void Verify(int[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
            if (data[i] > data[i + 1])
                throw new Exception($"Błąd sortowania na pozycji {i}!");
    }
}

class BubbleSorter : AbstractSorter
{
    protected override void DoSort(int[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
            for (int j = 0; j < data.Length - i - 1; j++)
                if (data[j] > data[j + 1])
                    (data[j], data[j + 1]) = (data[j + 1], data[j]);
    }
}

class InsertionSorter : AbstractSorter
{
    protected override void DoSort(int[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            int key = data[i];
            int j = i - 1;
            while (j >= 0 && data[j] > key)
            {
                data[j + 1] = data[j];
                j--;
            }
            data[j + 1] = key;
        }
    }
}

// ─── Typ 2: Z haczykami ──────────────────────────────────────────────────────

abstract class CaffeineRecipe
{
    public void Prepare()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (WantsCondiments())  // hook-guard: decyduje czy wywołać AddCondiments
            AddCondiments();
        if (WantsServed())       // hook-guard: opcjonalne podanie do stołu
            ServeAtTable();
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();

    // Kroki wspólne (nieabstrakcyjne)
    protected void BoilWater() => Console.WriteLine("  Gotuję wodę");
    protected void PourInCup() => Console.WriteLine("  Wlewam do filiżanki");

    // Hooki — domyślne wartości
    protected virtual bool WantsCondiments() => true;
    protected virtual bool WantsServed() => false;
    protected virtual void ServeAtTable() => Console.WriteLine("  Podaję do stolika");
}

class Coffee : CaffeineRecipe
{
    protected override void Brew() => Console.WriteLine("  Parzę kawę (filtr)");
    protected override void AddCondiments() => Console.WriteLine("  Mleko i cukier");
}

class Tea : CaffeineRecipe
{
    protected override void Brew() => Console.WriteLine("  Zaparzam herbatę (3 min)");
    protected override void AddCondiments() => Console.WriteLine("  Plaster cytryny");
    // Hook: herbata serwowana do stolika
    protected override bool WantsServed() => true;
}

class HerbalTea : CaffeineRecipe
{
    protected override void Brew() => Console.WriteLine("  Zaparzam ziołową (5 min)");
    protected override void AddCondiments() { } // pusta — bez dodatków
    // Hook: bez kondymentów i bez serwowania
    protected override bool WantsCondiments() => false;
}

// ─── Typ 3: Z domyślnymi implementacjami ─────────────────────────────────────

record HttpRequest(string Path, string Method, string User);

abstract class HttpRequestHandler
{
    public void Handle(HttpRequest req)
    {
        if (!Authenticate(req))
        {
            Console.WriteLine("  401 Unauthorized");
            return;
        }
        if (!Authorize(req))
        {
            Console.WriteLine("  403 Forbidden");
            return;
        }
        var result = Process(req);
        Log(req, result);
        Console.WriteLine($"  200 OK: {result}");
    }

    protected virtual bool Authenticate(HttpRequest req) => true;     // domyślnie: wszyscy uwierzytelnieni
    protected virtual bool Authorize(HttpRequest req) => true;         // domyślnie: wszyscy uprawnieni
    protected abstract string Process(HttpRequest req);
    protected virtual void Log(HttpRequest req, string result)
        => Console.WriteLine($"  [LOG] {req.Method} {req.Path} → {result}");
}

class PublicApiHandler : HttpRequestHandler
{
    // Używa wszystkich domyślnych — tylko Process jest unikalne
    protected override string Process(HttpRequest req)
        => $"Dane publiczne dla: {req.Path}";
}

class AdminApiHandler : HttpRequestHandler
{
    protected override bool Authorize(HttpRequest req)
    {
        bool isAdmin = req.User.Contains("admin");
        Console.WriteLine($"  Admin check: {req.User} → {(isAdmin ? "OK" : "BRAK UPRAWNIEŃ")}");
        return isAdmin;
    }
    protected override string Process(HttpRequest req)
        => $"Dane administratora: {req.Path}";
}

class AuditedApiHandler : HttpRequestHandler
{
    protected override string Process(HttpRequest req)
        => $"Dane z audytem: {req.Path}";
    // Rozszerzony log — z audytem
    protected override void Log(HttpRequest req, string result)
    {
        base.Log(req, result);
        Console.WriteLine($"  [AUDIT] {DateTime.UtcNow:O} | {req.User} | {req.Method} {req.Path}");
    }
}

// ─── Typ 4: Delegaty ─────────────────────────────────────────────────────────

class DataPipeline(
    Func<string> extract,
    Func<string, string> transform,
    Action<string> load)
{
    public void Run()
    {
        Console.WriteLine("  [Pipeline] Start");
        string raw = extract();
        string processed = transform(raw);
        load(processed);
        Console.WriteLine("  [Pipeline] Zakończony");
    }
}

// ─── Interfejsy default methods (C# 8+) ──────────────────────────────────────

interface IDocumentProcessor
{
    // Template Method jako default interface method (C# 8+)
    sealed void ProcessDocument(string path)
    {
        var content = Load(path);
        var validated = Validate(content);
        if (validated)
        {
            var result = Transform(content);
            Save(path, result);
        }
        OnComplete(path, validated); // hook
    }

    string Load(string path);
    bool Validate(string content);
    string Transform(string content);
    void Save(string path, string content);
    void OnComplete(string path, bool success) // hook z domyślną implementacją
        => Console.WriteLine($"  [DONE] {path}: {(success ? "OK" : "FAIL")}");
}

class PdfProcessor : IDocumentProcessor
{
    public string Load(string path) { Console.WriteLine($"  PDF: wczytuje {path}"); return "<pdf>content</pdf>"; }
    public bool Validate(string content) { Console.WriteLine("  PDF: walidacja XML"); return content.StartsWith("<"); }
    public string Transform(string content) { Console.WriteLine("  PDF: render do PNG"); return "[PNG]"; }
    public void Save(string path, string content) => Console.WriteLine($"  PDF: zapisuje output.png");
}

class WordProcessor : IDocumentProcessor
{
    public string Load(string path) { Console.WriteLine($"  Word: otwiera {path}"); return "Word document"; }
    public bool Validate(string content) { Console.WriteLine("  Word: spell check"); return true; }
    public string Transform(string content) { Console.WriteLine("  Word: konwersja do HTML"); return "<html>...</html>"; }
    public void Save(string path, string content) => Console.WriteLine($"  Word: zapisuje output.html");
}

