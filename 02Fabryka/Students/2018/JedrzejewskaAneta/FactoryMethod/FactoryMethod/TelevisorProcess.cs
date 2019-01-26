using System;
using System.Collections.Generic;
using System.Text;
using FactoryMethod.Product;
using FactoryMethod.Product.TV;

namespace FactoryMethod
{
    class TelevisorProcess : AbstractProductProcess
    {
        
        public override Product.Product CreateNew(string brand)
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

        public override string GetType()
        {
            return "type: televisor";
        }
    }
}
