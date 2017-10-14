using System;
using System.Collections.Generic;

namespace FabrykaWytworcza
{
	public abstract class Car
	{
		protected string Producent;
		protected string Model;
		protected double PojemnoscSilnika;
		protected List<string> Wlasciwosci = new List<string>();

		public string GetProducent() {
			return Producent;
		}

		public void Prepare() {
			Console.WriteLine(string.Format("Producent: {0}, Marka: {1}, Pojemnosc: {2}, Wlasciwosci:", Producent, Model, PojemnoscSilnika));
			foreach (var dd in Wlasciwosci)
			{
				Console.WriteLine(dd);
			}
		}

		public override string ToString() {
			var result = string.Empty;
			Wlasciwosci.ForEach(d => result += d + ',');
			return string.Format("Producent: {0}, Marka: {1}, Pojemnosc: {2}, Wlasciwosci: {3}", Producent, Model, PojemnoscSilnika, result);
		}
	}
}
