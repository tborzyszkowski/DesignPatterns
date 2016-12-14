using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
   public abstract class TShirtStore : TShirt
    {
        public abstract TShirt CreateTShirt(string type);

        public TShirt OrderTShirt(string size)
        {
            TShirt tshirt = CreateTShirt(size);
            Console.WriteLine("Dziergamy Koszulke o rozmiarze :" + size);
            tshirt.Create();
            tshirt.TShirtInfo();
            return tshirt;
        }

    }
}
