using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton{
        public class SingletonInheritance<T> where T: class{
        public static int counter = 0;
        private static readonly Lazy<T> NewInstance = new Lazy<T>(() => Activator.CreateInstance(typeof(T), 
            nonPublic: true) as T);
        protected SingletonInheritance()
        {
            counter++;
        }
        public static T Instance
        {
            get { return NewInstance.Value; }
        }
    }
}
