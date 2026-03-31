var basicRemote = new BasicRemote(new TvDevice());
basicRemote.TogglePower();
basicRemote.SetVolume(15);

basicRemote.Device = new RadioDevice();
basicRemote.TogglePower();
basicRemote.SetVolume(30);

internal interface IDevice
{
    void Enable();
    void Disable();
    void SetVolume(int value);
    string Status();
}

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
