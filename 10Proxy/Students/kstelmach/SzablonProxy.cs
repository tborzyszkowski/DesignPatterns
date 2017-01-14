using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class SzablonProxy : ISzablon
    {
        private Szablon _szablon = new Szablon();
        public string Przepros(string imie, string czyn)
        {
            return _szablon.Przepros(imie, czyn);
        }
        public string Popros(string imie, string rzecz)
        {
            return _szablon.Popros(imie, rzecz);
        }
        public string Pozdrow(string skad)
        {
            return _szablon.Pozdrow(skad);
        }
        public string Zyczenia(string imie)
        {
            return _szablon.Zyczenia(imie);
        }
    }
}
