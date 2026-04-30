// ============================================================
// Temat 04: Trzy typy implementacji wzorca Obserwator w C#
// ============================================================
// Ten sam scenariusz (czujnik temperatury) zaimplementowany
// trzema sposobami:
//   1. Ręczny interfejs IObserver
//   2. Zdarzenia C# (event EventHandler<T>)
//   3. IObserver<T> z BCL (.NET Standard / .NET 9)
// ============================================================

// ----------------------------------------------------------
// WARIANT 1: Ręczny interfejs
// ----------------------------------------------------------
Console.WriteLine("=== WARIANT 1: Ręczny interfejs ===");
Console.WriteLine();

var sensor1 = new InterfaceSensor("Sensor-1");

var display1a = new InterfaceDisplay("Monitor A");
var display1b = new InterfaceDisplay("Monitor B");
var logger1 = new InterfaceLogger();

sensor1.Subscribe(display1a);
sensor1.Subscribe(display1b);
sensor1.Subscribe(logger1);

sensor1.SetTemperature(22.5f);
Console.WriteLine();
sensor1.Unsubscribe(display1b);
sensor1.SetTemperature(30.0f);

Console.WriteLine();

// ----------------------------------------------------------
// WARIANT 2: Zdarzenia C#
// ----------------------------------------------------------
Console.WriteLine("=== WARIANT 2: Zdarzenia C# (event EventHandler<T>) ===");
Console.WriteLine();

var sensor2 = new EventSensor("Sensor-2");

EventHandler<TemperatureChangedEventArgs> handlerA = (sender, e) =>
    Console.WriteLine($"  [EventHandler-A] Od {((EventSensor)sender!).Name}: {e.Temperature}°C");

EventHandler<TemperatureChangedEventArgs> handlerB = (sender, e) =>
    Console.WriteLine($"  [EventHandler-B] Otrzymano zdarzenie: {e.Temperature}°C");

sensor2.TemperatureChanged += handlerA;
sensor2.TemperatureChanged += handlerB;

sensor2.SetTemperature(19.0f);
Console.WriteLine();

sensor2.TemperatureChanged -= handlerB;   // bezpieczne wypisanie
sensor2.SetTemperature(25.5f);

Console.WriteLine();

// ----------------------------------------------------------
// WARIANT 3: IObserver<T> z BCL
// ----------------------------------------------------------
Console.WriteLine("=== WARIANT 3: IObserver<T> / IObservable<T> (BCL) ===");
Console.WriteLine();

var sensor3 = new ObservableSensor("Sensor-3");

// Subskrypcja — Subscribe() zwraca IDisposable
IDisposable sub3a = sensor3.Subscribe(new BclDisplay("BCL-Display-A"));
IDisposable sub3b = sensor3.Subscribe(new BclDisplay("BCL-Display-B"));

sensor3.PublishTemperature(18.0f);
Console.WriteLine();

sub3b.Dispose();   // wypisanie obserwatora B — bezpieczne przez IDisposable
Console.WriteLine("  [Wypisano BCL-Display-B]");

sensor3.PublishTemperature(21.0f);
sensor3.Complete();   // informuje obserwatorów że strumień się skończył

// ============================================================
// WARIANT 1: Ręczny interfejs — implementacja
// ============================================================

internal interface ITempObserver
{
    void OnTemperatureChanged(string sensorName, float temperature);
}

internal sealed class InterfaceSensor(string name)
{
    private readonly List<ITempObserver> _observers = new();

    public string Name => name;

    public void Subscribe(ITempObserver obs) => _observers.Add(obs);
    public void Unsubscribe(ITempObserver obs) => _observers.Remove(obs);

    public void SetTemperature(float temperature)
    {
        Console.WriteLine($"  [{Name}] Nowa temperatura: {temperature}°C");
        foreach (ITempObserver obs in _observers.ToList())
            obs.OnTemperatureChanged(Name, temperature);
    }
}

internal sealed class InterfaceDisplay(string displayName) : ITempObserver
{
    public void OnTemperatureChanged(string sensorName, float temperature)
        => Console.WriteLine($"    [{displayName}] {sensorName}: {temperature}°C");
}

internal sealed class InterfaceLogger : ITempObserver
{
    public void OnTemperatureChanged(string sensorName, float temperature)
        => Console.WriteLine($"    [LOG] {DateTime.Now:HH:mm:ss} | {sensorName} | {temperature}°C");
}

// ============================================================
// WARIANT 2: Zdarzenia C# — implementacja
// ============================================================

internal sealed class TemperatureChangedEventArgs(float temperature) : EventArgs
{
    public float Temperature => temperature;
}

internal sealed class EventSensor(string name)
{
    public string Name => name;
    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

    public void SetTemperature(float temperature)
    {
        Console.WriteLine($"  [{Name}] Nowa temperatura: {temperature}°C");
        TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(temperature));
    }
}

// ============================================================
// WARIANT 3: IObserver<T> / IObservable<T> — BCL implementacja
// ============================================================

internal sealed record TemperatureReading(string SensorName, float Temperature, DateTimeOffset Timestamp);

// Własna implementacja IObservable<T> bez Rx.NET
internal sealed class ObservableSensor(string name) : IObservable<TemperatureReading>
{
    private readonly List<IObserver<TemperatureReading>> _observers = new();

    public string Name => name;

    public IDisposable Subscribe(IObserver<TemperatureReading> observer)
    {
        _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    public void PublishTemperature(float temperature)
    {
        var reading = new TemperatureReading(Name, temperature, DateTimeOffset.Now);
        Console.WriteLine($"  [{Name}] Publikuję: {temperature}°C");
        foreach (IObserver<TemperatureReading> obs in _observers.ToList())
            obs.OnNext(reading);
    }

    public void Complete()
    {
        foreach (IObserver<TemperatureReading> obs in _observers.ToList())
            obs.OnCompleted();
        _observers.Clear();
    }

    // Wypisanie przez Dispose — bezpieczne, nie wymaga wywołania -= 
    private sealed class Unsubscriber(List<IObserver<TemperatureReading>> observers,
        IObserver<TemperatureReading> observer) : IDisposable
    {
        public void Dispose() => observers.Remove(observer);
    }
}

internal sealed class BclDisplay(string displayName) : IObserver<TemperatureReading>
{
    public void OnNext(TemperatureReading value)
        => Console.WriteLine($"    [{displayName}] {value.SensorName}: {value.Temperature}°C @ {value.Timestamp:HH:mm:ss}");

    public void OnError(Exception error)
        => Console.WriteLine($"    [{displayName}] Błąd: {error.Message}");

    public void OnCompleted()
        => Console.WriteLine($"    [{displayName}] Strumień zakończony.");
}
