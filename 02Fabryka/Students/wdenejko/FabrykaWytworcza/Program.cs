using System;

namespace FabrykaWytworcza
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			CarShop europeanShop = new EuropeanCarShop();
			CarShop americanShop = new AmericanCarShop();

			Car car = europeanShop.OrderCar("audi");
			Console.WriteLine(string.Format("Janusz ordered: {0}", car.GetType()));

			car = americanShop.OrderCar("audi");
			Console.WriteLine(string.Format("John ordered: {0}", car.GetType()));

			car = americanShop.OrderCar("vw");
			Console.WriteLine(string.Format("Pope ordered: {0}", car.GetType()));

			car = europeanShop.OrderCar("vw");
			Console.WriteLine(string.Format("Grazynka ordered: {0}", car.GetType()));
		}
	}
}
