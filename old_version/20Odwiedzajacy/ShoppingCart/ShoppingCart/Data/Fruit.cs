using System;
using ShoppingCart.Visitors;


namespace ShoppingCart.Data
{
	public class Fruit : CartItem
	{
		public String Name { get; set; }
		public int PricePerKg { get; set; }
		public int Weight { get; set; }

		public Fruit(string name, int pricePerKg, int weight)
		{
			Name = name;
			PricePerKg = pricePerKg;
			Weight = weight;
		}
		public int Accept(ShoppingCartVisitor visitor) => visitor.Visit(this);
		
	}
}
