namespace SingletonPattern.ZadA
{
    public class SingletonDoubleCheck
    {
        private static SingletonDoubleCheck instance;
        private static readonly object syncLock = new object();

        private SingletonDoubleCheck() { }

        public static SingletonDoubleCheck Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDoubleCheck();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
