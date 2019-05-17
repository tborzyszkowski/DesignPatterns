package ClassRegistration.NoReflection.Products;



public class RunningShoes extends Shoes {



    public RunningShoes(){
        brand = "NIKE";
        name = "Air Zoom Pegasus";
        price = 499f;
        weight = 254;
        color = "BIAŁY";

    }

    @Override
    public Shoes createProduct() {
        return new RunningShoes();
    }
}
