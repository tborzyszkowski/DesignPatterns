using System;
using System.Collections.Generic;
using System.Text;
using FactoryMethod.Product;
using FactoryMethod.Product.Computer;

namespace FactoryMethod
{
    class LaptopProcess : AbstractProductProcess
    {
        public override Product.Product CreateNew(string model)
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
        public override string GetType()
        {
            return "type: laptop";
        }
    }

}
