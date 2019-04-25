package abstractFactory.shop;

import abstractFactory.bikes.Bike;
import model.BikeType;

public abstract class BikeShop {

    protected abstract Bike createBike(BikeType type);

    public Bike orderBike(BikeType type) {
        Bike bike = createBike(type);

        if (bike != null) {
            bike.prepareParts();
        }

        return bike;
    }

}
