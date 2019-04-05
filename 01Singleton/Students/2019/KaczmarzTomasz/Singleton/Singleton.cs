using System;

namespace SingletonPattern
{
	public sealed class Singleton
	{
		public static int counter = 0;

		private static Singleton instance = null;
		private static readonly object padlock = new object();

		public static Singleton Instance
		{
			get
			{
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new Singleton();
							Console.WriteLine("Singleton instance initiated");
						}
					}
				}
				
				return instance;
			}
		}

		private Singleton() { counter++; }
	}
}