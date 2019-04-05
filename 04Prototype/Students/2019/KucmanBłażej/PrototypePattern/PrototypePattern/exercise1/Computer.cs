using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.exercise1
{
    public class Computer : ComputerPrototype
    {
        string name;
        string motherboard;
        string processor;
        string hdd;

        public Computer(string name, string motherboard, string processor, string hdd)
        {
            this.name = name;
            this.motherboard = motherboard;
            this.processor = processor;
            this.hdd = hdd;
        }

        public string Name { get => name; set => name = value; }
        public string Motherboard { get => motherboard; set => motherboard = value; }
        public string Processor { get => processor; set => processor = value; }
        public string Hdd { get => hdd; set => hdd = value; }

        public override ComputerPrototype Clone()
        {
            return this.MemberwiseClone() as Computer;
        }
    }
}
