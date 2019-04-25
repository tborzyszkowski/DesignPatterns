package abstractFactory.shop;

import abstractFactory.bikes.*;
import abstractFactory.factory.PartsFactory;
import abstractFactory.factory.PolishPartsFactory;
import model.BikeType;

public class PolishBikeShop extends BikeShop {

    protected Bike createBike(BikeType type) {
        PartsFactory partsFactory = PolishPartsFactory.getInstance();
        Bike bike = null;

        switch (type) {
            case CITY: {
                bike = new CityBike(partsFactory);
                bike.setBrand("Merida");
                bike.setEngine(false);
                bike.setWheels("27");
                bike.setFrame("aluminiowa");
                return bike;
            }
            case CROSS: {
                bike = new CrossBike(partsFactory);
                bike.setBrand("DHS");
                bike.setEngine(false);
                bike.setWheels("28");
                bike.setFrame("tytanowa");
                return bike;
            }
            case ELECTRIC: {
                bike = new ElectricBike(partsFactory);
                bike.setBrand("Arkus");
                bike.setEngine(true);
                bike.setWheels("28");
                bike.setFrame("tytanowa");
                return bike;
            }
            case KIDS: {
                bike = new KidsBike(partsFactory);
                bike.setBrand("Merida");
                bike.setEngine(false);
                bike.setWheels("22");
                bike.setFrame("aluminiowa");
                return bike;
            }
            case MOUNTAIN: {
                bike = new MountainBike(partsFactory);
                bike.setBrand("Devron");
                bike.setEngine(false);
                bike.setWheels("28");
                bike.setFrame("stalowa");
                return bike;
            }
            default:
                return bike;
        }
    }
}
