// =============================================================================
// Wzorzec Polecenie — 01. Idea i kontekst
// Demonstracja problemu i rozwiązania: przycisk sterujący urządzeniami
// =============================================================================

// ── CZĘŚĆ 1: Problem — bez wzorca Polecenie ──────────────────────────────────

Console.WriteLine("=== CZĘŚĆ 1: Problem bez wzorca Polecenie ===\n");

var naiveProblem = new NaiveButton();
naiveProblem.ClickTurnOnLight();
naiveProblem.ClickStartFan();
naiveProblem.ClickOpenDoor();

Console.WriteLine();

// ── CZĘŚĆ 2: Rozwiązanie — wzorzec Polecenie ────────────────────────────────

Console.WriteLine("=== CZĘŚĆ 2: Rozwiązanie z wzorcem Polecenie ===\n");

// Stwórz odbiorniki
var light = new Light("Salon");
var fan = new Fan();
var door = new GarageDoor();

// Stwórz konkretne polecenia (enkapsulują żądania)
ICommand lightOn = new LightOnCommand(light);
ICommand lightOff = new LightOffCommand(light);
ICommand fanStart = new FanStartCommand(fan);
ICommand doorOpen = new GarageDoorOpenCommand(door);

// Podłącz polecenia do przycisków (Invoker)
var btn1 = new SmartButton("Przycisk 1");
var btn2 = new SmartButton("Przycisk 2");
var btn3 = new SmartButton("Przycisk 3");

btn1.SetCommand(lightOn);
btn2.SetCommand(fanStart);
btn3.SetCommand(doorOpen);

// Użytkownik klika przyciski — nie wie, co polecenie robi wewnątrz
btn1.Click();
btn2.Click();
btn3.Click();

Console.WriteLine("\n--- Teraz zmień polecenie przycisku 1 bez modyfikacji SmartButton: ---");
btn1.SetCommand(lightOff);
btn1.Click();

Console.WriteLine("\n--- Polecenie złożone (sekwencja): ---");
ICommand sequence = new SequenceCommand([lightOn, fanStart, doorOpen]);
var masterBtn = new SmartButton("Master");
masterBtn.SetCommand(sequence);
masterBtn.Click();

// =============================================================================
// PROBLEM: ścisłe powiązanie — NaiveButton zna wszystkich odbiorców
// =============================================================================
class NaiveButton
{
    // Bezpośrednie zależności na konkretne klasy — tight coupling!
    private readonly Light _light = new("Salon");
    private readonly Fan _fan = new();
    private readonly GarageDoor _door = new();

    // Każde nowe działanie to nowa metoda w Button — naruszenie OCP i SRP
    public void ClickTurnOnLight()
    {
        Console.WriteLine("[NaiveButton] Kliknięto → bezpośrednie wywołanie Light.TurnOn()");
        _light.TurnOn();
    }

    public void ClickStartFan()
    {
        Console.WriteLine("[NaiveButton] Kliknięto → bezpośrednie wywołanie Fan.Start()");
        _fan.Start();
    }

    public void ClickOpenDoor()
    {
        Console.WriteLine("[NaiveButton] Kliknięto → bezpośrednie wywołanie GarageDoor.Open()");
        _door.Open();
    }
}

// =============================================================================
// ROZWIĄZANIE: Wzorzec Polecenie — enkapsulacja żądań
// =============================================================================

// ── Interfejs Polecenia ──────────────────────────────────────────────────────
interface ICommand
{
    void Execute();
}

// ── Invoker — tylko wie, że ma ICommand i może go uruchomić ─────────────────
class SmartButton(string name)
{
    private ICommand? _command;

    public void SetCommand(ICommand command) => _command = command;

    public void Click()
    {
        Console.Write($"[{name}] Kliknięto → ");
        _command?.Execute();
    }
}

// ── Odbiorniki (Receivers) — zawierają faktyczną logikę ─────────────────────
class Light(string room)
{
    public void TurnOn() => Console.WriteLine($"Światło w [{room}] WŁĄCZONE");
    public void TurnOff() => Console.WriteLine($"Światło w [{room}] WYŁĄCZONE");
}

class Fan
{
    public void Start() => Console.WriteLine("Wentylator URUCHOMIONY");
    public void Stop() => Console.WriteLine("Wentylator ZATRZYMANY");
}

class GarageDoor
{
    public void Open() => Console.WriteLine("Brama garażowa OTWARTA");
    public void Close() => Console.WriteLine("Brama garażowa ZAMKNIĘTA");
}

// ── Konkretne polecenia (ConcreteCommands) ────────────────────────────────────
class LightOnCommand(Light light) : ICommand
{
    public void Execute() => light.TurnOn();
}

class LightOffCommand(Light light) : ICommand
{
    public void Execute() => light.TurnOff();
}

class FanStartCommand(Fan fan) : ICommand
{
    public void Execute() => fan.Start();
}

class GarageDoorOpenCommand(GarageDoor door) : ICommand
{
    public void Execute() => door.Open();
}

// ── Polecenie złożone — sekwencja poleceń ─────────────────────────────────────
class SequenceCommand(ICommand[] commands) : ICommand
{
    public void Execute()
    {
        Console.WriteLine("[Sequence] Uruchamiam sekwencję:");
        foreach (var cmd in commands)
        {
            Console.Write("  ");
            cmd.Execute();
        }
    }
}
