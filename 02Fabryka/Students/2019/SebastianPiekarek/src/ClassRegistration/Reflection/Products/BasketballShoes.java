package ClassRegistration.Reflection.Products;


import ClassRegistration.Reflection.ReflectionFactory;

public class BasketballShoes extends Shoes {

    static {
        ReflectionFactory reflectionFactory = ReflectionFactory.getReflectionFactory();
        reflectionFactory.registerProduct("Koszykówka", BasketballShoes.class);
    }

    public BasketballShoes(){
        brand = "NIKE";
        name = "Air Jordan";
        price = 849f;
        color = "CZERWONY";
        weight = 259;
    }

}