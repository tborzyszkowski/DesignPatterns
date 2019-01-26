using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Enumerations;

namespace FactoryPattern.Domain.Models
{
    public class HpGamingPC : IGamingPC
    {
        public ComputerProducer Producer { get; set; }
        public double CPUFrequency { get; set; }
        public int RAM { get; set; }
        public StorageType Storage { get; set; }
        public string DedicatedGraphicsCard { get; set; }

        public HpGamingPC()
        {
            this.Producer = ComputerProducer.HP;
            this.CPUFrequency = 3.5;
            this.RAM = 32;
            this.Storage = StorageType.SSD;
            this.DedicatedGraphicsCard = "AMD Radeon";
        }
    }
}
