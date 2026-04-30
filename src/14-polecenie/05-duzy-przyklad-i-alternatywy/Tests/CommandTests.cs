// =============================================================================
// Testy jednostkowe — Wzorzec Polecenie (Smart Home)
// Testuje: Execute, Undo, Redo, MacroCommand, NoOpCommand, CommandHistory
// =============================================================================
using Xunit;

namespace Command.SmartHome.Tests;

// ─────────────────────────────────────────────────────────────────────────────
// Proste stubs/fakes do testów
// ─────────────────────────────────────────────────────────────────────────────

public interface ICommand
{
    void Execute();
    void Undo();
    string Description { get; }
}

public class SpyCommand : ICommand
{
    public int ExecuteCount { get; private set; }
    public int UndoCount { get; private set; }
    public string Description => "SpyCommand";

    public void Execute() => ExecuteCount++;
    public void Undo()    => UndoCount++;
}

public class NoOpCommand : ICommand
{
    public string Description => "(brak akcji)";
    public void Execute() { }
    public void Undo()    { }
}

public class MacroCommand(ICommand[] commands) : ICommand
{
    public string Description => "MacroCommand";
    public List<string> Log { get; } = [];

    public void Execute()
    {
        foreach (var cmd in commands) cmd.Execute();
    }

    public void Undo()
    {
        foreach (var cmd in commands.Reverse()) cmd.Undo();
    }
}

// Simple counter receiver for testing
public class Counter
{
    public int Value { get; private set; } = 0;
    public void Add(int n) => Value += n;
    public void Sub(int n) => Value -= n;
}

public class IncrementCommand(Counter counter, int amount) : ICommand
{
    public string Description => $"Increment({amount})";
    public void Execute() => counter.Add(amount);
    public void Undo()    => counter.Sub(amount);
}

public class CommandHistory
{
    private readonly Stack<ICommand> _undo = new();
    private readonly Stack<ICommand> _redo = new();

    public int UndoDepth => _undo.Count;
    public int RedoDepth => _redo.Count;

    public void Execute(ICommand cmd)
    {
        cmd.Execute();
        _undo.Push(cmd);
        _redo.Clear();
    }

    public bool Undo()
    {
        if (!_undo.TryPop(out var cmd)) return false;
        cmd.Undo();
        _redo.Push(cmd);
        return true;
    }

    public bool Redo()
    {
        if (!_redo.TryPop(out var cmd)) return false;
        cmd.Execute();
        _undo.Push(cmd);
        return true;
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// Testy
// ─────────────────────────────────────────────────────────────────────────────

public class CommandTests
{
    [Fact]
    public void Execute_CallsExecuteOnce()
    {
        var spy = new SpyCommand();
        spy.Execute();
        Assert.Equal(1, spy.ExecuteCount);
    }

    [Fact]
    public void Undo_CallsUndoOnce()
    {
        var spy = new SpyCommand();
        spy.Execute();
        spy.Undo();
        Assert.Equal(1, spy.UndoCount);
    }

    [Fact]
    public void NoOpCommand_DoesNotThrow()
    {
        var noop = new NoOpCommand();
        noop.Execute(); // brak wyjątku
        noop.Undo();    // brak wyjątku
    }

    [Fact]
    public void IncrementCommand_Execute_AddsAmount()
    {
        var counter = new Counter();
        var cmd = new IncrementCommand(counter, 10);
        cmd.Execute();
        Assert.Equal(10, counter.Value);
    }

    [Fact]
    public void IncrementCommand_Undo_SubtractsAmount()
    {
        var counter = new Counter();
        var cmd = new IncrementCommand(counter, 10);
        cmd.Execute();
        cmd.Undo();
        Assert.Equal(0, counter.Value);
    }

    [Fact]
    public void CommandHistory_Execute_ThenUndo_RestoresState()
    {
        var counter = new Counter();
        var history = new CommandHistory();

        history.Execute(new IncrementCommand(counter, 5));
        history.Execute(new IncrementCommand(counter, 3));
        Assert.Equal(8, counter.Value);

        history.Undo();
        Assert.Equal(5, counter.Value);

        history.Undo();
        Assert.Equal(0, counter.Value);
    }

    [Fact]
    public void CommandHistory_Redo_ReappliesCommand()
    {
        var counter = new Counter();
        var history = new CommandHistory();

        history.Execute(new IncrementCommand(counter, 10));
        history.Undo();
        Assert.Equal(0, counter.Value);

        bool redoSuccess = history.Redo();
        Assert.True(redoSuccess);
        Assert.Equal(10, counter.Value);
    }

    [Fact]
    public void CommandHistory_NewExecute_ClearsRedoStack()
    {
        var counter = new Counter();
        var history = new CommandHistory();

        history.Execute(new IncrementCommand(counter, 10));
        history.Undo();

        // Nowa operacja powinna wyczyścić stos Redo
        history.Execute(new IncrementCommand(counter, 5));
        Assert.Equal(0, history.RedoDepth);

        bool redoSuccess = history.Redo();
        Assert.False(redoSuccess); // nic do ponowienia
    }

    [Fact]
    public void CommandHistory_Undo_WhenEmpty_ReturnsFalse()
    {
        var history = new CommandHistory();
        bool result = history.Undo();
        Assert.False(result);
    }

    [Fact]
    public void CommandHistory_Redo_WhenEmpty_ReturnsFalse()
    {
        var history = new CommandHistory();
        bool result = history.Redo();
        Assert.False(result);
    }

    [Fact]
    public void CommandHistory_UndoDepth_TracksCorrectly()
    {
        var counter = new Counter();
        var history = new CommandHistory();

        history.Execute(new IncrementCommand(counter, 1));
        history.Execute(new IncrementCommand(counter, 2));
        history.Execute(new IncrementCommand(counter, 3));
        Assert.Equal(3, history.UndoDepth);

        history.Undo();
        Assert.Equal(2, history.UndoDepth);
        Assert.Equal(1, history.RedoDepth);
    }
}

public class MacroCommandTests
{
    [Fact]
    public void MacroCommand_Execute_CallsAllSubcommands()
    {
        var spy1 = new SpyCommand();
        var spy2 = new SpyCommand();
        var spy3 = new SpyCommand();

        var macro = new MacroCommand([spy1, spy2, spy3]);
        macro.Execute();

        Assert.Equal(1, spy1.ExecuteCount);
        Assert.Equal(1, spy2.ExecuteCount);
        Assert.Equal(1, spy3.ExecuteCount);
    }

    [Fact]
    public void MacroCommand_Undo_CallsUndoOnAllSubcommands()
    {
        var spy1 = new SpyCommand();
        var spy2 = new SpyCommand();

        var macro = new MacroCommand([spy1, spy2]);
        macro.Execute();
        macro.Undo();

        Assert.Equal(1, spy1.UndoCount);
        Assert.Equal(1, spy2.UndoCount);
    }

    [Fact]
    public void MacroCommand_Undo_ExecutesInReverseOrder()
    {
        // Używamy counter by zweryfikować kolejność cofania
        var counter = new Counter();
        var order = new List<string>();

        // Symulujemy polecenia rejestrujące kolejność
        var cmdA = new OrderTrackingCommand("A", counter, order);
        var cmdB = new OrderTrackingCommand("B", counter, order);
        var cmdC = new OrderTrackingCommand("C", counter, order);

        var macro = new MacroCommand([cmdA, cmdB, cmdC]);
        macro.Execute();

        order.Clear();
        macro.Undo();

        // Undo powinno być w kolejności: C, B, A
        Assert.Equal(["C", "B", "A"], order);
    }

    [Fact]
    public void MacroCommand_WithNoOpCommands_DoesNotThrow()
    {
        var macro = new MacroCommand([new NoOpCommand(), new NoOpCommand()]);
        macro.Execute();
        macro.Undo();
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// Pomocnicze klasy testowe
// ─────────────────────────────────────────────────────────────────────────────

public class OrderTrackingCommand(string id, Counter counter, List<string> order) : ICommand
{
    public string Description => id;
    public void Execute() { counter.Add(1); }
    public void Undo()    { counter.Sub(1); order.Add(id); }
}
