using System;
using System.Collections.Generic;

namespace IObserverNet40.Publisher
{
	public class WeatherDataProvider : IObservable<WeatherData>
	{
		List<IObserver<WeatherData>> observers;

		public WeatherDataProvider()
		{
			observers = new List<IObserver<WeatherData>>();
		}

		public IDisposable Subscribe(IObserver<WeatherData> observer)
		{
			if (!observers.Contains(observer))
			{
				observers.Add(observer);
			}
			return new UnSubscriber(observers, observer);
		}

		private void MeasurementsChanged(float temp, float humid, float pres)
		{
			foreach (var obs in observers)
			{
				obs.OnNext(new WeatherData(temp, humid, pres));
			}
		}

		public void SetMeasurements(float temp, float humid, float pres)
		{
			MeasurementsChanged(temp, humid, pres);
		}
	}
}
