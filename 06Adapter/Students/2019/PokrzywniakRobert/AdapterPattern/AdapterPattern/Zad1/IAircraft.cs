using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Zad1
{
    public interface IAircraft
    {
        bool Airborne { get; }
        void TakeOff();
        int Height { get; set; }
    }
}
