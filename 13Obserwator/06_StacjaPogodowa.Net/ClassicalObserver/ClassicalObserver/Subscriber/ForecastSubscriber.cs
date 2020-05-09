using System;
using ClassicalObserver.Publisher;

namespace ClassicalObserver.Subscriber
{
	public class ForecastSubscriber : ISubscriber, IDisposable
	{
		public WeatherData Data { get; set; }
		private IPublisher _weatherData;

		public ForecastSubscriber(IPublisher weatherDataProvider)
		{
			_weatherData = weatherDataProvider;
			_weatherData.RegisterSubscriber(this);
		}

		public void Update(WeatherData data)
		{
			this.Data = data;
			this.Data.Temperature += 4;
		}

		public void Dispose()
		{
			_weatherData.RemoveSubscriber(this);
		}
	}
}
