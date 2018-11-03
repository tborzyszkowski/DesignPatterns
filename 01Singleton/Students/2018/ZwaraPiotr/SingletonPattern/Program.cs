using System;
using System.Diagnostics;
using System.Threading.Tasks;

using SingletonPattern.ZadA;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            // ====== SingletonGetterLock =======

            stopwatch.Start();

            SingletonGetterLock singleton1 = null;
            Parallel.For(0, 10, task =>
            {
                for (int i = 0; i < 1_000_000; i++)
                    singleton1 = SingletonGetterLock.Instance;
            });

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for SingletonGetterLock: {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            // ====== SingletonDoubleCheck ======

            stopwatch.Start();

            SingletonDoubleCheck singleton2 = null;
            Parallel.For(0, 10, task =>
            {
                for (int i = 0; i < 1_000_000; i++)
                    singleton2 = SingletonDoubleCheck.Instance;
            });

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for SingletonDoubleCheck: {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            // ====== SingletonLazy =============

            stopwatch.Start();

            SingletonLazy singleton3 = null;
            Parallel.For(0, 10, task =>
            {
                for (int i = 0; i < 1_000_000; i++)
                    singleton3 = SingletonLazy.Instance;
            });

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for SingletonLazy: {stopwatch.ElapsedTicks}");

            Console.ReadKey();
        }
    }
}
