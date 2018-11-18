using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ExtendedSingletonB : BasicSingleton
    {
        private new static ExtendedSingletonB singleton;
        private ExtendedSingletonB() : base() { }

        public new static ExtendedSingletonB CreateSingleton()
        {
            if (singleton == null)
            {
                singleton = new ExtendedSingletonB();
            }
            return singleton as ExtendedSingletonB;
        }
    }
}
