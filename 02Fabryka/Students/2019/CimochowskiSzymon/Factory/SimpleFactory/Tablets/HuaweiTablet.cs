using System;

namespace Factory.SimpleFactory.Tablets
{
    class HuaweiTablet : Tablet
    {
        public HuaweiTablet()
        {
            Manufacturer = "Huawei";
            Model = "Media Pad X2";
            Country = "China";
            ProdYear = 2018;
            Price = 1499;
            OperatingSystem = "Android 9";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Huawei Tablet software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Huawei Tablet construction.");
        }
    }
}
