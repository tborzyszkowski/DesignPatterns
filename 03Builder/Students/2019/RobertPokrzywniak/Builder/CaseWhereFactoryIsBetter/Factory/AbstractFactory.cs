using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;
using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Potatoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Builder.CaseWhereFactoryIsBetter.Factory
{
    class AbstractFactory : ICarbohydrateFactory
    {
        private static readonly Lazy<AbstractFactory> _abstractInstance =
            new Lazy<AbstractFactory>(() => Activator.CreateInstance(typeof(AbstractFactory),true) as AbstractFactory);

        public static AbstractFactory Instance
        {
            get { return _abstractInstance.Value; }
        }

        private AbstractFactory() { }

        public Potato CreatePotato(string type)
        {
            switch (type)
            {
                case "sweet": return new SweetPotato();
                default: return new TraditionalPotato();
            }
        }
        public Groat CreateGroat()
        {
            return new BuckwheatGroat();
        }

    }
}
