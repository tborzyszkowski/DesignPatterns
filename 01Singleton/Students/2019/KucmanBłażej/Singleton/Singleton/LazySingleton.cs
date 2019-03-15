using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class LazySingleton<T> where T : class
    {
        private static Lazy<T> lInstance = new Lazy<T>(CreateInstance);
        public static int counter = 0;
        public bool IsValueCreated { get { return lInstance.IsValueCreated; } }
        private static T CreateInstance()
        {
            counter++;
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        public static T Instance
        {
            get { return lInstance.Value; }
        }
    
    }
}
