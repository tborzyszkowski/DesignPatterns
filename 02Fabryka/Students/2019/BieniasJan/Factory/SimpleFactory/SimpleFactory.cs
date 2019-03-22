using Factory.MilitaryVehicles.Tanks;
using Factory.MilitaryVehicles.Warplanes;
using Factory.MilitaryVehicles.Warships;
using System;

//Simple Factory
namespace Factory.SimpleFactory
{
    public class SimpleFactory
    {
        //Singleton
        private static readonly Lazy<SimpleFactory> _instance =
            new Lazy<SimpleFactory>(() => Activator.CreateInstance(typeof(SimpleFactory), nonPublic: true) as SimpleFactory);

        public static SimpleFactory Instance
        {
            get { return _instance.Value; }
        }
        private SimpleFactory() { }
        //

        public Tank CreateTank(string name)
        {
            Tank tank;
            var result = name.Replace(" ", "").ToLower();
            if (result == "tiger")
                tank = new Tiger();
            else if (result == "oi")
                tank = new OI();
            else if (result == "renault")
                tank = new Renault();
            else if (result == "stg")
                tank = new STG();
            else if (result == "churchill")
                tank = new Churchill();
            else
                return null;
            return tank;
        }

        public Warplane CreateWarplane(string name)
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
            return warplane;
        }

        public Warship CreateWarship(string name)
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
            return warship;
        }
    }
}
