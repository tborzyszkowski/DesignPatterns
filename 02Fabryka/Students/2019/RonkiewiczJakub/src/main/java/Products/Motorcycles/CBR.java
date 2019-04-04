package Products.Motorcycles;

import Products.Brand;
import Products.Motorcycle;

public class CBR extends Motorcycle {
    public CBR() {
        brand = Brand.HONDA;
        model = "CBR 600RR";
        maxSpeed = 284;
        price = 15000;
    }
}
