using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie1;

namespace Buildery
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoesBuilder builder;
            Shop shop = new Shop();

            // Sport
            builder = new SportShoesBuilder();
            shop.Construct(builder);
            builder.Shoes.Show();

            // Winter
            builder = new WinterShoesBuilder();
            shop.Construct(builder);
            builder.Shoes.Show();

            Console.ReadLine();
        }
    
    }
}
