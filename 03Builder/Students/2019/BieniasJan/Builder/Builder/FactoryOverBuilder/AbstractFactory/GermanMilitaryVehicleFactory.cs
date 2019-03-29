using Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Tanks;
using Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Warplanes;
using System;

namespace Builder.FactoryOverBuilder.AbstractFactory
{
    public class GermanMilitaryVehicleFactory : IMilitaryVehicleFactory
    {
        //Singleton
        private GermanMilitaryVehicleFactory() { }

        private static readonly Lazy<GermanMilitaryVehicleFactory> _instance =
            new Lazy<GermanMilitaryVehicleFactory>(() => Activator.CreateInstance(typeof(GermanMilitaryVehicleFactory), nonPublic: true) as GermanMilitaryVehicleFactory);

        public static GermanMilitaryVehicleFactory Instance
        {
            get { return _instance.Value; }
        }
        //

        public Tank CreateTank(int id = 0)
        {
            return new Tiger();
        }

        public Warplane CreateWarplane(int id = 0)
        {
            return new Messerschmitt();
        }
    }
}
