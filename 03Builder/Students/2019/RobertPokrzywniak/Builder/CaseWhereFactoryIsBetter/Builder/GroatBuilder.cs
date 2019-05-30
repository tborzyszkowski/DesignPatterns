using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.CaseWhereFactoryIsBetter.Builder
{
    public abstract class GroatBuilder
    {
        protected Groat _groat;
        public Groat Groat => _groat;
        public abstract Groat CreateGroat();
        public abstract GroatBuilder SetType();
        public abstract GroatBuilder SetWeight();
        public abstract GroatBuilder SetPrice();

        public static implicit operator Groat(GroatBuilder groatBuilder)
        {
            return groatBuilder
                .SetType()
                .SetWeight()
                .SetPrice()
                .Groat;
        }
    }
}
