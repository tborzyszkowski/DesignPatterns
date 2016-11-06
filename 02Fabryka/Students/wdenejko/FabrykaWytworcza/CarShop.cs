using System;
namespace FabrykaWytworcza
{
	public abstract class CarShop
	{
		public abstract Car CreateCar(string item);

		public abstract Car OrderCar(string type);
	}
}
