using EventObserver.Publisher;

namespace EventObserver.Subscriber
{
	public class CurrentConditionsSubscriber
	{
		public WeatherData Data { get; set; }
		private WeatherDataProvider _wDataProvider;

		public CurrentConditionsSubscriber(WeatherDataProvider weatherDataProvider)
		{
			_wDataProvider = weatherDataProvider;
			_wDataProvider.RaiseWeatherDataChangedEvent += providerRaiseWeatherDataChangedEvent;
		}

		void providerRaiseWeatherDataChangedEvent(object sender, WeatherDataEventArgs e)
		{
			Data = e.Data;
		}

		public void Unsubscribe()
		{
			_wDataProvider.RaiseWeatherDataChangedEvent -= providerRaiseWeatherDataChangedEvent;
		}
	}
}
