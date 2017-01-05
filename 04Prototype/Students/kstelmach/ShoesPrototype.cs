using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{

    abstract class ShoesPrototype
    {
        public abstract ShoesPrototype Clone();
    }


    class Shoes : ShoesPrototype
    {
        private string _color;
        private float _size;
        private string _brand;

        public Shoes(string color, float size, string brand)
        {
            this._color = color;
            this._size = size;
            this._brand = brand;
        }

        public override ShoesPrototype Clone()
        {
            Console.WriteLine("Cloning Shoes : \n color: " + _color + "\n size: " + _size + "\n brand: " + _brand + "\n");

            return this.MemberwiseClone() as ShoesPrototype;
        }
    }

}
