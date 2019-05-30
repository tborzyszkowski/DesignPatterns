using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;

namespace Builder.CaseWhereFactoryIsBetter.Builder
{
    class MilletGroatBuilder : GroatBuilder
    {
        public MilletGroatBuilder()
        {
            _groat = CreateGroat();
        }

        public Groat GetGroat()
        {
            return _groat;
        }

        public override Groat CreateGroat()
        {
            return new MilletGroat { Producer = "Sonko", Name = "kasza jaglana Sonko" };
        }

        public override GroatBuilder SetType()
        {
            _groat.Type = "kasza jaglana";
            return this;
        }

        public override GroatBuilder SetWeight()
        {
            _groat.Weight = 450;
            return this;
        }

        public override GroatBuilder SetPrice()
        {
            _groat.Price = 3.4;
            return this;
        }
    }
}
