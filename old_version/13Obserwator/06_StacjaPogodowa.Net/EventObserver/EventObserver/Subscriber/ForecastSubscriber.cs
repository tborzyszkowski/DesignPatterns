
using EventObserver.Publisher;

namespace EventObserver.Subscriber
{
	public class ForecastSubscriber
	{
		public WeatherData Data { get; set; }
		private WeatherDataProvider _wDataProvider;

		public ForecastSubscriber(WeatherDataProvider weatherDataProvider)
		{
			_wDataProvider = weatherDataProvider;
			_wDataProvider.RaiseWeatherDataChangedEvent += providerRaiseWeatherDataChangedEvent;
		}

		void providerRaiseWeatherDataChangedEvent(object sender, WeatherDataEventArgs e)
		{
			Data = e.Data;
			Data.Temperature += 2;
		}

		public void Unsubscribe()
		{
			_wDataProvider.RaiseWeatherDataChangedEvent -= providerRaiseWeatherDataChangedEvent;
		}
	}
}
