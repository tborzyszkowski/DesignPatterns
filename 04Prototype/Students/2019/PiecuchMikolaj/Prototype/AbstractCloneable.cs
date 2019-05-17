using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public abstract class AbstractCloneable<T> : ICloneable where T : class
    {
        public object Clone()
        {
            T cloned = MemberwiseClone() as T;
            HandleDeepClone(cloned);
            return cloned;
        }

        public abstract void HandleDeepClone(T cloned);
    }
}
