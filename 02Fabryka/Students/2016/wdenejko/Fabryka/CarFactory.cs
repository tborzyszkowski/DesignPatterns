using System;
namespace Fabryka
{
	public class CarFactory
	{
		public Car CreateCar(String type)
		{
			Car samochod = null;

			if (type.Equals("audi"))
			{
				samochod = new Audi();
			}
			else if (type.Equals("vw"))
			{
				samochod = new Vw();
			}

			return samochod;
		}
	}
}
