using Builder.FactoryBetter.Factory.Computers.Notebook;
using Builder.FactoryBetter.Factory.Computers.Tablet;

namespace Builder.FactoryBetter.Factory
{
    public interface IComputerFactory
    {
        Notebook CreateNotebook(string type);
        Tablet CreateTablet();
    }
}
