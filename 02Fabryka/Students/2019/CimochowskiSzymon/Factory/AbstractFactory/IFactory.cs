using Factory.SimpleFactory.Notebooks;
using Factory.SimpleFactory.PCs;
using Factory.SimpleFactory.Tablets;

namespace Factory.AbstractFactory
{
    public interface IFactory
    {
        Notebook CreateNotebook();
        PC CreatePC();
        Tablet CreateTablet();
    }
}
