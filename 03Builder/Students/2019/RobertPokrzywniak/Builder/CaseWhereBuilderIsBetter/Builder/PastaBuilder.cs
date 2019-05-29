using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.CaseWhereBuilderIsBetter.Builder.Carbohydrates;

namespace Builder.CaseWhereBuilderIsBetter.Builder
{
    public abstract class PastaBuilder
    {
        protected Pasta _pasta;
        public Pasta Pasta => _pasta;
        public abstract void SetType();
    }
}
