using System;
namespace Fabryka
{
	public class CarShop
	{
		public CarFactory Factory;

		public CarShop(CarFactory factory)
		{
			this.Factory = factory;
		}

		public Car OrderCar(String producent)
		{
			Car car;
			car = Factory.CreateCar(producent);

			car.Prepare();
			car.ToString();
			return car;
		}
	}
}
