using System;

namespace Factory.SimpleFactory.PCs
{
    class HPPC : PC
    {
        public HPPC()
        {
            Manufacturer = "HP";
            Model = "Desktop Pro G2";
            Country = "USA";
            ProdYear = 2019;
            Price = 2399;
            CaseType = "ATX Desktop";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up HP PC software.");
        }

        public new void build()
        {
            Console.WriteLine("Building HP PC construction.");
        }
    }
}
