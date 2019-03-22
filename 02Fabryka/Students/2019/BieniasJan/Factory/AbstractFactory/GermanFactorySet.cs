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
    public class GermanFactorySet : IFactorySet
    {
        //Singleton
        private GermanFactorySet() { }

        private static readonly Lazy<GermanFactorySet> _instance =
            new Lazy<GermanFactorySet>(() => Activator.CreateInstance(typeof(GermanFactorySet), nonPublic: true) as GermanFactorySet);

        public static GermanFactorySet Instance
        {
            get { return _instance.Value; }
        }

        public Tank CreateTank()
        {
            return new Tiger();
        }

        public Warplane CreateWarplane()
        {
            return new Messerschmitt();
        }

        public Warship CreateWarship()
        {
            return new GrafZeppelin();
        }
    }
}
