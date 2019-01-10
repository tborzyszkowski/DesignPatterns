package car.cars;

import lombok.ToString;

@ToString
public abstract class Car {

    protected String name;
    protected int productionYear;
    protected String model;
    protected String gearBoxType;

    public void createAllPartsOfTheCar() {
        System.out.println("PRODUCTION: =======================================");
        System.out.println("Add name: "+name);
        System.out.println("Add production year: "+productionYear);
        System.out.println("Add model: "+model);
        System.out.println("Add gearbox type: "+gearBoxType);
        System.out.println("Creating a car.");
    }

    public void sendCarToCLient() {
        System.out.println("Sending car to client.");
        System.out.println("END OF PRODUCTION: ================================");
        System.out.println("\n");
    }

    public void cleanCar(){
        System.out.println("Cleaning car.");
    }

    public void checkCar(){
        System.out.println("Checking car before sending to client.");
    }

}
