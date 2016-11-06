using System;
namespace FabrykaWytworcza
{
	public class EuropeanVw : Car
	{
		public EuropeanVw()
		{
			Producent = "Vw";
			Model = "Golf";
			PojemnoscSilnika = 1.6;
			Wlasciwosci.Add("Diesel");
			Wlasciwosci.Add("Manual gearbox");
		}
	}
}
