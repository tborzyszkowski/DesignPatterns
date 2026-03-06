using ShoppingCart.Data;

namespace ShoppingCart.Visitors
{
	public interface ShoppingCartVisitor
	{
		int Visit(Book book);
		int Visit(Fruit fruit);
	}
}
