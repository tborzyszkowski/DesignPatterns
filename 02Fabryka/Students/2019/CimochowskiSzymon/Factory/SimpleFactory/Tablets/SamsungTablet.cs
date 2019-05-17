using System;

namespace Factory.SimpleFactory.Tablets
{
    class SamsungTablet : Tablet
    {
        public SamsungTablet()
        {
            Manufacturer = "Samsung";
            Model = "Galaxy Tab 3";
            Country = "South Korea";
            ProdYear = 2016;
            Price = 1299;
            OperatingSystem = "Android 8.1";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Samsung Tablet software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Samsung Tablet construction.");
        }
    }
}
