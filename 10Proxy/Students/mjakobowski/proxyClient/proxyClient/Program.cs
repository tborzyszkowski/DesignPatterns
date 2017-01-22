using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IActualPrices proxy = new ActualPricesProxy();

            Console.WriteLine("Cena złota: ");
            Console.WriteLine(proxy.GoldPrice);

            Console.WriteLine("Cena srebra: ");
            Console.WriteLine(proxy.SilverPrice);

            Console.WriteLine("Dolary na złotówki: ");
            Console.WriteLine(proxy.DollarToZloty);
            Console.ReadKey();
        }
    }
}
