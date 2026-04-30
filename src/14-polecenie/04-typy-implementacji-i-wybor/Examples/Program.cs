// =============================================================================
// Wzorzec Polecenie — 04. Typy implementacji
// Demonstracja 5 wariantów: prosty, undo/redo, makro, asynchroniczny, lambda
// =============================================================================
using System.Text;

// ── TYP 1: Prosty Command ────────────────────────────────────────────────────
Console.WriteLine("=== TYP 1: Prosty Command ===\n");

var lamp = new Lamp("Biuro");
ISimpleCommand lightOn  = new LampOnCommand(lamp);
ISimpleCommand lightOff = new LampOffCommand(lamp);

// Invoker z listą poleceń (harmonogram)
var scheduler = new CommandScheduler();
scheduler.Schedule(lightOn);
scheduler.Schedule(lightOff);
scheduler.Schedule(lightOn);
scheduler.RunAll();

// ── TYP 2: Command z Undo/Redo ───────────────────────────────────────────────
Console.WriteLine("\n=== TYP 2: Command z Undo/Redo ===\n");

var doc = new TextDocument();
var docHistory = new UndoRedoHistory();

docHistory.Execute(new InsertTextCommand(doc, 0, "Hello"));
docHistory.Execute(new InsertTextCommand(doc, 5, " World"));
docHistory.Execute(new InsertTextCommand(doc, 11, "!"));
Console.WriteLine($"Dokument: \"{doc.Content}\"");

docHistory.Undo();
Console.WriteLine($"Po Undo: \"{doc.Content}\"");
docHistory.Undo();
Console.WriteLine($"Po 2×Undo: \"{doc.Content}\"");
docHistory.Redo();
Console.WriteLine($"Po Redo: \"{doc.Content}\"");

// ── TYP 3: MacroCommand ───────────────────────────────────────────────────────
Console.WriteLine("\n=== TYP 3: MacroCommand ===\n");

var coffeeLight = new Lamp("Kuchnia");
var tv          = new Television();
var speaker     = new Speaker();

// Makropolecenie "Dobry wieczór"
IUndoCommand goodEvening = new MacroCommand([
    new LampDimCommand(coffeeLight, 40),
    new TvOnCommand(tv, "Netflix"),
    new SpeakerVolumeCommand(speaker, 30)
]);

Console.WriteLine("[Dobry wieczór — WŁĄCZ]");
goodEvening.Execute();
Console.WriteLine("\n[Dobry wieczór — COFNIJ]");
goodEvening.Undo();

// ── TYP 4: AsyncCommand ──────────────────────────────────────────────────────
Console.WriteLine("\n=== TYP 4: AsyncCommand ===\n");

var emailService = new EmailService();
IAsyncCommand sendEmail = new SendEmailAsyncCommand(emailService,
    to: "student@uczelnia.pl",
    subject: "Zadanie domowe",
    body: "Proszę o przesłanie rozwiązania do piątku.");

Console.WriteLine("[Wysyłam e-mail asynchronicznie...]");
await sendEmail.ExecuteAsync();

// ── TYP 5: LambdaCommand ─────────────────────────────────────────────────────
Console.WriteLine("\n=== TYP 5: LambdaCommand ===\n");

var counter = new AtomicCounter();

// Polecenie zbudowane z lambd — bez osobnej klasy
IUndoCommand increment10 = new LambdaCommand(
    execute: () => { counter.Add(10); Console.WriteLine($"[Lambda] Counter = {counter.Value}"); },
    undo:    () => { counter.Sub(10); Console.WriteLine($"[Lambda] Cofam   = {counter.Value}"); }
);

IUndoCommand multiply2 = new LambdaCommand(
    execute: () => { counter.Multiply(2); Console.WriteLine($"[Lambda] Counter = {counter.Value}"); },
    undo:    () => { counter.Divide(2);   Console.WriteLine($"[Lambda] Cofam   = {counter.Value}"); }
);

var lambdaHistory = new UndoRedoHistory();
lambdaHistory.Execute(increment10);
lambdaHistory.Execute(multiply2);
Console.WriteLine($"Wynik: {counter.Value}");
lambdaHistory.Undo();
Console.WriteLine($"Po Undo (÷2): {counter.Value}");
lambdaHistory.Undo();
Console.WriteLine($"Po Undo (-10): {counter.Value}");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ── Interfejsy ───────────────────────────────────────────────────────────────
interface ISimpleCommand { void Execute(); }
interface IUndoCommand : ISimpleCommand { void Undo(); }
interface IAsyncCommand { Task ExecuteAsync(); bool CanExecute(); }

// ════════════════════════════════════════════════════════════════════════════
// TYP 1: Prosty Command
// ════════════════════════════════════════════════════════════════════════════

class Lamp(string room)
{
    private int _brightness = 100;
    private bool _on = false;

    public void TurnOn()  { _on = true;  Console.WriteLine($"[Lampa {room}] WŁĄCZONA (jasność {_brightness}%)"); }
    public void TurnOff() { _on = false; Console.WriteLine($"[Lampa {room}] WYŁĄCZONA"); }
    public void Dim(int level) { _brightness = level; Console.WriteLine($"[Lampa {room}] Przyciemniona do {level}%"); }
    public void Restore(int level) { _brightness = level; Console.WriteLine($"[Lampa {room}] Jasność przywrócona do {level}%"); }
}

class LampOnCommand(Lamp lamp) : ISimpleCommand
{
    public void Execute() => lamp.TurnOn();
}

class LampOffCommand(Lamp lamp) : ISimpleCommand
{
    public void Execute() => lamp.TurnOff();
}

class LampDimCommand(Lamp lamp, int targetLevel) : IUndoCommand
{
    private int _prevLevel = 100;
    public void Execute() { _prevLevel = targetLevel; lamp.Dim(targetLevel); }
    public void Undo()    => lamp.Restore(_prevLevel);
}

class CommandScheduler
{
    private readonly List<ISimpleCommand> _commands = [];
    public void Schedule(ISimpleCommand cmd) => _commands.Add(cmd);
    public void RunAll() { foreach (var c in _commands) c.Execute(); }
}

// ════════════════════════════════════════════════════════════════════════════
// TYP 2: Command z Undo/Redo
// ════════════════════════════════════════════════════════════════════════════

class TextDocument
{
    private readonly StringBuilder _content = new();
    public string Content => _content.ToString();

    public void Insert(int pos, string text)
    {
        _content.Insert(pos, text);
        Console.WriteLine($"  [Dok] Insert({pos}, \"{text}\") → \"{Content}\"");
    }

    public void Delete(int pos, int length)
    {
        _content.Remove(pos, length);
        Console.WriteLine($"  [Dok] Delete({pos}, {length}) → \"{Content}\"");
    }
}

class InsertTextCommand(TextDocument doc, int position, string text) : IUndoCommand
{
    public void Execute() => doc.Insert(position, text);
    public void Undo()    => doc.Delete(position, text.Length);
}

class UndoRedoHistory
{
    private readonly Stack<IUndoCommand> _undo = new();
    private readonly Stack<IUndoCommand> _redo = new();

    public void Execute(IUndoCommand cmd)
    {
        cmd.Execute();
        _undo.Push(cmd);
        _redo.Clear();  // nowa operacja kasuje stos redo
    }

    public void Undo()
    {
        if (_undo.TryPop(out var cmd)) { cmd.Undo(); _redo.Push(cmd); }
        else Console.WriteLine("  [Historia] Brak operacji do cofnięcia");
    }

    public void Redo()
    {
        if (_redo.TryPop(out var cmd)) { cmd.Execute(); _undo.Push(cmd); }
        else Console.WriteLine("  [Historia] Brak operacji do ponowienia");
    }
}

// ════════════════════════════════════════════════════════════════════════════
// TYP 3: MacroCommand
// ════════════════════════════════════════════════════════════════════════════

class Television
{
    public void TurnOn(string channel) => Console.WriteLine($"[TV] WŁĄCZONY, kanał: {channel}");
    public void TurnOff() => Console.WriteLine("[TV] WYŁĄCZONY");
}

class Speaker
{
    private int _volume = 50;
    public void SetVolume(int vol) { _volume = vol; Console.WriteLine($"[Głośnik] Głośność: {vol}%"); }
    public int GetVolume() => _volume;
}

class TvOnCommand(Television tv, string channel) : IUndoCommand
{
    public void Execute() => tv.TurnOn(channel);
    public void Undo()    => tv.TurnOff();
}

class SpeakerVolumeCommand(Speaker speaker, int targetVolume) : IUndoCommand
{
    private int _prevVolume = 50;
    public void Execute() { _prevVolume = speaker.GetVolume(); speaker.SetVolume(targetVolume); }
    public void Undo()    => speaker.SetVolume(_prevVolume);
}

class MacroCommand(IUndoCommand[] commands) : IUndoCommand
{
    public void Execute() { foreach (var c in commands) c.Execute(); }
    public void Undo()    { foreach (var c in commands.Reverse()) c.Undo(); }
}

// ════════════════════════════════════════════════════════════════════════════
// TYP 4: AsyncCommand
// ════════════════════════════════════════════════════════════════════════════

class EmailService
{
    public async Task SendAsync(string to, string subject, string body)
    {
        await Task.Delay(50); // symulacja operacji sieciowej
        Console.WriteLine($"  [EmailService] ✓ Wysłano do: {to}");
        Console.WriteLine($"  [EmailService]   Temat: {subject}");
    }
}

class SendEmailAsyncCommand(EmailService service, string to, string subject, string body)
    : IAsyncCommand
{
    public bool CanExecute() => !string.IsNullOrEmpty(to) && !string.IsNullOrEmpty(subject);

    public async Task ExecuteAsync()
    {
        if (!CanExecute())
        {
            Console.WriteLine("[Email] Nie można wysłać — brak adresata lub tematu");
            return;
        }
        await service.SendAsync(to, subject, body);
    }
}

// ════════════════════════════════════════════════════════════════════════════
// TYP 5: LambdaCommand — wrapper na delegaty
// ════════════════════════════════════════════════════════════════════════════

class LambdaCommand(Action execute, Action undo) : IUndoCommand
{
    public void Execute() => execute();
    public void Undo()    => undo();
}

class AtomicCounter
{
    public int Value { get; private set; } = 0;
    public void Add(int n)      => Value += n;
    public void Sub(int n)      => Value -= n;
    public void Multiply(int n) => Value *= n;
    public void Divide(int n)   => Value /= n;
}
