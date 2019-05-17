using System;

namespace Factory.SimpleFactory.PCs
{
    class IBMPC : PC
    {
        public IBMPC()
        {
            Manufacturer = "IBM";
            Model = "PC64";
            Country = "USA";
            ProdYear = 1999;
            Price = 1099;
            CaseType = "ATX Mini Tower";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up IBM PC software.");
        }

        public new void build()
        {
            Console.WriteLine("Building IBM PC Construction");
        }
    }
}
