namespace Examples;

public sealed record IntegrationOption(
	string Name,
	double InitialCostPoints,
	double MonthlyMaintenancePoints,
	double SemanticRiskFactor,
	string Notes);

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("=== 05. Adapter vs alternatywy ===");

		var horizonMonths = 12;
		Console.WriteLine($"Horyzont analizy: {horizonMonths} miesiecy");

		var options = new[]
		{
			new IntegrationOption(
				"Adapter",
				InitialCostPoints: 8,
				MonthlyMaintenancePoints: 2.5,
				SemanticRiskFactor: 1.30,
				"Najlepszy przy cudzym API i migracji etapowej"),
			new IntegrationOption(
				"Facade",
				InitialCostPoints: 6,
				MonthlyMaintenancePoints: 2.0,
				SemanticRiskFactor: 1.10,
				"Dobre przy uproszczeniu, bez ciezkiej translacji semantyki"),
			new IntegrationOption(
				"Refactor",
				InitialCostPoints: 14,
				MonthlyMaintenancePoints: 0.9,
				SemanticRiskFactor: 1.00,
				"Najczystsza opcja, gdy obie strony sa pod kontrola")
		};

		Console.WriteLine();
		Console.WriteLine("Opcje:");
		foreach (var option in options)
		{
			var total = EstimateTotalCost(option, horizonMonths);
			Console.WriteLine(
				$"- {option.Name,-8} initial={option.InitialCostPoints,5:0.0} " +
				$"monthly={option.MonthlyMaintenancePoints,4:0.0} " +
				$"risk={option.SemanticRiskFactor,4:0.00} " +
				$"total={total,6:0.0} | {option.Notes}");
		}

		var best = options
			.OrderBy(o => EstimateTotalCost(o, horizonMonths))
			.First();

		Console.WriteLine();
		Console.WriteLine($"Rekomendacja: {best.Name}");
		Console.WriteLine("Uwagi:");
		Console.WriteLine("- adapter wybieraj, gdy koszt zmiany dostawcy API jest wysoki,");
		Console.WriteLine("- facade wybieraj, gdy potrzebujesz prostszego wejscia do stabilnego API,");
		Console.WriteLine("- refactor wybieraj, gdy masz kontrole nad obiema stronami integracji.");
	}

	internal static double EstimateTotalCost(IntegrationOption option, int months)
	{
		var baseline = option.InitialCostPoints + (option.MonthlyMaintenancePoints * months);
		return baseline * option.SemanticRiskFactor;
	}
}
