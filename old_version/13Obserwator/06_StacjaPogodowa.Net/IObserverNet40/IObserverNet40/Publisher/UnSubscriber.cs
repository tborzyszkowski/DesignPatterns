using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IObserverNet40.Publisher
{
	internal class UnSubscriber : IDisposable
	{
		private List<IObserver<WeatherData>> lstObservers;
		private IObserver<WeatherData> observer;

		internal UnSubscriber(List<IObserver<WeatherData>> observersCollection,
							IObserver<WeatherData> observer)
		{
			this.lstObservers = observersCollection;
			this.observer = observer;
		}

		public void Dispose()
		{
			if (this.observer != null)
			{
				lstObservers.Remove(this.observer);
			}
		}
	}
}
