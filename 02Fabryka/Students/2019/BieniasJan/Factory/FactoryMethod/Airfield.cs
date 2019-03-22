using Factory.MilitaryVehicles;
using Factory.MilitaryVehicles.Warplanes;
using System;

//Concrete Creator samolotów
namespace Factory.FactoryMethod
{
    public class Airfield : Factory
    {
        private static readonly Lazy<Airfield> _instance =
            new Lazy<Airfield>(() => Activator.CreateInstance(typeof(Airfield), nonPublic: true) as Airfield);

        public static Airfield Instance
        {
            get { return _instance.Value; }
        }
        private Airfield() { }

        protected override IMilitaryVehicle Create(string name)
        {
            Warplane warplane;
            var result = name.Replace(" ", "").ToLower();
            if (result == "bleriot")
                warplane = new Bleriot();
            else if (result == "spitfire")
                warplane = new Spitfire();
            else if (result == "messerschmitt")
                warplane = new Messerschmitt();
            else if (result == "nakajima")
                warplane = new Nakajima();
            else if (result == "petlyakov")
                warplane = new Petlyakov();
            else
                return null;
            warplane.Fly();
            return warplane;
        }
    }
}
