using System;
using System.Collections.Generic;
using System.Linq;
using ClassicalObserver.Subscriber;

namespace ClassicalObserver.Publisher
{
	public class WeatherDataProvider : IPublisher
	{
		List<ISubscriber> ListOfSubscribers;
		WeatherData data;
		public WeatherDataProvider()
		{
			ListOfSubscribers = new List<ISubscriber>();
		}
		public void RegisterSubscriber(ISubscriber subscriber)
		{
			ListOfSubscribers.Add(subscriber);
		}

		public void RemoveSubscriber(ISubscriber subscriber)
		{
			ListOfSubscribers.Remove(subscriber);
		}

		public void NotifySubscribers()
		{
			foreach (var sub in ListOfSubscribers)
			{
				sub.Update(data);
			}
		}

		private void MeasurementsChanged()
		{
			NotifySubscribers();
		}
		public void SetMeasurements(float temp, float humid, float pres)
		{
			data = new WeatherData(temp, humid, pres);
			MeasurementsChanged();
		}
	}
}
