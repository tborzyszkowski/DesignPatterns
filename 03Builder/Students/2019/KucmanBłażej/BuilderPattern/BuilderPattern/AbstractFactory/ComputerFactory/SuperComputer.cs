using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.AbstractFactory.ComputerFactory
{
    public class SuperComputer : Computer
    {
        public SuperComputer()
        {
            ComputerName = "SuperComputer";
            hdd = "1000GB";
            motherboard = "Gigabyte Z390 AORUS XTREME";
            musicCard = "Creative Sound Blaster ZXR";
            powerSupply = "Corsair HX 1200i 1200W";
            processor = "Intel i9-9900K 3.6 GHz 16MB";
            ram = "Corsair 64GB 3000MHz";
            ssd = "Samsung 4TB";
        }
    }
}
