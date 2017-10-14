package factory.method;

/**
 * Created by jakub on 1/14/17.
 */
public class BrilliantProduct implements Product {

    private ProductType productType;


    public BrilliantProduct(ProductType productType) {
        this.productType = productType;
    }

    @Override
    public ProductType getProductType() {
        return productType;
    }

    @Override
    public String toString() {
        return " what an excellent " + productType;
    }

}
