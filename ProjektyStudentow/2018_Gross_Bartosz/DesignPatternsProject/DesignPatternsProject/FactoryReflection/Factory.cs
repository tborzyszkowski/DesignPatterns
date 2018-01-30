using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsProject.Interfaces;

namespace DesignPatternsProject.FactoryReflection
{
    public class Factory
    {
        public static ICommunication GetShape<T>() where T : ICommunication
        {
            return Activator.CreateInstance<T>();
        }

        //Reflection
        public static ICommunication GetCommunicationObject(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(name).FullName;
            return (ICommunication) Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
        }
    }
}