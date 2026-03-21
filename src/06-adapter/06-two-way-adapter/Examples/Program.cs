namespace Examples;

public interface IAircraft
{
	string Fly();
}

public interface ISeacraft
{
	string Sail();
}

public sealed class Seabird : IAircraft, ISeacraft
{
	public string Fly() => "Seabird flying at 120 km/h";

	public string Sail() => "Seabird sailing at 35 knots";
}

public static class Program
{
	public static void Main()
	{
		var seabird = new Seabird();

		IAircraft aircraftView = seabird;
		ISeacraft seacraftView = seabird;

		Console.WriteLine(aircraftView.Fly());
		Console.WriteLine(seacraftView.Sail());
	}
}
