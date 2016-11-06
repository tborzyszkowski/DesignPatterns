using System;
namespace FabrykaWytworcza
{
	public class EuropeanCarShop : CarShop
	{
		public override Car CreateCar(string item)
		{
			if (item.Equals("audi"))
			{
				return new EuropeanAudi();
			}
			else if (item.Equals("vw"))
			{
				return new EuropeanVw();
			}
			else return null;
		}

		public override Car OrderCar(string type)
		{
			Car car = CreateCar(type);
			Console.WriteLine(string.Format("Creating european car of type {0}", type.GetType()));
			car.Prepare();

			return car;
		}
	}
}
