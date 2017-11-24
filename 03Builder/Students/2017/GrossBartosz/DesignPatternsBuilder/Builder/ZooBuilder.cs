using DesignPatternsBuilder.Product;

namespace DesignPatternsBuilder.Builder
{
    public abstract class ZooBuilder
    {

        protected Animal animal;

        public Animal Animal => animal;

        public abstract ZooBuilder BuildHead();
        public abstract ZooBuilder BuildBody();
        public abstract ZooBuilder BuildHands();
        public abstract ZooBuilder BuildLegs();

        public static implicit operator Animal(ZooBuilder bs)
        {
            return bs.BuildBody().BuildHead()
            .BuildHands()
            .BuildLegs()
            .Animal;
        }
    }
}
