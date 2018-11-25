using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ExtendedSingletonA : BasicSingleton
    {
        private new static ExtendedSingletonA singleton;
        private ExtendedSingletonA() : base() {}

        public new static ExtendedSingletonA CreateSingleton()
        {
            if (singleton == null)
            {
                singleton = new ExtendedSingletonA();
            }
            return singleton as ExtendedSingletonA;
        }
    }
}
