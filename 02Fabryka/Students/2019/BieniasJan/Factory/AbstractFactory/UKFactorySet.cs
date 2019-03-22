using Factory.MilitaryVehicles.Tanks;
using Factory.MilitaryVehicles.Warplanes;
using Factory.MilitaryVehicles.Warships;
using System;

//Concrete factories produce a family of products that belong
//to a single variant. The factory guarantees that the
//resulting products are compatible. Signatures of the concrete
//factory's methods return an abstract product, while inside
//the method a concrete product is instantiated.
namespace Factory.AbstractFactory
{
    public class UKFactorySet : IFactorySet
    {
        //Singleton
        private UKFactorySet() { }

        private static readonly Lazy<UKFactorySet> _instance =
            new Lazy<UKFactorySet>(() => Activator.CreateInstance(typeof(UKFactorySet), nonPublic: true) as UKFactorySet);

        public static UKFactorySet Instance
        {
            get { return _instance.Value; }
        }

        public Tank CreateTank()
        {
            return new Churchill();
        }

        public Warplane CreateWarplane()
        {
            return new Spitfire();
        }

        public Warship CreateWarship()
        {
            return new Valkyrie();
        }
    }
}
