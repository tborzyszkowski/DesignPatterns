using Factory.Products;
using Factory.Products.Groats;
using Factory.Products.Rices;
using Factory.Products.Pastas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.SimpleFactory
{
    public class SimpleCarbohydrateFactory
    {
        private static Lazy<SimpleCarbohydrateFactory> lazy = new Lazy<SimpleCarbohydrateFactory>(() => new SimpleCarbohydrateFactory());
        public static SimpleCarbohydrateFactory Instance { get { return lazy.Value; } set { lazy = new Lazy<SimpleCarbohydrateFactory>(() => value); } }

        public Rice CreateRice(string model)
        {
            model = model.ToLower();
            Rice rice = null;

            if (model.Equals("basmati"))
            {
                rice = new Basmati();
            }
            else if (model.Equals("black"))
            {
                rice = new Black();
            }
            else if (model.Equals("brown"))
            {
                rice = new Brown();
            }
            else if (model.Equals("jasmine"))
            {
                rice = new Jasmine();
            }

            return rice;
        }

        public Pasta CreatePasta(string model)
        {
            model = model.ToLower();
            Pasta pasta = null;

            if (model.Equals("campanelle"))
            {
                pasta = new Campanelle();
            }
            else if (model.Equals("farfalle"))
            {
                pasta = new Farfalle();
            }
            else if (model.Equals("pappardelle"))
            {
                pasta = new Pappardelle();
            }

            return pasta;
        }

        public Groat CreateGroat(string model)
        {
            model = model.ToLower();
            Groat groat = null;

            if (model.Equals("bikers"))
            {
                groat = new BuckWheat();
            }
            else if (model.Equals("endurace"))
            {
                groat = new Millet();
            }
            else if (model.Equals("silverbullet"))
            {
                groat = new Pearl();
            }

            return groat;
        }
    }
}
