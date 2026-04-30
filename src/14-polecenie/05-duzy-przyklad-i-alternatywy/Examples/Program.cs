// =============================================================================
// Wzorzec Polecenie — 05. Duży przykład: System Smart Home
//
// Pilot zdalnego sterowania (RemoteControl) steruje 7 urządzeniami.
// Każdy slot pilota może zawierać dowolne polecenie.
// Scenariusze: "Wychodzę z domu", "Dobry wieczór", "SOS".
// Pełna obsługa Undo/Redo.
// =============================================================================

// ── Konfiguracja systemu ──────────────────────────────────────────────────────
var livingRoomLight  = new SmartLight("Salon");
var bedroomLight     = new SmartLight("Sypialnia");
var kitchenLight     = new SmartLight("Kuchnia");
var thermostat       = new Thermostat();
var security         = new SecuritySystem();
var music            = new MusicPlayer();
var garage           = new GarageDoor();

var remote = new RemoteControl(slotCount: 7);

// ── Slot 0: Salon — włącz / wyłącz ───────────────────────────────────────────
remote.SetCommand(0,
    on:  new LightOnCommand(livingRoomLight),
    off: new LightOffCommand(livingRoomLight));

// ── Slot 1: Sypialnia — włącz / wyłącz ───────────────────────────────────────
remote.SetCommand(1,
    on:  new LightOnCommand(bedroomLight),
    off: new LightOffCommand(bedroomLight));

// ── Slot 2: Muzyka ────────────────────────────────────────────────────────────
remote.SetCommand(2,
    on:  new MusicPlayCommand(music, "Jazz Lounge"),
    off: new MusicStopCommand(music));

// ── Slot 3: Brama garażowa ────────────────────────────────────────────────────
remote.SetCommand(3,
    on:  new GarageOpenCommand(garage),
    off: new GarageCloseCommand(garage));

// ── Slot 4: Makro "Dobry wieczór" ─────────────────────────────────────────────
ICommand goodEvening = new MacroCommand("Dobry wieczór", [
    new LightDimCommand(livingRoomLight, 40),
    new LightOffCommand(bedroomLight),
    new ThermostatSetCommand(thermostat, 22.0),
    new MusicPlayCommand(music, "Relaxing Piano")
]);

ICommand dayMode = new MacroCommand("Tryb dzienny", [
    new LightOnCommand(livingRoomLight),
    new LightOnCommand(bedroomLight),
    new ThermostatSetCommand(thermostat, 20.0),
    new MusicStopCommand(music)
]);

remote.SetCommand(4, on: goodEvening, off: dayMode);

// ── Slot 5: Makro "Wychodzę z domu" ──────────────────────────────────────────
ICommand leaveHome = new MacroCommand("Wychodzę z domu", [
    new LightOffCommand(livingRoomLight),
    new LightOffCommand(bedroomLight),
    new LightOffCommand(kitchenLight),
    new ThermostatSetCommand(thermostat, 16.0),
    new SecurityArmCommand(security, "1234"),
    new GarageCloseCommand(garage)
]);

ICommand arriveHome = new MacroCommand("Wracam do domu", [
    new GarageOpenCommand(garage),
    new SecurityDisarmCommand(security, "1234"),
    new LightOnCommand(livingRoomLight),
    new ThermostatSetCommand(thermostat, 21.0)
]);

remote.SetCommand(5, on: leaveHome, off: arriveHome);

// ── Slot 6: SOS — pełne oświetlenie ──────────────────────────────────────────
ICommand sos = new MacroCommand("SOS - pełne oświetlenie", [
    new LightOnCommand(livingRoomLight),
    new LightOnCommand(bedroomLight),
    new LightOnCommand(kitchenLight),
    new SecurityDisarmCommand(security, "1234")
]);

remote.SetCommand(6, on: sos, off: new NoOpCommand());

// ─────────────────────────────────────────────────────────────────────────────
// DEMONSTRACJA
// ─────────────────────────────────────────────────────────────────────────────

Console.WriteLine("══════════════════════════════════════════════");
Console.WriteLine("   SYSTEM SMART HOME — Pilot Zdalnego Sterowania");
Console.WriteLine("══════════════════════════════════════════════\n");

remote.PrintStatus();

// Scenariusz 1: Poranne wstawanie
Console.WriteLine("\n──── Scenariusz 1: Poranne wstawanie ────");
remote.PressOn(0);   // salon ON
remote.PressOn(2);   // muzyka ON

// Scenariusz 2: Dobry wieczór
Console.WriteLine("\n──── Scenariusz 2: Dobry wieczór ────");
remote.PressOn(4);

// Cofnij tryb wieczorny
Console.WriteLine("\n──── Cofnij ostatnią akcję ────");
remote.PressUndo();

// Scenariusz 3: Wychodzę z domu
Console.WriteLine("\n──── Scenariusz 3: Wychodzę z domu ────");
remote.PressOn(5);

// Wracam
Console.WriteLine("\n──── Scenariusz 4: Wracam do domu ────");
remote.PressOff(5);

// Scenariusz 5: Wielokrotne Undo
Console.WriteLine("\n──── Scenariusz 5: Cofam 3 ostatnie operacje ────");
remote.PressUndo();
remote.PressUndo();
remote.PressUndo();

// Wyświetl aktualny status
Console.WriteLine("\n──── Status urządzeń ────");
Console.WriteLine("    " + livingRoomLight.GetStatus());
Console.WriteLine("    " + thermostat.GetStatus());
Console.WriteLine("    " + security.GetStatus());

// ─────────────────────────────────────────────────────────────────────────────
// IMPLEMENTACJE — Interfejsy
// ─────────────────────────────────────────────────────────────────────────────

interface ICommand
{
    void Execute();
    void Undo();
    string Description { get; }
}

// ─────────────────────────────────────────────────────────────────────────────
// Null Object Pattern — brak akcji (slot bez polecenia)
// ─────────────────────────────────────────────────────────────────────────────
class NoOpCommand : ICommand
{
    public string Description => "(brak akcji)";
    public void Execute() { /* nic nie rób */ }
    public void Undo()    { /* nic nie rób */ }
}

// ─────────────────────────────────────────────────────────────────────────────
// MacroCommand — kompozyt poleceń
// ─────────────────────────────────────────────────────────────────────────────
class MacroCommand(string description, ICommand[] commands) : ICommand
{
    public string Description => description;

    public void Execute()
    {
        Console.WriteLine($"  [Makro: {description}]");
        foreach (var cmd in commands)
            cmd.Execute();
    }

    public void Undo()
    {
        Console.WriteLine($"  [Cofam makro: {description}]");
        foreach (var cmd in commands.Reverse())
            cmd.Undo();
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// CommandHistory — stos Undo
// ─────────────────────────────────────────────────────────────────────────────
class CommandHistory
{
    private readonly Stack<ICommand> _stack = new();

    public void Push(ICommand cmd) => _stack.Push(cmd);

    public void Undo()
    {
        if (_stack.TryPop(out var cmd))
        {
            Console.WriteLine($"  [Undo] Cofam: {cmd.Description}");
            cmd.Undo();
        }
        else Console.WriteLine("  [Undo] Brak operacji do cofnięcia");
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// INVOKER — Pilot zdalnego sterowania
// ─────────────────────────────────────────────────────────────────────────────
class RemoteControl(int slotCount)
{
    private readonly ICommand[] _onCommands  = Enumerable.Range(0, slotCount).Select(_ => (ICommand)new NoOpCommand()).ToArray();
    private readonly ICommand[] _offCommands = Enumerable.Range(0, slotCount).Select(_ => (ICommand)new NoOpCommand()).ToArray();
    private readonly CommandHistory _history = new();

    public void SetCommand(int slot, ICommand on, ICommand off)
    {
        _onCommands[slot]  = on;
        _offCommands[slot] = off;
    }

    public void PressOn(int slot)
    {
        Console.WriteLine($"\n[Pilot] Przycisk ON  (slot {slot}): {_onCommands[slot].Description}");
        _onCommands[slot].Execute();
        _history.Push(_onCommands[slot]);
    }

    public void PressOff(int slot)
    {
        Console.WriteLine($"\n[Pilot] Przycisk OFF (slot {slot}): {_offCommands[slot].Description}");
        _offCommands[slot].Execute();
        _history.Push(_offCommands[slot]);
    }

    public void PressUndo() => _history.Undo();

    public void PrintStatus()
    {
        Console.WriteLine("┌─────────────────────────────────────────────┐");
        Console.WriteLine("│              PILOT — KONFIGURACJA            │");
        Console.WriteLine("├──────┬────────────────────┬──────────────────┤");
        Console.WriteLine("│ Slot │ ON                 │ OFF              │");
        Console.WriteLine("├──────┼────────────────────┼──────────────────┤");
        for (int i = 0; i < slotCount; i++)
            Console.WriteLine($"│  {i}   │ {_onCommands[i].Description,-18} │ {_offCommands[i].Description,-16} │");
        Console.WriteLine("└──────┴────────────────────┴──────────────────┘");
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// RECEIVERS — urządzenia Smart Home
// ─────────────────────────────────────────────────────────────────────────────

class SmartLight(string room)
{
    private bool _isOn = false;
    private int _brightness = 100;

    public void TurnOn()
    {
        _isOn = true; _brightness = 100;
        Console.WriteLine($"    [Lampa {room}] ✓ WŁĄCZONA (100%)");
    }
    public void TurnOff()
    {
        _isOn = false;
        Console.WriteLine($"    [Lampa {room}] ✗ WYŁĄCZONA");
    }
    public void Dim(int level)
    {
        _brightness = level; _isOn = level > 0;
        Console.WriteLine($"    [Lampa {room}] ⬇ Przyciemniona do {level}%");
    }
    public int GetBrightness() => _brightness;
    public string GetStatus() => $"Lampa {room}: {(_isOn ? $"ON ({_brightness}%)" : "OFF")}";
}

class Thermostat
{
    private double _temp = 21.0;
    public void SetTemperature(double temp)
    {
        double prev = _temp; _temp = temp;
        Console.WriteLine($"    [Termostat] {prev}°C → {temp}°C");
    }
    public double GetTemperature() => _temp;
    public string GetStatus() => $"Termostat: {_temp}°C";
}

class SecuritySystem
{
    private bool _armed = false;
    private string _pin = "";
    public void Arm(string pin)   { _armed = true;  _pin = pin; Console.WriteLine($"    [Alarm] 🔒 UZBROJONY"); }
    public void Disarm(string pin){ _armed = false;             Console.WriteLine($"    [Alarm] 🔓 ROZBROJONY"); }
    public bool IsArmed => _armed;
    public string GetStatus() => $"Alarm: {(_armed ? "UZBROJONY" : "rozbrojon")}";
}

class MusicPlayer
{
    private bool _playing = false;
    private string _track = "";
    private int _volume = 50;
    public void Play(string track) { _playing = true; _track = track; Console.WriteLine($"    [Muzyka] ▶ Gra: {track}"); }
    public void Stop()             { _playing = false;                Console.WriteLine($"    [Muzyka] ■ Zatrzymana"); }
    public void SetVolume(int vol) { _volume = vol; Console.WriteLine($"    [Muzyka] Głośność: {vol}%"); }
    public int GetVolume() => _volume;
}

class GarageDoor
{
    private bool _open = false;
    public void Open()  { _open = true;  Console.WriteLine($"    [Brama] ↑ OTWARTA"); }
    public void Close() { _open = false; Console.WriteLine($"    [Brama] ↓ ZAMKNIĘTA"); }
    public bool IsOpen => _open;
}

// ─────────────────────────────────────────────────────────────────────────────
// CONCRETE COMMANDS
// ─────────────────────────────────────────────────────────────────────────────

class LightOnCommand(SmartLight light) : ICommand
{
    public string Description => $"Włącz lampę";
    public void Execute() => light.TurnOn();
    public void Undo()    => light.TurnOff();
}

class LightOffCommand(SmartLight light) : ICommand
{
    public string Description => $"Wyłącz lampę";
    public void Execute() => light.TurnOff();
    public void Undo()    => light.TurnOn();
}

class LightDimCommand(SmartLight light, int targetLevel) : ICommand
{
    private int _prevLevel = 100;
    public string Description => $"Przyciemnij ({targetLevel}%)";
    public void Execute() { _prevLevel = light.GetBrightness(); light.Dim(targetLevel); }
    public void Undo()    => light.Dim(_prevLevel);
}

class ThermostatSetCommand(Thermostat thermostat, double targetTemp) : ICommand
{
    private double _prevTemp;
    public string Description => $"Termostat {targetTemp}°C";
    public void Execute() { _prevTemp = thermostat.GetTemperature(); thermostat.SetTemperature(targetTemp); }
    public void Undo()    => thermostat.SetTemperature(_prevTemp);
}

class SecurityArmCommand(SecuritySystem sec, string pin) : ICommand
{
    public string Description => "Uzbrój alarm";
    public void Execute() => sec.Arm(pin);
    public void Undo()    => sec.Disarm(pin);
}

class SecurityDisarmCommand(SecuritySystem sec, string pin) : ICommand
{
    public string Description => "Rozbrój alarm";
    public void Execute() => sec.Disarm(pin);
    public void Undo()    => sec.Arm(pin);
}

class MusicPlayCommand(MusicPlayer player, string track) : ICommand
{
    public string Description => $"Graj: {track}";
    public void Execute() => player.Play(track);
    public void Undo()    => player.Stop();
}

class MusicStopCommand(MusicPlayer player) : ICommand
{
    private string _prevTrack = "";
    public string Description => "Zatrzymaj muzykę";
    public void Execute() => player.Stop();
    public void Undo()    { if (!string.IsNullOrEmpty(_prevTrack)) player.Play(_prevTrack); }
}

class GarageOpenCommand(GarageDoor door) : ICommand
{
    public string Description => "Otwórz brame";
    public void Execute() => door.Open();
    public void Undo()    => door.Close();
}

class GarageCloseCommand(GarageDoor door) : ICommand
{
    public string Description => "Zamknij brame";
    public void Execute() => door.Close();
    public void Undo()    => door.Open();
}
