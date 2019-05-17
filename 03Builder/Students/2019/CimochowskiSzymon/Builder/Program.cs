using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.BuilderBetter.Builder;
using Builder.BuilderBetter.Factory;
using Builder.FactoryBetter.FluentBuilder;
using Builder.FactoryBetter.Factory;
using Builder.FactoryBetter.SimpleBuilder;
using Builder.FactoryBetter.SimpleBuilder.Computers;
using AppleTabBuilder = Builder.FactoryBetter.SimpleBuilder.AppleTabBuilder;



namespace Builder
{
    class Program
    {
        static void BuilderBetterThanFactory(int n)
        {
            BuilderFirst(n);
            BuilderThird(n);
            FactoryFirst(n);
        }

        static void FactoryBetterThanBuilder(int n)
        {
            BuilderSecond(n);
            FactorySecond(n);
        }

        static void BuilderFirst(int n)
        {
            BuilderBetter.Builder.Computer builderComputer;
            var compCompany = new ComputerCompany();
            for (int i = 0; i < n; i++)
            {
                builderComputer = compCompany.Build(new AsusBuilder());
            }
        }

        static void FactoryFirst(int n)
        {
            BuilderBetter.Factory.Computer factoryComputer;

            for (int i = 0; i < n; i++)
            {
                factoryComputer = ComputerFactory.Instance.CreateComputer("Asus");
            }
        }

        static void BuilderSecond(int n)
        {
            FactoryBetter.FluentBuilder.Computers.Notebook builderNotebook;

            var notebookFactory = new NotebookFactory();
            for (int i = 0; i < n; i++)
            {
                builderNotebook = notebookFactory.Make(new AsusNoteBuilder());
            }
        }

        static void FactorySecond(int n)
        {
            FactoryBetter.Factory.Computers.Notebook.Notebook factoryNotebook;

            for (int i = 0; i < n; i++)
            {
                factoryNotebook = CreatonFactory.Instance.CreateNotebook("Asus");
            }
        }

        static void BuilderThird(int n)
        {
            var simpleFactory = new TabCompany();

            for (int i = 0; i < n; i++)
            {
                simpleFactory.Make(new AppleTabBuilder());
            }
        }
        static void Main(string[] args)
        {
            int n = 10000000;

            BuilderBetterThanFactory(n);
            FactoryBetterThanBuilder(n);
        }

    }
}
