using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

const int operations = 200;
var initCostsMs = new[] { 1, 3, 8, 20 };

Console.WriteLine("=== 02. Kiedy stosować Object Pool ===");
Console.WriteLine($"Operacje: {operations}\n");

foreach (var simulatedInitMs in initCostsMs)
{
	var noPool = MeasureNoPool(operations, simulatedInitMs);
	var pooled = MeasureWithPool(operations, simulatedInitMs);

	Console.WriteLine($"Init = {simulatedInitMs,2} ms | new = {noPool,5} ms | pool = {pooled,5} ms | delta = {noPool - pooled,5} ms");
}

Console.WriteLine("\nInterpretacja:");
Console.WriteLine("- przy niskim koszcie inicjalizacji zysk z puli bywa marginalny lub ujemny,");
Console.WriteLine("- im droższa inicjalizacja, tym większa szansa, że pool się opłaci.");

static long MeasureNoPool(int operations, int initCostMs)
{
	var sw = Stopwatch.StartNew();

	Parallel.For(0, operations, _ =>
	{
		var resource = new SimulatedResource(initCostMs);
		resource.Execute();
	});

	sw.Stop();
	return sw.ElapsedMilliseconds;
}

static long MeasureWithPool(int operations, int initCostMs)
{
	var sw = Stopwatch.StartNew();
	using var pool = new AsyncCapPool<SimulatedResource>(
		create: () => new SimulatedResource(initCostMs),
		reset: resource => resource.Reset(),
		capacity: Environment.ProcessorCount);

	Parallel.For(0, operations, _ =>
	{
		var resource = pool.Acquire();
		try
		{
			resource.Execute();
		}
		finally
		{
			pool.Release(resource);
		}
	});

	sw.Stop();
	return sw.ElapsedMilliseconds;
}

sealed class SimulatedResource
{
	private readonly int _initCostMs;
	private int _state;

	public SimulatedResource(int initCostMs)
	{
		_initCostMs = initCostMs;
		Thread.Sleep(_initCostMs);
	}

	public void Execute()
	{
		_state++;
		Thread.SpinWait(25_000);
	}

	public void Reset()
	{
		_state = 0;
	}
}

sealed class AsyncCapPool<T> : IDisposable
{
	private readonly ConcurrentQueue<T> _items = new();
	private readonly Func<T> _create;
	private readonly Action<T> _reset;
	private readonly SemaphoreSlim _gate;

	public AsyncCapPool(Func<T> create, Action<T> reset, int capacity)
	{
		_create = create;
		_reset = reset;
		_gate = new SemaphoreSlim(capacity, capacity);

		for (var i = 0; i < capacity; i++)
		{
			_items.Enqueue(_create());
		}
	}

	public T Acquire()
	{
		_gate.Wait();
		if (_items.TryDequeue(out var item))
		{
			return item;
		}

		throw new InvalidOperationException("Pool inconsistency: no item after gate acquire.");
	}

	public void Release(T item)
	{
		_reset(item);
		_items.Enqueue(item);
		_gate.Release();
	}

	public void Dispose()
	{
		_gate.Dispose();
	}
}
