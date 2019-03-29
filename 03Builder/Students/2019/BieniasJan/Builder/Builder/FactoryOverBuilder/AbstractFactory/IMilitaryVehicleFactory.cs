using Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Tanks;
using Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Warplanes;

namespace Builder.FactoryOverBuilder.AbstractFactory
{
    public interface IMilitaryVehicleFactory
    {
        Tank CreateTank(int id);
        Warplane CreateWarplane(int id);
    }
}
