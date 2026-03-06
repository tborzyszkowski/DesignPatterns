using FactoryPattern.Domain.Enumerations;

namespace FactoryPattern.Domain.Abstraction
{
    public interface IWorkStation : IComputer
    {
        RaidConfiguration RaidConfiguration { get; set; }
    }
}
