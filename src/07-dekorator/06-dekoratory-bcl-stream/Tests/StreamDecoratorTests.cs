using Examples;
using Xunit;

public class StreamDecoratorTests
{
    [Fact]
    public void Compress_ThenDecompress_RoundTrips()
    {
        var original = "Dekorator w .NET: Stream -> BufferedStream -> GZipStream";

        var compressed = Program.Compress(original);
        var restored = Program.Decompress(compressed);

        Assert.Equal(original, restored);
    }

    [Fact]
    public void Compress_ProducesFewerBytesThanOriginal()
    {
        var original = new string('a', 500);

        var compressed = Program.Compress(original);

        Assert.True(compressed.Length < System.Text.Encoding.UTF8.GetByteCount(original));
    }

    [Fact]
    public void Compress_EmptyString_RoundTrips()
    {
        var compressed = Program.Compress(string.Empty);
        var restored = Program.Decompress(compressed);

        Assert.Equal(string.Empty, restored);
    }

    [Fact]
    public void Compress_ReturnsNonEmptyBytes()
    {
        var compressed = Program.Compress("hello");

        Assert.NotEmpty(compressed);
    }
}
