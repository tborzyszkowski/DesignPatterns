using CleanArch.TaskManager.Domain;

namespace CleanArch.TaskManager.Application;

// ─────────────────────────────────────────────────────────────
// Porty wyjściowe (Out-Ports / Driven Ports)
// Zdefiniowane w Application — implementowane w Infrastructure
// ─────────────────────────────────────────────────────────────

public interface IProjectRepository
{
    Task<Project?> FindByIdAsync(ProjectId id);
    Task SaveAsync(Project project);
    Task<IReadOnlyList<Project>> GetAllAsync();
    Task<bool> ExistsAsync(ProjectId id);
}

public interface INotificationService
{
    Task SendAsync(string recipient, string subject, string message);
}

// ─────────────────────────────────────────────────────────────
// DTOs — wychodzące z Use Cases (nie encje Domain!)
// ─────────────────────────────────────────────────────────────

public record WorkItemDto(
    Guid   Id,
    string Title,
    string Description,
    string Priority,
    string Status,
    string? AssignedTo,
    DateTime? DueDate,
    bool   IsOverdue
);

public record ProjectSummaryDto(
    Guid   Id,
    string Name,
    int    TotalItems,
    int    CompletedItems,
    int    InProgressItems,
    int    OverdueItems
);

// ─────────────────────────────────────────────────────────────
// Komendy (Commands) — dane wejściowe Use Cases
// ─────────────────────────────────────────────────────────────

public record CreateProjectCommand(Guid Id, string Name, string Description);

public record CreateWorkItemCommand(
    Guid      ProjectId,
    string    Title,
    string    Description,
    Priority  Priority,
    DateTime? DueDate = null
);

public record CompleteWorkItemCommand(Guid ProjectId, Guid WorkItemId);

public record AssignWorkItemCommand(Guid ProjectId, Guid WorkItemId, string UserName);

public record StartWorkItemCommand(Guid ProjectId, Guid WorkItemId);

public record CancelWorkItemCommand(Guid ProjectId, Guid WorkItemId);

// ─────────────────────────────────────────────────────────────
// Pomocnicza metoda mapowania encji → DTO
// ─────────────────────────────────────────────────────────────

internal static class WorkItemMapper
{
    public static WorkItemDto ToDto(WorkItem item) => new(
        item.Id.Value,
        item.Title,
        item.Description,
        item.Priority.ToString(),
        item.Status.ToString(),
        item.AssignedTo,
        item.DueDate,
        item.IsOverdue
    );
}

// ─────────────────────────────────────────────────────────────
// Use Cases — Command (zapis)
// ─────────────────────────────────────────────────────────────

public class CreateProjectUseCase(IProjectRepository projects)
{
    public async Task ExecuteAsync(CreateProjectCommand cmd)
    {
        if (string.IsNullOrWhiteSpace(cmd.Name))
            throw new ArgumentException("Nazwa projektu jest wymagana");

        var id = new ProjectId(cmd.Id == Guid.Empty ? Guid.NewGuid() : cmd.Id);

        if (await projects.ExistsAsync(id))
            throw new InvalidOperationException($"Projekt o id '{id}' już istnieje");

        var project = new Project(id, cmd.Name, cmd.Description);
        await projects.SaveAsync(project);
    }
}

public class CreateWorkItemUseCase(IProjectRepository projects)
{
    public async Task<WorkItemDto> ExecuteAsync(CreateWorkItemCommand cmd)
    {
        if (string.IsNullOrWhiteSpace(cmd.Title))
            throw new ArgumentException("Tytuł zadania jest wymagany");

        var project = await projects.FindByIdAsync(new ProjectId(cmd.ProjectId))
            ?? throw new ProjectNotFoundException(new ProjectId(cmd.ProjectId));

        var item = project.AddItem(cmd.Title, cmd.Description, cmd.Priority, cmd.DueDate);
        await projects.SaveAsync(project);
        return WorkItemMapper.ToDto(item);
    }
}

public class StartWorkItemUseCase(IProjectRepository projects)
{
    public async Task ExecuteAsync(StartWorkItemCommand cmd)
    {
        var project = await projects.FindByIdAsync(new ProjectId(cmd.ProjectId))
            ?? throw new ProjectNotFoundException(new ProjectId(cmd.ProjectId));

        var item = project.FindItem(new WorkItemId(cmd.WorkItemId));
        item.Start();
        await projects.SaveAsync(project);
    }
}

public class CompleteWorkItemUseCase(IProjectRepository projects, INotificationService notifications)
{
    public async Task ExecuteAsync(CompleteWorkItemCommand cmd)
    {
        var project = await projects.FindByIdAsync(new ProjectId(cmd.ProjectId))
            ?? throw new ProjectNotFoundException(new ProjectId(cmd.ProjectId));

        var item = project.FindItem(new WorkItemId(cmd.WorkItemId));
        item.Complete();
        await projects.SaveAsync(project);

        if (item.AssignedTo is not null)
            await notifications.SendAsync(
                item.AssignedTo,
                "Zadanie ukończone",
                $"Twoje zadanie '{item.Title}' zostało oznaczone jako ukończone.");
    }
}

public class AssignWorkItemUseCase(IProjectRepository projects)
{
    public async Task ExecuteAsync(AssignWorkItemCommand cmd)
    {
        var project = await projects.FindByIdAsync(new ProjectId(cmd.ProjectId))
            ?? throw new ProjectNotFoundException(new ProjectId(cmd.ProjectId));

        var item = project.FindItem(new WorkItemId(cmd.WorkItemId));
        item.AssignTo(cmd.UserName);
        await projects.SaveAsync(project);
    }
}

public class CancelWorkItemUseCase(IProjectRepository projects)
{
    public async Task ExecuteAsync(CancelWorkItemCommand cmd)
    {
        var project = await projects.FindByIdAsync(new ProjectId(cmd.ProjectId))
            ?? throw new ProjectNotFoundException(new ProjectId(cmd.ProjectId));

        var item = project.FindItem(new WorkItemId(cmd.WorkItemId));
        item.Cancel();
        await projects.SaveAsync(project);
    }
}

// ─────────────────────────────────────────────────────────────
// Use Cases — Query (odczyt)
// ─────────────────────────────────────────────────────────────

public class GetProjectWorkItemsUseCase(IProjectRepository projects)
{
    public async Task<IReadOnlyList<WorkItemDto>> ExecuteAsync(Guid projectId)
    {
        var project = await projects.FindByIdAsync(new ProjectId(projectId))
            ?? throw new ProjectNotFoundException(new ProjectId(projectId));

        return project.Items.Select(WorkItemMapper.ToDto).ToList().AsReadOnly();
    }
}

public class GetOverdueItemsUseCase(IProjectRepository projects)
{
    public async Task<IReadOnlyList<WorkItemDto>> ExecuteAsync(Guid projectId)
    {
        var project = await projects.FindByIdAsync(new ProjectId(projectId))
            ?? throw new ProjectNotFoundException(new ProjectId(projectId));

        return project.GetOverdueItems().Select(WorkItemMapper.ToDto).ToList().AsReadOnly();
    }
}

public class GetProjectSummaryUseCase(IProjectRepository projects)
{
    public async Task<ProjectSummaryDto> ExecuteAsync(Guid projectId)
    {
        var project = await projects.FindByIdAsync(new ProjectId(projectId))
            ?? throw new ProjectNotFoundException(new ProjectId(projectId));

        return new ProjectSummaryDto(
            project.Id.Value,
            project.Name,
            project.Items.Count,
            project.Items.Count(i => i.Status == WorkItemStatus.Done),
            project.Items.Count(i => i.Status == WorkItemStatus.InProgress),
            project.GetOverdueItems().Count
        );
    }
}
