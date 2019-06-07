using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototypGleboki
{

    [Serializable]
    public class czolg : prototyp<czolg>
    {
        public string nazwa;
        public kadlub kadlub;

        public czolg(string a, kadlub b)
        {
            nazwa = a;
            kadlub = b;
        }
    }
}
