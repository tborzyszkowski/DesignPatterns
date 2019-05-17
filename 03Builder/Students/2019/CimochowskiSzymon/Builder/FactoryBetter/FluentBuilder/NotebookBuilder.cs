using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.FluentBuilder.Computers;

namespace Builder.FactoryBetter.FluentBuilder
{
    public abstract class NotebookBuilder
    {
        protected Notebook _notebook;
        public Notebook Notebook => _notebook;
        public abstract Notebook CreateNotebook();
        public abstract NotebookBuilder SetCountry();
        public abstract NotebookBuilder SetProdYear();
        public abstract NotebookBuilder SetPrice();
        public abstract NotebookBuilder SetInches();

        public static implicit operator Notebook(NotebookBuilder epicBuild)
        {
            return epicBuild.SetCountry()
                .SetProdYear()
                .SetPrice()
                .SetInches()
                .Notebook;
        }
    }
}
