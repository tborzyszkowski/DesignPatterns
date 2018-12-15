package AbstractFactory;

public class KIAFactory implements CarAbstractFactory{
    private String brandName;
    private String model;
    private String type;
    private String fuelType;
    private int price;

    public KIAFactory(String brandName, String model, String type, String fuelType, int price){
        this.brandName = brandName;
        this.model = model;
        this.type = type;
        this.fuelType = fuelType;
        this.price = price;
    }
    @Override
    public Car showCar() {
        return new Nissan(brandName, model, type, fuelType, price);
    }
}
