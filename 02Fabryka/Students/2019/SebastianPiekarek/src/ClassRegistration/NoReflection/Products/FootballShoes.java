package ClassRegistration.NoReflection.Products;


public class FootballShoes extends Shoes {


    public FootballShoes(){
        brand = "NIKE";
        name = "Phantom Venom";
        price = 1149;
        color = "CZARNY";
        weight = 278;
    }

    @Override
    public Shoes createProduct() {
        return new FootballShoes();
    }
}