namespace Examples;

public interface ITarget
{
	string Request(string payload);
}

public sealed class Adaptee
{
	public string SpecificRequest(string raw)
	{
		return $"legacy::{raw}";
	}
}

public sealed class LegacyAdapter : ITarget
{
	private readonly Adaptee _adaptee;

	public LegacyAdapter(Adaptee adaptee)
	{
		_adaptee = adaptee;
	}

	public string Request(string payload)
	{
		var legacy = _adaptee.SpecificRequest(payload);
		return legacy.Replace("legacy::", "mapped::", StringComparison.Ordinal);
	}
}

public static class Program
{
	public static void Main()
	{
		ITarget target = new LegacyAdapter(new Adaptee());
		Console.WriteLine(target.Request("demo"));
	}
}
