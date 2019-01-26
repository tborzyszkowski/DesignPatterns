using FactoryMethod.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public abstract class AbstractProductProcess
    {
        public abstract Product.Product CreateNew(string model);
        public string GetInfo(string model)
        {
            Product.Product product = CreateNew(model);
            return "Brand: " + product.GetBrand() + "; model: " + product.GetModel() + ", " + GetType();
        }

        public abstract string GetType();
    }
}
