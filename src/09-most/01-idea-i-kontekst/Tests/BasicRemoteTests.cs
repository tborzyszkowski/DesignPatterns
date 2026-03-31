using System.IO;
using Xunit;

public class BasicRemoteTests
{
    [Fact]
    public void TogglePower_CallsEnableAndPrintsStatus()
    {
        var device = new FakeDevice();
        var remote = new BasicRemote(device);
        var output = CaptureConsole(() => remote.TogglePower());

        Assert.True(device.EnableCalled);
        Assert.Contains("Remote: toggle power", output);
        Assert.Contains("fake-status", output);
    }

    [Fact]
    public void SetVolume_ForwardsVolumeToDevice()
    {
        var device = new FakeDevice();
        var remote = new BasicRemote(device);

        var output = CaptureConsole(() => remote.SetVolume(42));

        Assert.Equal(42, device.LastVolume);
        Assert.Contains("fake-status", output);
    }

    [Fact]
    public void Device_CanBeSwitchedAtRuntime()
    {
        var first = new FakeDevice();
        var second = new FakeDevice();
        var remote = new BasicRemote(first);

        remote.Device = second;
        CaptureConsole(() => remote.TogglePower());

        Assert.False(first.EnableCalled);
        Assert.True(second.EnableCalled);
    }

    private static string CaptureConsole(Action action)
    {
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);

        try
        {
            action();
            return writer.ToString();
        }
        finally
        {
            Console.SetOut(original);
        }
    }

    private sealed class FakeDevice : IDevice
    {
        public bool EnableCalled { get; private set; }
        public int LastVolume { get; private set; }

        public void Enable() => EnableCalled = true;
        public void Disable()
        {
        }

        public void SetVolume(int value) => LastVolume = value;
        public string Status() => "fake-status";
    }
}