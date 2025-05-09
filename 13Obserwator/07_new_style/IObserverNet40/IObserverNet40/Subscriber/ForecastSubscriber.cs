using System;
using IObserverNet40.Publisher;

namespace IObserverNet40.Subscriber
{
	class ForecastSubscriber : IObserver<WeatherData>
	{
		public WeatherData Data { get; set; }
		private IDisposable _unsubscriber;

		public ForecastSubscriber()
		{
		}
		public ForecastSubscriber(IObservable<WeatherData> provider)
		{
			_unsubscriber = provider.Subscribe(this);
		}

		public void Subscribe(IObservable<WeatherData> provider)
		{
			if (_unsubscriber == null)
			{
				_unsubscriber = provider.Subscribe(this);
			}
		}

		public void Unsubscribe()
		{
			_unsubscriber.Dispose();
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(WeatherData value)
		{
			this.Data = value;
			this.Data.Temperature += 4;
		}
	}
}
