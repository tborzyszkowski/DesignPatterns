// =============================================================================
// Wzorzec Polecenie — 03. Struktura GoF i jak działa
// Czysty szkielet wzorca + konkretny przykład: robot przemysłowy
// =============================================================================

// ── CZĘŚĆ 1: Czysty szkielet GoF ─────────────────────────────────────────────
Console.WriteLine("=== CZĘŚĆ 1: Czysty szkielet GoF ===\n");

var receiver = new Receiver("Receiver-1");
ICommand concreteCommand = new ConcreteCommand(receiver, "Akcja Alpha");
var invoker = new Invoker();

// Client konfiguruje
invoker.SetCommand(concreteCommand);

// Invoker uruchamia — nie wie, co robi ConcreteCommand
invoker.ExecuteCommand();
invoker.UndoCommand();

// ── CZĘŚĆ 2: Konkretny przykład — robot przemysłowy ─────────────────────────
Console.WriteLine("\n=== CZĘŚĆ 2: Robot przemysłowy ===\n");

// Receiver — ramię robota
var arm = new RobotArm();

// ConcreteCommands
ICommand moveLeft  = new MoveCommand(arm, Direction.Left,  50);
ICommand moveRight = new MoveCommand(arm, Direction.Right, 30);
ICommand pickUp    = new PickUpCommand(arm, "śrubka M4");
ICommand putDown   = new PutDownCommand(arm);

// Invoker — kontroler robota
var controller = new RobotController();

// Client ustawia sekwencję
controller.Queue(moveLeft);
controller.Queue(pickUp);
controller.Queue(moveRight);
controller.Queue(putDown);

// Wykonaj całą kolejkę
Console.WriteLine("[Kontroler] Uruchamiam sekwencję:");
controller.RunAll();

// Cofnij ostatnią operację
Console.WriteLine("\n[Kontroler] Cofam ostatnią operację:");
controller.UndoLast();

Console.WriteLine($"\n[Robot] Pozycja końcowa: {arm.Position} mm");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ── Interfejs Polecenia ───────────────────────────────────────────────────────
interface ICommand
{
    void Execute();
    void Undo();
}

// ────────────────────────────────────────────────────────────────────────────
// CZĘŚĆ 1: Czysty szkielet
// ────────────────────────────────────────────────────────────────────────────

/// <summary>
/// Receiver — zawiera faktyczną logikę biznesową.
/// Invoker nigdy nie odwołuje się do Receiver bezpośrednio.
/// </summary>
class Receiver(string id)
{
    public void DoAction(string name)
        => Console.WriteLine($"  [Receiver {id}] Wykonuję akcję: {name}");

    public void ReverseAction(string name)
        => Console.WriteLine($"  [Receiver {id}] Cofam akcję: {name}");
}

/// <summary>
/// ConcreteCommand — łączy Receiver z konkretną akcją.
/// Przechowuje wszystkie parametry potrzebne do Execute i Undo.
/// </summary>
class ConcreteCommand(Receiver receiver, string actionName) : ICommand
{
    public void Execute() => receiver.DoAction(actionName);
    public void Undo()    => receiver.ReverseAction(actionName);
}

/// <summary>
/// Invoker — inicjuje żądania.
/// Zna TYLKO interfejs ICommand, nie zna Receiver ani ConcreteCommand.
/// </summary>
class Invoker
{
    private ICommand? _command;
    private readonly Stack<ICommand> _history = new();

    public void SetCommand(ICommand command) => _command = command;

    public void ExecuteCommand()
    {
        if (_command is null) return;
        Console.WriteLine("[Invoker] ExecuteCommand()");
        _command.Execute();
        _history.Push(_command);
    }

    public void UndoCommand()
    {
        if (_history.TryPop(out var cmd))
        {
            Console.WriteLine("[Invoker] UndoCommand()");
            cmd.Undo();
        }
        else Console.WriteLine("[Invoker] Brak historii do cofnięcia");
    }
}

// ────────────────────────────────────────────────────────────────────────────
// CZĘŚĆ 2: Robot przemysłowy
// ────────────────────────────────────────────────────────────────────────────

enum Direction { Left = -1, Right = 1 }

/// <summary>
/// Receiver — ramię robota zawierające faktyczną logikę sterowania.
/// </summary>
class RobotArm
{
    public int Position { get; private set; } = 0;
    public string? HeldItem { get; private set; }

    public void Move(Direction dir, int mm)
    {
        int delta = (int)dir * mm;
        Position += delta;
        Console.WriteLine($"  [Ramię] Przesunięcie {(dir == Direction.Left ? "←" : "→")} {mm}mm → pozycja {Position}mm");
    }

    public void Grab(string item)
    {
        HeldItem = item;
        Console.WriteLine($"  [Ramię] Chwycono: {item}");
    }

    public void Release()
    {
        Console.WriteLine($"  [Ramię] Odłożono: {HeldItem}");
        HeldItem = null;
    }
}

class MoveCommand(RobotArm arm, Direction dir, int mm) : ICommand
{
    public void Execute() => arm.Move(dir, mm);
    public void Undo()    => arm.Move(dir == Direction.Left ? Direction.Right : Direction.Left, mm);
}

class PickUpCommand(RobotArm arm, string item) : ICommand
{
    public void Execute() => arm.Grab(item);
    public void Undo()    => arm.Release();
}

class PutDownCommand(RobotArm arm) : ICommand
{
    private string? _item;
    public void Execute() { _item = arm.HeldItem; arm.Release(); }
    public void Undo()    { if (_item is not null) arm.Grab(_item); }
}

/// <summary>
/// Invoker z kolejką — kontroler robota.
/// Wykonuje polecenia i umożliwia cofanie.
/// </summary>
class RobotController
{
    private readonly Queue<ICommand> _queue = new();
    private readonly Stack<ICommand> _history = new();

    public void Queue(ICommand cmd) => _queue.Enqueue(cmd);

    public void RunAll()
    {
        while (_queue.TryDequeue(out var cmd))
        {
            cmd.Execute();
            _history.Push(cmd);
        }
    }

    public void UndoLast()
    {
        if (_history.TryPop(out var cmd))
            cmd.Undo();
        else
            Console.WriteLine("[Kontroler] Brak historii");
    }
}
