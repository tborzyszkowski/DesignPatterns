using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.CaseWhereFactoryIsBetter.Builder
{
    class GroatFactory
    {
        public Groat Construct(GroatBuilder groatBuilder)
        {
            return groatBuilder;
        }
    }
}
