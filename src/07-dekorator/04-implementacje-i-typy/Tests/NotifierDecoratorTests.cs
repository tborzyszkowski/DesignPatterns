using Examples;
using Xunit;

public class NotifierDecoratorTests
{
    [Fact]
    public void ConsoleNotifier_Notify_HasNotifyPrefix()
    {
        var notifier = new ConsoleNotifier();

        var result = notifier.Notify("hello");

        Assert.Equal("NOTIFY:hello", result);
    }

    [Fact]
    public void TimestampDecorator_Notify_ContainsNotifyPrefix()
    {
        var notifier = new TimestampDecorator(new ConsoleNotifier());

        var result = notifier.Notify("msg");

        Assert.Contains("NOTIFY:", result);
    }

    [Fact]
    public void TimestampDecorator_Notify_ContainsTimestampBrackets()
    {
        var notifier = new TimestampDecorator(new ConsoleNotifier());

        var result = notifier.Notify("msg");

        Assert.Contains("[", result);
        Assert.Contains("]", result);
    }

    [Fact]
    public void TimestampDecorator_Notify_ContainsOriginalMessage()
    {
        var notifier = new TimestampDecorator(new ConsoleNotifier());

        var result = notifier.Notify("unique-message");

        Assert.Contains("unique-message", result);
    }

    [Fact]
    public void TimestampDecorator_DelegatesToInner()
    {
        var spy = new SpyNotifier();
        var decorator = new TimestampDecorator(spy);

        decorator.Notify("test");

        Assert.NotNull(spy.LastMessage);
        Assert.Contains("test", spy.LastMessage);
    }

    private sealed class SpyNotifier : INotifier
    {
        public string? LastMessage { get; private set; }

        public string Notify(string message)
        {
            LastMessage = message;
            return $"SPY:{message}";
        }
    }
}
