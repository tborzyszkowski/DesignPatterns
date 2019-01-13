namespace Singleton.DefaultSingleton
{
    public class DefaultSingleton
    {
    	private static DefaultSingleton singletonInstance = null;
        public static int singletonCounter = 0;

        private DefaultSingleton() { }

    	public static DefaultSingleton GetSingletonInstance()
    	{
            if (singletonInstance == null)
            {
                singletonInstance = new DefaultSingleton();
                singletonCounter += 1;
            }
            return singletonInstance;
    	}
    }
}
