using System;
namespace FabrykaWytworcza
{
	public class AmericanCarShop : CarShop
	{
		public override Car CreateCar(string item)
		{
			if (item.Equals("audi"))
			{
				return new AmericanAudi();
			}
			else if (item.Equals("vw"))
			{
				return new AmericanVw();
			}
			else return null;
		}

		public override Car OrderCar(string type)
		{
			Car car = CreateCar(type);
			Console.WriteLine(string.Format("Creating american car of type {0}", type.GetType()));
			car.Prepare();

			return car;
		}
	}
}
