using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Factory.Frigates;
using Factory.CapitalShips;
using Factory.Cruisers;

namespace Factory.ClassRegistration
{
    public class RegistrationFactoryWithReflection
    {
        private static readonly Lazy<RegistrationFactoryWithReflection> MethodInstance =
            new Lazy<RegistrationFactoryWithReflection>(() => Activator.CreateInstance(typeof(RegistrationFactoryWithReflection), nonPublic: true) as RegistrationFactoryWithReflection);
        public static RegistrationFactoryWithReflection Instance
        {
            get { return MethodInstance.Value; }
        }

        private static Dictionary<string, Type> registeredType = new Dictionary<string, Type>();

        public void BuildShip()
        {
            var TypesOfShips = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Frigate)) ||
            t.IsSubclassOf(typeof(Cruiser)) || t.IsSubclassOf(typeof(CapitalShip)));

            foreach (var position in TypesOfShips)
            {
                registeredType.Add(position.Name, position);
            }
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
