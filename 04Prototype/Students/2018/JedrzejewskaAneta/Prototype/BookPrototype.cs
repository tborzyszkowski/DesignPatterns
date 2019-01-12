using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    [Serializable()]
    abstract class BookPrototype
    {
        public abstract BookPrototype Duplicate();
    }
}
