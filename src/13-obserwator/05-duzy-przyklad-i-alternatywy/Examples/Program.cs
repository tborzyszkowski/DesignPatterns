// ============================================================
// Temat 05: Duży przykład — Stacja Pogodowa
// ============================================================
// Kompletna implementacja wzorca Obserwator:
//   - WeatherStation (Subject)
//   - CurrentConditionsDisplay
//   - StatisticsDisplay
//   - ForecastDisplay
//   - HeatIndexDisplay (z formułą NOAA)
// ============================================================

using Observer.WeatherStation;

Console.WriteLine("=== STACJA POGODOWA — Wzorzec Obserwator ===");
Console.WriteLine();

var station = new WeatherStation();

var current = new CurrentConditionsDisplay("Panel główny");
var stats = new StatisticsDisplay();
var forecast = new ForecastDisplay();
var heatIndex = new HeatIndexDisplay();

station.Subscribe(current);
station.Subscribe(stats);
station.Subscribe(forecast);
station.Subscribe(heatIndex);

Console.WriteLine("--- Pomiar 1 ---");
station.SetMeasurements(22.5f, 65f, 1013.1f);

Console.WriteLine();
Console.WriteLine("--- Pomiar 2 ---");
station.SetMeasurements(28.0f, 80f, 1008.3f);

Console.WriteLine();
Console.WriteLine("--- Odłączanie HeatIndexDisplay ---");
station.Unsubscribe(heatIndex);

Console.WriteLine();
Console.WriteLine("--- Pomiar 3 (HeatIndex nie powiadamiany) ---");
station.SetMeasurements(19.0f, 55f, 1020.5f);

Console.WriteLine();
Console.WriteLine("--- Statystyki końcowe ---");
Console.WriteLine($"  Temperatura: min={stats.Min:F1}°C  max={stats.Max:F1}°C  śr={stats.Average:F1}°C");
