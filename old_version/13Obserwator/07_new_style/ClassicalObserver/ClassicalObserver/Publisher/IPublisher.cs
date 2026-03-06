using ClassicalObserver.Subscriber;

namespace ClassicalObserver.Publisher
{
	public interface IPublisher
	{
		void RegisterSubscriber(ISubscriber subscriber);
		void RemoveSubscriber(ISubscriber subscriber);
		void NotifySubscribers();
	}
}
