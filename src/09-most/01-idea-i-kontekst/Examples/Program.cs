// ============================================================
// Sprint 1: dwie abstrakcje, dwa implementory
// ============================================================
Console.WriteLine("=== Sprint 1: BasicRemote + AdvancedRemote / Tv + Radio ===");

var tv = new TvDevice();
var radio = new RadioDevice();

var basic = new BasicRemote(tv);
basic.TogglePower();
basic.SetVolume(15);

var advanced = new AdvancedRemote(radio);
advanced.TogglePower();
advanced.SetVolume(25);
advanced.Mute();                             // tylko w AdvancedRemote

// ============================================================
// Runtime switch: podmiana urzadzenia bez zmiany pilota
// ============================================================
Console.WriteLine("\n=== Runtime switch: BasicRemote przelaczony na Radio ===");
basic.Device = radio;
basic.TogglePower();
basic.SetVolume(30);

// ============================================================
// Sprint 2: nowy implementor ProjectorDevice
//   => zero zmian w BasicRemote / AdvancedRemote
// ============================================================
Console.WriteLine("\n=== Sprint 2 (Team B): +ProjectorDevice – piloty bez zmian ===");
var projector = new ProjectorDevice();
var advancedWithProjector = new AdvancedRemote(projector);
advancedWithProjector.TogglePower();
advancedWithProjector.SetVolume(50);
advancedWithProjector.Mute();

// ============================================================
// Sprint 2: nowa abstrakcja VoiceRemote
//   => zero zmian w TvDevice / RadioDevice / ProjectorDevice
// ============================================================
Console.WriteLine("\n=== Sprint 2 (Team A): +VoiceRemote – urzadzenia bez zmian ===");
var voice = new VoiceRemote(tv);
voice.TogglePower();
voice.VoiceCommand("volume up");

// ============================================================
// Interfaces & Implementations
// ============================================================

internal interface IDevice
{
    void Enable();
    void Disable();
    void SetVolume(int value);
    string Status();
}

// ---------- Abstraction ----------

internal class BasicRemote(IDevice device)
{
    public IDevice Device { get; set; } = device;

    public void TogglePower()
    {
        Console.WriteLine("Remote: toggle power");
        Device.Enable();
        Console.WriteLine(Device.Status());
    }

    public void SetVolume(int value)
    {
        Device.SetVolume(value);
        Console.WriteLine(Device.Status());
    }
}

// RefinedAbstraction – rozszerza API bez zmian implementorow
internal sealed class AdvancedRemote(IDevice device) : BasicRemote(device)
{
    public void Mute()
    {
        Console.WriteLine("Remote: mute");
        Device.SetVolume(0);
        Console.WriteLine(Device.Status());
    }
}

// RefinedAbstraction Sprint 2 – dodana przez Team A, implementory bez zmian
internal sealed class VoiceRemote(IDevice device)
{
    public IDevice Device { get; } = device;

    public void TogglePower()
    {
        Console.WriteLine("VoiceRemote: toggle power");
        Device.Enable();
        Console.WriteLine(Device.Status());
    }

    public void VoiceCommand(string cmd)
    {
        Console.WriteLine($"VoiceRemote: received voice command '{cmd}'");
        if (cmd == "volume up") Device.SetVolume(70);
        Console.WriteLine(Device.Status());
    }
}

// ---------- ConcreteImplementors ----------

internal sealed class TvDevice : IDevice
{
    private bool _enabled;
    private int _volume;

    public void Enable() => _enabled = true;
    public void Disable() => _enabled = false;
    public void SetVolume(int value) => _volume = value;
    public string Status() => $"TV: enabled={_enabled}, volume={_volume}";
}

internal sealed class RadioDevice : IDevice
{
    private bool _enabled;
    private int _volume;

    public void Enable() => _enabled = true;
    public void Disable() => _enabled = false;
    public void SetVolume(int value) => _volume = value;
    public string Status() => $"Radio: enabled={_enabled}, volume={_volume}";
}

// ConcreteImplementor Sprint 2 – dodany przez Team B, piloty bez zmian
internal sealed class ProjectorDevice : IDevice
{
    private bool _enabled;
    private int _brightness;

    public void Enable() => _enabled = true;
    public void Disable() => _enabled = false;
    public void SetVolume(int value) => _brightness = value;   // volume -> brightness w projektorze
    public string Status() => $"Projector: enabled={_enabled}, brightness={_brightness}";
}

