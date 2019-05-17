using System;

namespace Factory.SimpleFactory.PCs
{
    class NZXTPC : PC
    {
        public NZXTPC()
        {
            Manufacturer = "NZXT";
            Model = "H500";
            Country = "Taiwan";
            ProdYear = 2013;
            Price = 2299;
            CaseType = "Home Theater Computer Case";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up NZXT PC software.");
        }

        public new void build()
        {
            Console.WriteLine("Building NZXT PC construction.");
        }
    }
}
