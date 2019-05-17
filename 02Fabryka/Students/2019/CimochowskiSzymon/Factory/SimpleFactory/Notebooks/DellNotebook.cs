using System;

namespace Factory.SimpleFactory.Notebooks
{
    class DellNotebook : Notebook
    {
        public DellNotebook()
        {
            Manufacturer = "Dell";
            Model = "Latitude";
            Country = "USA";
            ProdYear = 2019;
            Price = 3299;
            Inches = 15;
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Dell Notebook software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Dell Notebook construction.");
        }
    }
}
