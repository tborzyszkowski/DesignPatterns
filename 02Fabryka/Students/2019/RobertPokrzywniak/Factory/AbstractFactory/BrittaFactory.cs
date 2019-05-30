using Factory.Products;
using Factory.Products.Groats;
using Factory.Products.Rices;
using Factory.Products.Pastas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    public class BrittaFactory : IFactory
    {
        private static Lazy<BrittaFactory> lazy = new Lazy<BrittaFactory>(() => new BrittaFactory());
        public static BrittaFactory Instance { get { return lazy.Value; } set { lazy = new Lazy<BrittaFactory>(() => value); } }

        public Rice CreateRice()
        {
            return new Black();
        }
        public Groat CreateGroat()
        {
            return new Semolina();
        }
        public Pasta CreatePasta()
        {
            return new Campanelle();
        }
    }
}
