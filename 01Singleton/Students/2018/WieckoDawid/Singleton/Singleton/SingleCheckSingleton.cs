namespace Singleton.SingleCheckedSingleton
{
    public sealed class SingleCheckSingleton
    {
    	private static SingleCheckSingleton singletonInstance = null;
        private static readonly object locker = new object();
        public static int singletonCounter = 0;

        private SingleCheckSingleton() { }

    	public static SingleCheckSingleton GetSingletonInstance()
    	{
            lock(locker)
            {
                if (singletonInstance == null)
                {
                    singletonInstance = new SingleCheckSingleton();
                    singletonCounter += 1;
                }
            }
            return singletonInstance;
    	}
    }
}
