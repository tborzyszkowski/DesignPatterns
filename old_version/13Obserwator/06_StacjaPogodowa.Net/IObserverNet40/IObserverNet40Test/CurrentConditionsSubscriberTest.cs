using NUnit.Framework;
using IObserverNet40.Publisher;
using IObserverNet40.Subscriber;

namespace IObserverNet40Test
{
	[TestFixture]
	public class CurrentConditionsSubscriberTest
	{
		[Test]
		public void CurrentConditionsSubscriber_NotifyFirstChange_Temperature()
		{
			var wdp = new WeatherDataProvider();
			var ccs = new CurrentConditionsSubscriber(wdp);

			wdp.SetMeasurements(10, 20, 30);

			Assert.That(ccs.Data.Temperature, Is.EqualTo(10.0).Within(0.001));
		}
		[Test]
		public void CurrentConditionsSubscriber_NotifySecondChange_Temperature()
		{
			var wdp = new WeatherDataProvider();
			var ccs = new CurrentConditionsSubscriber(wdp);

			wdp.SetMeasurements(10, 20, 30);
			wdp.SetMeasurements(40, 50, 60);

			Assert.That(ccs.Data.Temperature, Is.EqualTo(40.0).Within(0.001));
		}
	}
}
