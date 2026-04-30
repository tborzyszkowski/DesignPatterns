// ============================================================
// Temat 01: Idea i kontekst wzorca Obserwator
// ============================================================
// Demonstruje:
//   1. Naiwne podejście (tight coupling) — problem
//   2. Refaktoring do wzorca Obserwator — rozwiązanie
//   3. Dynamiczne subskrybowanie i wypisywanie
// ============================================================

Console.WriteLine("=== CZĘŚĆ 1: Naiwne podejście (tight coupling) ===");
Console.WriteLine();

var naiveStation = new NaiveWeatherStation();
naiveStation.SetMeasurements(22.5f, 65f);
naiveStation.SetMeasurements(19.0f, 70f);

Console.WriteLine();
Console.WriteLine("=== CZĘŚĆ 2: Wzorzec Obserwator (loose coupling) ===");
Console.WriteLine();

var station = new WeatherStation();

// Subskrypcja dynamiczna — żadna z tych klas nie jest znana WeatherStation
var currentDisplay = new CurrentConditionsDisplay("Ekran główny");
var statsDisplay = new StatisticsDisplay();
var mobileDisplay = new MobileAppDisplay();

station.Subscribe(currentDisplay);
station.Subscribe(statsDisplay);
station.Subscribe(mobileDisplay);

Console.WriteLine("-- Pomiar 1 (wszyscy subskrybenci aktywni) --");
station.SetMeasurements(22.5f, 65f);

Console.WriteLine();
Console.WriteLine("-- Odsubskrybowanie ekranu głównego --");
station.Unsubscribe(currentDisplay);

Console.WriteLine();
Console.WriteLine("-- Pomiar 2 (tylko StatisticsDisplay i MobileAppDisplay) --");
station.SetMeasurements(19.0f, 70f);

Console.WriteLine();
Console.WriteLine($"StatisticsDisplay: śr. temp = {statsDisplay.AverageTemperature:F1}°C");

// ============================================================
// PODEJŚCIE NAIWNE (tight coupling) — dla ilustracji problemu
// ============================================================

internal sealed class NaiveWeatherStation
{
    private float _temperature;
    private float _humidity;

    // Stacja bezpośrednio zna konkretne wyświetlacze — tight coupling!
    private readonly NaiveCurrentDisplay _currentDisplay = new();
    private readonly NaiveStatsDisplay _statsDisplay = new();

    public void SetMeasurements(float temperature, float humidity)
    {
        _temperature = temperature;
        _humidity = humidity;
        // Musimy ręcznie wywołać każdy wyświetlacz:
        _currentDisplay.Update(_temperature, _humidity);
        _statsDisplay.Update(_temperature, _humidity);
        // Dodanie nowego wyświetlacza = zmiana tej metody!
    }
}

internal sealed class NaiveCurrentDisplay
{
    public void Update(float t, float h)
        => Console.WriteLine($"  [Naive Current] Temp: {t}°C  Hum: {h}%");
}

internal sealed class NaiveStatsDisplay
{
    public void Update(float t, float h)
        => Console.WriteLine($"  [Naive Stats] Zapis: {t}°C / {h}%");
}

// ============================================================
// WZORZEC OBSERWATOR — właściwe rozwiązanie
// ============================================================

internal interface IWeatherObserver
{
    void Update(float temperature, float humidity);
}

internal sealed class WeatherStation
{
    private readonly List<IWeatherObserver> _observers = new();
    private float _temperature;
    private float _humidity;

    public void Subscribe(IWeatherObserver observer) => _observers.Add(observer);

    public void Unsubscribe(IWeatherObserver observer) => _observers.Remove(observer);

    public void SetMeasurements(float temperature, float humidity)
    {
        _temperature = temperature;
        _humidity = humidity;
        NotifyAll();
    }

    private void NotifyAll()
    {
        foreach (IWeatherObserver obs in _observers)
            obs.Update(_temperature, _humidity);
    }
}

// Obserwator 1 — wyświetla aktualne warunki
internal sealed class CurrentConditionsDisplay(string name) : IWeatherObserver
{
    public void Update(float temperature, float humidity)
        => Console.WriteLine($"  [{name}] Temp: {temperature}°C  Hum: {humidity}%");
}

// Obserwator 2 — gromadzi statystyki
internal sealed class StatisticsDisplay : IWeatherObserver
{
    private float _sum;
    private int _count;

    public float AverageTemperature => _count == 0 ? 0f : _sum / _count;

    public void Update(float temperature, float humidity)
    {
        _sum += temperature;
        _count++;
        Console.WriteLine($"  [Statystyki] Próbek: {_count}, śr. temp: {AverageTemperature:F1}°C");
    }
}

// Obserwator 3 — symuluje aplikację mobilną
internal sealed class MobileAppDisplay : IWeatherObserver
{
    public void Update(float temperature, float humidity)
    {
        string emoji = temperature > 20 ? "☀" : "🌧";
        Console.WriteLine($"  [Mobile {emoji}] {temperature}°C / {humidity}%");
    }
}
