using Factory.MilitaryVehicles.Tanks;
using Factory.MilitaryVehicles.Warplanes;
using Factory.MilitaryVehicles.Warships;

namespace Factory.AbstractFactory
{
    public abstract class Base
    {
        private readonly IFactorySet _factory;

        protected Base(IFactorySet factory)
        {
            _factory = factory;
        }

        public Tank BuildTank()
        {
            return _factory.CreateTank();
        }

        public Warplane BuildWarplane()
        {
            return _factory.CreateWarplane();
        }

        public Warship BuildWarship()
        {
            return _factory.CreateWarship();
        }
    }
}
