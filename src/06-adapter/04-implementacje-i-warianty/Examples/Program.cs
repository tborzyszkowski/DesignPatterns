namespace Examples;

public interface IFileExporter
{
	string Export(string input);
}

public class LegacyCsvService
{
	public virtual string SaveCsv(string data) => $"CSV::{data}";
}

public sealed class ObjectAdapter : IFileExporter
{
	private readonly LegacyCsvService _service;

	public ObjectAdapter(LegacyCsvService service)
	{
		_service = service;
	}

	public string Export(string input) => _service.SaveCsv(input);
}

public sealed class ClassAdapter : LegacyCsvService, IFileExporter
{
	public string Export(string input) => SaveCsv(input);
}

public static class Program
{
	public static void Main()
	{
		IFileExporter objectAdapter = new ObjectAdapter(new LegacyCsvService());
		IFileExporter classAdapter = new ClassAdapter();

		Console.WriteLine($"ObjectAdapter: {objectAdapter.Export("report")}");
		Console.WriteLine($"ClassAdapter : {classAdapter.Export("report")}");
	}
}
