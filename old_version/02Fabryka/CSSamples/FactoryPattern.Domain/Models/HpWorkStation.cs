using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Enumerations;

namespace FactoryPattern.Domain.Models
{
    public class HpWorkStation : IWorkStation
    {
        public ComputerProducer Producer { get; set; }
        public double CPUFrequency { get; set; }
        public int RAM { get; set; }
        public StorageType Storage { get; set; }
        public RaidConfiguration RaidConfiguration { get; set; }

        public HpWorkStation()
        {
            this.Producer = ComputerProducer.HP;
            this.CPUFrequency = 3.0;
            this.RAM = 16;
            this.Storage = StorageType.HDD;
            this.RaidConfiguration = RaidConfiguration.Five;
        }
    }
}
