using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product
{
    public abstract class Televisor : Product
    {
        protected bool isSmartTV;

        public bool IsSmartTV()
        {
            return isSmartTV;
        }
    }
}
