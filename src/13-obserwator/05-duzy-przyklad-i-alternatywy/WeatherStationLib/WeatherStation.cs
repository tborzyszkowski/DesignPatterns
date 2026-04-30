namespace Observer.WeatherStation;

// ============================================================
// Dane pogodowe — przekazywane przez Obserwatora (Push)
// ============================================================

public sealed record WeatherData(float Temperature, float Humidity, float Pressure);

// ============================================================
// Interfejs obserwatora
// ============================================================

public interface IWeatherObserver
{
    void Update(WeatherData data);
}

// ============================================================
// Subject: WeatherStation
// ============================================================

public sealed class WeatherStation
{
    private readonly List<IWeatherObserver> _observers = new();

    public WeatherData? LastReading { get; private set; }

    public void Subscribe(IWeatherObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(IWeatherObserver observer)
        => _observers.Remove(observer);

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        LastReading = new WeatherData(temperature, humidity, pressure);
        NotifyAll(LastReading);
    }

    private void NotifyAll(WeatherData data)
    {
        // Kopia listy — bezpieczna gdy obserwator wypisuje się w Update()
        foreach (IWeatherObserver obs in _observers.ToList())
            obs.Update(data);
    }
}

// ============================================================
// Wyświetlacz bieżących warunków
// ============================================================

public sealed class CurrentConditionsDisplay(string name) : IWeatherObserver
{
    private WeatherData? _last;

    public void Update(WeatherData data)
    {
        _last = data;
        Console.WriteLine($"  [{name}] Temp: {data.Temperature:F1}°C  " +
                          $"Wilg: {data.Humidity:F0}%  Ciśn: {data.Pressure:F1} hPa");
    }
}

// ============================================================
// Wyświetlacz statystyk
// ============================================================

public sealed class StatisticsDisplay : IWeatherObserver
{
    private readonly List<float> _temps = new();

    public float Average => _temps.Count == 0 ? 0 : _temps.Average();
    public float Min => _temps.Count == 0 ? 0 : _temps.Min();
    public float Max => _temps.Count == 0 ? 0 : _temps.Max();

    public void Update(WeatherData data)
    {
        _temps.Add(data.Temperature);
        Console.WriteLine($"  [Statystyki] Min: {Min:F1}°C  Max: {Max:F1}°C  Śr: {Average:F1}°C  " +
                          $"(próbki: {_temps.Count})");
    }
}

// ============================================================
// Wyświetlacz prognozy (na podstawie zmiany ciśnienia)
// ============================================================

public sealed class ForecastDisplay : IWeatherObserver
{
    private float _lastPressure;
    private bool _hasPrevious;

    public void Update(WeatherData data)
    {
        string forecast;

        if (!_hasPrevious)
        {
            forecast = "Brak danych do prognozy";
        }
        else if (data.Pressure > _lastPressure)
        {
            forecast = "Poprawa pogody — rośnie ciśnienie";
        }
        else if (data.Pressure < _lastPressure)
        {
            forecast = "Możliwe opady — spada ciśnienie";
        }
        else
        {
            forecast = "Bez zmian";
        }

        _lastPressure = data.Pressure;
        _hasPrevious = true;

        Console.WriteLine($"  [Prognoza] {forecast}  (ciśnienie: {data.Pressure:F1} hPa)");
    }
}

// ============================================================
// Wyświetlacz indeksu ciepła (Heat Index)
// Wzór: uproszczona formuła NOAA (Head First Design Patterns, s. 68)
// ============================================================

public sealed class HeatIndexDisplay : IWeatherObserver
{
    public float LastHeatIndex { get; private set; }

    public void Update(WeatherData data)
    {
        LastHeatIndex = ComputeHeatIndex(data.Temperature, data.Humidity);
        Console.WriteLine($"  [Heat Index] {LastHeatIndex:F1}°C  " +
                          $"(temp: {data.Temperature:F1}°C, wilg: {data.Humidity:F0}%)");
    }

    private static float ComputeHeatIndex(float celsius, float humidity)
    {
        float t = celsius * 9f / 5f + 32f; // Celsius → Fahrenheit
        float h = humidity;

        float heatIndexF =
            16.923f
            + 0.185212f * t
            + 5.37941f * h
            - 0.100254f * t * h
            + 0.00941695f * (t * t)
            + 0.00728898f * (h * h)
            + 0.000345372f * (t * t * h)
            - 0.000814971f * (t * h * h)
            + 0.0000102102f * (t * t * h * h)
            - 0.000038646f * (t * t * t)
            + 0.0000291583f * (h * h * h)
            + 0.00000142721f * (t * t * t * h)
            + 0.000000197483f * (t * h * h * h)
            - 0.0000000218429f * (t * t * t * h * h)
            + 0.000000000843296f * (t * t * h * h * h)
            - 0.0000000000481975f * (t * t * t * h * h * h);

        return (heatIndexF - 32f) * 5f / 9f; // Fahrenheit → Celsius
    }
}
