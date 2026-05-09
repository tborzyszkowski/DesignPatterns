// =============================================================
// Stream abstractions + konkretne backendy — Most w System.IO
// =============================================================
// Abstrakcja:  System.IO.Stream (klasa abstrakcyjna)
// Implementory: FileStream, MemoryStream, NetworkStream, ...
// Most+Dekorator: GZipStream, BufferedStream (owijają dowolny Stream)
// =============================================================

using System.IO.Compression;
using System.Text.Json;

// ---- Funkcja niezależna od backendu ---------------------------
// Zależy TYLKO od Stream — nie wie nic o FileStream, MemoryStream itp.
static async Task SaveJsonAsync(Stream destination, object data, string label)
{
    await JsonSerializer.SerializeAsync(destination, data);
    await destination.FlushAsync();
    Console.WriteLine($"[{label}] zapisano {destination.Length} bajtów");
}

var payload = new { Id = 1, Name = "Widget", Price = 9.99m };

// ---- Backend A: plik na dysku (FileStream) --------------------
await using (var fileStream = new FileStream("dane.json", FileMode.Create))
    await SaveJsonAsync(fileStream, payload, "FileStream");

// ---- Backend B: pamięć (MemoryStream) -------------------------
using var memStream = new MemoryStream();
await JsonSerializer.SerializeAsync(memStream, payload);
Console.WriteLine($"[MemoryStream] {memStream.Length} bajtów w pamięci");

// ---- Backend C: plik + kompresja GZip (Most + Dekorator) ------
await using (var compressedFile = new FileStream("dane.json.gz", FileMode.Create))
await using (var gzip = new GZipStream(compressedFile, CompressionMode.Compress))
    await JsonSerializer.SerializeAsync(gzip, payload);

var rawSize = new FileInfo("dane.json").Length;
var gzipSize = new FileInfo("dane.json.gz").Length;
Console.WriteLine($"[GZipStream] {rawSize} B → {gzipSize} B (kompresja)");

// ---- Backend D: własny CloudStream ----------------------------
await using (var cloud = new CloudStream("https://storage.example.com/blob/dane.json"))
    await JsonSerializer.SerializeAsync(cloud, payload);

Console.WriteLine("\nTa sama metoda SaveJsonAsync działała z 4 różnymi backendami.");

// Sprzątanie plików testowych
File.Delete("dane.json");
File.Delete("dane.json.gz");

// =============================================================
// Własny Concrete Implementor — rozszerzenie bez zmiany kodu
// =============================================================
class CloudStream(string blobUrl) : Stream
{
    private long _written = 0;

    public override bool CanRead => false;
    public override bool CanSeek => true;   // potrzebne przez JsonSerializer do Length
    public override bool CanWrite => true;
    public override long Length => _written;
    public override long Position { get => _written; set => throw new NotSupportedException(); }

    public override void Flush() => Console.WriteLine($"[CloudStream] Flush → {blobUrl}");

    public override void Write(byte[] buffer, int offset, int count)
    {
        _written += count;
        Console.WriteLine($"[CloudStream] Write {count} bajtów → {blobUrl}");
    }

    public override int Read(byte[] buffer, int offset, int count) =>
        throw new NotSupportedException();

    public override long Seek(long offset, SeekOrigin origin) =>
        throw new NotSupportedException();

    public override void SetLength(long value) =>
        throw new NotSupportedException();
}
