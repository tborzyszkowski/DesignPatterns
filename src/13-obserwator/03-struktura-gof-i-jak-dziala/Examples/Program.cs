// ============================================================
// Temat 03: Struktura GoF — Push Model vs Pull Model
// ============================================================
// Demonstruje:
//   1. Model Push: Subject wysyła dane w parametrach Update()
//   2. Model Pull: Observer pobiera dane ze Subject
//   3. Porównanie zachowania obu modeli
// ============================================================

Console.WriteLine("=== MODEL PUSH: Subject wysyła dane przez parametry ===");
Console.WriteLine();

var pushStation = new PushWeatherStation();

pushStation.Subscribe(new PushCurrentDisplay());
pushStation.Subscribe(new PushStatisticsDisplay());

pushStation.SetMeasurements(22.5f, 65f, 1013f);
Console.WriteLine();
pushStation.SetMeasurements(18.0f, 72f, 1008f);

Console.WriteLine();
Console.WriteLine("=== MODEL PULL: Observer pobiera dane ze Subject ===");
Console.WriteLine();

var pullStation = new PullWeatherStation();

pullStation.Subscribe(new PullTemperatureDisplay());   // potrzebuje tylko temperatury
pullStation.Subscribe(new PullHumidityDisplay());      // potrzebuje tylko wilgotności
pullStation.Subscribe(new PullFullDisplay());          // potrzebuje wszystkiego

pullStation.SetMeasurements(22.5f, 65f, 1013f);
Console.WriteLine();
pullStation.SetMeasurements(18.0f, 72f, 1008f);

// ============================================================
// PUSH MODEL
// ============================================================

// Observer interfejs — parametry niosą dane
internal interface IPushObserver
{
    void Update(float temperature, float humidity, float pressure);
}

internal sealed class PushWeatherStation
{
    private readonly List<IPushObserver> _observers = new();

    public void Subscribe(IPushObserver obs) => _observers.Add(obs);
    public void Unsubscribe(IPushObserver obs) => _observers.Remove(obs);

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        // Push: wysyłamy snapshot danych w momencie notyfikacji
        foreach (IPushObserver obs in _observers.ToList())
            obs.Update(temperature, humidity, pressure);
    }
}

internal sealed class PushCurrentDisplay : IPushObserver
{
    public void Update(float temperature, float humidity, float pressure)
        => Console.WriteLine($"  [Push-Current] Temp: {temperature}°C  Hum: {humidity}%  Press: {pressure} hPa");
}

internal sealed class PushStatisticsDisplay : IPushObserver
{
    private float _minTemp = float.MaxValue, _maxTemp = float.MinValue, _sumTemp;
    private int _count;

    public void Update(float temperature, float humidity, float pressure)
    {
        _sumTemp += temperature;
        _count++;
        _minTemp = MathF.Min(_minTemp, temperature);
        _maxTemp = MathF.Max(_maxTemp, temperature);
        Console.WriteLine($"  [Push-Stats] Min: {_minTemp}°C  Max: {_maxTemp}°C  Avg: {_sumTemp / _count:F1}°C");
    }
}

// ============================================================
// PULL MODEL
// ============================================================

// Interfejs danych — Observer zna tylko ten interfejs, nie konkretny Subject
internal interface IWeatherData
{
    float Temperature { get; }
    float Humidity { get; }
    float Pressure { get; }
}

// Observer interfejs — dostaje referencję do źródła danych
internal interface IPullObserver
{
    void Update(IWeatherData source);
}

internal sealed class PullWeatherStation : IWeatherData
{
    private readonly List<IPullObserver> _observers = new();

    // IWeatherData — Observer może pobrać co chce
    public float Temperature { get; private set; }
    public float Humidity { get; private set; }
    public float Pressure { get; private set; }

    public void Subscribe(IPullObserver obs) => _observers.Add(obs);
    public void Unsubscribe(IPullObserver obs) => _observers.Remove(obs);

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;

        // Pull: wysyłamy tylko siebie (referencję do IWeatherData)
        foreach (IPullObserver obs in _observers.ToList())
            obs.Update(this);
    }
}

// Observer A — potrzebuje tylko temperatury
internal sealed class PullTemperatureDisplay : IPullObserver
{
    public void Update(IWeatherData source)
        => Console.WriteLine($"  [Pull-TempOnly] Temperatura: {source.Temperature}°C");
}

// Observer B — potrzebuje tylko wilgotności
internal sealed class PullHumidityDisplay : IPullObserver
{
    public void Update(IWeatherData source)
        => Console.WriteLine($"  [Pull-HumOnly] Wilgotność: {source.Humidity}%");
}

// Observer C — potrzebuje wszystkich danych
internal sealed class PullFullDisplay : IPullObserver
{
    public void Update(IWeatherData source)
        => Console.WriteLine($"  [Pull-Full] {source.Temperature}°C / {source.Humidity}% / {source.Pressure} hPa");
}
