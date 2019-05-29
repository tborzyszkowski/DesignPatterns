using Builder.CaseWhereBuilderIsBetter.Builder;
using Builder.CaseWhereBuilderIsBetter.Builder.Carbohydrates;
using Builder.CaseWhereBuilderIsBetter.Factory;
using Builder.CaseWhereFactoryIsBetter.Builder;
using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;
using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Potatoes;
using Builder.CaseWhereFactoryIsBetter.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10_000_000;

            CaseWhereBuilderIsBetter(n);
            CaseWhenFactoryIsBetter(n);
        }

        static void CaseWhereBuilderIsBetter(int n)
        {
            BuilderBetter(n);
            FactoryWorse(n);
        }

        static void CaseWhenFactoryIsBetter(int n)
        {
            FactoryBetter(n);
            BuilderWorse(n);
        }

        static void BuilderBetter(int n)
        {
            var factory = new PastaCompany();
            Pasta pasta;

            for (int i = 0; i < n; i++)
            {
                var builder = new SonkoPastaBuilder();
                factory.Construct(builder);
                pasta = builder.Pasta;
            }
        }

        static void FactoryWorse(int n)
        {
            Rice rice;

            for (int i = 0; i < n; i++)
            {
                rice = RiceFactory.Instance.CreateRice("halina");
            }
        }
        static void FactoryBetter(int n)
        {
            Potato potato;

            for (int i = 0; i < n; i++)
            {
                potato = AbstractFactory.Instance.CreatePotato("sweet");
            }
        }
        static void BuilderWorse(int n)
        {
            Groat groat;
            var groatFactory = new GroatFactory();

            for (int i = 0; i < n; i++)
            {
                groat = groatFactory.Construct(new BuckwheatGroatBuilder());
            }
        }
    }
}
