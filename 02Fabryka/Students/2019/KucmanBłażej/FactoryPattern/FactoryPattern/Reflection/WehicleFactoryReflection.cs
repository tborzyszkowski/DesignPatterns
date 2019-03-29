using FactoryPattern.SimpleFactory;
using FactoryPattern.SimpleFactory.Cars;
using FactoryPattern.SimpleFactory.Tractors;
using FactoryPattern.SimpleFactory.Trucks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Reflection
{
    public class WehicleFactoryReflection
    {
        private static Lazy<WehicleFactoryReflection> instanceWehicle = new Lazy<WehicleFactoryReflection>(CreateInstance);

        private static WehicleFactoryReflection CreateInstance()
        {
            return Activator.CreateInstance(typeof(WehicleFactoryReflection), true) as WehicleFactoryReflection;
        }
        public static WehicleFactoryReflection Instance
        {
            get { return instanceWehicle.Value; }
        }


        //private Hashtable m_RegisteredProducts = new Hashtable();
        private static Dictionary<string, Type> m_RegisteredProducts = new Dictionary<string, Type>();

        public void RegisterProduct()
        {

            var productTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Car)) || t.IsSubclassOf(typeof(Truck)) || t.IsSubclassOf(typeof(Tractor)));

            // w for () nie działało
            foreach (var type in productTypes)
            {
                m_RegisteredProducts.Add(type.Name, type);
            }

           // foreach (var x in m_RegisteredProducts)
             //   Console.WriteLine(x.Key + " " + x.Value);
        }

        public IWehicle CreateWehicle(string name)
        {
            Type wehicle;
            if (m_RegisteredProducts.ContainsKey(name))
            {
                wehicle = m_RegisteredProducts[name];
                return Activator.CreateInstance(wehicle) as IWehicle;
            }
            else
                return null;
        }

    }
}
