using SimpleFactory.Product;
using SimpleFactory.Product.Computer;
using SimpleFactory.Product.Smartphone;
using SimpleFactory.Product.TV;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    class SimpleFactory
    {
        static private SimpleFactory simpleFactory;

        private SimpleFactory()
        {
        }

        public static SimpleFactory GetInstance()
        {
            if (simpleFactory != null)
            {
                simpleFactory = new SimpleFactory();
            }

            return simpleFactory;
        }

        public static Laptop NewLaptop(string model)
        {
            if (model == "Ideapad")
            {
                return new Ideapad();
            }
            else if (model == "MacBook")
            {
                return new MacBook();
            }
            else if (model == "Nitro")
            {
                return new Nitro();
            }
            else if (model == "Omen")
            {
                return new Omen();
            }
            else if (model == "Vostro")
            {
                return new Vostro();
            }
            else
                return null;
        }

        public static MobilePhone NewMobilePhone(string model)
        {
            if (model == "Galaxy")
            {
                return new Galaxy();
            }
            else if (model == "Mate")
            {
                return new Mate();
            }
            else if (model == "Pixel")
            {
                return new Pixel();
            }
            else if (model == "Xperia")
            {
                return new Xperia();
            }
            else if (model == "Zenfone")
            {
                return new Zenfone();
            }
            else
            {
                return null;
            }
        }

        public static Televisor NewTelevisor(string brand)
        {
            if (brand == "LG")
            {
                return new LG();
            }
            else if (brand == "Panasonic")
            {
                return new Panasonic();
            }
            else if (brand == "Samsung")
            {
                return new Samsung();
            }
            else if (brand == "Sharp")
            {
                return new Sharp();
            }
            else if (brand == "Toshiba")
            {
                return new Toshiba();
            }
            else
            {
                return null;
            }
        }
    }
}
