using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder
{
    public abstract class ComputerBuilder
    {
        protected Computer computer;

        Computer Computer
        {
            get { return computer; }
        }

        public abstract ComputerBuilder BuildMotherboard();
        public abstract ComputerBuilder BuildProcessor();
        public abstract ComputerBuilder BuildPowerSupply();
        public abstract ComputerBuilder BuildRam();
        public abstract ComputerBuilder BuildHDD();
        public abstract ComputerBuilder BuildSDD();
        public abstract ComputerBuilder BuildMusicCard();

        public static implicit operator Computer(ComputerBuilder computerBuilder)
        {
            return computerBuilder
                .BuildMotherboard()
                .BuildProcessor()
                .BuildRam()
                .BuildHDD()
                .BuildPowerSupply()
                .BuildSDD()
                .BuildMusicCard()
                .Computer;
        }

    }
}