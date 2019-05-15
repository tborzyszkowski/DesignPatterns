package builderWins.factory;

public abstract class CarBase {
    public String brand;
    public String model;
    public String engine;
    public String productionYear;
    public String fuelType;
    public boolean radio;
    public boolean airConditioning;

    @Override
    public String toString() {
        return "CarBase{" +
                "brand='" + brand + '\'' +
                ", model='" + model + '\'' +
                ", engine='" + engine + '\'' +
                ", productionYear='" + productionYear + '\'' +
                ", fuelType='" + fuelType + '\'' +
                ", radio=" + radio +
                ", airConditioning=" + airConditioning +
                '}';
    }
}
