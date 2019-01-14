using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product
{
    public abstract class Laptop
    {
        protected string brand;
        protected string model;
        protected int ram;
        protected double diagonal;

        public string GetBrand()
        {
            return brand;
        }

        public int GetRam()
        {
            return ram;
        }

        public double GetDiagonal()
        {
            return diagonal;
        }
    }
}
