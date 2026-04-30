// =============================================================================
// Wzorzec Metoda Szablonowa — 05. Wady i Zalety
// Demonstruje: DRY, Fragile Base Class, LSP, testowalność, alternatywy
// =============================================================================

// ─── ZALETA 1: DRY — eliminacja duplikacji ────────────────────────────────────

Console.WriteLine("═══ ZALETA 1: DRY — eliminacja duplikacji ═══\n");

Console.WriteLine("BEZ WZORCA (duplikacja):");
new BadCsvProcessor().Process("data.csv");
Console.WriteLine();
new BadJsonProcessor().Process("data.json");

Console.WriteLine("\nZ WZORCEM (bez duplikacji):");
AbstractDataProcessor csv = new CsvProcessor();
csv.Process("data.csv");
AbstractDataProcessor json = new JsonProcessor();
json.Process("data.json");

// ─── ZALETA 2: Kontrola rozszerzania (sealed) ─────────────────────────────────

Console.WriteLine("\n═══ ZALETA 2: Kontrola rozszerzania — sealed ═══\n");

PaymentProcessor payment = new CreditCardPayment();
payment.ExecutePayment(249.99m);

Console.WriteLine();
PaymentProcessor transfer = new BankTransferPayment();
transfer.ExecutePayment(1500.00m);

// ─── WADA 1: Fragile Base Class ───────────────────────────────────────────────

Console.WriteLine("\n═══ WADA 1: Fragile Base Class Problem ═══\n");

Console.WriteLine("Problem: bazowa klasa v1 działała. Dodanie nowego abstract");
Console.WriteLine("kroku w v2 powoduje błąd kompilacji u WSZYSTKICH podklas.");
Console.WriteLine();
Console.WriteLine("Rozwiązanie: dodawaj tylko virtual (z domyślną implementacją),");
Console.WriteLine("nigdy nie usuwaj ani nie zmieniaj istniejących abstract kroków.\n");

// Demonstracja: nowa wersja bazowej z hook (virtual) — NIE psuje istniejących podklas
AbstractReportV2 rep = new SalesReportV2();
rep.Generate();

// ─── WADA 2: LSP — ryzyko naruszenia ─────────────────────────────────────────

Console.WriteLine("\n═══ WADA 2: LSP (Liskov Substitution Principle) ═══\n");

Console.WriteLine("Prawidłowe: podklasa rozszerza, nie zwęża kontraktu bazowej.");
Console.WriteLine("Naruszenie: podklasa rzuca wyjątek w kroku, który bazowa");
Console.WriteLine("oczekuje bez wyjątku, lub modyfikuje skutki uboczne.\n");

// Demonstracja prawidłowa:
AbstractLogger[] loggers = [new FileLogger(), new ConsoleLogger()];
foreach (var logger in loggers)
{
    logger.LogMessage("System started");
}

// ─── WADA 3: Trudna testowalność ─────────────────────────────────────────────

Console.WriteLine("\n═══ WADA 3: Testowalność — abstract class vs delegaty ═══\n");

Console.WriteLine("Abstract class — wymaga konkretnej podklasy do testowania:");
AbstractDataProcessor testable = new TestableProcessor(
    open: p => $"content_of_{p}",
    validate: c => !string.IsNullOrEmpty(c),
    transform: c => c.ToUpperInvariant(),
    save: r => Console.WriteLine($"  [TEST] Saved: {r}")
);
testable.Process("test_input.dat");

Console.WriteLine("\nAlternatywa: Func<> - bezpośrednio testowalne w teście jednostkowym:");
var captured = new List<string>();
var delegatePipeline = new TestablePipeline(
    load: () => "raw_data",
    process: d => d.ToUpperInvariant(),
    save: r => captured.Add(r)
);
delegatePipeline.Run();
Console.WriteLine($"  Przechwycony wynik: [{string.Join(", ", captured)}]");

// ─── WADA 4: Głęboka hierarchia ──────────────────────────────────────────────

Console.WriteLine("\n═══ WADA 4: Głęboka hierarchia klas ═══\n");

Console.WriteLine("Hierarchia: AbstractBase → SpecializedBase → ConcreteClass");
Console.WriteLine("Problem: zachowanie rozproszone na 3 poziomach, trudny debug.\n");

AbstractBase concrete = new ConcreteThreeLevel();
concrete.Execute();

// ─── ALTERNATYWA: Kompozycja zamiast dziedziczenia ───────────────────────────

Console.WriteLine("\n═══ ALTERNATYWA: Strategia / Kompozycja ═══\n");

Console.WriteLine("Zamiast hierarchii klas — wstrzyknięte strategie:");
var exporter = new DataExporter(
    new JsonFormatter(),
    new FileStorage()
);
exporter.Export(["Record1", "Record2", "Record3"]);

Console.WriteLine("\nInny wariant — bez wzmiankowania wzorców:");
var csvExporter = new DataExporter(
    new CsvFormatter(),
    new DatabaseStorage()
);
csvExporter.Export(["Row1", "Row2"]);

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── DRY — BEZ wzorca ────────────────────────────────────────────────────────

class BadCsvProcessor
{
    public void Process(string path)
    {
        Console.WriteLine($"  [CSV] Otwieram: {path}");  // DUPLIKACJA
        Console.WriteLine($"  [CSV] Czytam zawartość");   // DUPLIKACJA
        Console.WriteLine("  [CSV] Parsowanie CSV");       // unikalne
        Console.WriteLine($"  [CSV] Zamykam");            // DUPLIKACJA
        Console.WriteLine($"  [CSV] Log: sukces");         // DUPLIKACJA
    }
}

class BadJsonProcessor
{
    public void Process(string path)
    {
        Console.WriteLine($"  [JSON] Otwieram: {path}");  // DUPLIKACJA
        Console.WriteLine($"  [JSON] Czytam zawartość");   // DUPLIKACJA
        Console.WriteLine("  [JSON] Parsowanie JSON");      // unikalne
        Console.WriteLine($"  [JSON] Zamykam");            // DUPLIKACJA
        Console.WriteLine($"  [JSON] Log: sukces");         // DUPLIKACJA
    }
}

// ─── DRY — Z wzorcem ─────────────────────────────────────────────────────────

abstract class AbstractDataProcessor
{
    public void Process(string path)
    {
        Console.WriteLine($"  [{GetType().Name}] Otwieram: {path}");   // raz!
        var content = Open(path);
        if (Validate(content))
        {
            var result = Transform(content);
            SaveResult(result);
        }
        Console.WriteLine($"  [{GetType().Name}] Log: sukces");         // raz!
    }

    protected abstract string Open(string path);
    protected abstract bool Validate(string content);
    protected abstract string Transform(string content);
    protected abstract void SaveResult(string result);
}

class CsvProcessor : AbstractDataProcessor
{
    protected override string Open(string path) => $"csv_data_from_{path}";
    protected override bool Validate(string c) => c.Contains("csv");
    protected override string Transform(string c) => c.Replace("_", ";");
    protected override void SaveResult(string r) => Console.WriteLine($"  CSV: {r}");
}

class JsonProcessor : AbstractDataProcessor
{
    protected override string Open(string path) => $"json_data_from_{path}";
    protected override bool Validate(string c) => c.Contains("json");
    protected override string Transform(string c) => $"{{\"{c}\"}}";
    protected override void SaveResult(string r) => Console.WriteLine($"  JSON: {r}");
}

// ─── Kontrola — sealed ───────────────────────────────────────────────────────

abstract class PaymentProcessor
{
    public void ExecutePayment(decimal amount)
    {
        Console.WriteLine($"  Płatność: {amount:C}");
        Validate(amount);
        Authorize(amount);
        Charge(amount);
        SendConfirmation(amount); // hook
    }

    protected virtual void Validate(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Kwota musi być > 0");
        Console.WriteLine("  Walidacja kwoty: OK");
    }

    protected abstract void Authorize(decimal amount);
    protected abstract void Charge(decimal amount);
    protected virtual void SendConfirmation(decimal amount)
        => Console.WriteLine("  Wysłano potwierdzenie e-mail");
}

class CreditCardPayment : PaymentProcessor
{
    protected override void Authorize(decimal a) => Console.WriteLine("  CC: Autoryzacja 3DS");
    protected override void Charge(decimal a) => Console.WriteLine($"  CC: Obciążono kartę {a:C}");
}

class BankTransferPayment : PaymentProcessor
{
    protected override void Authorize(decimal a) => Console.WriteLine("  BT: Sprawdzam saldo konta");
    protected override void Charge(decimal a) => Console.WriteLine($"  BT: Przelew {a:C} wykonany");
    protected override void SendConfirmation(decimal a)
    {
        base.SendConfirmation(a);
        Console.WriteLine("  BT: Dodatkowe powiadomienie SMS");
    }
}

// ─── Fragile Base Class — rozwiązanie (virtual, nie abstract) ────────────────

abstract class AbstractReportV2
{
    public void Generate()
    {
        FetchData();
        Render();
        AddFooter();         // NOWY krok — virtual (nie abstract!) — nie psuje podklas
        Export();
    }
    protected abstract void FetchData();
    protected abstract void Render();
    protected virtual void AddFooter()
        => Console.WriteLine("  Footer: Generowany automatycznie");
    protected abstract void Export();
}

class SalesReportV2 : AbstractReportV2
{
    protected override void FetchData() => Console.WriteLine("  Sprzedaż: ładuję dane");
    protected override void Render() => Console.WriteLine("  Sprzedaż: rendering tabeli");
    protected override void Export() => Console.WriteLine("  Sprzedaż: eksport do PDF");
    // AddFooter() NIE musi być przesłonięty — nie psuje się po aktualizacji bazowej
}

// ─── LSP — prawidłowe użycie ─────────────────────────────────────────────────

abstract class AbstractLogger
{
    public void LogMessage(string msg)
    {
        var formatted = FormatMessage(msg);  // podklasa formatuje
        WriteLog(formatted);                  // podklasa zapisuje
        if (ShouldFlush())                   // hook
            Flush();
    }
    protected abstract string FormatMessage(string msg);
    protected abstract void WriteLog(string formatted);
    protected virtual bool ShouldFlush() => false;
    protected virtual void Flush() { }
}

class FileLogger : AbstractLogger
{
    protected override string FormatMessage(string msg)
        => $"[{DateTime.UtcNow:HH:mm:ss}] {msg}";
    protected override void WriteLog(string f)
        => Console.WriteLine($"  FILE: {f}");
    protected override bool ShouldFlush() => true;
    protected override void Flush() => Console.WriteLine("  FILE: buffer flush");
}

class ConsoleLogger : AbstractLogger
{
    protected override string FormatMessage(string msg)
        => $"> {msg}";
    protected override void WriteLog(string f)
        => Console.WriteLine($"  CONSOLE: {f}");
}

// ─── Testowalność — testowalna podklasa ──────────────────────────────────────

class TestableProcessor(
    Func<string, string> open,
    Func<string, bool> validate,
    Func<string, string> transform,
    Action<string> save) : AbstractDataProcessor
{
    protected override string Open(string path) => open(path);
    protected override bool Validate(string c) => validate(c);
    protected override string Transform(string c) => transform(c);
    protected override void SaveResult(string r) => save(r);
}

class TestablePipeline(
    Func<string> load,
    Func<string, string> process,
    Action<string> save)
{
    public void Run()
    {
        var data = load();
        var result = process(data);
        save(result);
    }
}

// ─── Głęboka hierarchia ──────────────────────────────────────────────────────

abstract class AbstractBase
{
    public void Execute()
    {
        StepA(); // poziom 1
        StepB(); // poziom 2
        StepC(); // poziom 3
    }
    protected abstract void StepA();
    protected abstract void StepB();
    protected abstract void StepC();
}

abstract class SpecializedBase : AbstractBase
{
    protected override void StepA() => Console.WriteLine("  Level2: StepA — wspólne dla specjalizacji");
    // StepB i StepC nadal abstract
}

class ConcreteThreeLevel : SpecializedBase
{
    // StepA z Level2 (dziedziczone)
    protected override void StepB() => Console.WriteLine("  Level3: StepB");
    protected override void StepC() => Console.WriteLine("  Level3: StepC");
}

// ─── Alternatywa: Kompozycja + Strategia ─────────────────────────────────────

interface IFormatter
{
    string Format(IEnumerable<string> records);
}

interface IStorage
{
    void Save(string data);
}

class JsonFormatter : IFormatter
{
    public string Format(IEnumerable<string> records)
        => $"[{string.Join(",", records.Select(r => $"\"{r}\""))}]";
}

class CsvFormatter : IFormatter
{
    public string Format(IEnumerable<string> records)
        => string.Join("\n", records);
}

class FileStorage : IStorage
{
    public void Save(string data) => Console.WriteLine($"  FILE: {data[..Math.Min(50, data.Length)]}...");
}

class DatabaseStorage : IStorage
{
    public void Save(string data) => Console.WriteLine($"  DB: INSERT {data.Length} znaków");
}

class DataExporter(IFormatter formatter, IStorage storage)
{
    public void Export(IEnumerable<string> records)
    {
        Console.WriteLine("  Formatowanie...");
        var formatted = formatter.Format(records);
        storage.Save(formatted);
        Console.WriteLine("  Eksport zakończony");
    }
}

