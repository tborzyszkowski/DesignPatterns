using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product
{
    public abstract class Product
    {
        protected string brand;
        protected string model;
        protected double diagonal;

        public string GetBrand()
        {
            return brand;
        }

        public string GetModel()
        {
            return model;
        }

        public double GetDiagonal()
        {
            return diagonal;
        }
    }
}
