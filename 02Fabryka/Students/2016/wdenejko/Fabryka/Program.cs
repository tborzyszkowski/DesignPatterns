using System;

namespace Fabryka
{
	class MainClass
	{
		public static void Main()
		{
			var factory = new CarFactory();
			var shop = new CarShop(factory);

			var car = shop.OrderCar("audi");
			Console.WriteLine(car.GetType());

			car = shop.OrderCar("vw");
			Console.WriteLine(car.GetType());

			Console.ReadLine();
		}


	}
}
