using System;
namespace Fabryka
{
	public class Audi : Car
	{
		public Audi()
		{
			Producent = "Audi";
			Model = "A3";
			PojemnoscSilnika = 1.6;
			Wlasciwosci.Add("LPG");
			Wlasciwosci.Add("Centralny zamek");
			Wlasciwosci.Add("Cuda na kiju");
		}
	}
}
