using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    class PumaTShirtStore : TShirtStore
    {
        public override TShirt CreateTShirt(string type)
        {
            if (type.Equals("Sport"))
            {
                return new PumaSportTShirt();
            }
            else if (type.Equals("Football"))
            {
                return new PumaFootballTShirt();
            }
            else return null;
        }
    }
}
