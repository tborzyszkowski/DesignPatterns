using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.AbstractFactory.ComputerFactory
{
    public class Computer
    {
        public string ComputerName { get; set; }
        public string motherboard { get; set; }
        public string processor { get; set; }
        public string ram { get; set; }
        public string powerSupply { get; set; }
        public string hdd { get; set; }
        public string ssd { get; set; }
        public string musicCard { get; set; }
        public void ComputerSet()
        {
            Console.WriteLine("Computer: {0}", ComputerName);
            Console.WriteLine("Motherboard: {0}", motherboard);
            Console.WriteLine("Processor: {0}", processor);
            Console.WriteLine("RAM: {0}", ram);
            Console.WriteLine("Power Supplhy: {0}", powerSupply);
            Console.WriteLine("HDD: {0}", hdd);
            Console.WriteLine("SSD: {0}", ssd);
            Console.WriteLine("Music Card: {0}", musicCard);

        }


    }
}
