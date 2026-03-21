using System.Collections.Concurrent;
using System.Diagnostics;

var pool = new SimpleObjectPool<ExpensiveResource>(
	factory: () => new ExpensiveResource(),
	reset: resource => resource.Reset(),
	maxRetained: 4);

Console.WriteLine("=== 01. Idea i kontekst: dlaczego pool? ===");
Console.WriteLine("Symulacja: 10 operacji na kosztownym zasobie.\n");

var swNoPool = Stopwatch.StartNew();
for (var i = 0; i < 10; i++)
{
	var resource = new ExpensiveResource();
	resource.Use();
}
swNoPool.Stop();

var swPool = Stopwatch.StartNew();
for (var i = 0; i < 10; i++)
{
	var resource = pool.Acquire();
	try
	{
		resource.Use();
	}
	finally
	{
		pool.Release(resource);
	}
}
swPool.Stop();

Console.WriteLine($"Bez puli: {swNoPool.ElapsedMilliseconds} ms");
Console.WriteLine($"Z pulą : {swPool.ElapsedMilliseconds} ms");

sealed class ExpensiveResource
{
	private byte[] _buffer = new byte[256 * 1024];

	public ExpensiveResource()
	{
		// Symulacja kosztownej inicjalizacji I/O lub dużego bufora.
		Thread.Sleep(35);
	}

	public void Use()
	{
		_buffer[0] = 1;
		Thread.Sleep(10);
	}

	public void Reset()
	{
		Array.Clear(_buffer, 0, _buffer.Length);
	}
}

sealed class SimpleObjectPool<T>
{
	private readonly ConcurrentBag<T> _items = new();
	private readonly Func<T> _factory;
	private readonly Action<T> _reset;
	private readonly int _maxRetained;
	private int _created;

	public SimpleObjectPool(Func<T> factory, Action<T> reset, int maxRetained)
	{
		_factory = factory;
		_reset = reset;
		_maxRetained = maxRetained;
	}

	public T Acquire()
	{
		if (_items.TryTake(out var item))
		{
			return item;
		}

		Interlocked.Increment(ref _created);
		return _factory();
	}

	public void Release(T item)
	{
		_reset(item);
		if (_items.Count >= _maxRetained)
		{
			return;
		}

		_items.Add(item);
	}
}
