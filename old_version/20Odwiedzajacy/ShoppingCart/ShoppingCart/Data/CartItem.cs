using ShoppingCart.Visitors;

namespace ShoppingCart.Data

{
	public interface CartItem
	{
		int Accept(ShoppingCartVisitor visitor);
	}
}
