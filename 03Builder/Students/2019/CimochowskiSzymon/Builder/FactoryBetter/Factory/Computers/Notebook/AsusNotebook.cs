using System;

namespace Builder.FactoryBetter.Factory.Computers.Notebook
{
    public class AsusNotebook : Notebook
    {
        public AsusNotebook()
        {
            Manufacturer = "ASUS";
            Model = "ZenBook";
            Country = "Taiwan";
            ProdYear = 2017;
            Price = 2499;
            Inches = 15.6;
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up ASUS Notebook software.");
        }
        public new void build()
        {
            Console.WriteLine("Building ASUS Notebook construction.");
        }
    }
}
