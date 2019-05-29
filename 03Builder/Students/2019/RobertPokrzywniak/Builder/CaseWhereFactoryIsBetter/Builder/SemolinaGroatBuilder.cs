using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;

namespace Builder.CaseWhereFactoryIsBetter.Builder
{
    class SemolinaGroatBuilder : GroatBuilder
    {
        public SemolinaGroatBuilder()
        {
            _groat = CreateGroat();
        }

        public Groat GetGroat()
        {
            return _groat;
        }

        public override Groat CreateGroat()
        {
            return new SemolinaGroat { Producer = "Kupiec", Name = "kasza manna Sonko" };
        }

        public override GroatBuilder SetType()
        {
            _groat.Type = "kasza manna";
            return this;
        }

        public override GroatBuilder SetWeight()
        {
            _groat.Weight = 320;
            return this;
        }

        public override GroatBuilder SetPrice()
        {
            _groat.Price = 1.4;
            return this;
        }
    }
}
