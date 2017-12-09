namespace WzoreceProjektoweSingleton.SingletonBase
{
    public sealed class SingletonNotThreadSave
    {
        private static SingletonNotThreadSave instance = null;

        private SingletonNotThreadSave()
        {
        }

        public static SingletonNotThreadSave Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonNotThreadSave();
                }
                return instance;
            }
        }
    }
}
