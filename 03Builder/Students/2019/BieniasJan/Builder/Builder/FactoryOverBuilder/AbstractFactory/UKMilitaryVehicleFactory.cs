using Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Tanks;
using Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Warplanes;
using System;

namespace Builder.FactoryOverBuilder.AbstractFactory
{
    public class UKMilitaryVehicleFactory : IMilitaryVehicleFactory
    {
        //Singleton
        private UKMilitaryVehicleFactory() { }

        private static readonly Lazy<UKMilitaryVehicleFactory> _instance =
            new Lazy<UKMilitaryVehicleFactory>(() => Activator.CreateInstance(typeof(UKMilitaryVehicleFactory), nonPublic: true) as UKMilitaryVehicleFactory);

        public static UKMilitaryVehicleFactory Instance
        {
            get { return _instance.Value; }
        }
        //

        public Tank CreateTank(int id)
        {
            if (id == 0)
                return new Sherman();
            else if (id == 1)
                return new Churchill();
            else
                return null;
        }

        public Warplane CreateWarplane(int id)
        {
            return new Spitfire();
        }
    }
}
