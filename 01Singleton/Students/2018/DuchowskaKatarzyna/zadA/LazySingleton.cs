using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.zadA
{
    public class LazySingleton
    {
        public static int constructorCount = 0;
        private static Lazy<LazySingleton> _singleton = new Lazy<LazySingleton>(() => new LazySingleton());

        private LazySingleton()
        {
            constructorCount++;
        }

        public static LazySingleton singleton
        {
            get { return _singleton.Value; }
        }
    }
}
