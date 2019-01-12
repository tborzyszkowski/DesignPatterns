using System;
using System.Collections.Generic;
using System.Text;
using FactoryMethod.Product;
using FactoryMethod.Product.Smartphone;

namespace FactoryMethod
{
    class MobilePhoneProcess : AbstractProductProcess
    {
        public override Product.Product CreateNew(string model)
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
        public override string GetType()
        {
            return "type: smartphone";
        }
    }
}
