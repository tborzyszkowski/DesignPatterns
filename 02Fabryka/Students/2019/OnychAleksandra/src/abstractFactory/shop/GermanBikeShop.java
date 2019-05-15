package abstractFactory.shop;

import abstractFactory.bikes.*;
import abstractFactory.factory.GermanPartsFactory;
import abstractFactory.factory.PartsFactory;
import model.BikeType;

public class GermanBikeShop extends BikeShop {

    protected Bike createBike(BikeType type) {
        PartsFactory partsFactory = GermanPartsFactory.getInstance();
        Bike bike = null;

        switch (type) {
            case CITY: {
                bike = new CityBike(partsFactory);
                bike.setBrand("Devron");
                bike.setEngine(false);
                bike.setWheels("26");
                bike.setFrame("stalowa");
                return bike;
            }
            case CROSS:{
                bike = new CrossBike(partsFactory);
                bike.setBrand("Arkus");
                bike.setEngine(false);
                bike.setWheels("28");
                bike.setFrame("aluminiowa");
                return bike;
            }
            case ELECTRIC: {
                bike = new ElectricBike(partsFactory);
                bike.setBrand("DHS");
                bike.setEngine(true);
                bike.setWheels("29");
                bike.setFrame("stalowa");
                return bike;
            }
            case KIDS: {
                bike = new KidsBike(partsFactory);
                bike.setBrand("DHS");
                bike.setEngine(false);
                bike.setWheels("20");
                bike.setFrame("aluminiowa");
                return bike;
            }
            case MOUNTAIN: {
                bike = new MountainBike(partsFactory);
                bike.setBrand("Merida");
                bike.setEngine(false);
                bike.setWheels("29");
                bike.setFrame("tytanowa");
                return bike;
            }
            default:
                return bike;
        }
    }
}
