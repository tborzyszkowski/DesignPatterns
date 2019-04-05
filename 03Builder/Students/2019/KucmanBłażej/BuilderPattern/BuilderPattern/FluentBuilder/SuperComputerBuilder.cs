using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder
{
    public class SuperComputerBuilder : ComputerBuilder
    {
        public SuperComputerBuilder()
        {
            computer = new Computer("SuperComputer");
        }

        public override ComputerBuilder BuildHDD()
        {
            computer["hdd"] = "1000GB";
            return this;
        }

        public override ComputerBuilder BuildMotherboard()
        {
            computer["motherboard"] = "Gigabyte Z390 AORUS XTREME";
            return this;
        }

        public override ComputerBuilder BuildMusicCard()
        {
            computer["musicCard"] = "Creative Sound Blaster ZXR";
            return this;
        }

        public override ComputerBuilder BuildPowerSupply()
        {
            computer["powerSupply"] = "Corsair HX 1200i 1200W";
            return this;
        }

        public override ComputerBuilder BuildProcessor()
        {
            computer["processor"] = "Intel i9-9900K 3.6 GHz 16MB";
            return this;
        }

        public override ComputerBuilder BuildRam()
        {
            computer["ram"] = "Corsair 64GB 3000MHz";
            return this;
        }

        public override ComputerBuilder BuildSDD()
        {
            computer["SSD"] = "Samsung 4TB";
            return this;
        }
    }
}
