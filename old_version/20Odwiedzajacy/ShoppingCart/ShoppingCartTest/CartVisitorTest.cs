using NUnit.Framework;
using ShoppingCart;
using ShoppingCart.Data;
using ShoppingCart.Visitors;

namespace ShoppingCartTest
{
	[TestFixture]
	public class CartVisitorTest
	{
		[Test]
		public void Cart_OneBookAndOneFruit_Total()
		{
			var cart = new Cart()
				.Attach(new Book(10, "SomeISBN"))
				.Attach(new Fruit("Apple", 10, 2));

			var total = cart.CalculatePrice();

			Assert.That(total, Is.EqualTo(30));
		}
	}
}
