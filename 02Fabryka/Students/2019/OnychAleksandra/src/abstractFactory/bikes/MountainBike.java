package abstractFactory.bikes;

import abstractFactory.factory.PartsFactory;
import model.BikeType;

public class MountainBike extends Bike {
    PartsFactory partsFactory;

    public MountainBike(PartsFactory partsFactory) {
        this.partsFactory = partsFactory;
        this.type = BikeType.MOUNTAIN;
    }

    public void prepareParts() {
        System.out.println("Preparing parts for " + getBrand());
        bell = partsFactory.createBell();
        basket = partsFactory.createBasket();
        lamp = partsFactory.createLamp();
    }
}
