using System;
namespace Fabryka
{
	public class Vw : Car
	{
		public Vw()
		{
			Producent = "Vw";
			Model = "Golf";
			PojemnoscSilnika = 2.0;
			Wlasciwosci.Add("Diesel");
			Wlasciwosci.Add("Dres w zestawie");
			Wlasciwosci.Add("tez cuda na kiju");
		}
	}
}
