using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Enumerations;

namespace FactoryPattern.Domain.Models
{
    public class DellGamingPC : IGamingPC
    {
        public ComputerProducer Producer { get; set; }
        public double CPUFrequency { get; set; }
        public int RAM { get; set; }
        public StorageType Storage { get; set; }
        public string DedicatedGraphicsCard { get; set; }

        public DellGamingPC()
        {
            this.Producer = ComputerProducer.DELL;
            this.CPUFrequency = 3.8;
            this.RAM = 16;
            this.Storage = StorageType.SSD;
            this.DedicatedGraphicsCard = "NVIDIA GeForce";
        }
    }
}
