package builderVsFactory.factory;

import builderVsFactory.Car;

public class KIA extends Car {
    public KIA(String brandName, String model, String type, String fuelType, int price) {
        this.brandName = brandName;
        this.model = model;
        this.type = type;
        this.fuelType = fuelType;
        this.price = price;
    }

}