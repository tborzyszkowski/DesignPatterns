using Factory.SimpleFactory.Notebooks;
using Factory.SimpleFactory.PCs;
using Factory.SimpleFactory.Tablets;

namespace Factory.AbstractFactory
{
    public abstract class Company
    {
        private readonly IFactory _factory;

        protected Company(IFactory factory)
        {
            _factory = factory;
        }

        public Notebook CreateNotebook()
        {
            return _factory.CreateNotebook();
        }

        public PC CreatePC()
        {
            return _factory.CreatePC();
        }

        public Tablet CreateTablet()
        {
            return _factory.CreateTablet();
        }
    }
}
