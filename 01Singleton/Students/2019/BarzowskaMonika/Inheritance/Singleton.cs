using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inheritance
{
    public abstract class Singleton<T> where T : class
    {
        protected static readonly Lazy<T> 
            _instance = 
                new Lazy<T>(
                () => Activator.CreateInstance(typeof(T), nonPublic: true) as T, LazyThreadSafetyMode.ExecutionAndPublication
                );

        public static T Instance => _instance.Value;

        protected Singleton()
        {
            Counter++;
        }

        public static int Counter;
    }
}
