using System;

namespace FabrykaAbstrakcyjna
{
	class MainClass
	{
		public static void Main()
		{
			CarFactory europe = new EuropeanCarFactory();
			CarShop world = new CarShop(europe);
			world.ShowOffer();

			CarFactory america = new AmericanCarFactory();
			world = new CarShop(america);
			world.ShowOffer();

			Console.ReadKey();
		}
	}
}