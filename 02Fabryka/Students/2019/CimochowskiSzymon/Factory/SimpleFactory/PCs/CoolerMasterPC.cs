using System;

namespace Factory.SimpleFactory.PCs
{
    class CoolerMasterPC : PC
    {
        public CoolerMasterPC()
        {
            Manufacturer = "Cooler Master";
            Model = "H1000";
            Country = "Taiwan";
            ProdYear = 2016;
            Price = 2799;
            CaseType = "ATX Mid Tower";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Cooler Master PC software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Cooler Master PC construction.");
        }
    }
}
