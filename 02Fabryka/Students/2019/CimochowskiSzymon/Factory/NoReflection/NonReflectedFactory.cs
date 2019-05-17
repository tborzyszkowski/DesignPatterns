using System;
using System.Collections.Generic;
using Factory.SimpleFactory.Notebooks;

namespace Factory.NoReflection
{
    class NonReflectedFactory
    {
        private static readonly Lazy<NonReflectedFactory> computerInstance = 
            new Lazy<NonReflectedFactory>(() =>
                Activator.CreateInstance(typeof(NonReflectedFactory),
                    true) as NonReflectedFactory);

        public static NonReflectedFactory Instance
        {
            get { return computerInstance.Value; }
        }

        private NonReflectedFactory() { }

        private Dictionary<string, Type> _registeredModels = new Dictionary<string, Type>();

        public void RegisterNotebook(string name, Type type)
        {
            _registeredModels.Add(name, type);
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

        public T CreateNotebook<T>() where T : Notebook, new()
        {
            return new T();
        }

    }
}
