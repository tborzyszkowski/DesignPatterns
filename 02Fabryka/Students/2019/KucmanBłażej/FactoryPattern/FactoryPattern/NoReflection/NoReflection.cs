using FactoryPattern.SimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.NoReflection
{
    public class NoReflection
    {
        private static Lazy<NoReflection> instanceWehicle = new Lazy<NoReflection>(CreateInstance);

        private static NoReflection CreateInstance()
        {
            return Activator.CreateInstance(typeof(NoReflection), true) as NoReflection;
        }
        public static NoReflection Instance
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
