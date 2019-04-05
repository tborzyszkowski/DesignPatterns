using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder
{
    public class SlowComputerBuilder : ComputerBuilder
    {
        public SlowComputerBuilder()
        {
            computer = new Computer("SlowComputer");
        }

        public override ComputerBuilder BuildHDD()
        {
            computer["hdd"] = "500GB";
            return this;
        }

        public override ComputerBuilder BuildMotherboard()
        {
            computer["motherboard"] = "Gigabyte GA-F2A68HM-DS2";
            return this;
        }

        public override ComputerBuilder BuildMusicCard()
        {
            computer["musicCard"] = "Creative Sound Blaster Audigy FX";
            return this;
        }

        public override ComputerBuilder BuildPowerSupply()
        {
            computer["powerSupply"] = "SilentiumPC 500W";
            return this;
        }

        public override ComputerBuilder BuildProcessor()
        {
            computer["processor"] = "AMD A6-7480";
            return this;
        }

        public override ComputerBuilder BuildRam()
        {
            computer["ram"] = "GOODRAM DDR3 4GB";
            return this;
        }

        public override ComputerBuilder BuildSDD()
        {
            computer["ssd"] = "PNY 120GB";
            return this;
        }
    }
}
