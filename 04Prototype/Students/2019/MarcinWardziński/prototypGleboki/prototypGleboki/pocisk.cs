using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototypGleboki
{
    [Serializable]
    public class pocisk
    {
        public int kaliber;
        public string typ;

        public pocisk(int a, string b)
        {
            kaliber = a;
            typ = b;
        }
    }
}
