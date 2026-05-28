using CleanArch.TaskManager.Application;
using CleanArch.TaskManager.Domain;

namespace CleanArch.TaskManager.Infrastructure;

// ─────────────────────────────────────────────────────────────
// Adapter: IProjectRepository → In-Memory
// ─────────────────────────────────────────────────────────────

public class InMemoryProjectRepository : IProjectRepository
{
    private readonly Dictionary<Guid, Project> _db = [];

    public Task<Project?> FindByIdAsync(ProjectId id)
    {
        _db.TryGetValue(id.Value, out var project);
        return Task.FromResult(project);
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

    public Task<bool> ExistsAsync(ProjectId id)
        => Task.FromResult(_db.ContainsKey(id.Value));
}

// ─────────────────────────────────────────────────────────────
// Adapter: INotificationService → Console
// ─────────────────────────────────────────────────────────────

public class ConsoleNotificationService : INotificationService
{
    public Task SendAsync(string recipient, string subject, string message)
    {
        Console.WriteLine($"  [Powiadomienie] Do: {recipient} | Temat: {subject}");
        Console.WriteLine($"    {message}");
        return Task.CompletedTask;
    }
}
