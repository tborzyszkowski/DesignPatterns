using System;
namespace FabrykaAbstrakcyjna
{
	class CarShop
	{
		private Audi _audi;
		private Ford _ford;

		public CarShop(CarFactory factory)
		{
			_audi = factory.CreateAudi();
			_ford = factory.CreateFord();
		}

		public void ShowOffer()
		{
			_audi.PrintDetails();
			_ford.PrintDetails();
		}
	}
}
