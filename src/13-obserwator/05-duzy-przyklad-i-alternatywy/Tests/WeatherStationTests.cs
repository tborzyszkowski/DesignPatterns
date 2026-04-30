using Observer.WeatherStation;
using Xunit;

namespace Observer.WeatherStation.Tests;

// ============================================================
// Testy jednostkowe — WeatherStation (wzorzec Obserwator)
// ============================================================

public sealed class WeatherStationTests
{
    // ----------------------------------------------------------
    // 1. Subskrypcja i powiadamianie
    // ----------------------------------------------------------

    [Fact]
    public void Subscribe_WhenMeasurementsSet_ObserverReceivesData()
    {
        var station = new WeatherStation();
        var observer = new SpyObserver();
        station.Subscribe(observer);

        station.SetMeasurements(22.5f, 65f, 1013f);

        Assert.Single(observer.ReceivedData);
        Assert.Equal(22.5f, observer.ReceivedData[0].Temperature);
        Assert.Equal(65f, observer.ReceivedData[0].Humidity);
        Assert.Equal(1013f, observer.ReceivedData[0].Pressure);
    }

    // ----------------------------------------------------------
    // 2. Wypisanie — observer nie dostaje notyfikacji
    // ----------------------------------------------------------

    [Fact]
    public void Unsubscribe_AfterUnsubscribe_ObserverNotNotified()
    {
        var station = new WeatherStation();
        var observer = new SpyObserver();
        station.Subscribe(observer);
        station.SetMeasurements(20f, 60f, 1010f);

        station.Unsubscribe(observer);
        station.SetMeasurements(25f, 70f, 1005f);

        Assert.Single(observer.ReceivedData);   // tylko pierwsze powiadomienie
    }

    // ----------------------------------------------------------
    // 3. Wiele obserwatorów — każdy dostaje niezależnie
    // ----------------------------------------------------------

    [Fact]
    public void MultipleObservers_AllReceiveNotification()
    {
        var station = new WeatherStation();
        var obs1 = new SpyObserver();
        var obs2 = new SpyObserver();
        var obs3 = new SpyObserver();

        station.Subscribe(obs1);
        station.Subscribe(obs2);
        station.Subscribe(obs3);

        station.SetMeasurements(18f, 50f, 1020f);

        Assert.Single(obs1.ReceivedData);
        Assert.Single(obs2.ReceivedData);
        Assert.Single(obs3.ReceivedData);
    }

    // ----------------------------------------------------------
    // 4. Spójność stanu — LastReading aktualizuje się
    // ----------------------------------------------------------

    [Fact]
    public void SetMeasurements_UpdatesLastReading()
    {
        var station = new WeatherStation();
        Assert.Null(station.LastReading);

        station.SetMeasurements(30f, 80f, 1000f);

        Assert.NotNull(station.LastReading);
        Assert.Equal(30f, station.LastReading!.Temperature);
    }

    [Fact]
    public void SetMeasurements_TwiceSetsLastReadingToLatest()
    {
        var station = new WeatherStation();
        station.SetMeasurements(22f, 65f, 1013f);
        station.SetMeasurements(28f, 75f, 1008f);

        Assert.Equal(28f, station.LastReading!.Temperature);
    }

    // ----------------------------------------------------------
    // 5. Wypisanie w trakcie powiadamiania — bezpieczna iteracja
    // ----------------------------------------------------------

    [Fact]
    public void Unsubscribe_DuringNotification_DoesNotThrow()
    {
        var station = new WeatherStation();
        var selfUnsubscriber = new SelfUnsubscribingObserver(station);

        station.Subscribe(selfUnsubscriber);
        station.Subscribe(new SpyObserver());

        // Nie powinno rzucić InvalidOperationException
        var exception = Record.Exception(() => station.SetMeasurements(20f, 60f, 1010f));
        Assert.Null(exception);
    }

    // ----------------------------------------------------------
    // 6. StatisticsDisplay — oblicza poprawnie min/max/avg
    // ----------------------------------------------------------

    [Fact]
    public void StatisticsDisplay_CalculatesCorrectMinMaxAvg()
    {
        var station = new WeatherStation();
        var stats = new StatisticsDisplay();
        station.Subscribe(stats);

        station.SetMeasurements(10f, 50f, 1000f);
        station.SetMeasurements(20f, 60f, 1010f);
        station.SetMeasurements(30f, 70f, 1020f);

        Assert.Equal(10f, stats.Min);
        Assert.Equal(30f, stats.Max);
        Assert.Equal(20f, stats.Average, precision: 1);
    }

    // ----------------------------------------------------------
    // 7. HeatIndexDisplay — wartość jest rozsądna
    // ----------------------------------------------------------

    [Fact]
    public void HeatIndexDisplay_ReturnsReasonableValue()
    {
        var station = new WeatherStation();
        var heatIndex = new HeatIndexDisplay();
        station.Subscribe(heatIndex);

        station.SetMeasurements(35f, 90f, 1010f);

        // Przy 35°C i 90% wilgotności heat index powinien być wyższy niż temperatura
        Assert.True(heatIndex.LastHeatIndex > 35f,
            $"Oczekiwano heat index > 35°C, ale wynosi {heatIndex.LastHeatIndex:F1}°C");
    }
}

// ============================================================
// Pomocnicze klasy testowe (test doubles)
// ============================================================

internal sealed class SpyObserver : IWeatherObserver
{
    public List<WeatherData> ReceivedData { get; } = new();

    public void Update(WeatherData data) => ReceivedData.Add(data);
}

// Observer, który wypisuje się z Subject przy pierwszym powiadomieniu
internal sealed class SelfUnsubscribingObserver(WeatherStation station) : IWeatherObserver
{
    private bool _unsubscribed;

    public void Update(WeatherData data)
    {
        if (!_unsubscribed)
        {
            station.Unsubscribe(this);
            _unsubscribed = true;
        }
    }
}
