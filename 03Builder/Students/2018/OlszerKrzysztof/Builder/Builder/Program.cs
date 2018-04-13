using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildingBuilder builder;

            Shop shop = new Shop();

            builder = new HouseBuilder();
            shop.Construct(builder);
            builder.Building.Show();

            builder = new MultiFamilyHouseBuilder();
            shop.Construct(builder);
            builder.Building.Show();

            builder = new SkyscraperBuilder();
            shop.Construct(builder);
            builder.Building.Show();

            Console.ReadKey();
        }
    }
}
