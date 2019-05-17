using Factory.SimpleFactory;

namespace Factory.FactoryMethod
{
    public abstract class Factory
    {
        protected abstract IComputer Create(string name);

        public IComputer CreateComputer(string name)
        {
            IComputer computer = Create(name);
            if (computer == null)
                return null;

            return computer;
        }
    }
}
