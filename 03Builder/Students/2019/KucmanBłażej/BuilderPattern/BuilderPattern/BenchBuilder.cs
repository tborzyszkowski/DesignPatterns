using BenchmarkDotNet.Attributes;
using BuilderPattern.AbstractFactory;
using BuilderPattern.AbstractFactory.ComputerFactory;
using BuilderPattern.BuilderSimple;
using BuilderPattern.FluentBuilder;
using BuilderPattern.FluentBuilder2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class BenchBuilder
    {
        public BenchBuilder()
        {
            computerStore = new ComputerStore();
            computerStore2 = new ComputerStore2();
            abstractFactory = new FactoryFA(PolandFactory.Instance);
            //computerSuper = new ComputerSuper();
            superComputerBuilder = new ComputerSuperBuilder();
        }

        protected ComputerStore computerStore { get; set; }
        protected ComputerStore2 computerStore2 { get; set; }
        protected AbstractFactory.AbstractFactory abstractFactory { get; set; }
        protected ComputerSuper computerSuper {get; set;}
        protected ComputerSuperBuilder superComputerBuilder { get; set; }

        [Benchmark]
        public void Builder()
        {
            computerStore.Construct(new MediumComputerBuilder2());
        }
        [Benchmark]
        public void AbstraFabric()
        {
            abstractFactory.CreateComputer();
        }
        [Benchmark]
        public void SimpleBuilder()
        {
            computerSuper = superComputerBuilder
                .BuildMotherboard()
                .BuildHDD()
                .BuildMusicCard()
                .BuildRam()
                .BuildSDD()
                .BuildProcessor()
                .BuildPowerSupply()
                .buildComputerSuper();
        }
        [Benchmark]
        public void fluent2()
        {
            computerStore2.Construct(new SlowComputerBuilder2());
        }

    }
}
