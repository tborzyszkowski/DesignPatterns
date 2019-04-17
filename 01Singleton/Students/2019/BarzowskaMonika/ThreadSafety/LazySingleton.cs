using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafety
{
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton>
            Lazy =
                new Lazy<LazySingleton>(
                    () => new LazySingleton(), LazyThreadSafetyMode.ExecutionAndPublication
                );

        public static LazySingleton Instance => Lazy.Value;

        private LazySingleton()
        {
            Counter++;
        }

        public static int Counter;
    }
}
