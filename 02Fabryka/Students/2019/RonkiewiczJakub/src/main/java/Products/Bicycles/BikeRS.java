package Products.Bicycles;

import Products.Bicycle;
import Products.Brand;

public class BikeRS extends Bicycle {
    public BikeRS() {
        brand = Brand.PORSCHE;
        model = "Bike RS";
        weight = 10.5f;
        maxSpeed = 100;
        price = 30000;
    }
}
