using System;

namespace Factory.SimpleFactory.Notebooks
{
    class AcerNotebook : Notebook
    {
        public AcerNotebook()
        {
            Manufacturer = "Acer";
            Model = "Predator 500";
            Country = "China";
            ProdYear = 2019;
            Price = 6499;
            Inches = 16;
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Acer Notebook software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Acer Notebook construction.");
        }
    }
}
