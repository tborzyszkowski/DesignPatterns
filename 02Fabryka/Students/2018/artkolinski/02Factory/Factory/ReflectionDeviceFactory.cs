using System;
using System.Linq;
using System.Reflection;
using Factory.Models;

namespace Factory
{
    public abstract class ReflectionDeviceFactory
    {
        public static Device CreateDevice<T>() where T : Device
        {
            return Activator.CreateInstance<T>();
        }
        public static Device CreateDevice(string name)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == name);
            return (Device)Activator.CreateInstance(currentType);
        }
    }
}
