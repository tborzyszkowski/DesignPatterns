using System;
namespace FabrykaWytworcza
{
	public class EuropeanAudi : Car
	{
		public EuropeanAudi()
		{
			Producent = "Audi";
			Model = "A3";
			PojemnoscSilnika = 1.6;
			Wlasciwosci.Add("LPG");
			Wlasciwosci.Add("Manual gearbox");
		}
	}
}
