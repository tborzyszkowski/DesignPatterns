using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator
{
    abstract class ShopItem
    {
        private int _copies;

        // Property
        public int Copies
        {
            get { return _copies; }
            set { _copies = value; }
        }

        public abstract void Display();
    }
}

