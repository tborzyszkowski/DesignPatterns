using System;

namespace SingletonPattern.ZadA
{
    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> lazyIstance = new Lazy<SingletonLazy>(() => new SingletonLazy());

        private SingletonLazy() { }

        public static SingletonLazy Instance
        {
            get { return lazyIstance.Value; }
        }
    }
}
