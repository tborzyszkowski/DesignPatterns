using System.Diagnostics;

namespace Examples;

public readonly record struct DecisionMetrics(long NoAdapterMs, long AdapterMs);

public static class Benchmark
{
	public static DecisionMetrics Run(int operations, int mapCostMs)
	{
		var noAdapterMs = Measure(operations, 0);
		var adapterMs = Measure(operations, mapCostMs);
		return new DecisionMetrics(noAdapterMs, adapterMs);
	}

	private static long Measure(int operations, int mapCostMs)
	{
		var sw = Stopwatch.StartNew();
		Parallel.For(0, operations, _ =>
		{
			if (mapCostMs > 0)
			{
				Thread.Sleep(mapCostMs);
			}

			Thread.SpinWait(8_000);
		});
		sw.Stop();
		return sw.ElapsedMilliseconds;
	}
}

public static class Program
{
	public static void Main()
	{
		Console.WriteLine("=== 02. Kiedy stosować Adapter ===");

		var metrics = Benchmark.Run(operations: 1000, mapCostMs: 2);
		Console.WriteLine($"NoAdapter={metrics.NoAdapterMs} ms, Adapter={metrics.AdapterMs} ms");
		Console.WriteLine("Interpretacja: gdy koszt mapowania rośnie szybciej niż zysk izolacji kontraktu, adapter może być nieopłacalny.");
	}
}
