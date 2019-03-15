using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class GenericSingleton<T> where T : class
    {
        private static readonly Lazy<GenericSingleton<T>> instance =
            new Lazy<GenericSingleton<T>>
                (() => new GenericSingleton<T>());

        public static int counter = 0;

        protected GenericSingleton()
        {
            counter++;
        }

        public static GenericSingleton<T> getInstance
        {
            get { return instance.Value; }
        }

        public int getCounter()
        {
            return counter;
        }
    }
}
