using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    class NikeTShirtStore : TShirtStore
    {
        public override TShirt CreateTShirt(string type)
        {
            if (type.Equals("Sport"))
            {
                return new NikeSportTShirt();
            }
            else if (type.Equals("Football"))
            {
                return new NikeFootballTShirt();
            }
            else return null;
        }
    }
}
