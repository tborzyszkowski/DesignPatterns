using Xunit;

public class MessageBridgeTests
{
    [Fact]
    public void Send_AddsBridgePrefix()
    {
        var sender = new FakeSender();
        var bridge = new MessageBridge(sender);

        bridge.Send("hello");

        Assert.Equal("[Bridge] hello", sender.LastText);
    }

    [Fact]
    public void Bridge_CanSwitchSenderAtRuntime()
    {
        var first = new FakeSender();
        var second = new FakeSender();
        var bridge = new MessageBridge(first);

        bridge.Sender = second;
        bridge.Send("switch");

        Assert.Null(first.LastText);
        Assert.Equal("[Bridge] switch", second.LastText);
    }

    [Theory]
    [InlineData("email", typeof(EmailSender))]
    [InlineData("sms", typeof(SmsSender))]
    [InlineData("push", typeof(PushSender))]
    [InlineData("unknown", typeof(PushSender))]
    public void SenderFactory_ReturnsExpectedImplementation(string key, Type expected)
    {
        var sender = SenderFactory.Create(key);
        Assert.IsType(expected, sender);
    }

    private sealed class FakeSender : IMessageSender
    {
        public string? LastText { get; private set; }

        public void SendRaw(string text) => LastText = text;
    }
}