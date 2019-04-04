package Products.Bicycles;

import Products.Bicycle;
import Products.Brand;

public class SilverBullet extends Bicycle {
    public SilverBullet() {
        brand = Brand.HONDA;
        model = "RN01 SILVER BULLET";
        weight = 19.5f;
        maxSpeed = 90;
        price = 5000;
    }
}
