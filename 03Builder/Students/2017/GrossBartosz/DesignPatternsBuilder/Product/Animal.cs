using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBuilder.Product
{
    public class Animal
    {
        private string _animalType;

        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        public Animal(string animalType)
        {
            this._animalType = animalType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Animal Type: {0}", _animalType);
            Console.WriteLine(" Hands : {0}", _parts["hands"]);
            Console.WriteLine(" Head : {0}", _parts["head"]);
            Console.WriteLine(" Legs: {0}", _parts["legs"]);
            Console.WriteLine(" Body : {0}", _parts["body"]);
        }

    }
}
