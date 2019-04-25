package abstractFactory.bikes;

import abstractFactory.factory.PartsFactory;
import model.BikeType;

public class CrossBike extends Bike {
    PartsFactory partsFactory;

    public CrossBike(PartsFactory partsFactory) {
        this.partsFactory = partsFactory;
        this.type = BikeType.CROSS;
    }

    public void prepareParts() {
        System.out.println("Preparing parts for " + getBrand());
        bell = partsFactory.createBell();
        basket = partsFactory.createBasket();
        lamp = partsFactory.createLamp();
    }
}
