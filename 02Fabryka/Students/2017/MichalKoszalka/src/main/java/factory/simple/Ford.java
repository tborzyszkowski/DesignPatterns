package factory.simple;

public class Ford {

    protected static final String brand = "Car";
    protected String model;
    protected BodyType bodyType;


    public String getModel() {
        return model;
    }

    public void refuel() {
        System.out.println("refueling car");
    }

    public void prepareTires() {
        System.out.println("prepare both winter and summer tires");
    }

}
