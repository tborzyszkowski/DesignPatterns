using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            Building house = shop.Construct(new HouseBuilder());
            house.Show();

            shop.Construct(new SkyscraperBuilder()).Show();

            Console.ReadKey();
        }
    }
}
