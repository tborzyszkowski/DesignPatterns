package abstractFactory.bikes;

import abstractFactory.factory.PartsFactory;
import model.BikeType;

public class KidsBike extends Bike {
    PartsFactory partsFactory;

    public KidsBike(PartsFactory partsFactory) {
        this.partsFactory = partsFactory;
        this.type = BikeType.KIDS;
    }

    public void prepareParts() {
        System.out.println("Preparing parts for " + getBrand());
        bell = partsFactory.createBell();
        basket = partsFactory.createBasket();
        lamp = partsFactory.createLamp();
    }
}
