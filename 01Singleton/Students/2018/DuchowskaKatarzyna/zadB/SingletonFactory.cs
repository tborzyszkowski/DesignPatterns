using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonFactory
    {
        private static SingletonFactory factory;
        private Dictionary<Type, BasicSingleton> dictionary;

        private SingletonFactory()
        {
            dictionary = new Dictionary<Type, BasicSingleton>();
        }

        public static SingletonFactory CreateSingletonFactory()
        {
            if (factory == null)
            {
                factory = new SingletonFactory();
            }
            return factory;
        }

        public BasicSingleton CreateSingleton(Type type)
        {
            if (!dictionary.ContainsKey(type))
            {
                Console.WriteLine("Tworzymy typ: " + type);
                var method = type.GetMethod("CreateSingleton");
                dictionary.Add(type, (BasicSingleton)method.Invoke(null, null));
            }
            return dictionary[type];
        }
    }
}
