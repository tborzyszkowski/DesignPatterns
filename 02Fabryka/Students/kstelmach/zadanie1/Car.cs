using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    public class Car
    {
        public string name;
        public string color;
        public string type;
        public string brand;

        public string GetName()
        {
            return name;
        }

        public void Create()
        {
            Console.WriteLine("Created " + name);
        }

        public string CarInfo()
        {
            string display = "---- " + name + " ----\n";
            display += "color: " + color + "\n";
            display += "type: " + type + "\n";
            display += "brand: " + brand + "\n";

            return display;
        }
    }
}
