using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Shoes
    {
        private string _shoesType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        public Shoes(string shoesType)
        {
            this._shoesType = shoesType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("Shoes Type: {0}", _shoesType);
            Console.WriteLine("shoes sole : {0}", _parts["sole"]);
            Console.WriteLine("shoes laces : {0}", _parts["laces"]);
            Console.WriteLine("shoes material : {0} \n", _parts["material"]);
        }

    }
}
