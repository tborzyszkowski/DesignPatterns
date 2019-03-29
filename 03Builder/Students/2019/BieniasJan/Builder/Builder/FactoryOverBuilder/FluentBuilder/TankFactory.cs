using Builder.FactoryOverBuilder.FluentBuilder.MilitaryVehicles.Tanks;

namespace Builder.FactoryOverBuilder.FluentBuilder
{
    //Director
    public class TankFactory
    {
        public Tank Construct(TankBuilder tankBuilder)
        {
            return tankBuilder;
        }
    }
}
