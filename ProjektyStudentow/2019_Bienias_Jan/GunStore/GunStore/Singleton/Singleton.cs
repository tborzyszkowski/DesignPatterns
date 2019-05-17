using System;

namespace GunStore.Singleton
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => Activator.CreateInstance(typeof(T), nonPublic: true) as T);

        protected Singleton() { }

        public static T Instance
        {
            get { return _instance.Value; }
        }
    }
}
