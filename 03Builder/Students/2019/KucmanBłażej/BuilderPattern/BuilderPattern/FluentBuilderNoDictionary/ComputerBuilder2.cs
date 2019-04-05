using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder2
{
    public abstract class ComputerBuilder2
    {
        protected Computer2 computer;

        Computer2 Computer
        {
            get { return computer; }
        }

        public abstract Computer2 CreateComputer();
        public abstract ComputerBuilder2 BuildMotherboard();
        public abstract ComputerBuilder2 BuildProcessor();
        public abstract ComputerBuilder2 BuildPowerSupply();
        public abstract ComputerBuilder2 BuildRam();
        public abstract ComputerBuilder2 BuildHDD();
        public abstract ComputerBuilder2 BuildSDD();
        public abstract ComputerBuilder2 BuildMusicCard();

        public static implicit operator Computer2(ComputerBuilder2 computerBuilder)
        {
            return computerBuilder
                .BuildMotherboard()
                .BuildProcessor()
                //.BuildRam()
                //.BuildHDD()
                //.BuildPowerSupply()
                //.BuildSDD()
                //.BuildMusicCard()
                .Computer;
        }
    }
}
