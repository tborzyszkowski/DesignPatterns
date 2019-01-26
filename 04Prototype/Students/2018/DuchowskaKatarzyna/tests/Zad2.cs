using NUnit.Framework;
using Prototype.zad2;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Zad2
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
        public void ShallowCopyOfCart_CurrencySame()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.ShallowCopy() as ShoppingCart;

            Currency fathersCurrency = fathersCart.Products[0].Price.Currency;
            Currency unclesCurrency = unclesCart.Products[0].Price.Currency;

            Assert.AreSame(fathersCurrency, unclesCurrency);
        }

        [Test]
        public void DeepCopyOfCart_CurrencyNotSame()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.DeepCopy() as ShoppingCart;

            Currency fathersCurrency = fathersCart.Products[0].Price.Currency;
            Currency unclesCurrency = unclesCart.Products[0].Price.Currency;

            Assert.AreNotSame(fathersCurrency, unclesCurrency);
        }

        [Test]
        public void ShallowCopyOfCart_CurrencyChangesInBothCarts()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.ShallowCopy() as ShoppingCart;
            
            fathersCart.Products[0].Price.Currency.CurrencyName = "PLN";
            unclesCart.Products[0].Price.Currency.CurrencyName = "USD";

            String fathersCurrency = fathersCart.Products[0].Price.Currency.CurrencyName;

            Assert.AreEqual(fathersCurrency, "USD");
        }

        [Test]
        public void DeepCopyOfCart_CurrencyChangesInOneCart()
        {
            ShoppingCart fathersCart = manager.Get("father");
            ShoppingCart unclesCart = fathersCart.DeepCopy() as ShoppingCart;

            fathersCart.Products[0].Price.Currency.CurrencyName = "PLN";
            unclesCart.Products[0].Price.Currency.CurrencyName = "USD";

            String fathersCurrency = fathersCart.Products[0].Price.Currency.CurrencyName;

            Assert.AreEqual(fathersCurrency, "PLN");
        }
    }
}