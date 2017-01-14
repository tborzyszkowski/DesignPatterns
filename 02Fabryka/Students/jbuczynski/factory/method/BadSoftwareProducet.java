package factory.method;

/**
 * Created by jakub on 1/14/17.
 */
public class BadSoftwareProducet implements SoftwareProducer {

    @Override
    public Product developProduct(ProductType type) {
        return new ShoddyProduct(type);
    }
}
