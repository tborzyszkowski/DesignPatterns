using ClassicalObserver.Publisher;

namespace ClassicalObserver.Subscriber
{
	public class CurrentConditionsSubscriber : ISubscriber
	{
		public WeatherData Data { get; set; }
		private IPublisher weatherDataPublisher;

		public CurrentConditionsSubscriber(IPublisher weatherDataProvider)
		{
			weatherDataPublisher = weatherDataProvider;
			weatherDataPublisher.RegisterSubscriber(this);
		}
		
		public void Update(WeatherData data)
		{
			this.Data = data;
		}
	}
}
