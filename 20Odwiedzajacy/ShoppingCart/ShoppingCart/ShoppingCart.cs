using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data;
using ShoppingCart.Visitors;

namespace ShoppingCart
{
	public class Cart
	{
		private List<CartItem> _cartItems = new List<CartItem>();

		public Cart Attach(CartItem cartItem)
		{
			_cartItems.Add(cartItem);
			return this;
		}

		public Cart Detach(CartItem cartItem)
		{
			_cartItems.Remove(cartItem);
			return this;
		}

		public int CalculatePrice()
		{
			var visitor = new ShoppingCartVisitorImpl();
			return _cartItems.Select(cartItem => cartItem.Accept(visitor)).Sum();
		}
	}
}
