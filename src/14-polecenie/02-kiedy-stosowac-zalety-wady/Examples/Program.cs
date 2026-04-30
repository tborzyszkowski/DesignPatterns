// =============================================================================
// Wzorzec Polecenie — 02. Kiedy stosować, zalety i wady
// Demonstracja 5 scenariuszy: prosty, undo, makro, kolejka, delegat
// =============================================================================

// ── Scenariusz A: Prosty Command — tylko Execute ─────────────────────────────
Console.WriteLine("=== A: Prosty Command ===\n");

var printer = new Printer();
ISimpleCommand printHello = new PrintCommand(printer, "Hello, Command!");
ISimpleCommand printBye   = new PrintCommand(printer, "Goodbye!");

var invokerA = new SimpleInvoker();
invokerA.SetCommand(printHello);
invokerA.Run();
invokerA.SetCommand(printBye);
invokerA.Run();

// ── Scenariusz B: Zaleta — cofanie (Undo) ───────────────────────────────────
Console.WriteLine("\n=== B: Zaleta — cofanie operacji ===\n");

var account = new BankAccount("Jan Kowalski", 1000m);
var history = new CommandHistory();

history.Execute(new DepositCommand(account, 500m));
history.Execute(new WithdrawCommand(account, 200m));
Console.WriteLine($"\nSaldo po operacjach: {account.Balance:C}");

Console.WriteLine("\n[Cofam ostatnią operację]");
history.Undo();
Console.WriteLine($"Saldo po Undo: {account.Balance:C}");

Console.WriteLine("\n[Cofam drugą operację]");
history.Undo();
Console.WriteLine($"Saldo po 2x Undo: {account.Balance:C}");

// ── Scenariusz C: Makropolecenie — kompozyt akcji ───────────────────────────
Console.WriteLine("\n=== C: Makropolecenie ===\n");

var light1 = new SmartLight("Salon");
var light2 = new SmartLight("Sypialnia");
var fan    = new CeilingFan();

// "Wieczorny tryb" = zestaw akcji
IUndoCommand eveningMode = new MacroCommand([
    new SmartLightDimCommand(light1, 30),
    new SmartLightOffCommand(light2),
    new FanOffCommand(fan)
]);

Console.WriteLine("[Włącz tryb wieczorny]");
eveningMode.Execute();

Console.WriteLine("\n[Cofnij tryb wieczorny]");
eveningMode.Undo();

// ── Scenariusz D: Wada — nadmiar klas dla prostych operacji ─────────────────
Console.WriteLine("\n=== D: Wada vs. Delegat — kiedy wzorzec jest nadmiarowy ===\n");

// Prosty przypadek — delegat wystarczy
Console.WriteLine("[Wariant 1: Delegat/Action — wystarczy dla prostej akcji]");
Action greet = () => Console.WriteLine("Cześć z delegata!");
greet();

// Złożony przypadek — pełny wzorzec jest uzasadniony
Console.WriteLine("\n[Wariant 2: Pełny wzorzec — potrzebny gdy mamy Undo + stan]");
var history2 = new CommandHistory();
var counter = new Counter();
history2.Execute(new IncrementCommand(counter, 10));
history2.Execute(new IncrementCommand(counter, 5));
Console.WriteLine($"Counter = {counter.Value}");
history2.Undo();
Console.WriteLine($"Counter po Undo = {counter.Value}");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ── Interfejsy ───────────────────────────────────────────────────────────────
interface ISimpleCommand { void Execute(); }
interface IUndoCommand : ISimpleCommand { void Undo(); }

// ── Scenariusz A: Prosty Command ─────────────────────────────────────────────
class Printer
{
    public void Print(string message) => Console.WriteLine($"[Drukarka] {message}");
}

class PrintCommand(Printer printer, string message) : ISimpleCommand
{
    public void Execute() => printer.Print(message);
}

class SimpleInvoker
{
    private ISimpleCommand? _command;
    public void SetCommand(ISimpleCommand cmd) => _command = cmd;
    public void Run() => _command?.Execute();
}

// ── Scenariusz B: Undo — rachunek bankowy ─────────────────────────────────────
class BankAccount(string owner, decimal initialBalance)
{
    public decimal Balance { get; private set; } = initialBalance;

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"[{owner}] Wpłata {amount:C} → saldo {Balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
        Console.WriteLine($"[{owner}] Wypłata {amount:C} → saldo {Balance:C}");
    }
}

class DepositCommand(BankAccount account, decimal amount) : IUndoCommand
{
    public void Execute() => account.Deposit(amount);
    public void Undo()    => account.Withdraw(amount);
}

class WithdrawCommand(BankAccount account, decimal amount) : IUndoCommand
{
    public void Execute() => account.Withdraw(amount);
    public void Undo()    => account.Deposit(amount);
}

class CommandHistory
{
    private readonly Stack<IUndoCommand> _stack = new();

    public void Execute(IUndoCommand cmd)
    {
        cmd.Execute();
        _stack.Push(cmd);
    }

    public void Undo()
    {
        if (_stack.TryPop(out var cmd))
            cmd.Undo();
        else
            Console.WriteLine("[Historia] Brak operacji do cofnięcia");
    }
}

// ── Scenariusz C: Makropolecenie ─────────────────────────────────────────────
class SmartLight(string room)
{
    private int _brightness = 100;
    private bool _isOn = true;

    public void Dim(int level)
    {
        int prev = _brightness;
        _brightness = level;
        Console.WriteLine($"[Światło {room}] Przyciemnione z {prev}% do {_brightness}%");
    }

    public void SetBrightness(int level)
    {
        _brightness = level;
        Console.WriteLine($"[Światło {room}] Jasność przywrócona do {_brightness}%");
    }

    public void TurnOff()
    {
        _isOn = false;
        Console.WriteLine($"[Światło {room}] WYŁĄCZONE");
    }

    public void TurnOn()
    {
        _isOn = true;
        Console.WriteLine($"[Światło {room}] WŁĄCZONE");
    }
}

class CeilingFan
{
    private bool _running = true;
    public void Stop()  { _running = false; Console.WriteLine("[Wentylator] ZATRZYMANY"); }
    public void Start() { _running = true;  Console.WriteLine("[Wentylator] URUCHOMIONY"); }
}

class SmartLightDimCommand(SmartLight light, int targetLevel) : IUndoCommand
{
    private int _prevLevel = 100;
    public void Execute() { _prevLevel = targetLevel; light.Dim(targetLevel); }
    public void Undo()    => light.SetBrightness(_prevLevel);
}

class SmartLightOffCommand(SmartLight light) : IUndoCommand
{
    public void Execute() => light.TurnOff();
    public void Undo()    => light.TurnOn();
}

class FanOffCommand(CeilingFan fan) : IUndoCommand
{
    public void Execute() => fan.Stop();
    public void Undo()    => fan.Start();
}

class MacroCommand(IUndoCommand[] commands) : IUndoCommand
{
    public void Execute()
    {
        foreach (var cmd in commands)
            cmd.Execute();
    }

    public void Undo()
    {
        // WAŻNE: cofamy w odwrotnej kolejności!
        foreach (var cmd in commands.Reverse())
            cmd.Undo();
    }
}

// ── Scenariusz D: Counter z Undo ─────────────────────────────────────────────
class Counter
{
    public int Value { get; private set; } = 0;
    public void Add(int n) { Value += n; Console.WriteLine($"[Counter] +{n} → {Value}"); }
    public void Sub(int n) { Value -= n; Console.WriteLine($"[Counter] -{n} → {Value}"); }
}

class IncrementCommand(Counter counter, int amount) : IUndoCommand
{
    public void Execute() => counter.Add(amount);
    public void Undo()    => counter.Sub(amount);
}
