namespace Singleton.DoubleCheckedLockingSingleton
{
    public sealed class DoubleCheckLockingSingleton
    {
    	private static DoubleCheckLockingSingleton singletonInstance = null;
    	private static readonly object locker = new object();
        public static int SingletonInstances = 0;

        private DoubleCheckLockingSingleton() { }

    	public static DoubleCheckLockingSingleton GetSingletonInstance()
        {
                if (singletonInstance == null)
                {
                    lock (locker)
                    {
                        if (singletonInstance == null)
                        {
                            singletonInstance = new DoubleCheckLockingSingleton();
                            SingletonInstances += 1;
                        }
                    }
                }

                return singletonInstance;
        }
    }
}
