namespace Examples;

public interface IAircraft
{
	void TakeOff(int targetAltitudeMeters);
	void Land();
	string GetFlightTelemetry();
}

public interface ISeacraft
{
	void Dive(int targetDepthMeters);
	void Surface();
	string GetSeaTelemetry();
}

public sealed class InvalidVehicleStateException : Exception
{
	public InvalidVehicleStateException(string message) : base(message)
	{
	}
}

public sealed class Seabird : IAircraft, ISeacraft
{
	private enum Mode
	{
		Docked,
		InAir,
		AtSea,
		Submerged
	}

	private Mode _mode = Mode.Docked;
	private int _altitudeMeters;
	private int _depthMeters;

	public void TakeOff(int targetAltitudeMeters)
	{
		if (targetAltitudeMeters <= 0)
		{
			throw new InvalidVehicleStateException("Docelowa wysokosc lotu musi byc dodatnia.");
		}

		if (_mode is Mode.Submerged)
		{
			throw new InvalidVehicleStateException("Nie mozna wystartowac bedac pod woda.");
		}

		_mode = Mode.InAir;
		_altitudeMeters = targetAltitudeMeters;
		_depthMeters = 0;
	}

	public void Land()
	{
		if (_mode is not Mode.InAir)
		{
			throw new InvalidVehicleStateException("Ladowanie jest dozwolone tylko w trybie lotu.");
		}

		_mode = Mode.Docked;
		_altitudeMeters = 0;
	}

	public string GetFlightTelemetry()
	{
		return _mode switch
		{
			Mode.InAir => $"AIR | altitude={_altitudeMeters}m | speed=220km/h",
			Mode.Docked => "DOCKED | gotowy do startu",
			Mode.AtSea => "SEA | najpierw wroc do portu, aby wystartowac",
			Mode.Submerged => "SUBMERGED | wynurz sie przed lotem",
			_ => "UNKNOWN"
		};
	}

	public void Dive(int targetDepthMeters)
	{
		if (targetDepthMeters <= 0)
		{
			throw new InvalidVehicleStateException("Docelowa glebokosc musi byc dodatnia.");
		}

		if (_mode is Mode.InAir)
		{
			throw new InvalidVehicleStateException("Nie mozna zanurkowac podczas lotu. Najpierw wyladuj.");
		}

		_mode = Mode.Submerged;
		_depthMeters = targetDepthMeters;
		_altitudeMeters = 0;
	}

	public void Surface()
	{
		if (_mode is not Mode.Submerged)
		{
			throw new InvalidVehicleStateException("Wynurzenie jest dozwolone tylko po zanurzeniu.");
		}

		_mode = Mode.AtSea;
		_depthMeters = 0;
	}

	public string GetSeaTelemetry()
	{
		return _mode switch
		{
			Mode.Submerged => $"SUBMERGED | depth={_depthMeters}m | speed=22kn",
			Mode.AtSea => "SEA | sailing speed=35kn",
			Mode.Docked => "DOCKED | gotowy do rejsu",
			Mode.InAir => "AIR | najpierw wyladuj, aby plywac",
			_ => "UNKNOWN"
		};
	}
}

public static class Program
{
	public static void Main()
	{
		var seabird = new Seabird();

		IAircraft aircraftView = seabird;
		ISeacraft seacraftView = seabird;

		Console.WriteLine("=== 06. Two Way Adapter ===");
		Console.WriteLine($"Start (air view): {aircraftView.GetFlightTelemetry()}");
		Console.WriteLine($"Start (sea view): {seacraftView.GetSeaTelemetry()}");

		aircraftView.TakeOff(1200);
		Console.WriteLine($"Po starcie: {aircraftView.GetFlightTelemetry()}");

		aircraftView.Land();
		seacraftView.Dive(80);
		Console.WriteLine($"Po zanurzeniu: {seacraftView.GetSeaTelemetry()}");

		seacraftView.Surface();
		Console.WriteLine($"Po wynurzeniu: {seacraftView.GetSeaTelemetry()}");

		try
		{
			aircraftView.Land();
		}
		catch (InvalidVehicleStateException ex)
		{
			Console.WriteLine($"[Walidacja] {ex.Message}");
		}
	}
}
