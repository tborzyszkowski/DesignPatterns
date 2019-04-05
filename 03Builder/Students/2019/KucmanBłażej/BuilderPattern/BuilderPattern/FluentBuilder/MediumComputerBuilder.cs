using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder
{
    public class MediumComputerBuilder2 : ComputerBuilder
    {
        public MediumComputerBuilder2()
        {
            computer = new Computer("MediumComputer");
        }

        public override ComputerBuilder BuildHDD()
        {
            computer["hdd"] = "1000GB";
            return this;
        }

        public override ComputerBuilder BuildMotherboard()
        {
            computer["motherboard"] = "ASRock Z370 Pro4";
            return this;
        }

        public override ComputerBuilder BuildMusicCard()
        {
            computer["musicCard"] = "ASUS Strix Soar";
            return this;
        }

        public override ComputerBuilder BuildPowerSupply()
        {
            computer["powerSupply"] = "be quiet!600W";
            return this;
        }

        public override ComputerBuilder BuildProcessor()
        {
            computer["processor"] = "Intel Core i5-8400";
            return this;
        }

        public override ComputerBuilder BuildRam()
        {
            computer["ram"] = "16 GB (DIMM DDR4, 2666 MHz)";
            return this;
        }

        public override ComputerBuilder BuildSDD()
        {
            computer["ssd"] = "Crucial 500GB";
            return this;
        }
    }
}
