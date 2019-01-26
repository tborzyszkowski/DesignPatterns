package AbstractFactory;

public class Nissan extends Car {
    private String brandName;
    private String model;
    private String type;
    private String fuelType;
    private int price;

    public Nissan(String brandName, String model, String type, String fuelType, int price) {
        this.brandName = brandName;
        this.model = model;
        this.type = type;
        this.fuelType = fuelType;
        this.price = price;
    }
    @Override
    public String getBrandName() {
        return this.brandName;
    }

    @Override
    public String getModel() {
        return this.model;
    }

    @Override
    public String getType() {
        return this.type;
    }
    @Override
    public String getFuelType() {
        return this.fuelType;
    }

    @Override
    public int getPrice() {
        return this.price;
    }

}
