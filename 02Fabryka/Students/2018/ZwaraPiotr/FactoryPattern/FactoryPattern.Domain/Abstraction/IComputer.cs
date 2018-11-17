using FactoryPattern.Domain.Enumerations;

namespace FactoryPattern.Domain.Abstraction
{
    public interface IComputer
    {
        ComputerProducer Producer { get; set; }
        double CPUFrequency { get; set; }
        int RAM { get; set; }
        StorageType Storage { get; set; }
    }
}
