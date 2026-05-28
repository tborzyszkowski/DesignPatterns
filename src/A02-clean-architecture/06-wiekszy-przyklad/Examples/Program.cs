using CleanArch.TaskManager.Application;
using CleanArch.TaskManager.Domain;
using CleanArch.TaskManager.Infrastructure;

Console.WriteLine("=== System zarządzania zadaniami (Work Items) ===");
Console.WriteLine("    Clean Architecture: Domain + Application + Infrastructure\n");

// ─────────────────────────────────────────────────────────────
// COMPOSITION ROOT — jedyne miejsce tworzenia konkretnych klas
// ─────────────────────────────────────────────────────────────
var repository    = new InMemoryProjectRepository();
var notifications = new ConsoleNotificationService();

var createProject   = new CreateProjectUseCase(repository);
var createWorkItem  = new CreateWorkItemUseCase(repository);
var startWorkItem   = new StartWorkItemUseCase(repository);
var completeItem    = new CompleteWorkItemUseCase(repository, notifications);
var assignItem      = new AssignWorkItemUseCase(repository);
var cancelItem      = new CancelWorkItemUseCase(repository);
var getItems        = new GetProjectWorkItemsUseCase(repository);
var getOverdue      = new GetOverdueItemsUseCase(repository);
var getSummary      = new GetProjectSummaryUseCase(repository);

// ─────────────────────────────────────────────────────────────
// SCENARIUSZ 1: Utworzenie projektu i zadań
// ─────────────────────────────────────────────────────────────
Console.WriteLine("─── Scenariusz 1: Tworzenie projektu i zadań ───");

var projectId = Guid.NewGuid();
await createProject.ExecuteAsync(new CreateProjectCommand(
    projectId, "Portal E-Commerce", "System sprzedaży online"));

Console.WriteLine($"Projekt 'Portal E-Commerce' utworzony (id: {projectId.ToString()[..8]}...)");

var item1 = await createWorkItem.ExecuteAsync(new CreateWorkItemCommand(
    projectId, "Implementacja koszyka", "Dodaj/usuń produkty, oblicz sumę",
    Priority.High, DateTime.UtcNow.AddDays(7)));

var item2 = await createWorkItem.ExecuteAsync(new CreateWorkItemCommand(
    projectId, "Integracja z płatnościami", "Stripe API",
    Priority.Critical, DateTime.UtcNow.AddDays(14)));

var item3 = await createWorkItem.ExecuteAsync(new CreateWorkItemCommand(
    projectId, "Strona główna (UI)", "Responsywny layout",
    Priority.Medium, DateTime.UtcNow.AddDays(5)));

Console.WriteLine($"Dodano zadania: {item1.Title}, {item2.Title}, {item3.Title}");

// ─────────────────────────────────────────────────────────────
// SCENARIUSZ 2: Przypisanie i zmiana statusów
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Scenariusz 2: Przypisanie i zmiana statusów ───");

await assignItem.ExecuteAsync(new AssignWorkItemCommand(projectId, item1.Id, "anna.kowal"));
await assignItem.ExecuteAsync(new AssignWorkItemCommand(projectId, item2.Id, "piotr.lewandowski"));
Console.WriteLine("Zadania przypisane do deweloperów");

await startWorkItem.ExecuteAsync(new StartWorkItemCommand(projectId, item1.Id));
await startWorkItem.ExecuteAsync(new StartWorkItemCommand(projectId, item2.Id));
Console.WriteLine("Zadania 1 i 2 — status: InProgress");

await completeItem.ExecuteAsync(new CompleteWorkItemCommand(projectId, item1.Id));
Console.WriteLine("Zadanie 1 — status: Done (wysłano powiadomienie)");

// ─────────────────────────────────────────────────────────────
// SCENARIUSZ 3: Anulowanie i obsługa błędów
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Scenariusz 3: Anulowanie i błędy domeny ───");

await cancelItem.ExecuteAsync(new CancelWorkItemCommand(projectId, item3.Id));
Console.WriteLine($"Zadanie '{item3.Title}' — anulowane");

// Próba ukończenia anulowanego zadania — błąd domeny
try
{
    await completeItem.ExecuteAsync(new CompleteWorkItemCommand(projectId, item3.Id));
}
catch (InvalidWorkItemStateException ex)
{
    Console.WriteLine($"Błąd domeny: {ex.Message}");
}

// ─────────────────────────────────────────────────────────────
// SCENARIUSZ 4: Przeterminowane zadania (symulacja)
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Scenariusz 4: Przeterminowane zadania ───");

// Tworzymy zadanie z datą w przeszłości
var overdueItem = await createWorkItem.ExecuteAsync(new CreateWorkItemCommand(
    projectId, "Audyt bezpieczeństwa (zaległy)", "Zaległy przegląd",
    Priority.Critical, DateTime.UtcNow.AddDays(-3)));  // 3 dni temu!

var overdueList = await getOverdue.ExecuteAsync(projectId);
Console.WriteLine($"Przeterminowane zadania: {overdueList.Count}");
foreach (var ov in overdueList)
    Console.WriteLine($"  - '{ov.Title}' (priorytet: {ov.Priority}, termin: {ov.DueDate:yyyy-MM-dd})");

// ─────────────────────────────────────────────────────────────
// SCENARIUSZ 5: Podsumowanie projektu
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Scenariusz 5: Podsumowanie projektu ───");

var summary = await getSummary.ExecuteAsync(projectId);
Console.WriteLine($"Projekt: {summary.Name}");
Console.WriteLine($"  Wszystkie zadania: {summary.TotalItems}");
Console.WriteLine($"  Ukończone:         {summary.CompletedItems}");
Console.WriteLine($"  W trakcie:         {summary.InProgressItems}");
Console.WriteLine($"  Przeterminowane:   {summary.OverdueItems}");

// ─────────────────────────────────────────────────────────────
// SCENARIUSZ 6: Lista wszystkich zadań z ich statusami
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Scenariusz 6: Wszystkie zadania ───");

var allItems = await getItems.ExecuteAsync(projectId);
foreach (var it in allItems)
{
    var assignee = it.AssignedTo is not null ? $" [{it.AssignedTo}]" : "";
    var overdue  = it.IsOverdue ? " ⚠ PRZETERMINOWANE" : "";
    Console.WriteLine($"  [{it.Status,-12}] {it.Title}{assignee}{overdue}");
}

Console.WriteLine("\n=== Demo zakończone ===");
