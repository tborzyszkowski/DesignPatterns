namespace Singleton
{
    public sealed class SingletonLock
    {
        static readonly object myLock = new object();
        static private SingletonLock myInstance;
        private SingletonLock()
        {
        }

        public static SingletonLock GetInstance()
        {
            lock (myLock)
            {
                if (myInstance == null)
                {
                    myInstance = new SingletonLock();
                }
                return myInstance;
            }
        }
    }
}