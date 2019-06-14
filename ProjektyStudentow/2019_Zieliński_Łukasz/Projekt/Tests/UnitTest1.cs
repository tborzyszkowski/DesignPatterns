using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Factory;
using Projekt.Factory.Products;
using Projekt.Prototype;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void Create1()
        {
            AFactory factory = new Factory1(LocalFactory.Instance);
            var ship = factory.CreateChair();
            Assert.IsNotNull(ship);
        }
        
    }
}
