using Examples;
using Xunit;

public class ExporterDecoratorTests
{
    [Fact]
    public void BaseExporter_Export_ReturnsBytesOfPayload()
    {
        var exporter = new BaseExporter();

        var result = exporter.Export("hello");

        Assert.Equal(System.Text.Encoding.UTF8.GetBytes("hello"), result);
    }

    [Fact]
    public void ValidationDecorator_EmptyPayload_ThrowsArgumentException()
    {
        var exporter = new ValidationDecorator(new BaseExporter());

        Assert.Throws<ArgumentException>(() => exporter.Export("  "));
    }

    [Fact]
    public void ValidationDecorator_ValidPayload_ReturnsNonEmptyBytes()
    {
        var exporter = new ValidationDecorator(new BaseExporter());

        var result = exporter.Export("data");

        Assert.NotEmpty(result);
    }

    [Fact]
    public void EncryptionDecorator_PayloadIsBase64Encoded()
    {
        var inner = new SpyExporter();
        var decorator = new EncryptionDecorator(inner);

        decorator.Export("secret");

        // EncryptionDecorator converts to Base64 before delegating
        var expectedBase64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("secret"));
        Assert.Equal(expectedBase64, inner.LastPayload);
    }

    [Fact]
    public void AuditDecorator_DelegatesToInner()
    {
        var inner = new SpyExporter();
        var decorator = new AuditDecorator(inner);

        decorator.Export("data");

        Assert.Equal("data", inner.LastPayload);
    }

    [Fact]
    public void FullChain_DoesNotThrowForValidPayload()
    {
        var chain = new ValidationDecorator(
            new AuditDecorator(
                new EncryptionDecorator(
                    new BaseExporter())));

        var ex = Record.Exception(() => chain.Export("payload"));

        Assert.Null(ex);
    }

    private sealed class SpyExporter : IReportExporter
    {
        public string LastPayload { get; private set; } = string.Empty;

        public byte[] Export(string payload)
        {
            LastPayload = payload;
            return System.Text.Encoding.UTF8.GetBytes(payload);
        }
    }
}
