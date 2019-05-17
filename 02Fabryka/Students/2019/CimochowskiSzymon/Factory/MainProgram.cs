using System;
using System.Diagnostics;
using Factory.AbstractFactory;
using Factory.FactoryMethod;
using Factory.NoReflection;
using Factory.Reflection;
using Factory.SimpleFactory;
using Factory.SimpleFactory.Notebooks;

namespace Factory
{
    class MainProgram
    {
        public static void Main(string[] args)
        {
            FactoryGenerations();
            Console.Write("End");
            //FactoryGenerateWithTimes();
            //Console.ReadKey();
        }

        public static void FactoryGenerations()
        {
            int n = 10_000_000;

            IComputer notebook;

            // 1. SIMPLE FACTORY
            var simpleFactory = ComputerFactory.Instance;
            for (int i = 0; i < n; i++)
            {
                notebook = simpleFactory.CreateNotebook("Acer");
            }
            // 2. FACTORY METHOD
            var factoryMethod = NotebookFactory.Instance;
            for (int i = 0; i < n; i++)
            {
                notebook = factoryMethod.CreateComputer("Acer");
            }
            // 3. ABSTRACT FACTORY
            var abstractFactory = EpicFactory.Instance;
            for (int i = 0; i < n; i++)
            {
                notebook = abstractFactory.CreateNotebook();
            }
            // 4. GENERIC ABSTRACT FACTORY
            var genericAbstract = new EpicCompany(CreatonFactory.Instance);
            for (int i = 0; i < n; i++)
            {
                notebook = genericAbstract.CreateNotebook();
            }
            // 5. NON-REFLECTIVE FACTORY
            var nonReflection = NonReflectedFactory.Instance;
            nonReflection.RegisterNotebook("Acer", typeof(AcerNotebook));
            for (int i = 0; i < n; i++)
            {
                notebook = nonReflection.CreateNotebook("Acer");
            }
            // 6. NON-REFLECTIVE GENERIC FACTORY
            nonReflection = NonReflectedFactory.Instance;
            for (int i = 0; i < n; i++)
            {
                notebook = nonReflection.CreateNotebook<AcerNotebook>();
            }
            // 7. REFLECTIVE FACTORY
            var reflection = ReflectedFactory.Instance;
            reflection.RegisterNotebooks();
            for (int i = 0; i < n; i++)
            {
                notebook = reflection.CreateNotebook("Acer");
            }
        }

        public static void FactoryGenerateWithTimes()
        {
            int n = 10000000;

            Console.WriteLine(n + " iterations for each method...");
            var watch = new Stopwatch();
            double[] times = new double[7];
            string[] methodNames = { "SimpleFactory", "FactoryMethod", "AbstractFact.", "Generic", "NoReflection", "GenericNoReflection", "Reflection" };


            IComputer notebook;

            var simpleFactory = ComputerFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                notebook = simpleFactory.CreateNotebook("Acer");
            }
            watch.Stop();
            times[0] = watch.ElapsedMilliseconds;
            watch.Reset();

            var factoryMethod = NotebookFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                notebook = factoryMethod.CreateComputer("Acer");
            }
            watch.Stop();
            times[1] = watch.ElapsedMilliseconds;
            watch.Reset();

            var abstractFactory = EpicFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                notebook = abstractFactory.CreateNotebook();
            }
            watch.Stop();
            times[2] = watch.ElapsedMilliseconds;
            watch.Reset();

            var genericAbstract = new EpicCompany(CreatonFactory.Instance);
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                notebook = genericAbstract.CreateNotebook();
            }
            watch.Stop();
            times[3] = watch.ElapsedMilliseconds;
            watch.Reset();

            var nonReflection = NonReflectedFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                notebook = nonReflection.CreateNotebook("Acer");
            }
            watch.Stop();
            times[4] = watch.ElapsedMilliseconds;
            watch.Reset();

            nonReflection = NonReflectedFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                notebook = nonReflection.CreateNotebook<AcerNotebook>();
            }
            watch.Stop();
            times[5] = watch.ElapsedMilliseconds;
            watch.Reset();

            var reflection = ReflectedFactory.Instance;
            reflection.RegisterNotebooks();
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                notebook = reflection.CreateNotebook("Acer");
            }
            watch.Stop();
            times[6] = watch.ElapsedMilliseconds;
            watch.Reset();


            Console.WriteLine("Method: \t time");
            for (int i = 0; i < times.Length; i++)
            {
                Console.WriteLine(methodNames[i] + ":\t " + times[i] + " ms");
            }
        }
    }
}
