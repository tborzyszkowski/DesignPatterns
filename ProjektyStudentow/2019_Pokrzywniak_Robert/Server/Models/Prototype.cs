using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public abstract class Prototype<T> where T : class
    {
        public T ShallowCopy()
        {
            return MemberwiseClone() as T;
        }
    }
}
