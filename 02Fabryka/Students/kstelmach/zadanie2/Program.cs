using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie1;
using zadanie2;

namespace _02Fabryka
{
    class Program
    {
        static void Main(string[] args)
        {
            TShirtStore AdidasStore = new AdidasTShirtStore();
            TShirtStore NikeStore = new NikeTShirtStore();
            TShirtStore PumaStore = new PumaTShirtStore();

            TShirt tshirt = AdidasStore.CreateTShirt("Sport");
            Console.WriteLine(tshirt.name);

            tshirt = AdidasStore.CreateTShirt("Football");
            Console.WriteLine(tshirt.name);

            tshirt = NikeStore.CreateTShirt("Football");
            Console.WriteLine(tshirt.name);

            tshirt = NikeStore.CreateTShirt("Sport");
            Console.WriteLine(tshirt.name);
            Console.WriteLine(tshirt.GetSize());
            Console.WriteLine(tshirt.TShirtInfo());

            tshirt = PumaStore.CreateTShirt("Football");
            Console.WriteLine(tshirt.name);

            tshirt = PumaStore.CreateTShirt("Sport");
            Console.WriteLine(tshirt.name);

            Console.ReadLine();
        }
    }
}
