using DesignPatternsBuilder.Builder;
using DesignPatternsBuilder.Product;

namespace DesignPatternsBuilder.Director
{
    public class AniamalCreator
    {
        public Animal Construct(ZooBuilder zooBuilder)
        {
            return zooBuilder;
        }
    }
}
