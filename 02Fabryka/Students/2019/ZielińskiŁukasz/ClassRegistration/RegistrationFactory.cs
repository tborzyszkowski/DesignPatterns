using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Frigates;
using Factory.CapitalShips;
using Factory.Cruisers;

namespace Factory.ClassRegistration
{
    public class RegistrationFactory
    {
        private static readonly Lazy<RegistrationFactory> MethodInstance =
            new Lazy<RegistrationFactory>(() => Activator.CreateInstance(typeof(RegistrationFactory), nonPublic: true) as RegistrationFactory);
        public static RegistrationFactory Instance
        {
            get { return MethodInstance.Value; }
        }
        private static Dictionary<string, Type> registeredType = new Dictionary<string, Type>();

        public void BuildShip(string Name, Type type)
        {
            registeredType.Add(Name, type);
        }

        public Ships CreateShip(string shipName)
        {
            Type ship;
            if (registeredType.ContainsKey(shipName))
            {
                ship = registeredType[shipName];
                return Activator.CreateInstance(ship) as Ships;
            }
            else
                return null;
        }
    }
}
