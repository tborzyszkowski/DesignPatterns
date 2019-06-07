using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.FluentBuilder.Computers;

namespace Builder.FactoryBetter.FluentBuilder
{
    class NotebookFactory
    {
        public Notebook Make(NotebookBuilder notebookBuilder)
        {
            return notebookBuilder;
        }
    }
}
