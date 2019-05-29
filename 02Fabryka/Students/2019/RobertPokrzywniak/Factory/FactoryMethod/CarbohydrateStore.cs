using Factory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryMethod
{
    public abstract class CarbohydrateStore
    {
        public abstract Carbohydrate Createcarbohydrate(string name);

        public Carbohydrate Build(string name)
        {
            Carbohydrate carbohydrate = Createcarbohydrate(name);
            return carbohydrate;
        }
    }
}
