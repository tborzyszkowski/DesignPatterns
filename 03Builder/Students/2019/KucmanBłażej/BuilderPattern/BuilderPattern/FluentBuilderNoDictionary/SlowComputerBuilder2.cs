using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder2
{
    public class SlowComputerBuilder2 : ComputerBuilder2
    {
        public SlowComputerBuilder2()
        {
            computer = CreateComputer();
        }
        public override ComputerBuilder2 BuildHDD()
        {
            this.computer.hdd = "1000GB";
            return this;
        }

        public override ComputerBuilder2 BuildMotherboard()
        {
            this.computer.motherboard = "Gigabyte Z390 AORUS XTREME";
            return this;
        }

        public override ComputerBuilder2 BuildMusicCard()
        {
            this.computer.musicCard = "Creative Sound Blaster ZXR";
            return this;
        }

        public override ComputerBuilder2 BuildPowerSupply()
        {
            this.computer.powerSupply = "Corsair HX 1200i 1200W";
            return this;
        }

        public override ComputerBuilder2  BuildProcessor()
        {
            this.computer.processor = "Intel i9-9900K 3.6 GHz 16MB";
            return this;
        }

        public override ComputerBuilder2 BuildRam()
        {
            this.computer.ram = "Corsair 64GB 3000MHz";
            return this;
        }

        public override ComputerBuilder2 BuildSDD()
        {
            this.computer.ssd = "Samsung 4TB";
            return this;
        }

        public override Computer2 CreateComputer()
        {
            return new Computer2() { ComputerName = "Slow" };
        }
    }
}
