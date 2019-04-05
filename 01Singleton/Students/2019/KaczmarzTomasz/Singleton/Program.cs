using System;
using System.Linq;
using System.Threading.Tasks;

namespace SingletonPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			if (InstancesSame())
				Console.WriteLine("Instances are same");
			else
				Console.WriteLine("Instances are different!");

			if (ThreadSafe())
				Console.WriteLine("One instance created");
			else
				Console.WriteLine("More instances created!");
			
			Console.ReadKey();
		}

		public static bool InstancesSame()
		{
			Singleton s1 = Singleton.Instance;
			Singleton s2 = Singleton.Instance;
			return s1 == s2;
		}

		public static bool ThreadSafe()
		{
			const int threads = 1000;
			Task[] tasks = new Task[threads];
			for (int i = 0; i < threads; i++)
			{
				tasks[i] = new Task(() => { Singleton s = Singleton.Instance; });
				tasks[i].Start();
			}

			tasks.AsParallel().ForAll((t) => t.Wait());

			if (Singleton.counter != 1)
				return false;
			else
				return true;
		}
	}
}