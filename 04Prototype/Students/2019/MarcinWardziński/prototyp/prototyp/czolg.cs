using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototyp
{
    public class czolg : prototyp<czolg>
    {
        public string nazwa;
        public wieza wieza;

        public czolg(string a, wieza b)
        {
            nazwa = a;
            wieza = b;
        }
    }
}
