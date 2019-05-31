using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototypGleboki
{
    [Serializable]
    public class dzialo
    {
        public pocisk pocisk;

        public dzialo(pocisk a)
        {
            pocisk = a;
        }
    }
}
