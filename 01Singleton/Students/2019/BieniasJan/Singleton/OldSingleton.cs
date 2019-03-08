
//Jan Bienias
//Singleton (stary) z double-checked locking

namespace Singleton
{
    public class OldSingleton
    {
        private static OldSingleton _instance; //volatile?
        //The volatile keyword indicates that a field might be modified by multiple threads that are executing at the same time.
        //However according to https://stackoverflow.com/questions/394898/double-checked-locking-in-net
        //There's no need to use volatile - .NET has stronger memory model than Java (had?)
        private static readonly object @object = new object();

        private OldSingleton()
        {

        }

        public static OldSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (@object)
                    {
                        if (_instance == null)
                        {
                            _instance = new OldSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}