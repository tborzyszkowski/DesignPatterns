using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Szablon :ISzablon
    {
       public string Przepros(string imie, string czyn)
        {
            return "Przepraszam Cie " + imie + " serdecznie za " + czyn;
        }
       public string Popros(string imie, string rzecz)
        {
            return "Prosze Cie " + imie + " o " + rzecz;
        }
       public string Pozdrow(string skad)
        {
            return "Pozdrawiam serdecznie z " + skad;
        }
       public string Zyczenia(string imie)
        {
            return imie + " , życze Ci wszystkiego co najlepsze";
        }
    }
}
