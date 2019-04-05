using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderSimple
{
    public abstract class ComputerSimple
    {
        public string ComputerName;
        public string motherboard;
        public string processor;
        public string ram;
        public string powerSupply;
        public string hdd;
        public string ssd;
        public string musicCard;
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
