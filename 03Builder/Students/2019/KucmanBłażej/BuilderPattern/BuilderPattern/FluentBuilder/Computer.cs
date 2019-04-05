using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder
{
    public class Computer
    {
        private string computerType;
        private Dictionary<string, string> partsOfComputer =
            new Dictionary<string, string>();

        public Computer(string computerType)
        {
            this.computerType = computerType;
        }

        public string this[string key]
        {
            get { return partsOfComputer[key]; }
            set { partsOfComputer[key] = value; }
        }

        public void ComputerSet()
        {
            Console.WriteLine("Computer: {0}", computerType);
            Console.WriteLine("Motherboard: {0}", partsOfComputer["motherboard"]);
            Console.WriteLine("Processor: {0}", partsOfComputer["processor"]);
            Console.WriteLine("RAM: {0}", partsOfComputer["ram"]);
            Console.WriteLine("Power Supplhy: {0}", partsOfComputer["powerSupply"]);
            Console.WriteLine("HDD: {0}", partsOfComputer["hdd"]);
            Console.WriteLine("SSD: {0}", partsOfComputer["ssd"]);
            Console.WriteLine("Music Card: {0}", partsOfComputer["musicCard"]);

        }
    }
}
