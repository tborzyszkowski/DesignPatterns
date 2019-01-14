using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product
{
    public abstract class Laptop : Product
    {
        protected int ram;

        public int GetRam()
        {
            return ram;
        }

    }
}
