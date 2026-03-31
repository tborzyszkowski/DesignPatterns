using Examples;
using Xunit;

public class MessageSenderDecoratorTests
{
    [Fact]
    public void EmailSender_Send_HasEmailPrefix()
    {
        var sender = new EmailSender();

        var result = sender.Send("hello");

        Assert.Equal("EMAIL:hello", result);
    }

    [Fact]
    public void SignatureDecorator_AppendsSignatureBeforeInner()
    {
        var inner = new SpySender();
        var decorator = new SignatureDecorator(inner);

        decorator.Send("hello");

        Assert.Contains("hello", inner.LastMessage);
        Assert.Contains("Sent from Decorator Demo", inner.LastMessage);
    }

    [Fact]
    public void LoggingDecorator_DelegatesToInner()
    {
        var inner = new SpySender();
        var decorator = new LoggingDecorator(inner);

        decorator.Send("test");

        Assert.Equal("test", inner.LastMessage);
    }

    [Fact]
    public void StackedChain_LoggingOverSignatureOverEmail_ReturnsEmailResult()
    {
        IMessageSender chain = new LoggingDecorator(
            new SignatureDecorator(
                new EmailSender()));

        var result = chain.Send("Witaj");

        Assert.StartsWith("EMAIL:", result);
        Assert.Contains("Sent from Decorator Demo", result);
    }

    [Fact]
    public void EmailSender_Send_PreservesMessage()
    {
        var sender = new EmailSender();

        var result = sender.Send("abc123");

        Assert.Contains("abc123", result);
    }

    private sealed class SpySender : IMessageSender
    {
        public string LastMessage { get; private set; } = string.Empty;

        public string Send(string message)
        {
            LastMessage = message;
            return $"SPY:{message}";
        }
    }
}
