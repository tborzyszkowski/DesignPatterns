using System.IO.Compression;
using System.Text;

namespace Examples;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== 06. Dekoratory w BCL Stream ===");

        var original = "Dekorator w .NET: Stream -> BufferedStream -> GZipStream";
        var compressed = Compress(original);
        var restored = Decompress(compressed);

        Console.WriteLine($"Original length : {Encoding.UTF8.GetByteCount(original)} bytes");
        Console.WriteLine($"Compressed size : {compressed.Length} bytes");
        Console.WriteLine($"Restored text   : {restored}");
    }

    private static byte[] Compress(string text)
    {
        using var output = new MemoryStream();
        using (var buffered = new BufferedStream(output, 4096))
        using (var gzip = new GZipStream(buffered, CompressionLevel.Optimal, leaveOpen: true))
        using (var writer = new StreamWriter(gzip, Encoding.UTF8))
        {
            writer.Write(text);
        }
        return output.ToArray();
    }

    private static string Decompress(byte[] payload)
    {
        using var input = new MemoryStream(payload);
        using var buffered = new BufferedStream(input, 4096);
        using var gzip = new GZipStream(buffered, CompressionMode.Decompress);
        using var reader = new StreamReader(gzip, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
