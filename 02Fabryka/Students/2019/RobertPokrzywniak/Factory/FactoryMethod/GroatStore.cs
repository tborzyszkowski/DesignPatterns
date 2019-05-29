using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Products;
using Factory.Products.Groats;
using Factory.Products.Rices;
using Factory.Products.Pastas;

namespace Factory.FactoryMethod
{
    public class GroatStore : CarbohydrateStore
    {
        private static Lazy<GroatStore> lazy = new Lazy<GroatStore>(() => new GroatStore());
        public static GroatStore Instance { get { return lazy.Value; } set { lazy = new Lazy<GroatStore>(() => value); } }

        public override Carbohydrate Createcarbohydrate(string name)
        {
            name = name.ToLower();

            if (name.Equals("buckwheat"))
            {
                return new BuckWheat();
            }
            else if (name.Equals("millet"))
            {
                return new Millet();
            }
            else if (name.Equals("pearl"))
            {
                return new Pearl();
            }
            else return null;
        }
    }
}
