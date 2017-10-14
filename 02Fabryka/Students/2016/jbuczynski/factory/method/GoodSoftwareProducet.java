package factory.method;

/**
 * Created by jakub on 1/14/17.
 */
public class GoodSoftwareProducet implements SoftwareProducer {
    @Override
    public Product developProduct(ProductType type) {
        return new BrilliantProduct(type);
    }
}
