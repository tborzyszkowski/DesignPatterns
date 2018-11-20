using System;

namespace SingletonDesignPattern
{
    public class ParentSingleton<T> where T : ParentSingleton<T>
    {
        private static readonly object @object = new object();
        private static T _instance;

        protected ParentSingleton()
        {
        }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (@object)
                    {
                        if (_instance == null)
                        {
                            _instance = (T) Activator.CreateInstance(typeof(T), true);
                        }
                    }
                }

                return _instance;
            }
        }
    }
}