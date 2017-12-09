using System;
using System.Threading;
using System.Threading.Tasks;
using WzoreceProjektoweSingleton.SingletonBase;

namespace WzoreceProjektoweSingleton.Test
{
    /// <summary>
    /// The Singleton Thread Test.
    /// </summary>
    public class SingletonThreadTest
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string Name;

        /// <summary>
        /// The singleton instance.
        /// </summary>
        private Singleton singleton;

        /// <summary>
        /// The singleton With Lock instance.
        /// </summary>
        private SingletonWithLock singletonWithLock;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonThreadTest"/> class.
        /// </summary>
        /// <param name="name"></param>
        public SingletonThreadTest(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The run without task wait option test.
        /// </summary>
        public void RunWithoutTaskWait()
        {
            Console.WriteLine($"Thread {this.Name} start instructions");
            Console.WriteLine($"Run without task wait *** Thread {this.Name} Loading: singleton, singletonWithLock\n");

            try
            {
                Task t1 = new Task(delegate ()
                {
                    singleton = Singleton.Instance;
                    Console.Write($"singleton\n");
                    Thread.Sleep(3000);
                });

                Task t2 = new Task(delegate ()
                {
                    singletonWithLock = SingletonWithLock.Instance;
                    Console.Write("singletonWithLock\n");
                    Thread.Sleep(3000);
                });

                t1.Start();
                t2.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Thread {this.Name} - error");
                throw e;
            }
            Console.WriteLine($"Thread {this.Name} - finish work");
        }

        /// <summary>
        /// The base method test run.
        /// </summary>
        public void Run()
        {
            Console.WriteLine($"Thread {this.Name} start instructions");
            Console.WriteLine($"Run with waiting **** Thread {this.Name} Loading: singleton, singletonWithLock\n");

            try
            {
                Task t1 = new Task(delegate ()
                {
                    singleton = Singleton.Instance;
                    Console.Write($"singleton\n");
                    Thread.Sleep(3000);
                });
                Task t2 = t1.ContinueWith((t) =>
                {
                    singletonWithLock = SingletonWithLock.Instance;
                    Console.Write("singletonWithLock\n");
                    Thread.Sleep(3000);
                });

                t1.Start();
                t2.Wait();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Thread {this.Name} - error");
                throw e;
            }

            Console.WriteLine($"Thread {this.Name} - finish work.");
        }
    }
}
