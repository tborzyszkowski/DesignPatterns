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

public sealed class AdapterRegistry
{
	private readonly Dictionary<string, IMessageAdapter> _map;

	public AdapterRegistry(IEnumerable<IMessageAdapter> adapters)
	{
		_map = adapters.ToDictionary(x => x.SourceType, StringComparer.OrdinalIgnoreCase);
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
		var registry = new AdapterRegistry(new IMessageAdapter[]
		{
			new JsonAdapter(),
			new XmlAdapter()
		});

		var json = registry.Resolve("json").Adapt("{ \"name\": \"Anna\" }");
		var xml = registry.Resolve("xml").Adapt("<user name='Anna' />");

		Console.WriteLine(json);
		Console.WriteLine(xml);
	}
}
