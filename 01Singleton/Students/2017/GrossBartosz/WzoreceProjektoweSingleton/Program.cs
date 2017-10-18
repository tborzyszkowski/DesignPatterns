using System;
using System.Threading;
using WzoreceProjektoweSingleton.SingletonBase;
using WzoreceProjektoweSingleton.SingletonDerivedClasses;
using WzoreceProjektoweSingleton.Test;

namespace WzoreceProjektoweSingleton
{
    internal class Program
    {
        /// <summary>
        /// The main class method.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            var square = new GenericShape<SingletonSquare>(SingletonSquare.Squareingleton);
            var rectangle = new GenericShape<SingletonRectangle>(SingletonRectangle.RectangleSingleton);

            var singletonTestRunner = new SingletonTests();

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Base Singleton");
            singletonTestRunner.SingletonPerformanceTest(Singleton.Instance);
            Console.WriteLine("------------------------------------------------------------------");

            Console.WriteLine("Singleton with lock");
            singletonTestRunner.SingletonPerformanceTest(SingletonWithLock.Instance);
            Console.WriteLine("------------------------------------------------------------------");

            var serializeTestCaseWithLock = false;
            Console.WriteLine("Singleton without lock - serialize test");
            singletonTestRunner.SerializableTest(serializeTestCaseWithLock);
            Console.WriteLine("------------------------------------------------------------------");
            serializeTestCaseWithLock = true;
            Console.WriteLine("Singleton ***WITH*** lock - serialize test");
            singletonTestRunner.SerializableTest(serializeTestCaseWithLock);
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Singleton inheritance test");

            var singletonParent = Singleton.Instance;
            Singleton squareSingleton = SingletonSquare.Squareingleton;
            Singleton rectangleSingleton = SingletonRectangle.RectangleSingleton;
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Call GetName Function from main class:");
            Console.WriteLine($"name: {singletonParent.GetName()},\n type: {singletonParent.GetType()}\n");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Call GetName Function from derived class square:");
            Console.WriteLine($"name: {squareSingleton.GetName()},\n type: {squareSingleton.GetType()} \n");
            Console.WriteLine("Call GetName Function from derived class rectangle:");
            Console.WriteLine($"name: {rectangleSingleton.GetName()},\ntype: {rectangleSingleton.GetType()} \n");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine( "Call GetName Function from derived class'GenericShape'\nwhich inherit from main class.\nIt has generic functionality derived from class that inherit from Singleton. 'CurrentType.GetName()'\n");
            Console.WriteLine("******************************************************************");
            Console.WriteLine($"name : {square.GetName()},\n type: {square.GetType()}\n");
            Console.WriteLine($"name : {rectangle.GetName()},\n type: {rectangle.GetType()}\n");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\n\nTask Test run");

            var t1 = new SingletonThreadTest("1.");
            var t2 = new SingletonThreadTest("2.");
            var t3 = new SingletonThreadTest("3.");
            var t4 = new SingletonThreadTest("4.");
            var t5 = new SingletonThreadTest("5.");
            var t6 = new SingletonThreadTest("6.");
            var t7 = new SingletonThreadTest("7.");
            var t8 = new SingletonThreadTest("8.");
            var t9 = new SingletonThreadTest("9.");

            t1.Run();
            t2.Run();
            t3.Run();
            t4.Run();
            t5.Run();
            t6.Run();
            t7.Run();
            t8.Run();
            t9.Run();

            Console.WriteLine("------------------------------------------------------------------");

            t1.RunWithoutTaskWait();
            t2.RunWithoutTaskWait();
            t3.RunWithoutTaskWait();
            t4.RunWithoutTaskWait();
            t5.RunWithoutTaskWait();
            t6.RunWithoutTaskWait();
            t7.RunWithoutTaskWait();
            t8.RunWithoutTaskWait();
            t9.RunWithoutTaskWait();
            Thread.Sleep(10);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("OK!\npozdrowienia.");
        }
    }
}