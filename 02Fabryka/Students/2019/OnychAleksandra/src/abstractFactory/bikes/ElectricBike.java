package abstractFactory.bikes;

import abstractFactory.factory.PartsFactory;
import model.BikeType;

public class ElectricBike extends Bike {
    PartsFactory partsFactory;

    public ElectricBike(PartsFactory partsFactory) {
        this.partsFactory = partsFactory;
        this.type = BikeType.ELECTRIC;
    }

    public void prepareParts() {
        System.out.println("Preparing parts for " + getBrand());
        bell = partsFactory.createBell();
        basket = partsFactory.createBasket();
        lamp = partsFactory.createLamp();
    }
}
