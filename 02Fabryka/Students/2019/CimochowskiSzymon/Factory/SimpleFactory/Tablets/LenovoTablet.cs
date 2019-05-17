using System;

namespace Factory.SimpleFactory.Tablets
{
    class LenovoTablet : Tablet
    {
        public LenovoTablet()
        {
            Manufacturer = "Lenovo";
            Model = "Yoga Tab 2";
            Country = "China";
            ProdYear = 2014;
            Price = 999;
            OperatingSystem = "Windows 8.1";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Lenovo Tablet software.");
        }
        public new void build()
        {
            Console.WriteLine("Building Lenovo Tablet construction.");
        }
    }
}
