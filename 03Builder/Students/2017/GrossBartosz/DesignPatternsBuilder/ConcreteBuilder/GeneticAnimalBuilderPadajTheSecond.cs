using DesignPatternsBuilder.Builder;
using DesignPatternsBuilder.Product;

namespace DesignPatternsBuilder.ConcreteBuilder
{
    public class GeneticAnimalBuilderPadajTheSecond : ZooBuilder
    {
        public GeneticAnimalBuilderPadajTheSecond()
        {
            this.animal = new Animal("Cat");
        }

        public override ZooBuilder BuildBody()
        {
            animal["body"] = "Kevlar";
            return this;
        }

        public override ZooBuilder BuildHands()
        {
            animal["hands"] = "Titanium";
            return this;
        }

        public override ZooBuilder BuildHead()
        {
            animal["head"] = "Model V2 Rocket";
            return this;
        }

        public override ZooBuilder BuildLegs()
        {
            animal["legs"] = "Ulitimate diamond drill";
            return this;
        }
    }
}
