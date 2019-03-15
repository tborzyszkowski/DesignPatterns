using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class LockSingleton
    {
        private static LockSingleton lockSingletonInstance = null;
        private static readonly object obj = new object();
        public static int counter = 0;

        public static LockSingleton getInstance()
        {
            lock (obj)
            {
                if (lockSingletonInstance == null)
                {
                    counter++;
                    lockSingletonInstance = new LockSingleton();
                }
                return lockSingletonInstance;
            }
        }
    }
}
