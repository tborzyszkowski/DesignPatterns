package abstractFactory.bikes;

import abstractFactory.factory.PartsFactory;
import model.BikeType;

public class CityBike extends Bike {
    PartsFactory partsFactory;

    public CityBike(PartsFactory partsFactory) {
        this.partsFactory = partsFactory;
        this.type = BikeType.CITY;
    }

    public void prepareParts() {
        System.out.println("Preparing parts for " + getBrand());
        bell = partsFactory.createBell();
        basket = partsFactory.createBasket();
        lamp = partsFactory.createLamp();
    }
}
