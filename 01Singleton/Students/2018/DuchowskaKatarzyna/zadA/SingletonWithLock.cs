using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.zadA
{
    public class SingletonWithLock
    {
        public static int constructorCount = 0;
        private static SingletonWithLock _singleton = new SingletonWithLock();
        private static readonly object lockObj = new object();

        private SingletonWithLock()
        {
            constructorCount++;
        }

        public static SingletonWithLock GetSingleton()
        {
            lock (lockObj)
            {
                if (_singleton == null)
                {
                    _singleton = new SingletonWithLock();
                }
                return _singleton;
            }
        }
    }
}
