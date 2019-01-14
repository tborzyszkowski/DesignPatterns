using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product
{
    public abstract class MobilePhone : Product
    {
        protected int year;

        public int GetYear()
        {
            return year;
        }

    }
}
