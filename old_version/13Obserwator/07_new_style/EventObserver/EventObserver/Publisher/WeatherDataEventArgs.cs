using System;

namespace EventObserver.Publisher
{
	public class WeatherDataEventArgs : EventArgs
	{
		public WeatherData Data { get; private set; }
		public WeatherDataEventArgs(WeatherData data)
		{
			this.Data = data;
		}
	}
}
