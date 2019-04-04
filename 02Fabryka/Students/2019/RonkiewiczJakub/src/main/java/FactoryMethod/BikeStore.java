package FactoryMethod;

import Products.Bicycles.BikeRS;
import Products.Bicycles.Endurace;
import Products.Bicycles.SilverBullet;
import Products.Vehicle;

public class BikeStore extends VehicleStore {
    private static BikeStore instance;

    private BikeStore() {}

    public static BikeStore getInstance() {
        if(instance == null)
            instance = new BikeStore();
        return instance;
    }

    @Override
    Vehicle createVehicle(String model) {
        model = model.toLowerCase();

        if(model.equals("bikers")){
            return new BikeRS();
        } else if(model.equals("endurace")){
            return new Endurace();
        } else if(model.equals("silverbullet")){
            return new SilverBullet();
        } else return null;
    }
}
