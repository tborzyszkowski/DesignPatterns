using Factory.MilitaryVehicles.Tanks;
using System;
using System.Collections.Generic;

namespace Factory.ClassRegistrationFactory.NoReflection
{
    public class NoReflectionFactory
    {
        //Singleton
        private static readonly Lazy<NoReflectionFactory> _instance =
           new Lazy<NoReflectionFactory>(() => Activator.CreateInstance(typeof(NoReflectionFactory), nonPublic: true) as NoReflectionFactory);

        public static NoReflectionFactory Instance
        {
            get { return _instance.Value; }
        }

        private NoReflectionFactory() { }
        //

        private Dictionary<string, Type> _registeredTypes = new Dictionary<string, Type>();

        public void RegisterTank(string name, Type type) //<- No reflection
        {
            _registeredTypes.Add(name, type);
        }

        //RegisterWarplane, RegisterWarship

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

        public T CreateTank<T>() where T : Tank, new()
        {
            //lub jeszcze jakies metody, np:
            //Tank tank = new T();
            // tank.Drive(), tank.Shoot() etc...
            return new T();
        }
        //CreateWarship<T>, CreateWarplane<T>
    }
}
