using NUnit.Framework;
using EventObserver.Publisher;
using EventObserver.Subscriber;

namespace EventObserverTest
{
	[TestFixture]
	public class CurrentConditionsSubscriberTest
	{
		[Test]
		public void CurrentConditionsSubscriber_NotifyFirstChange_Temperature()
		{
			var wdp = new WeatherDataProvider();
			var ccs = new CurrentConditionsSubscriber(wdp);

			wdp.Notify(10, 20, 30);

			Assert.That(ccs.Data.Temperature, Is.EqualTo(10.0).Within(0.001));
		}
		[Test]
		public void CurrentConditionsSubscriber_NotifySecondChange_Temperature()
		{
			var wdp = new WeatherDataProvider();
			var ccs = new CurrentConditionsSubscriber(wdp);

			wdp.Notify(10, 20, 30);
			wdp.Notify(40, 50, 60);

			Assert.That(ccs.Data.Temperature, Is.EqualTo(40.0).Within(0.001));
		}
	}
}
