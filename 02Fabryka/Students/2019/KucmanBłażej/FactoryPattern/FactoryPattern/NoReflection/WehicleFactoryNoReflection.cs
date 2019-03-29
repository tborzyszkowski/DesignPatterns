using FactoryPattern.SimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.NoReflection
{
    public class WehicleFactoryNoReflection
    {
        private static Lazy<WehicleFactoryNoReflection> instanceWehicle = new Lazy<WehicleFactoryNoReflection>(CreateInstance);

        private static WehicleFactoryNoReflection CreateInstance()
        {
            return Activator.CreateInstance(typeof(WehicleFactoryNoReflection), true) as WehicleFactoryNoReflection;
        }
        public static WehicleFactoryNoReflection Instance
        {
            get { return instanceWehicle.Value; }
        }

        //private Hashtable m_RegisteredProducts = new Hashtable();
        private static Dictionary<string, Type> m_RegisteredProducts = new Dictionary<string, Type>();

        public void RegisterProduct(string Name, Type type)
        {

            m_RegisteredProducts.Add(Name, type);

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
