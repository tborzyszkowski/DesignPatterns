namespace Singleton
{
    public sealed class SingletonLock2
    {
        static readonly object myLock = new object();
        static SingletonLock2 myInstance;
        SingletonLock2()
        {
        }

        public static SingletonLock2 GetInstance()
        {
            if (myInstance == null)
            {
                lock (myLock)
                {
                    if (myInstance == null)
                    {
                        myInstance = new SingletonLock2();
                    }
                    
                }
            }
            return myInstance;

        }
    }
}