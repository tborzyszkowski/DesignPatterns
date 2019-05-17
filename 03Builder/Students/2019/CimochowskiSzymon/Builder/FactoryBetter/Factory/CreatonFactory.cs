using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.Factory.Computers.Notebook;
using Builder.FactoryBetter.Factory.Computers.Tablet;


namespace Builder.FactoryBetter.Factory
{
    class CreatonFactory : IComputerFactory
    {
        private static readonly Lazy<CreatonFactory> CreatonInstance =
            new Lazy<CreatonFactory>(() =>
                Activator.CreateInstance(typeof(CreatonFactory),
                    true) as CreatonFactory);

        public static CreatonFactory Instance
        {
            get { return CreatonInstance.Value; }
        }

        private CreatonFactory() { }

        public Notebook CreateNotebook(string type)
        {
            switch (type)
            {
                case "Asus": return new AsusNotebook();
                default: return new DellNotebook();
            }
        }
        public Tablet CreateTablet()
        {
            return new SamsungTablet();
        }

    }
}
