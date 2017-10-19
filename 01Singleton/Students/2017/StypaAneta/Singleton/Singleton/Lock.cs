using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Lock
    {
        private static object c_syncLockObject = new object();
        private volatile static Lock _singleton;

        private Lock() { }

        public static Lock Instance
        {
            get
            {
                if (_singleton == null)
                {
                    lock (c_syncLockObject)
                    {
                        if (_singleton == null)
                        {
                            _singleton = new Lock();
                        }
                    }
                }
                return _singleton;
            }
        }

        public virtual void Log(People p1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(p1.name + " " + p1.lastname);
        }
    }

}