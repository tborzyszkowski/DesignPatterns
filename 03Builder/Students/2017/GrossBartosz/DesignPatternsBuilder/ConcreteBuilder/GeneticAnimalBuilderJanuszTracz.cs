using DesignPatternsBuilder.Builder;
using DesignPatternsBuilder.Product;

namespace DesignPatternsBuilder.ConcreteBuilder
{
    public class GeneticAnimalBuilderJanuszTracz : ZooBuilder
    {
        public GeneticAnimalBuilderJanuszTracz()
        {
            this.animal = new Animal("Pies");
        }

        public override ZooBuilder BuildBody()
        {
            animal["body"] = "Husky";
            return this;
        }

        public override ZooBuilder BuildHands()
        {
            animal["hands"] = "Pitbull";
            return this;
        }

        public override ZooBuilder BuildHead()
        {
            animal["head"] = "Some cute stuff";
            return this;
        }

        public override ZooBuilder BuildLegs()
        {
            animal["legs"] = "Pitbull";
            return this;
        }
    }
}
