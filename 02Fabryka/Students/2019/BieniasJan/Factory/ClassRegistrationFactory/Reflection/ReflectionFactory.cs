using Factory.MilitaryVehicles.Tanks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factory.ClassRegistrationFactory.Reflection
{
    class ReflectionFactory
    {
        //Singleton
        private static readonly Lazy<ReflectionFactory> _instance =
           new Lazy<ReflectionFactory>(() => Activator.CreateInstance(typeof(ReflectionFactory), nonPublic: true) as ReflectionFactory);

        public static ReflectionFactory Instance
        {
            get { return _instance.Value; }
        }

        private ReflectionFactory() { }
        //

        private Dictionary<string, Type> _registeredTypes = new Dictionary<string, Type>();

        public void RegisterTanks() //<- Reflection
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var allTankTypes = currentAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Tank)));

            foreach (var type in allTankTypes)
                _registeredTypes.Add(type.Name, type);
        }

        //RegisterWarplanes, RegisterWarships

        public Tank CreateTank(string name)
        {
            Type tank;
            if (_registeredTypes.ContainsKey(name))
            {
                tank = _registeredTypes[name];
                return Activator.CreateInstance(tank) as Tank;
            }
            else
                return null;
        }

        //CreateWarship, CreateWarplane
    }
}
