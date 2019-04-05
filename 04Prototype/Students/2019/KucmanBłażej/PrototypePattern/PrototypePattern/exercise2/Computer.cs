using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.exercise2
{
    [Serializable()]
    public class Computer : ComputerPrototype
    {
        public string Name { get; set; }
        public Motherboard Motherboard { get; set; }
        public string Hdd { get; set; }
        public string Price { get; set; }

        public Computer(string name, Motherboard motherboard, string hdd, string price)
        {
            this.Name = name;
            this.Motherboard = motherboard;
            this.Hdd = hdd;
            this.Price = price;
        }
       
    }
}
