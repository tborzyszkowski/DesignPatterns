using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.CaseWhereBuilderIsBetter.Builder.Carbohydrates;

namespace Builder.CaseWhereBuilderIsBetter.Builder
{
    class SonkoPastaBuilder : PastaBuilder
    {
        public SonkoPastaBuilder()
        {
            _pasta = new Pasta {Producer = "Sonko", Name = "Makaron spaghetti Sonko"};
        }

        public override void SetType()
        {
            _pasta.Type = "Spaghetti";
        }
    }
}
