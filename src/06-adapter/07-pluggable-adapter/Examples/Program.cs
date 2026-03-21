namespace Examples;

public interface IMessageAdapter
{
	string SourceType { get; }
	string Adapt(string input);
}

public sealed class JsonAdapter : IMessageAdapter
{
	public string SourceType => "json";

	public string Adapt(string input) => $"JSON_ADAPTED::{input}";
}

public sealed class XmlAdapter : IMessageAdapter
{
	public string SourceType => "xml";

	public string Adapt(string input) => $"XML_ADAPTED::{input}";
}

public sealed class CsvAdapter : IMessageAdapter
{
	public string SourceType => "csv";

	public string Adapt(string input)
	{
		var columns = input.Split(',', StringSplitOptions.TrimEntries);
		return $"CSV_ADAPTED::[{string.Join(" | ", columns)}]";
	}
}

public sealed class AdapterRegistry
{
	private readonly Dictionary<string, IMessageAdapter> _map =
		new(StringComparer.OrdinalIgnoreCase);

	public AdapterRegistry(IEnumerable<IMessageAdapter> adapters)
	{
		foreach (var adapter in adapters)
		{
			Register(adapter);
		}
	}

	public void Register(IMessageAdapter adapter)
	{
		if (string.IsNullOrWhiteSpace(adapter.SourceType))
		{
			throw new ArgumentException("Adapter SourceType nie moze byc pusty.", nameof(adapter));
		}

		if (_map.ContainsKey(adapter.SourceType))
		{
			throw new InvalidOperationException($"Adapter '{adapter.SourceType}' jest juz zarejestrowany.");
		}

		_map.Add(adapter.SourceType, adapter);
	}

	public bool TryResolve(string sourceType, out IMessageAdapter? adapter)
	{
		return _map.TryGetValue(sourceType, out adapter);
	}

	public IEnumerable<string> RegisteredTypes()
	{
		return _map.Keys.OrderBy(x => x, StringComparer.OrdinalIgnoreCase);
	}

	public IMessageAdapter Resolve(string sourceType)
	{
		if (_map.TryGetValue(sourceType, out var adapter))
		{
			return adapter;
		}

		throw new InvalidOperationException($"No adapter registered for '{sourceType}'.");
	}
}

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("=== 07. Pluggable Adapter ===");

		var registry = new AdapterRegistry(new IMessageAdapter[]
		{
			new JsonAdapter(),
			new XmlAdapter()
		});

		Console.WriteLine("Poczatkowo zarejestrowane adaptery:");
		Console.WriteLine(string.Join(", ", registry.RegisteredTypes()));

		var json = registry.Resolve("json").Adapt("{ \"name\": \"Anna\" }");
		var xml = registry.Resolve("xml").Adapt("<user name='Anna' />");

		Console.WriteLine(json);
		Console.WriteLine(xml);

		registry.Register(new CsvAdapter());
		Console.WriteLine("Po dolaczeniu pluginu CSV:");
		Console.WriteLine(string.Join(", ", registry.RegisteredTypes()));

		if (registry.TryResolve("csv", out var csvAdapter) && csvAdapter is not null)
		{
			Console.WriteLine(csvAdapter.Adapt("Anna,Nowak,Premium"));
		}

		try
		{
			registry.Resolve("yaml");
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine($"[Fallback/blad] {ex.Message}");
		}
	}
}
