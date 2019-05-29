using Factory.Products;
using Factory.Products.Rices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryReflection
{
    public class ReflectionRiceFactory
    {
        private static Lazy<ReflectionRiceFactory> lazy = new Lazy<ReflectionRiceFactory>(() => new ReflectionRiceFactory());
        public static ReflectionRiceFactory Instance { get { return lazy.Value; } set { lazy = new Lazy<ReflectionRiceFactory>(() => value); } }
        private IDictionary<string, Type> _registeredTypes = new Dictionary<string, Type>();

        public void RegisterRices()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var allRiceTypes = currentAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Rice)));
            foreach (var type in allRiceTypes)
                _registeredTypes.Add(type.Name.ToLower(), type);
        }
        public Rice GetRice(string name)
        {
            var type = _registeredTypes[name];
            return Activator.CreateInstance(type) as Rice;
        }
    }
}
