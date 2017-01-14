using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface ISzablon
    {
        string Przepros(string imie, string czyn);
        string Popros(string imie, string rzecz);
        string Pozdrow(string skad);
        string Zyczenia(string imie);
    }
}
