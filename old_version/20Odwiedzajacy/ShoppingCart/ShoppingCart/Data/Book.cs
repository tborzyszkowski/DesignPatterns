using System;
using ShoppingCart.Visitors;

namespace ShoppingCart.Data
{
	public class Book : CartItem
	{
		public int Price { get; set; }
		public String IsbnNumber { get; set; }

		public Book(int price, string isbnNumber)
		{
			Price = price;
			IsbnNumber = isbnNumber;
		}
		public int Accept(ShoppingCartVisitor visitor) => visitor.Visit(this);
	}
}
