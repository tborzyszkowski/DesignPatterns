using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    public class AdidasTShirtStore : TShirtStore
    {
        public override TShirt CreateTShirt(string type)
        {
            if (type.Equals("Sport"))
            {
                return new AdidasSportTShirt();
            }else if (type.Equals("Football"))
            {
                return new AdidasFootballTShirt();
            }
            else return null;
        }
    }
}
