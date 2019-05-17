using System;
using Factory.SimpleFactory.Notebooks;
using Factory.SimpleFactory.PCs;
using Factory.SimpleFactory.Tablets;

namespace Factory.AbstractFactory
{
    class EpicFactory : IFactory
    {
        private static readonly Lazy<EpicFactory> EpicInstance =
            new Lazy<EpicFactory>(() =>
                Activator.CreateInstance(typeof(EpicFactory),
                    true) as EpicFactory);

        public static EpicFactory Instance
        {
            get { return EpicInstance.Value; }
        }

        private EpicFactory() { }

        public Notebook CreateNotebook()
        {
            return new DellNotebook();
        }

        public PC CreatePC()
        {
            return new HPPC();
        }

        public Tablet CreateTablet()
        {
            return new MicrosoftTablet();
        }
    }
}
