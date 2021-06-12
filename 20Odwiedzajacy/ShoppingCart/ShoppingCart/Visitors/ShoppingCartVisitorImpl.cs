using ShoppingCart.Data;

namespace ShoppingCart.Visitors
{
	public class ShoppingCartVisitorImpl : ShoppingCartVisitor
	{
		public int Visit(Book book) => (book.Price > 50) ? book.Price - 5 : book.Price;

		public int Visit(Fruit fruit) => fruit.PricePerKg * fruit.Weight;
	}
}
