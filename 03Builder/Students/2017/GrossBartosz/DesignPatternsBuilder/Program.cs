using System;
using System.Diagnostics;
using DesignPatternsBuilder.Builder;
using DesignPatternsBuilder.ConcreteBuilder;
using DesignPatternsBuilder.Director;
using DesignPatternsBuilder.zad2;
using WzorceFactory.Fabryka;
using Animal = DesignPatternsBuilder.Product.Animal;
using AnimalFactory = WzorceFactory.Fabryka.Animal;

namespace DesignPatternsBuilder
{
    public class Program
    {
        private static Animal andrzeAnimal;

        public static void Main(string[] args)
        {
            BasicBuilderCallLoop();
            FactoryCreatAnimalLoop();
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("\n---------------------------");
            BuilerTestCaseFlow();
            FactoryExampleCall();
        }

        #region Builder Methods

        public static bool CreateAndrzej()
        {
            var animal = new Animal("Andzej");
            andrzeAnimal = animal;
            return true;
        }

        public static bool ChangeAndrzejHistory()
        {
            andrzeAnimal["head"] = "Intel processor i9";
            andrzeAnimal["body"] = "Adonis type";
            andrzeAnimal["hands"] = "Soft and shiny";
            andrzeAnimal["legs"] = "3";
            return true;
        }

        public static bool ShowAndrzej()
        {
            andrzeAnimal.Show();
            return true;
        }

        #endregion

        #region private static methods
        private static void BasicBuilderCallLoop()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Basic Builder call 100K");

            var sklep = new AniamalCreator();
            var katamaran = sklep.Construct(new GeneticAnimalBuilderPadajTheSecond());
            katamaran.Show();

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                sklep.Construct(new GeneticAnimalBuilderJanuszTracz()); //.Show();
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine($"Time needed to create Instance call: Seconds {ts.Seconds:00} Milliseconds: {ts.Milliseconds:00} Ticks:{ts.Ticks}");
        }
        private static void FactoryCreatAnimalLoop()
        {
            AnimalFactory animal = null;
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("FactoryCreatAnimalLoop 100K");
            Console.WriteLine("\n---------------------------");

            var factory = new ZooFactory();
            var zooFactoryA = new ZooFactoryA(factory);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                animal = zooFactoryA.CreateAnimal("Cat");
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine($"Time needed to create Instance call: Seconds {ts.Seconds:00} Milliseconds: {ts.Milliseconds:00} Ticks:{ts.Ticks}");
            Console.WriteLine(animal.ToString());
        }

        private static void FactoryExampleCall()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("FactoryExampleCall");
            Console.WriteLine("\n---------------------------");

            var factory = new ZooFactory();
            var zooFactoryA = new ZooFactoryA(factory);
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var animal = zooFactoryA.CreateAnimal("Andrzej");

            stopWatch.Stop();
            var ts2 = stopWatch.Elapsed;
            Console.WriteLine($"Time needed to create Instance call: {ts2.Seconds:00}:{ts2.Milliseconds:00}:{ts2.Ticks}");
            Console.WriteLine(animal.ToString());
        }

        private static void BuilerTestCaseFlow()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("BuilerTestCaseFlow");

            var stopWatch = new Stopwatch();
            var testFlowCreator = new TestFlowCreator();
            var katamaran2 = new GeneticAnimalBuilderPadajTheSecond();

            var builder = testFlowCreator.TestCaseFlow(new TestFlowBuilder<ConfigurabilityBase>()
                .DefineStep(() => CreateAndrzej())
                .DefineStep(() => ChangeAndrzejHistory())
                .DefineStep(() => ShowAndrzej()));

            //dd.GetTestSteps();
            stopWatch.Start();
            var flowRunner = Executor.Execute(builder);
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine($"Time needed to create Instance call: {ts.Seconds:00}:{ts.Milliseconds:00}:{ts.Ticks}");
        }

        #endregion
    }
}