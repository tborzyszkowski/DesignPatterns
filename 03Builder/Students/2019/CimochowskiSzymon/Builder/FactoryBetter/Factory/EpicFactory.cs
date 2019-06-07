using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.Factory.Computers.Notebook;
using Builder.FactoryBetter.Factory.Computers.Tablet;

namespace Builder.FactoryBetter.Factory
{
    class EpicFactory : IComputerFactory
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

        public Notebook CreateNotebook(string type)
        {
            return new DellNotebook();
        }

        public Tablet CreateTablet()
        {
            return new MicrosoftTablet();
        }
    }
}
