using Ceramics.Ceramics;
using Ceramics.Decorator;
using Ceramics.Factories;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class DecoratorTest
    {

        [Test]
        public void TestDecoratorNumberOfELements()
        {

            ICeramicsFactory ceramicsFactory = new FactoryCerluxPoland();
            Plate plateIn = new PlateDecorator(new SmallPLate(
                ceramicsFactory)) as PlateDecorator;
            plateIn.Prepare();
            plateIn.Firing();

            Assert.AreEqual(1, PlateDecorator.NumberOfPlate);

        }
        [Test]
        public void TestDecoratorPricaSum()
        {
            
            ICeramicsFactory ceramicsFactory = new FactoryCerluxPoland();
            Plate plateIn = new PlateDecorator(new SmallPLate(ceramicsFactory)) as PlateDecorator;
           // plateIn.Prepare();
            //plateIn.Firing();

            Assert.AreEqual(4.5, PlateDecorator.PriceOfPlates1);

        }

        


    }
}