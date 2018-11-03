namespace SingletonPattern.ZadA
{
    public class SingletonGetterLock
    {
        private static SingletonGetterLock instance;
        private static readonly object syncLock = new object();

        private SingletonGetterLock() { }

        public static SingletonGetterLock Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonGetterLock();
                    }
                }
                return instance;
            }
        }
    }
}
