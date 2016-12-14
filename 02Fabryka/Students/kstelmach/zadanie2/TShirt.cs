using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    public class TShirt
    {
        public string name;
        public string type;
        public string color;
        public string size;

        public void Create()
        {
            Console.WriteLine("Zrobilismy twoja upragniona koszulke");
        }

        public string GetSize()
        {
            return size;
        }

        public string TShirtInfo()
        {
            string display = "---- " + name + " ----\n";
            display += "color: " + color + "\n";
            display += "type: " + type + "\n";
            display += "size: " + size + "\n";

            return display;
        }
    }
}
