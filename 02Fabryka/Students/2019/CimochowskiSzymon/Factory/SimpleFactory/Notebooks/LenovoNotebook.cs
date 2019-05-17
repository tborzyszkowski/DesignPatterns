using System;

namespace Factory.SimpleFactory.Notebooks
{
    class LenovoNotebook : Notebook
    {
        public LenovoNotebook()
        {
            Manufacturer = "Lenovo";
            Model = "Thinkpad";
            Country = "China";
            ProdYear = 2013;
            Price = 1099;
            Inches = 17.3;
        }

        public new void setUp()
        {
            Console.WriteLine("Setting up Lenovo Notebook software.");
        }

        public new void build()
        {
            Console.WriteLine("Building Lenovo Notebook construction.");
        }
    }
}
