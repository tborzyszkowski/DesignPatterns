using System;

namespace Singleton
{
    public class SingletonBase
    {
        private static SingletonBase instance;
        private static object instance_lock = new object();

        protected SingletonBase()
        {

        }

        public static SingletonBase GetInstance<T>() where T : SingletonBase
        {
            if (instance != null)
                return instance;

            lock (instance_lock)
            {
                if (instance != null)
                    return instance;

                instance = Activator.CreateInstance(typeof(T), true) as SingletonBase;
                return instance;
            }
        }

        public virtual string TestMethod()
        {
            return $"Test method from abstract Singleton<T> class.";
        }
    }
}
