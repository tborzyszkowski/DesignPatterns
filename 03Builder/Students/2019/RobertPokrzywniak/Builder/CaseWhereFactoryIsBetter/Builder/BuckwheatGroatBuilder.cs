using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.CaseWhereFactoryIsBetter.Builder
{
    class BuckwheatGroatBuilder : GroatBuilder
    {
        public BuckwheatGroatBuilder()
        {
            _groat = CreateGroat();
        }

        public Groat GetGroat()
        {
            return _groat;
        }

        public override Groat CreateGroat()
        {
            return new BuckwheatGroat { Producer = "Halina", Name = "kasza gryczana Halina" };
        }

        public override GroatBuilder SetType()
        {
            _groat.Type = "kasza gryczana";
            return this;
        }

        public override GroatBuilder SetWeight()
        {
            _groat.Weight = 500;
            return this;
        }

        public override GroatBuilder SetPrice()
        {
            _groat.Price = 5.4;
            return this;
        }
    }
}
