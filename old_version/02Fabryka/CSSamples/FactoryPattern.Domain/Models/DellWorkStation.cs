using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Enumerations;

namespace FactoryPattern.Domain.Models
{
    public class DellWorkStation : IWorkStation
    {
        public ComputerProducer Producer { get; set; }
        public double CPUFrequency { get; set; }
        public int RAM { get; set; }
        public StorageType Storage { get; set; }
        public RaidConfiguration RaidConfiguration { get; set; }

        public DellWorkStation()
        {
            this.Producer = ComputerProducer.DELL;
            this.CPUFrequency = 3.2;
            this.RAM = 8;
            this.Storage = StorageType.SSD;
            this.RaidConfiguration = RaidConfiguration.One;
        }
    }
}
