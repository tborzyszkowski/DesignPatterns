package simple;

import model.Bike;
import model.BikeType;

public class SimpleBikeShop {
    private SimpleBikeFactory simpleBikeFactory;

    public SimpleBikeShop(SimpleBikeFactory simpleBikeFactory) {
        this.simpleBikeFactory = simpleBikeFactory.getInstance();
    }

    public Bike makeBike(BikeType type) {
        Bike bike = simpleBikeFactory.createBike(type);

        if (bike != null) {
            bike.prepareParts();
        }

        return bike;
    }
}
