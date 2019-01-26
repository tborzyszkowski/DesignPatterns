using NUnit.Framework;
using Prototype.zad1;
using System.Collections.Generic;

namespace Tests
{
    public class Zad1
    {
        ShoppingCartManager manager;

        [SetUp]
        public void Setup()
        {
            Product car = new Product("Samochód", 70000);

            manager = new ShoppingCartManager();
            manager.Add("father", new ShoppingCart(new List<Product> { car }));
        }

        [Test]
        public void ShallowCopyOfCart_CartsNotSame()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.ShallowCopy() as ShoppingCart;

            Assert.AreNotSame(fathersCart, unclesCart);
        }

        [Test]
        public void ShallowCopyOfCart_ProductsInCartSame()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.ShallowCopy() as ShoppingCart;

            Product fathersProduct = fathersCart.Products[0];
            Product unclesProduct = unclesCart.Products[0];

            Assert.AreSame(fathersProduct, unclesProduct);
        }

        [Test]
        public void DeepCopyOfCart_ProductsInCartNotSame()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.DeepCopy() as ShoppingCart;

            Product fathersProduct = fathersCart.Products[0];
            Product unclesProduct = unclesCart.Products[0];

            Assert.AreNotSame(fathersProduct, unclesProduct);
        }


        [Test]
        public void ShallowCopyOfCart_RemovingProductFromBothCarts()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.ShallowCopy() as ShoppingCart;

            unclesCart.RemoveFromCart(unclesCart.Products[0]);

            Assert.AreEqual(fathersCart.Products.Count, unclesCart.Products.Count);
        }

        [Test]
        public void DeepCopyOfCart_RemovingProductFromOneCart()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.DeepCopy() as ShoppingCart;

            unclesCart.RemoveFromCart(unclesCart.Products[0]);

            Assert.AreNotEqual(fathersCart.Products.Count, unclesCart.Products.Count);
        }
    }
}