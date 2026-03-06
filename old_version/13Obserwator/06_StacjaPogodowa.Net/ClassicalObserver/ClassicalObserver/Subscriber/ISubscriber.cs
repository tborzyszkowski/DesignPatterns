using ClassicalObserver.Publisher;

namespace ClassicalObserver.Subscriber
{
	public interface ISubscriber
	{
		void Update(WeatherData data);
	}
}
