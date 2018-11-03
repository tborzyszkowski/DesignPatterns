using System;

namespace SingletonPattern.ZadB
{
    public class SingletonBaseClass<T>
        where T : SingletonBaseClass<T> //, new()
    {
        private static T instance;
        private static readonly object syncLock = new object();

        protected SingletonBaseClass() { }

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = (T)Activator.CreateInstance(typeof(T), nonPublic: true); // return new T();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
