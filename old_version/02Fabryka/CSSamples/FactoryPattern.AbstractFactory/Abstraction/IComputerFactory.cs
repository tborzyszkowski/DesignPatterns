using FactoryPattern.Domain.Abstraction;

namespace FactoryPattern.AbstractFactory.Abstraction
{
    public interface IComputerFactory
    {
        IGamingPC CreateGamingPC();
        IWorkStation CreateWorkStation();
    }
}
