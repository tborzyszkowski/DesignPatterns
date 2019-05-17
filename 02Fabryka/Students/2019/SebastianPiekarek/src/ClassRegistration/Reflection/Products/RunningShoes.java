package ClassRegistration.Reflection.Products;


import ClassRegistration.Reflection.ReflectionFactory;

public class RunningShoes extends Shoes {

    static {
        ReflectionFactory reflectionFactory = ReflectionFactory.getReflectionFactory();

        reflectionFactory.registerProduct("Bieganie", RunningShoes.class);
    }

    public RunningShoes(){
        brand = "NIKE";
        name = "Air Zoom Pegasus";
        price = 499f;
        weight = 254;
        color = "BIAŁY";

    }

}
