package factory.method;

/**
 * Created by jakub on 1/14/17.
 */
public class Agent {

    SoftwareProducer softwareProducer;

    public Agent(SoftwareProducer softwareProducer) {
        this.softwareProducer = softwareProducer;
    }

    public Product requestProduct(ProductType pType) {
        return softwareProducer.developProduct(pType);
    }

}
