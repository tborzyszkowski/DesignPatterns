package Products.Bicycles;

import Products.Bicycle;
import Products.Brand;

public class Cruise extends Bicycle {
    public Cruise(){
        brand = Brand.BMW;
        model = "Cruise M";
        price = 3000;
        weight = 14.5f;
        maxSpeed = 50;
    }
}
