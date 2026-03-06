using System;

namespace EventObserver.Publisher
{
	public class WeatherDataProvider : IDisposable
	{
		public event EventHandler<WeatherDataEventArgs> RaiseWeatherDataChangedEvent;

		protected virtual void OnRaiseWeatherDataChangedEvent(WeatherDataEventArgs e) =>
			RaiseWeatherDataChangedEvent?.Invoke(this, e);

		public void Notify(float temp, float humid, float pres) =>
			OnRaiseWeatherDataChangedEvent
				(new WeatherDataEventArgs(
					 new WeatherData(temp, humid, pres)));

		public void Dispose()
		{
			if (RaiseWeatherDataChangedEvent != null)
			{
				foreach (EventHandler<WeatherDataEventArgs> item in RaiseWeatherDataChangedEvent.GetInvocationList())
				{
					RaiseWeatherDataChangedEvent -= item;
				}
			}
		}
	}
}
