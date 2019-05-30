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
    public class HalinaFactory : IFactory
    {
        private static Lazy<HalinaFactory> lazy = new Lazy<HalinaFactory>(() => new HalinaFactory());
        public static HalinaFactory Instance { get { return lazy.Value; } set { lazy = new Lazy<HalinaFactory>(() => value); } }

        public Rice CreateRice()
        {
            return new Basmati();
        }
        public Groat CreateGroat()
        {
            return new Pearl();
        }
        public Pasta CreatePasta()
        {
            return new Pappardelle();
        }
    }
}
