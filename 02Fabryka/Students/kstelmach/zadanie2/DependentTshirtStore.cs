using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    public class DependentTShirtStore
    {
        public TShirt CreateTShirt(string company, string type)
        {
            TShirt tshirt = null;
            if (company.Equals("Adidas"))
            {
                if (type.Equals("Sport"))
                {
                    tshirt = new AdidasSportTShirt();
                }else if (type.Equals("Football"))
                {
                    tshirt = new AdidasFootballTShirt();
                }
                
            }else if (company.Equals("Nike"))
            {
                if (type.Equals("Sport"))
                {
                    tshirt = new NikeSportTShirt();
                }
                else if (type.Equals("Football"))
                {
                    tshirt = new NikeFootballTShirt();
                }
            }else if (company.Equals("Puma"))
            {
                if (type.Equals("Sport"))
                {
                    tshirt = new PumaSportTShirt();
                }
                else if (type.Equals("Football"))
                {
                    tshirt = new PumaFootballTShirt();
                }
            }
            else
            {
                Console.WriteLine("Błędnie podana firma");
            }
            tshirt.GetSize();
            tshirt.TShirtInfo();
            return tshirt;
        }
    }
}
