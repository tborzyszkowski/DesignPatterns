using CleanArch.TaskManager.Application;
using CleanArch.TaskManager.Domain;
using CleanArch.TaskManager.Infrastructure;
using Xunit;

namespace CleanArch.TaskManager.Tests;

// ─────────────────────────────────────────────────────────────
// Pomocnicze Fake (testy nie zależą od prawdziwej infrastruktury)
// ─────────────────────────────────────────────────────────────

class FakeProjectRepository : IProjectRepository
{
    private readonly Dictionary<Guid, Project> _db = [];

    public Task<Project?> FindByIdAsync(ProjectId id)
    {
        _db.TryGetValue(id.Value, out var p);
        return Task.FromResult(p);
    }

    public Task SaveAsync(Project project)
    {
        _db[project.Id.Value] = project;
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Project>> GetAllAsync()
    {
        IReadOnlyList<Project> result = _db.Values.ToList().AsReadOnly();
        return Task.FromResult(result);
    }

    public Task<bool> ExistsAsync(ProjectId id) => Task.FromResult(_db.ContainsKey(id.Value));
}

class FakeNotificationService : INotificationService
{
    public List<(string Recipient, string Subject, string Message)> Sent { get; } = [];

    public Task SendAsync(string recipient, string subject, string message)
    {
        Sent.Add((recipient, subject, message));
        return Task.CompletedTask;
    }
}

// Pomocnik tworzący projekt z jednym zadaniem
static class TestFixture
{
    public static async Task<(FakeProjectRepository Repo, Project Project, WorkItem Item)>
        CreateProjectWithItem(Priority priority = Priority.Medium, DateTime? dueDate = null)
    {
        var repo = new FakeProjectRepository();
        var uc   = new CreateProjectUseCase(repo);
        var pid  = Guid.NewGuid();
        await uc.ExecuteAsync(new CreateProjectCommand(pid, "Test Project", "Opis"));
        var project = (await repo.FindByIdAsync(new ProjectId(pid)))!;
        var item    = project.AddItem("Test Item", "Opis", priority, dueDate);
        await repo.SaveAsync(project);
        return (repo, project, item);
    }
}

// ─────────────────────────────────────────────────────────────
// Testy encji WorkItem (Domain Layer)
// ─────────────────────────────────────────────────────────────

public class WorkItemEntityTests
{
    [Fact]
    public void NewWorkItem_HasTodoStatus()
    {
        var item = new WorkItem(WorkItemId.New(), "Test", "Opis", Priority.Medium, null);
        Assert.Equal(WorkItemStatus.Todo, item.Status);
    }

    [Fact]
    public void Start_WhenTodo_ChangesStatusToInProgress()
    {
        var item = new WorkItem(WorkItemId.New(), "Test", "", Priority.Low, null);
        item.Start();
        Assert.Equal(WorkItemStatus.InProgress, item.Status);
    }

    [Fact]
    public void Complete_WhenInProgress_ChangesStatusToDone()
    {
        var item = new WorkItem(WorkItemId.New(), "Test", "", Priority.Low, null);
        item.Start();
        item.Complete();
        Assert.Equal(WorkItemStatus.Done, item.Status);
    }

    [Fact]
    public void Complete_WhenTodo_ChangesStatusToDone()
    {
        // Można ukończyć bez startowania (bezpośrednio)
        var item = new WorkItem(WorkItemId.New(), "Test", "", Priority.Low, null);
        item.Complete();
        Assert.Equal(WorkItemStatus.Done, item.Status);
    }

    [Fact]
    public void Start_WhenAlreadyDone_ThrowsInvalidWorkItemStateException()
    {
        var item = new WorkItem(WorkItemId.New(), "Test", "", Priority.Low, null);
        item.Complete();
        Assert.Throws<InvalidWorkItemStateException>(() => item.Start());
    }

    [Fact]
    public void Cancel_WhenDone_ThrowsInvalidWorkItemStateException()
    {
        var item = new WorkItem(WorkItemId.New(), "Test", "", Priority.Low, null);
        item.Complete();
        Assert.Throws<InvalidWorkItemStateException>(() => item.Cancel());
    }

    [Fact]
    public void IsOverdue_WhenDueDateInPast_ReturnsTrue()
    {
        var item = new WorkItem(WorkItemId.New(), "Test", "", Priority.High,
            DateTime.UtcNow.AddDays(-1));
        Assert.True(item.IsOverdue);
    }

    [Fact]
    public void IsOverdue_WhenDone_ReturnsFalse()
    {
        var item = new WorkItem(WorkItemId.New(), "Test", "", Priority.High,
            DateTime.UtcNow.AddDays(-1));
        item.Complete();
        Assert.False(item.IsOverdue);  // ukończone — nie jest przeterminowane
    }

    [Fact]
    public void Constructor_EmptyTitle_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new WorkItem(WorkItemId.New(), "", "Opis", Priority.Low, null));
    }
}

// ─────────────────────────────────────────────────────────────
// Testy agregatu Project (Domain Layer)
// ─────────────────────────────────────────────────────────────

public class ProjectAggregateTests
{
    [Fact]
    public void AddItem_AddsItemToProject()
    {
        var project = new Project(ProjectId.New(), "Projekt A", "Opis");
        project.AddItem("Zadanie 1", "Opis", Priority.Low);
        Assert.Single(project.Items);
    }

    [Fact]
    public void FindItem_ExistingItem_ReturnsItem()
    {
        var project = new Project(ProjectId.New(), "Projekt A", "Opis");
        var item    = project.AddItem("Zadanie 1", "Opis", Priority.Low);
        var found   = project.FindItem(item.Id);
        Assert.Equal(item.Id, found.Id);
    }

    [Fact]
    public void FindItem_NonExistingItem_ThrowsWorkItemNotFoundException()
    {
        var project = new Project(ProjectId.New(), "Projekt A", "Opis");
        Assert.Throws<WorkItemNotFoundException>(() =>
            project.FindItem(WorkItemId.New()));
    }

    [Fact]
    public void GetOverdueItems_ReturnsOnlyOverdueItems()
    {
        var project  = new Project(ProjectId.New(), "Projekt A", "Opis");
        project.AddItem("Zaległe", "Opis", Priority.High, DateTime.UtcNow.AddDays(-2));
        project.AddItem("OK",      "Opis", Priority.Low,  DateTime.UtcNow.AddDays(5));
        Assert.Single(project.GetOverdueItems());
    }
}

// ─────────────────────────────────────────────────────────────
// Testy Use Case: CreateWorkItemUseCase (Application Layer)
// ─────────────────────────────────────────────────────────────

public class CreateWorkItemUseCaseTests
{
    [Fact]
    public async Task Execute_ValidCommand_ReturnsDto()
    {
        var (repo, project, _) = await TestFixture.CreateProjectWithItem();
        var uc     = new CreateWorkItemUseCase(repo);
        var result = await uc.ExecuteAsync(new CreateWorkItemCommand(
            project.Id.Value, "Nowe zadanie", "Opis", Priority.Medium));

        Assert.Equal("Nowe zadanie", result.Title);
        Assert.Equal("Todo", result.Status);
    }

    [Fact]
    public async Task Execute_ProjectNotFound_ThrowsProjectNotFoundException()
    {
        var repo = new FakeProjectRepository();
        var uc   = new CreateWorkItemUseCase(repo);

        await Assert.ThrowsAsync<ProjectNotFoundException>(() =>
            uc.ExecuteAsync(new CreateWorkItemCommand(
                Guid.NewGuid(), "Zadanie", "Opis", Priority.Low)));
    }

    [Fact]
    public async Task Execute_EmptyTitle_ThrowsArgumentException()
    {
        var (repo, project, _) = await TestFixture.CreateProjectWithItem();
        var uc = new CreateWorkItemUseCase(repo);

        await Assert.ThrowsAsync<ArgumentException>(() =>
            uc.ExecuteAsync(new CreateWorkItemCommand(
                project.Id.Value, "", "Opis", Priority.Low)));
    }

    [Fact]
    public async Task Execute_PersistsItemToRepository()
    {
        var repo = new FakeProjectRepository();
        var pid  = Guid.NewGuid();
        var createProj = new CreateProjectUseCase(repo);
        await createProj.ExecuteAsync(new CreateProjectCommand(pid, "Test", "Opis"));

        var uc = new CreateWorkItemUseCase(repo);
        await uc.ExecuteAsync(new CreateWorkItemCommand(pid, "Zadanie", "Opis", Priority.High));

        var saved = await repo.FindByIdAsync(new ProjectId(pid));
        Assert.Single(saved!.Items);
    }
}

// ─────────────────────────────────────────────────────────────
// Testy Use Case: CompleteWorkItemUseCase (Application Layer)
// ─────────────────────────────────────────────────────────────

public class CompleteWorkItemUseCaseTests
{
    [Fact]
    public async Task Execute_ValidItem_ChangesStatusToDone()
    {
        var (repo, project, item) = await TestFixture.CreateProjectWithItem();
        var notify = new FakeNotificationService();
        var uc     = new CompleteWorkItemUseCase(repo, notify);

        await uc.ExecuteAsync(new CompleteWorkItemCommand(project.Id.Value, item.Id.Value));

        var saved = await repo.FindByIdAsync(project.Id);
        Assert.Equal(WorkItemStatus.Done, saved!.FindItem(item.Id).Status);
    }

    [Fact]
    public async Task Execute_AssignedItem_SendsNotification()
    {
        var (repo, project, item) = await TestFixture.CreateProjectWithItem();
        var assignUc = new AssignWorkItemUseCase(repo);
        await assignUc.ExecuteAsync(new AssignWorkItemCommand(
            project.Id.Value, item.Id.Value, "jan.kowal"));

        var notify = new FakeNotificationService();
        var uc     = new CompleteWorkItemUseCase(repo, notify);
        await uc.ExecuteAsync(new CompleteWorkItemCommand(project.Id.Value, item.Id.Value));

        Assert.Single(notify.Sent);
        Assert.Equal("jan.kowal", notify.Sent[0].Recipient);
    }

    [Fact]
    public async Task Execute_UnassignedItem_DoesNotSendNotification()
    {
        var (repo, project, item) = await TestFixture.CreateProjectWithItem();
        var notify = new FakeNotificationService();
        var uc     = new CompleteWorkItemUseCase(repo, notify);
        await uc.ExecuteAsync(new CompleteWorkItemCommand(project.Id.Value, item.Id.Value));
        Assert.Empty(notify.Sent);
    }

    [Fact]
    public async Task Execute_ItemNotFound_ThrowsWorkItemNotFoundException()
    {
        var (repo, project, _) = await TestFixture.CreateProjectWithItem();
        var uc = new CompleteWorkItemUseCase(repo, new FakeNotificationService());

        await Assert.ThrowsAsync<WorkItemNotFoundException>(() =>
            uc.ExecuteAsync(new CompleteWorkItemCommand(project.Id.Value, Guid.NewGuid())));
    }

    [Fact]
    public async Task Execute_AlreadyDone_ThrowsInvalidWorkItemStateException()
    {
        var (repo, project, item) = await TestFixture.CreateProjectWithItem();
        var notify = new FakeNotificationService();
        var uc     = new CompleteWorkItemUseCase(repo, notify);

        // Pierwsze ukończenie
        await uc.ExecuteAsync(new CompleteWorkItemCommand(project.Id.Value, item.Id.Value));

        // Drugie ukończenie — błąd
        await Assert.ThrowsAsync<InvalidWorkItemStateException>(() =>
            uc.ExecuteAsync(new CompleteWorkItemCommand(project.Id.Value, item.Id.Value)));
    }
}

// ─────────────────────────────────────────────────────────────
// Testy Use Cases: Query (Application Layer)
// ─────────────────────────────────────────────────────────────

public class QueryUseCaseTests
{
    [Fact]
    public async Task GetProjectWorkItems_ReturnsAllItems()
    {
        var (repo, project, _) = await TestFixture.CreateProjectWithItem();
        var createUc = new CreateWorkItemUseCase(repo);
        await createUc.ExecuteAsync(new CreateWorkItemCommand(
            project.Id.Value, "Drugie zadanie", "Opis", Priority.Low));

        var uc     = new GetProjectWorkItemsUseCase(repo);
        var result = await uc.ExecuteAsync(project.Id.Value);

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetProjectWorkItems_ProjectNotFound_ThrowsProjectNotFoundException()
    {
        var repo = new FakeProjectRepository();
        var uc   = new GetProjectWorkItemsUseCase(repo);
        await Assert.ThrowsAsync<ProjectNotFoundException>(() =>
            uc.ExecuteAsync(Guid.NewGuid()));
    }

    [Fact]
    public async Task GetOverdueItems_ReturnsOnlyOverdue()
    {
        var repo     = new FakeProjectRepository();
        var pid      = Guid.NewGuid();
        var createProj = new CreateProjectUseCase(repo);
        await createProj.ExecuteAsync(new CreateProjectCommand(pid, "Test", "Opis"));

        var createItem = new CreateWorkItemUseCase(repo);
        await createItem.ExecuteAsync(new CreateWorkItemCommand(
            pid, "OK", "Opis", Priority.Low, DateTime.UtcNow.AddDays(10)));
        await createItem.ExecuteAsync(new CreateWorkItemCommand(
            pid, "Zaległe", "Opis", Priority.High, DateTime.UtcNow.AddDays(-5)));

        var uc     = new GetOverdueItemsUseCase(repo);
        var result = await uc.ExecuteAsync(pid);

        Assert.Single(result);
        Assert.Equal("Zaległe", result[0].Title);
    }

    [Fact]
    public async Task GetProjectSummary_ReturnsCorrectCounts()
    {
        var (repo, project, item1) = await TestFixture.CreateProjectWithItem();
        var createUc = new CreateWorkItemUseCase(repo);
        var item2Dto = await createUc.ExecuteAsync(new CreateWorkItemCommand(
            project.Id.Value, "Drugie", "Opis", Priority.Medium));

        // Ukończ pierwsze
        var completeUc = new CompleteWorkItemUseCase(repo, new FakeNotificationService());
        await completeUc.ExecuteAsync(new CompleteWorkItemCommand(project.Id.Value, item1.Id.Value));

        // Uruchom drugie
        var startUc = new StartWorkItemUseCase(repo);
        await startUc.ExecuteAsync(new StartWorkItemCommand(project.Id.Value, item2Dto.Id));

        var summaryUc = new GetProjectSummaryUseCase(repo);
        var summary   = await summaryUc.ExecuteAsync(project.Id.Value);

        Assert.Equal(2, summary.TotalItems);
        Assert.Equal(1, summary.CompletedItems);
        Assert.Equal(1, summary.InProgressItems);
    }
}
