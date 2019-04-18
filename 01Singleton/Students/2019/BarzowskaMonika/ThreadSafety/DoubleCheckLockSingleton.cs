using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafety
{
    public class DoubleCheckLockSingleton
    {
        private static readonly object _padlock = new object();
        private static volatile DoubleCheckLockSingleton _instance;

        public static DoubleCheckLockSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckLockSingleton();
                        }
                    }
                }

                return _instance;
            }
        }

        private DoubleCheckLockSingleton()
        {
        }
    }
}
