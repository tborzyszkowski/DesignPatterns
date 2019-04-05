package Products.Motorcycles;

import Products.Brand;
import Products.Motorcycle;

public class VFR extends Motorcycle {
    public VFR() {
        brand = Brand.HONDA;
        model = "VFR 800F";
        maxSpeed = 250;
        price = 25000;
    }
}
