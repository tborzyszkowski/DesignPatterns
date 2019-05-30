using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Products;
using Factory.Products.Rices;
using Factory.Products.Pastas;

namespace Factory.FactoryMethod
{
    public class RiceStore : CarbohydrateStore
    {
        private static Lazy<RiceStore> lazy = new Lazy<RiceStore>(() => new RiceStore());
        public static RiceStore Instance { get { return lazy.Value; } set { lazy = new Lazy<RiceStore>(() => value); } }

        public override Carbohydrate Createcarbohydrate(string name)
        {
            name = name.ToLower();

            if (name.Equals("basmati"))
            {
                return new Basmati();
            }
            else if (name.Equals("black"))
            {
                return new Black();
            }
            else if (name.Equals("brown"))
            {
                return new Brown();
            }
            else if (name.Equals("jasmine"))
            {
                return new Jasmine();
            }
            else return null;
        }
    }
}
