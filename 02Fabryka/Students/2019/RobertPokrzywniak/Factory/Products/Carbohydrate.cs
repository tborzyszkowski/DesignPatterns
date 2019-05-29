using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products
{
    public abstract class Carbohydrate
    {
        public Brand Brand { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int BoilTime { get; set; }

        public abstract void Boil();
        public abstract void Eat();
        public override string ToString()
        {
            return (Brand + " | " + Type + " | ") +
                    "$" + Price + " | " + BoilTime + "min";
        }
    }
}
