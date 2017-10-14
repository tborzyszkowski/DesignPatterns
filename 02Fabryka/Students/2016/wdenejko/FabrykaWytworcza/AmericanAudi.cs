using System;
namespace FabrykaWytworcza
{
	public class AmericanAudi : Car
	{
		public AmericanAudi()
		{
			Producent = "Audi";
			Model = "A3";
			PojemnoscSilnika = 1.6;
			Wlasciwosci.Add("LPG");
			Wlasciwosci.Add("Automatic gearbox");
		}
	}
}
