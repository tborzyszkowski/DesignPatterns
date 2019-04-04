package Products.Bicycles;

import Products.Bicycle;
import Products.Brand;

public class Endurace extends Bicycle {
    public Endurace() {
        brand = Brand.CANYON;
        model = "Endurace CF";
        weight = 7.8f;
        maxSpeed = 100;
        price = 3000;
    }
}
