using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderSimple
{
   public class ComputerSuperBuilder
    {
        private ComputerSuper computerSuper;

        public ComputerSuperBuilder()
        {
            computerSuper = new ComputerSuper();

        }

        public ComputerSuperBuilder BuildHDD()
        {
            this.computerSuper.hdd = "1000GB";
            return this;
        }

        public ComputerSuperBuilder BuildMotherboard()
        {
            this.computerSuper.motherboard = "Gigabyte Z390 AORUS XTREME";
            return this;
        }

        public ComputerSuperBuilder BuildMusicCard()
        {
            this.computerSuper.musicCard = "Creative Sound Blaster ZXR";
            return this;
        }

        public ComputerSuperBuilder BuildPowerSupply()
        {
            this.computerSuper.powerSupply = "Corsair HX 1200i 1200W";
            return this;
        }

        public ComputerSuperBuilder BuildProcessor()
        {
            this.computerSuper.processor = "Intel i9-9900K 3.6 GHz 16MB";
            return this;
        }

        public ComputerSuperBuilder BuildRam()
        {
            this.computerSuper.ram = "Corsair 64GB 3000MHz";
            return this;
        }

        public ComputerSuperBuilder BuildSDD()
        {
            this.computerSuper.ssd = "Samsung 4TB";
            return this;
        }
        public ComputerSuper buildComputerSuper()
        {
            return this.computerSuper;
        }
    }
}
