using Factory.Products;
using Factory.Products.Rices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactorySuplier
{
    public class NonReflectionRiceFactory
    {
        private static Lazy<NonReflectionRiceFactory> lazy = new Lazy<NonReflectionRiceFactory>(() => new NonReflectionRiceFactory());
        public static NonReflectionRiceFactory Instance { get { return lazy.Value; } set { lazy = new Lazy<NonReflectionRiceFactory>(() => value); } }
        private IDictionary<string, Type> _registeredTypes = new Dictionary<string, Type>();

        public void RegisterRice(string name, Type type)
        {
            _registeredTypes.Add(name, type);
        }
        public Rice GetRice(string name)
        {
            var rice = _registeredTypes[name];
            return Activator.CreateInstance(rice) as Rice;
        }
    }
}
