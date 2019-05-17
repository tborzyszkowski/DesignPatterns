using System;

namespace Builder.BuilderBetter.Factory
{
    class ComputerFactory : IComputerFactory
    {
        private static readonly Lazy<ComputerFactory> _factInstance = 
            new Lazy<ComputerFactory>(() => Activator
                .CreateInstance(typeof(ComputerFactory), true)
                as ComputerFactory);
        private ComputerFactory() { }

        public static ComputerFactory Instance
        {
            get { return _factInstance.Value; }
        }

        public Computer CreateComputer(string type)
        {
            switch (type)
            {
                case "Asus": return new AsusComputer();
                case "MSI": return new MSIComputer();
                default: return new xKomComputer();
            }
        }
    }
}
