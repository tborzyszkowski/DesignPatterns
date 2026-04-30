// =============================================================================
// Wzorzec Metoda Szablonowa — 02. Kiedy stosować, zalety, wady, odmiany
// =============================================================================

// ─── SYGNAŁ 1: Identyczna struktura kroków w wielu klasach ────────────────────

Console.WriteLine("═══ SYGNAŁ: Kiedy stosować Template Method ═══\n");

// Przykład: różne testy jednostkowe mają ten sam rytuał
// setup → execute → verify → teardown
// JUnit, NUnit, xUnit — wszystkie implementują ten wzorzec!

Console.WriteLine("--- Przykład: Testy jednostkowe (jak JUnit/NUnit) ---");
TestRunner runner = new OrderValidationTest();
runner.RunTest();

Console.WriteLine();
runner = new PaymentProcessorTest();
runner.RunTest();

// ─── ZALETA 1: DRY — eliminacja duplikacji ────────────────────────────────────

Console.WriteLine("\n═══ ZALETA 1: DRY — kod w jednym miejscu ═══\n");

// Zmiana logowania wpłynie na WSZYSTKIE game AI, bez edycji podklas
Console.WriteLine("AI tury gry — różne klasy, jeden szkielet:");
GameAI[] enemies = [new WarriorAI(), new MageAI(), new ArcherAI()];
foreach (GameAI ai in enemies)
    ai.TakeTurn();

// ─── ZALETA 2: Kontrola punktów rozszerzenia (hooks) ─────────────────────────

Console.WriteLine("\n═══ ZALETA 2: Hooki — kontrolowane punkty rozszerzenia ═══\n");

Console.WriteLine("Napoje kawiarniane (klasyczny przykład GoF/Head First):");
CaffeineRecipe[] drinks = [new Coffee(), new Tea(), new Espresso()];
foreach (CaffeineRecipe drink in drinks)
{
    Console.WriteLine($"\n▸ Przygotowuję: {drink.GetType().Name}");
    drink.PrepareRecipe();
}

// ─── WADA 1: Dziedziczenie — głęboka hierarchia ──────────────────────────────

Console.WriteLine("\n═══ WADA 1: Ryzyko — zbyt głęboka hierarchia ═══\n");
Console.WriteLine("Hierarchia A → B → C → D:  każdy poziom trudniej zrozumieć.");
Console.WriteLine("Template Method: maksymalnie 2–3 poziomy dziedziczenia!");

// Demonstracja problemu:
var deepC = new Level3Concrete();
deepC.Execute();

// ─── WADA 2: Fragile Base Class ───────────────────────────────────────────────

Console.WriteLine("\n═══ WADA 2: Fragile Base Class Problem ═══\n");
Console.WriteLine("Zmiana kolejności kroków w klasie bazowej zepsuje WSZYSTKIE podklasy.");
Console.WriteLine("Dlatego: metoda szablonowa powinna być 'sealed'!\n");

// Odmiana z delegatem — alternatywa bez dziedziczenia:
Console.WriteLine("Odmiana z delegatem (bez dziedziczenia):");
var pipeline = new DataPipeline(
    connect: () => Console.WriteLine("  Łączę z DB"),
    process: () => Console.WriteLine("  Przetwarzam dane"),
    save:    () => Console.WriteLine("  Zapisuję wyniki")
);
pipeline.Run();

// ─── ODMIANA: Porównanie 4 wariantów ─────────────────────────────────────────

Console.WriteLine("\n═══ ODMIANY: 4 warianty implementacji ═══\n");

// Wariant A: Czysto abstrakcyjny
Console.WriteLine("Wariant A — czysto abstrakcyjny (wszystkie kroki obowiązkowe):");
AbstractReport reportA = new SalesReport();
reportA.Generate();

// Wariant B: Z haczykami
Console.WriteLine("\nWariant B — z haczykami (opcjonalne rozszerzenia):");
AbstractReport reportB = new FinancialReport();
reportB.Generate();

// =============================================================================
// Implementacje
// =============================================================================

// ─── Testy jak JUnit ─────────────────────────────────────────────────────────

abstract class TestRunner
{
    public void RunTest()
    {
        Console.Write($"  [{GetType().Name}] ");
        SetUp();
        Execute();
        Verify();
        TearDown();
        Console.WriteLine(" ✓ TEST PASSED");
    }

    protected virtual void SetUp() { }    // hook — opcjonalny
    protected abstract void Execute();
    protected abstract void Verify();
    protected virtual void TearDown() { } // hook — opcjonalny
}

class OrderValidationTest : TestRunner
{
    protected override void SetUp()
        => Console.Write("Setup→ ");
    protected override void Execute()
        => Console.Write("ValidateOrder→ ");
    protected override void Verify()
        => Console.Write("AssertValid ");
    protected override void TearDown()
        => Console.Write("Cleanup ");
}

class PaymentProcessorTest : TestRunner
{
    protected override void Execute()
        => Console.Write("ProcessPayment→ ");
    protected override void Verify()
        => Console.Write("AssertCharged ");
}

// ─── AI gry ──────────────────────────────────────────────────────────────────

abstract class GameAI
{
    public void TakeTurn()
    {
        CollectResources();
        BuildStructures();
        Attack();
        LogTurn();
    }

    protected abstract void CollectResources();
    protected abstract void BuildStructures();
    protected abstract void Attack();

    protected virtual void LogTurn()
        => Console.WriteLine($"  [{GetType().Name}] Tura zakończona.");
}

class WarriorAI : GameAI
{
    protected override void CollectResources() => Console.WriteLine("  Warrior: Zbieram złoto");
    protected override void BuildStructures() => Console.WriteLine("  Warrior: Buduję koszary");
    protected override void Attack() => Console.WriteLine("  Warrior: Atakuję mieczem!");
}

class MageAI : GameAI
{
    protected override void CollectResources() => Console.WriteLine("  Mage: Zbieram many");
    protected override void BuildStructures() => Console.WriteLine("  Mage: Buduję wieżę magów");
    protected override void Attack() => Console.WriteLine("  Mage: Rzucam kulę ognia!");
}

class ArcherAI : GameAI
{
    protected override void CollectResources() => Console.WriteLine("  Archer: Zbieram drewno");
    protected override void BuildStructures() => Console.WriteLine("  Archer: Buduję strzelnicę");
    protected override void Attack() => Console.WriteLine("  Archer: Strzał z łuku!");
}

// ─── Napoje (klasyczny Head First) ───────────────────────────────────────────

abstract class CaffeineRecipe
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments()) // hook-guard
            AddCondiments();
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();

    protected void BoilWater() => Console.WriteLine("  Gotuję wodę");
    protected void PourInCup() => Console.WriteLine("  Wlewam do filiżanki");

    // Hook — domyślnie: tak, dodaj dodatki
    protected virtual bool CustomerWantsCondiments() => true;
}

class Coffee : CaffeineRecipe
{
    protected override void Brew() => Console.WriteLine("  Parzę kawę przez filtr");
    protected override void AddCondiments() => Console.WriteLine("  Dodaję mleko i cukier");
}

class Tea : CaffeineRecipe
{
    protected override void Brew() => Console.WriteLine("  Zaparzam herbatę");
    protected override void AddCondiments() => Console.WriteLine("  Dodaję cytrynę");
}

class Espresso : CaffeineRecipe
{
    protected override void Brew() => Console.WriteLine("  Tłoczę kawę pod ciśnieniem");
    protected override void AddCondiments() => Console.WriteLine("  Dodaję piankę z mleka");
    // Hook: espresso podawane bez pytania — zawsze z pianką
    protected override bool CustomerWantsCondiments() => true;
}

// ─── Głęboka hierarchia (problem) ────────────────────────────────────────────

abstract class Level1Base
{
    public void Execute()
    {
        Step1();
        CoreAction(); // abstract
        Step3();
    }
    protected void Step1() => Console.WriteLine("  Level1: Step1");
    protected void Step3() => Console.WriteLine("  Level1: Step3");
    protected abstract void CoreAction();
}

abstract class Level2Extended : Level1Base
{
    protected override void CoreAction()
    {
        PreAction();
        SpecificAction(); // nowy abstract!
        PostAction();
    }
    protected virtual void PreAction() => Console.WriteLine("  Level2: PreAction");
    protected abstract void SpecificAction();
    protected virtual void PostAction() => Console.WriteLine("  Level2: PostAction");
}

class Level3Concrete : Level2Extended
{
    protected override void SpecificAction() => Console.WriteLine("  Level3: SpecificAction");
}

// ─── Odmiana z delegatem ──────────────────────────────────────────────────────

class DataPipeline(Action connect, Action process, Action save)
{
    public void Run()
    {
        connect();
        process();
        save();
        Console.WriteLine("  Pipeline zakończony.");
    }
}

// ─── Warianty raportów ────────────────────────────────────────────────────────

abstract class AbstractReport
{
    public void Generate()
    {
        FetchData();
        FormatContent();
        Export();
        if (ShouldSendNotification()) Notify(); // hook
    }

    protected abstract void FetchData();
    protected abstract void FormatContent();
    protected abstract void Export();
    protected virtual bool ShouldSendNotification() => false; // hook — domyślnie: nie
    protected virtual void Notify() => Console.WriteLine("  Wysyłam powiadomienie");
}

class SalesReport : AbstractReport
{
    protected override void FetchData() => Console.WriteLine("  Pobieranie danych sprzedaży...");
    protected override void FormatContent() => Console.WriteLine("  Formatowanie tabeli sprzedaży");
    protected override void Export() => Console.WriteLine("  Eksport do PDF");
}

class FinancialReport : AbstractReport
{
    protected override void FetchData() => Console.WriteLine("  Pobieranie danych finansowych...");
    protected override void FormatContent() => Console.WriteLine("  Formatowanie bilansu");
    protected override void Export() => Console.WriteLine("  Eksport do Excel");
    // Hook aktywowany — raport finansowy zawsze powiadamia CFO
    protected override bool ShouldSendNotification() => true;
    protected override void Notify() => Console.WriteLine("  Email do CFO wysłany!");
}

