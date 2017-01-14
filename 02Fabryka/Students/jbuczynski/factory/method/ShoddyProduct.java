package factory.method;

/**
 * Created by jakub on 1/14/17.
 */
public class ShoddyProduct implements Product {

    private ProductType productType;

    public ShoddyProduct(ProductType productType) {
        this.productType = productType;
    }

    @Override
    public ProductType getProductType() {
        return productType;
    }

    @Override
    public String toString() {
        return " uuh shame on producent ";
    }
}
