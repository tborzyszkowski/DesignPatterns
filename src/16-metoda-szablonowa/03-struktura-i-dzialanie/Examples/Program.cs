// =============================================================================
// Wzorzec Metoda Szablonowa — 03. Struktura i działanie (GoF)
// Demonstruje: role GoF, diagram klas, sekwencja wywołań, konsekwencje
// =============================================================================

// ─── CZĘŚĆ 1: Kanoniczna struktura GoF ────────────────────────────────────────

Console.WriteLine("═══ CZĘŚĆ 1: Kanoniczna struktura GoF ═══\n");

Console.WriteLine("--- ConcreteClassA (bez hooka) ---");
AbstractClass objA = new ConcreteClassA();
objA.TemplateMethod();

Console.WriteLine("\n--- ConcreteClassB (z hookiem) ---");
AbstractClass objB = new ConcreteClassB();
objB.TemplateMethod();

// ─── CZĘŚĆ 2: Śledzenie przepływu sterowania ──────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 2: Przepływ sterowania — Hollywood Principle ═══\n");

Console.WriteLine("Klasa bazowa wywołuje metody podklasy — NIE odwrotnie!");
Console.WriteLine("Podklasa NIE wie kiedy zostanie wywołana.\n");

var traced = new TracedConcrete();
Console.WriteLine(">> Klient wywołuje: TemplateMethod()");
traced.TemplateMethod();

// ─── CZĘŚĆ 3: Przykład z domeną — przetwarzanie dokumentów ───────────────────

Console.WriteLine("\n═══ CZĘŚĆ 3: Przykład domenowy — DocumentProcessor ═══\n");

DocumentProcessor[] processors =
[
    new InvoiceProcessor(),
    new ContractProcessor(),
    new ReportProcessor(),
];

foreach (DocumentProcessor processor in processors)
{
    Console.WriteLine($"\n▸ {processor.GetType().Name}:");
    processor.Process("sample_document.txt");
}

// ─── CZĘŚĆ 4: Konsekwencje stosowania wzorca ──────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 4: Konsekwencje — sealed vs. nicht sealed ═══\n");

// Demonstracja: co by się stało gdyby TemplateMethod NIE była sealed?
Console.WriteLine("TemplateMethod jest SEALED — żadna podklasa nie może zmienić kolejności:");
var safeProcessor = new SafeDocumentProcessor();
safeProcessor.Process("safe.txt");

// ─── CZĘŚĆ 5: Mapowanie na .NET ──────────────────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 5: Template Method w .NET — Stream ═══\n");

// System.IO.Stream to idealny przykład Template Method:
// CopyTo() to metoda szablonowa — wywołuje Read() i Write()
// Read() i Write() są abstrakcyjne — implementuje je MemoryStream, FileStream, etc.

using var ms = new System.IO.MemoryStream();
using var writer = new System.IO.StreamWriter(ms);
writer.Write("Hello, Template Method!");
writer.Flush();
ms.Seek(0, System.IO.SeekOrigin.Begin);
using var reader = new System.IO.StreamReader(ms);
Console.WriteLine($"Stream (Template Method w .NET): '{reader.ReadToEnd()}'");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── Kanoniczna struktura GoF ─────────────────────────────────────────────────

abstract class AbstractClass
{
    // METODA SZABLONOWA (Template Method) — nie-wirtualna, nie można przesłonić!
    public void TemplateMethod()
    {
        Console.WriteLine($"  [AbstractClass] TemplateMethod() START");
        PrimitiveOperation1();
        PrimitiveOperation2();
        Hook();
        Console.WriteLine($"  [AbstractClass] TemplateMethod() END");
    }

    // KROKI OBOWIĄZKOWE (Primitive Operations) — abstract
    protected abstract void PrimitiveOperation1();
    protected abstract void PrimitiveOperation2();

    // HACZYK (Hook) — virtual, domyślnie: nic nie robi
    protected virtual void Hook()
        => Console.WriteLine("  [AbstractClass] Hook() — domyślna implementacja (pusta)");
}

class ConcreteClassA : AbstractClass
{
    protected override void PrimitiveOperation1()
        => Console.WriteLine("  [ConcreteClassA] PrimitiveOperation1()");

    protected override void PrimitiveOperation2()
        => Console.WriteLine("  [ConcreteClassA] PrimitiveOperation2()");

    // Nie przesłania Hook — używa domyślnej (pustej)
}

class ConcreteClassB : AbstractClass
{
    protected override void PrimitiveOperation1()
        => Console.WriteLine("  [ConcreteClassB] PrimitiveOperation1()");

    protected override void PrimitiveOperation2()
        => Console.WriteLine("  [ConcreteClassB] PrimitiveOperation2()");

    // Przesłania Hook — dodaje własne zachowanie
    protected override void Hook()
        => Console.WriteLine("  [ConcreteClassB] Hook() — WŁASNA IMPLEMENTACJA!");
}

// ─── Śledzenie przepływu ─────────────────────────────────────────────────────

class TracedConcrete : AbstractClass
{
    protected override void PrimitiveOperation1()
        => Console.WriteLine("  << Podklasa: PrimitiveOperation1() - tu jesteśmy");

    protected override void PrimitiveOperation2()
        => Console.WriteLine("  << Podklasa: PrimitiveOperation2() - tu jesteśmy");

    protected override void Hook()
        => Console.WriteLine("  << Podklasa: Hook() - opcjonalne zachowanie");
}

// ─── Przykład domenowy ────────────────────────────────────────────────────────

abstract class DocumentProcessor
{
    // Metoda szablonowa
    public void Process(string filePath)
    {
        Open(filePath);
        var content = ReadContent();
        var validated = Validate(content);
        if (validated)
        {
            var processed = Transform(content);
            Save(processed);
        }
        else
        {
            OnValidationFailed(content); // hook
        }
        Close();
        LogResult(filePath, validated); // wspólne logowanie
    }

    protected abstract void Open(string filePath);
    protected abstract string ReadContent();
    protected abstract bool Validate(string content);
    protected abstract string Transform(string content);
    protected abstract void Save(string result);
    protected abstract void Close();

    // Hooki — opcjonalne zachowania
    protected virtual void OnValidationFailed(string content)
        => Console.WriteLine("  [WARN] Walidacja nieudana — pominięto dokument");

    protected virtual void LogResult(string path, bool success)
        => Console.WriteLine($"  [LOG] {path}: {(success ? "sukces" : "błąd")}");
}

class InvoiceProcessor : DocumentProcessor
{
    protected override void Open(string filePath) => Console.WriteLine($"  Otwieram fakturę: {filePath}");
    protected override string ReadContent() => "Faktura FV/2024/001, kwota: 1230.00 PLN";
    protected override bool Validate(string content) => content.Contains("FV/");
    protected override string Transform(string content) => $"[PRZETWORZONA] {content}";
    protected override void Save(string result) => Console.WriteLine($"  Zapisuję: {result}");
    protected override void Close() => Console.WriteLine("  Zamykam fakturę");
}

class ContractProcessor : DocumentProcessor
{
    protected override void Open(string filePath) => Console.WriteLine($"  Otwieram umowę: {filePath}");
    protected override string ReadContent() => "UMOWA NR 123 z dn. 2024-01-01";
    protected override bool Validate(string content) => content.StartsWith("UMOWA");
    protected override string Transform(string content) => content.ToUpperInvariant();
    protected override void Save(string result) => Console.WriteLine($"  Archiwizuję: {result}");
    protected override void Close() => Console.WriteLine("  Zamykam umowę");
    // Przesłania hook — umowy mają własny log
    protected override void LogResult(string path, bool success)
        => Console.WriteLine($"  [AUDIT] Umowa {path} przetworzona. Status: {(success ? "OK" : "FAIL")}");
}

class ReportProcessor : DocumentProcessor
{
    protected override void Open(string filePath) => Console.WriteLine($"  Otwieram raport: {filePath}");
    protected override string ReadContent() => "invalid_report"; // celowo zły
    protected override bool Validate(string content) => content.StartsWith("RAPORT");
    protected override string Transform(string content) => content;
    protected override void Save(string result) => Console.WriteLine($"  Zapisuję raport");
    protected override void Close() => Console.WriteLine("  Zamykam raport");
    // Przesłania hook walidacji
    protected override void OnValidationFailed(string content)
    {
        base.OnValidationFailed(content);
        Console.WriteLine("  [ERROR] Raport odrzucony! Wysyłam alert do działu IT.");
    }
}

// ─── Sealed zabezpieczenie ────────────────────────────────────────────────────

abstract class SafeProcessorBase
{
    // Nie-wirtualna — niemożliwe do przesłonięcia
    public void Process(string file)
    {
        Init(file);
        Execute();
        Cleanup();
    }
    protected abstract void Init(string file);
    protected abstract void Execute();
    protected virtual void Cleanup() => Console.WriteLine("  Czyszczenie zasobów");
}

class SafeDocumentProcessor : SafeProcessorBase
{
    protected override void Init(string file) => Console.WriteLine($"  Inicjalizacja dla: {file}");
    protected override void Execute() => Console.WriteLine("  Wykonuję przetwarzanie");
    // Nie może przesłonić Process() — gwarantuje to sealed!
}

