using System;
namespace FabrykaWytworcza
{
	public class AmericanVw : Car
	{
		public AmericanVw()
		{
			Producent = "Vw";
			Model = "Golf";
			PojemnoscSilnika = 2.0;
			Wlasciwosci.Add("Diesel");
			Wlasciwosci.Add("Automatic gearbox");
		}
	}
}
