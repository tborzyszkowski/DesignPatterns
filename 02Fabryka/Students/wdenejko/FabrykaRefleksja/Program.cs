namespace FabrykaRefleksja
{
	class MainClass
	{
		public static void Main(string[] args)
		{
		    var car = CarShop.GetCar<Audi>();
		    var anotherCar = CarShop.GetCar("FabrykaRefleksja.Vw");
            car.Produce();
            anotherCar.Produce();
		}
	}
}
