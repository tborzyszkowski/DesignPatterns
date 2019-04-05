using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.AbstractFactory.ComputerFactory
{
    public class SlowComputer : Computer
    {
        public SlowComputer()
        {
            ComputerName = "SlowComputer";
            hdd = "500GB";
            motherboard = "Gigabyte GA - F2A68HM - DS2";
            musicCard = "Creative Sound Blaster Audigy FX";
            powerSupply = "SilentiumPC 500W";
            processor = "AMD A6-7480";
            ram = "GOODRAM DDR3 4GB";
            ssd = "PNY 120GB";
        }
    }
}
