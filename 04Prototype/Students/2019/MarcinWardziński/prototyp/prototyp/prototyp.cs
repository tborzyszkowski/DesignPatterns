using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototyp
{
    public abstract class prototyp<T> where T : class
    {
        public T kopiuj()
        {
            return MemberwiseClone() as T;
        }
    }
}
