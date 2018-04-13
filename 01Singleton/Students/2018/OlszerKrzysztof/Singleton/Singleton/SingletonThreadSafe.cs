using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe instance;
        private static Object lockObj = new Object();
        public static int count = 0;

        private SingletonThreadSafe()
        { }

        public static SingletonThreadSafe getInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new SingletonThreadSafe();
                        count++;
                    }
                }
            }
            return instance;
        }

        public static void setNullInstance()
        {
            instance = null;
        }
    }
}
