using Ceramics.Ceramics;
using Ceramics.Decorator;
using Ceramics.Factories;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class FacrtoryTests
    {
        [Test]
        public void TestFactoryPoland()
        {
            CerluxPoland cerluxPoland = CerluxPoland.Instance;

            var a = (PlateDecorator)cerluxPoland.PurchasePlate("SmallPlate");
            var x = a.Plate;
            
            Assert.AreEqual(typeof(SmallPLate), x.GetType());

            Assert.IsInstanceOf<SmallPLate>(x);
        }

        [Test]
        public void TestFactoryPolandCheckNameAfterPrepare()
        {
            CerluxPoland cerluxPoland = CerluxPoland.Instance;

            var a = (PlateDecorator)cerluxPoland.PurchasePlate("SmallPlate");
            a.Prepare();
            var x = a.Plate;

            Assert.AreEqual("SmallPlate", x.name);
        }

        [Test]
        public void TestFactoryPolandCheckNameAfterPrepare1()
        {
            CerluxPoland cerluxPoland = CerluxPoland.Instance;

            var a = (PlateDecorator)cerluxPoland.PurchasePlate("SmallPlate");
            a.Prepare();
            var x = a.Plate;

            Assert.AreEqual(4.50, x.price);
        }

        [Test]
        public void TestFactoryChina()
        {
            TaociChina taociChina = TaociChina.Instance;

            var a = (PlateDecorator)taociChina.PurchasePlate("SmallPlate");
            var x = a.Plate;

            Assert.AreEqual(typeof(SmallPLate), x.GetType());

            Assert.IsInstanceOf<SmallPLate>(x);
        }

        [Test]
        public void TestFactoryChinaCheckNameAfterPrepare()
        {
            TaociChina taociChina = TaociChina.Instance;

            var a = (PlateDecorator)taociChina.PurchasePlate("SmallPlate");
            a.Prepare();
            var x = a.Plate;

            Assert.AreEqual("SmallPlate", x.name);
        }

        [Test]
        public void TestFactoryChinaCheckNameAfterPrepare1()
        {
            TaociChina taociChina = TaociChina.Instance;

            var a = (PlateDecorator)taociChina.PurchasePlate("SmallPlate");
            a.Prepare();
            var x = a.Plate;

            Assert.AreEqual(4.50, x.price);
        }
    }
}