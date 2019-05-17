using System;
using Factory.SimpleFactory.Notebooks;
using Factory.SimpleFactory.PCs;
using Factory.SimpleFactory.Tablets;

namespace Factory.AbstractFactory
{
    class CreatonFactory : IFactory
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

        public Notebook CreateNotebook()
        {
            return new AcerNotebook();
        }

        public PC CreatePC()
        {
            return new CoolerMasterPC();
        }

        public Tablet CreateTablet()
        {
            return new LenovoTablet();
        }

    }
}
