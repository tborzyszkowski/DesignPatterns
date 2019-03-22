using Factory.MilitaryVehicles;
using Factory.MilitaryVehicles.Warships;
using System;

//Concrete Creator statków
namespace Factory.FactoryMethod
{
    public class Shipyard : Factory
    {
        private static readonly Lazy<Shipyard> _instance =
            new Lazy<Shipyard>(() => Activator.CreateInstance(typeof(Shipyard), nonPublic: true) as Shipyard);

        public static Shipyard Instance
        {
            get { return _instance.Value; }
        }
        private Shipyard() { }

        protected override IMilitaryVehicle Create(string name)
        {
            Warship warship;
            var result = name.Replace(" ", "").ToLower();
            if (result == "bougainville")
                warship = new Bougainville();
            else if (result == "grafzeppelin")
                warship = new GrafZeppelin();
            else if (result == "oleg")
                warship = new Oleg();
            else if (result == "tachibana")
                warship = new Tachibana();
            else if (result == "valkyrie")
                warship = new Valkyrie();
            else
                return null;
            warship.Swim();
            return warship;
        }
    }
}
