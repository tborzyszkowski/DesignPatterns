package ClassRegistration.NoReflection.Products;


public class BasketballShoes extends Shoes {



    public BasketballShoes(){
        brand = "NIKE";
        name = "Air Jordan";
        price = 849f;
        color = "CZERWONY";
        weight = 259;
    }

    @Override
    public Shoes createProduct() {
        return new BasketballShoes();
    }
}