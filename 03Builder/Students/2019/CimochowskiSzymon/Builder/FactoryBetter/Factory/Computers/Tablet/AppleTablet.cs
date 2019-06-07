using System;

namespace Builder.FactoryBetter.Factory.Computers.Tablet
{
    class AppleTablet : Tablet
    {
        public AppleTablet()
        {
            Manufacturer = "Apple";
            Model = "iPad Pro";
            Country = "USA";
            ProdYear = 2019;
            Price = 1899;
            OperatingSystem = "iOS 12";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Apple Tablet software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Apple Tablet construction.");
        }
    }
}
