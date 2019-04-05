package Products.Cars;

import Products.Body;
import Products.Brand;
import Products.Car;

public class M240 extends Car {
    public M240() {
        brand = Brand.BMW;
        model = "M240i";
        body = Body.COUPE;
        maxSpeed = 280;
        price = 220000;
    }

    public M240 CreateM240(){
        return new M240();
    }

}
