using System;

namespace Factory.SimpleFactory.Tablets
{
    class MicrosoftTablet : Tablet
    {
        public MicrosoftTablet()
        {
            Manufacturer = "Microsoft";
            Model = "Surface Pro 4";
            Country = "USA";
            ProdYear = 2019;
            Price = 3099;
            OperatingSystem = "Windows 10";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Microsoft Tablet software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Microsoft Tablet construction.");
        }
    }
}
