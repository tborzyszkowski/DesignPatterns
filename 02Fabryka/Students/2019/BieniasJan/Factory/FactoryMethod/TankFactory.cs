using Factory.MilitaryVehicles;
using Factory.MilitaryVehicles.Tanks;
using System;

//Concrete Creator czołgów
namespace Factory.FactoryMethod
{
    public class TankFactory : Factory
    {
        private static readonly Lazy<TankFactory> _instance =
            new Lazy<TankFactory>(() => Activator.CreateInstance(typeof(TankFactory), nonPublic: true) as TankFactory);

        public static TankFactory Instance
        {
            get { return _instance.Value; }
        }
        private TankFactory() { }

        protected override IMilitaryVehicle Create(string name)
        {
            /*
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
            */
            //tank.Drive();
            //return tank;
            return new Tiger();
        }
    }
}
