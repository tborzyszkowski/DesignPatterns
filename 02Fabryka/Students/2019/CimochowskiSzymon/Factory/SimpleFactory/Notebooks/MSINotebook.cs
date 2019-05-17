using System;

namespace Factory.SimpleFactory.Notebooks
{
    class MSINotebook : Notebook
    {
        public MSINotebook()
        {
            Manufacturer = "MSI";
            Model = "GE72 Leopard Pro";
            Country = "Taiwan";
            ProdYear = 2018;
            Price = 3999;
            Inches = 17.3;
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up MSI Notebook software.");
        }

        public new void build()
        {
            Console.WriteLine("Building MSI Notebook construction.");
        }
    }
}
