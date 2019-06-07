using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.FluentBuilder.Computers;

namespace Builder.FactoryBetter.FluentBuilder
{
    class AsusNoteBuilder : NotebookBuilder
    {
        public AsusNoteBuilder()
        {
            _notebook = CreateNotebook();
        }

        public Notebook GetNotebook()
        {
            return _notebook;
        }

        public override Notebook CreateNotebook()
        {
            return new Notebook {Manufacturer = "ASUS", Model = "ZenBook"};
        }

        public override NotebookBuilder SetCountry()
        {
            _notebook.Country = "Taiwan";
            return this;
        }

        public override NotebookBuilder SetProdYear()
        {
            _notebook.ProdYear = 2017;
            return this;
        }

        public override NotebookBuilder SetPrice()
        {
            _notebook.Price = 2499;
            return this;
        }

        public override NotebookBuilder SetInches()
        {
            _notebook.Inches = 15.6;
            return this;
        }
    }
}
