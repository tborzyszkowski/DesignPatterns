using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafety
{
    public class SimpleLockSingleton
    {
        private static SimpleLockSingleton _instance;
        private static readonly object _padlock = new object();

        public static SimpleLockSingleton Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SimpleLockSingleton();
                    }
                    return _instance;
                }
            }
        }

        private SimpleLockSingleton()
        {
        }
    }
}
