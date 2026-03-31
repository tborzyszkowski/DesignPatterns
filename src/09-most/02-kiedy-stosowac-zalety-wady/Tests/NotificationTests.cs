using Xunit;

public class NotificationTests
{
    [Fact]
    public void IncidentNotification_FormatsPayloadWithIncidentPrefix()
    {
        var channel = new FakeChannel();
        Notification notification = new IncidentNotification(channel);

        notification.Send("API timeout");

        Assert.Equal("[INCIDENT] API timeout", channel.LastPayload);
    }

    [Fact]
    public void Notification_CanSwitchChannelAtRuntime()
    {
        var first = new FakeChannel();
        var second = new FakeChannel();
        Notification notification = new IncidentNotification(first);

        notification.Channel = second;
        notification.Send("DB down");

        Assert.Null(first.LastPayload);
        Assert.Equal("[INCIDENT] DB down", second.LastPayload);
    }

    private sealed class FakeChannel : IChannel
    {
        public string? LastPayload { get; private set; }

        public void Deliver(string payload) => LastPayload = payload;
    }
}