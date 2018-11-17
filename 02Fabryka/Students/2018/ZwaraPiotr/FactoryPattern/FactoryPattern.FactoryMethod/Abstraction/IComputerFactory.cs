using FactoryPattern.Domain.Abstraction;
using FactoryPattern.FactoryMethod.Enumerations;

namespace FactoryPattern.FactoryMethod.Abstraction
{
    public interface IComputerFactory
    {
        IComputer CreateComputer(ComputerType type);
    }
}
