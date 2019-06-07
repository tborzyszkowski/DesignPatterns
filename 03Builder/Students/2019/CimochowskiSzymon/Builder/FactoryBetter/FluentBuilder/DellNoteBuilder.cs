using Builder.FactoryBetter.FluentBuilder.Computers;

namespace Builder.FactoryBetter.FluentBuilder
{
    class DellNoteBuilder : NotebookBuilder
    {
        public DellNoteBuilder()
        {
            _notebook = CreateNotebook();
        }

        public Notebook GetNotebook()
        {
            return _notebook;
        }

        public override Notebook CreateNotebook()
        {
            return new Notebook{Manufacturer = "Dell", Model = "Latitude"};
        }

        public override NotebookBuilder SetCountry()
        {
            _notebook.Country = "USA";
            return this;
        }

        public override NotebookBuilder SetProdYear()
        {
            _notebook.ProdYear = 2019;
            return this;
        }

        public override NotebookBuilder SetPrice()
        {
            _notebook.Price = 3299;
            return this;
        }

        public override NotebookBuilder SetInches()
        {
            _notebook.Inches = 15;
            return this;
        }
    }
}
