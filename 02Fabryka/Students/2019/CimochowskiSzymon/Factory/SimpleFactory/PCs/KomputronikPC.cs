using System;

namespace Factory.SimpleFactory.PCs
{
    class KomputronikPC : PC
    {
        public KomputronikPC()
        {
            Manufacturer = "Komputronik";
            Model = "XT50";
            Country = "Poland";
            ProdYear = 2018;
            Price = 4499;
            CaseType = "ATX Full Tower";
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Komputronik PC software.");
        }
        public new void build()
        {
            Console.WriteLine("Building Komputronik PC construction.");
        }
    }
}
