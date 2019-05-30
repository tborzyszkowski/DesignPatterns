using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Products;
using Factory.Products.Pastas;

namespace Factory.FactoryMethod
{
    public class PastaStore : CarbohydrateStore
    {
        private static Lazy<PastaStore> lazy = new Lazy<PastaStore>(() => new PastaStore());
        public static PastaStore Instance { get { return lazy.Value; } set { lazy = new Lazy<PastaStore>(() => value); } }

        public override Carbohydrate Createcarbohydrate(string name)
        {
            name = name.ToLower();

            if (name.Equals("campanelle"))
            {
                return new Campanelle();
            }
            else if (name.Equals("farfalle"))
            {
                return new Farfalle();
            }
            else if (name.Equals("pappardelle"))
            {
                return new Pappardelle();
            }
            else return null;
        }
    }
}
