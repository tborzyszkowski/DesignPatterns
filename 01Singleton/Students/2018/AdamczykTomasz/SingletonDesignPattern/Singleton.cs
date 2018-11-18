namespace SingletonDesignPattern
{
    public class Singleton
    {
        private static readonly object @object = new object();
        private static Singleton _instance;

        public static int counter = 0;

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (@object)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                            counter++;
                        }
                    }
                }

                return _instance;
            }
        }

        public int GetCounter()
        {
            return counter;
        }

        public void DeleteInstance()
        {
            _instance = null;
        }
    }
}