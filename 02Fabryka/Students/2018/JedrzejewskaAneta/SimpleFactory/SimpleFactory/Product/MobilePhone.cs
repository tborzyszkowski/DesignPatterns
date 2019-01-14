using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Product
{
    public abstract class MobilePhone
    {
        protected string brand;
        protected string model;
        protected int year;
        protected double diagonal;

        public string GetBrand()
        {
            return brand;
        }

        public string GetModel()
        {
            return model;
        }

        public int GetYear()
        {
            return year;
        }

        public double GetDiagonal()
        {
            return diagonal;
        }
    }
}
