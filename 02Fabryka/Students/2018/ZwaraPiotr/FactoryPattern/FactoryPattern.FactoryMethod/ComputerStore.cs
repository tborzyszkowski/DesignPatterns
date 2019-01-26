using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Enumerations;
using FactoryPattern.FactoryMethod.Abstraction;
using FactoryPattern.FactoryMethod.Enumerations;

namespace FactoryPattern.FactoryMethod
{
    public class ComputerStore
    {
        public IComputer SellComputer(ComputerProducer producer, ComputerType type)
        {
            IComputerFactory factory = null;
            if (producer == ComputerProducer.DELL)
            {
                factory = DellComputerFactory.Instance;
            }
            else if (producer == ComputerProducer.HP)
            {
                factory = HpComputerFactory.Instance;
            }
            return factory?.CreateComputer(type);
        }
    }
}
