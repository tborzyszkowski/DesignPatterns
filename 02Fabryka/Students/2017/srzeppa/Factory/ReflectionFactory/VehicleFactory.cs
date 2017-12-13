using System;
using ReflectionFactory.Model;
using System.Reflection;
using System.Linq;

namespace ReflectionFactory
{
    public abstract class VehicleFactory
    {
        public static BaseVehicle CreateVehicle<T>() where T : BaseVehicle
        {
            return Activator.CreateInstance<T>();
        }

        public static BaseVehicle CreateVehicle(string name)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == name);
            return (BaseVehicle)Activator.CreateInstance(currentType);
        }
    }
}
