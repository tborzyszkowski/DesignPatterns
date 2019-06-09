using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.Construct(new OfficeBuilder()).Show();
            shop.Construct(new MidRangeBuilder()).Show();
            shop.Construct(new GamingBuilder()).Show();

            Console.ReadKey();
        }
    }
}
