using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Factory.SimpleFactory.Notebooks;

namespace Factory.Reflection
{
    class ReflectedFactory
    {
        private static readonly Lazy<ReflectedFactory> computerInstance = 
            new Lazy<ReflectedFactory>(() => 
                Activator.CreateInstance(typeof(ReflectedFactory),
                    true) as ReflectedFactory);

        public static ReflectedFactory Instance
        {
            get { return computerInstance.Value; }
        }

        private ReflectedFactory() { }

        private Dictionary<string, Type> _registeredModels = new Dictionary<string, Type>();

        public void RegisterNotebooks()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var allNotebooks = currentAssembly.GetTypes().Where(n => n.IsSubclassOf(typeof(Notebook)));

            foreach (var model in allNotebooks)
                _registeredModels.Add(model.Name, model);
        }

        public Notebook CreateNotebook(string name)
        {
            Type notebook;
            if (_registeredModels.ContainsKey(name))
            {
                notebook = _registeredModels[name];
                return Activator.CreateInstance(notebook) as Notebook;
            }
            else
            {
                return null;
            }
        }
    }
}
