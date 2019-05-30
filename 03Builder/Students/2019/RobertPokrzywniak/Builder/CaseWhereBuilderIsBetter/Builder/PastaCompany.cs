using Builder.CaseWhereBuilderIsBetter.Builder.Carbohydrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.CaseWhereBuilderIsBetter.Builder
{
    class PastaCompany
    {
        public void Construct(PastaBuilder pastaBuilder)
        {
            pastaBuilder.SetType();
        }
    }
}
