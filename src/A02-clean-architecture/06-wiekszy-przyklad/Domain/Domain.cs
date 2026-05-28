namespace CleanArch.TaskManager.Domain;

// ─────────────────────────────────────────────────────────────
// Enumeracje
// ─────────────────────────────────────────────────────────────

public enum Priority { Low, Medium, High, Critical }

public enum WorkItemStatus { Todo, InProgress, Done, Cancelled }

// ─────────────────────────────────────────────────────────────
// Value Objects
// ─────────────────────────────────────────────────────────────

public record WorkItemId(Guid Value)
{
    public static WorkItemId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}

public record ProjectId(Guid Value)
{
    public static ProjectId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}

// ─────────────────────────────────────────────────────────────
// Domain Exceptions
// ─────────────────────────────────────────────────────────────

public class WorkItemNotFoundException(WorkItemId id)
    : Exception($"Zadanie o id '{id}' nie zostało znalezione");

public class InvalidWorkItemStateException(string message)
    : Exception(message);

public class ProjectNotFoundException(ProjectId id)
    : Exception($"Projekt o id '{id}' nie został znaleziony");

// ─────────────────────────────────────────────────────────────
// Entity: WorkItem
// ─────────────────────────────────────────────────────────────

public class WorkItem
{
    public WorkItemId    Id          { get; }
    public string        Title       { get; private set; }
    public string        Description { get; private set; }
    public Priority      Priority    { get; private set; }
    public WorkItemStatus Status     { get; private set; }
    public string?       AssignedTo  { get; private set; }
    public DateTime?     DueDate     { get; private set; }
    public DateTime      CreatedAt   { get; }

    public bool IsOverdue =>
        DueDate.HasValue &&
        DueDate.Value < DateTime.UtcNow &&
        Status is not (WorkItemStatus.Done or WorkItemStatus.Cancelled);

    public WorkItem(WorkItemId id, string title, string description, Priority priority, DateTime? dueDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tytuł zadania jest wymagany", nameof(title));

        Id          = id;
        Title       = title;
        Description = description;
        Priority    = priority;
        DueDate     = dueDate;
        Status      = WorkItemStatus.Todo;
        CreatedAt   = DateTime.UtcNow;
    }

    public void Start()
    {
        if (Status != WorkItemStatus.Todo)
            throw new InvalidWorkItemStateException(
                $"Zadanie '{Title}' musi być w stanie Todo aby je rozpocząć (aktualny: {Status})");
        Status = WorkItemStatus.InProgress;
    }

    public void Complete()
    {
        if (Status is WorkItemStatus.Done)
            throw new InvalidWorkItemStateException($"Zadanie '{Title}' jest już ukończone");
        if (Status is WorkItemStatus.Cancelled)
            throw new InvalidWorkItemStateException($"Zadanie '{Title}' zostało anulowane i nie może być ukończone");
        Status = WorkItemStatus.Done;
    }

    public void Cancel()
    {
        if (Status is WorkItemStatus.Done)
            throw new InvalidWorkItemStateException($"Ukończonego zadania '{Title}' nie można anulować");
        if (Status is WorkItemStatus.Cancelled)
            throw new InvalidWorkItemStateException($"Zadanie '{Title}' jest już anulowane");
        Status = WorkItemStatus.Cancelled;
    }

    public void AssignTo(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("Nazwa użytkownika jest wymagana", nameof(userName));
        if (Status is WorkItemStatus.Done or WorkItemStatus.Cancelled)
            throw new InvalidWorkItemStateException($"Nie można przypisać ukończonego lub anulowanego zadania '{Title}'");
        AssignedTo = userName;
    }

    public void UpdatePriority(Priority priority) => Priority = priority;
}

// ─────────────────────────────────────────────────────────────
// Aggregate Root: Project
// ─────────────────────────────────────────────────────────────

public class Project
{
    private readonly List<WorkItem> _items = [];

    public ProjectId  Id          { get; }
    public string     Name        { get; private set; }
    public string     Description { get; private set; }
    public DateTime   CreatedAt   { get; }

    public IReadOnlyList<WorkItem> Items => _items.AsReadOnly();

    public Project(ProjectId id, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nazwa projektu jest wymagana", nameof(name));

        Id          = id;
        Name        = name;
        Description = description;
        CreatedAt   = DateTime.UtcNow;
    }

    public WorkItem AddItem(string title, string description, Priority priority, DateTime? dueDate = null)
    {
        var item = new WorkItem(WorkItemId.New(), title, description, priority, dueDate);
        _items.Add(item);
        return item;
    }

    public WorkItem FindItem(WorkItemId id)
    {
        return _items.FirstOrDefault(i => i.Id == id)
            ?? throw new WorkItemNotFoundException(id);
    }

    public IReadOnlyList<WorkItem> GetOverdueItems() =>
        _items.Where(i => i.IsOverdue).ToList().AsReadOnly();

    public IReadOnlyList<WorkItem> GetItemsByStatus(WorkItemStatus status) =>
        _items.Where(i => i.Status == status).ToList().AsReadOnly();
}
