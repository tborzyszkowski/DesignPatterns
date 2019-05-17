package ClassRegistration.Reflection.Products;


import ClassRegistration.Reflection.ReflectionFactory;

public class FootballShoes extends Shoes {
    static {
        ReflectionFactory reflectionFactory = ReflectionFactory.getReflectionFactory();

        reflectionFactory.registerProduct("Piłka nożna", FootballShoes.class);
    }

    public FootballShoes(){
        brand = "NIKE";
        name = "Phantom Venom";
        price = 1149;
        color = "CZARNY";
        weight = 278;
    }


}