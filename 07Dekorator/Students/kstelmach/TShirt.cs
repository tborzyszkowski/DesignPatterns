using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator
{
    class TShirt :ShopItem
    {
        private string _brand;
        private string _color;
        private string _model;

        public TShirt(string brand, string color, string model, int copies)
        {
            this._brand = brand;
            this._color = color;
            this._model = model;
            this.Copies = copies;
        }

        public override void Display()
        {
            Console.WriteLine("\nTShirt");
            Console.WriteLine("------------------------------ \n");
            Console.WriteLine(" Brand: {0}", _brand);
            Console.WriteLine(" color: {0}", _color);
            Console.WriteLine(" model: {0}", _model);
            Console.WriteLine(" copies: {0}\n", Copies);
        }
    }
}
